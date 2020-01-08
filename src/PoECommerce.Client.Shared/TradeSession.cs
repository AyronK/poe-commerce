using System;
using System.Collections.Generic;
using System.Linq;
using PoECommerce.Core;
using PoECommerce.Core.Model.Search;
using PoECommerce.Core.Model.Trade;

namespace PoECommerce.Client.Shared
{
    public class TradeSession
    {
        private readonly ITradeService _tradeService;

        public enum TradeSessionState
        {
            New,
            Pending,
            Closed
        }

        private readonly List<ListedItem> _result;
        private const int MaximumItemsPerRequest = 10;

        public Query Query { get; }

        public IReadOnlyCollection<ListedItem> Result => _result;

        public uint Total { get; private set; }

        public TradeSessionState State { get; set; }

        public TradeSession(Query query, ITradeService tradeService)
        {
            _tradeService = tradeService;
            Query = query;
            _result = new List<ListedItem>();
            State = TradeSessionState.New;
        }

        public async IAsyncEnumerable<ListedItem> Begin()
        {
            if (State != TradeSessionState.New)
            {
                throw new Exception($"Method '{nameof(Begin)}' was already called.");
            }

            State = TradeSessionState.Pending;
            SearchResult searchResult = await _tradeService.Search(Query);
            Query.Id = searchResult.QueryId;

            Total = searchResult.Total;

            if (searchResult.ItemIds?.Any() != true)
            {
                State = TradeSessionState.Closed;
                yield break;
            }

            for (int i = 0; i < searchResult.ItemIds.Length; i += MaximumItemsPerRequest)
            {
                string[] ids = searchResult.ItemIds.Skip(i).Take(MaximumItemsPerRequest).ToArray();

                foreach (ListedItem item in await _tradeService.Fetch(searchResult.QueryId, ids))
                {
                    _result.Add(item);
                    yield return item;
                }
            }

            State = TradeSessionState.Closed;
        }
    }
}