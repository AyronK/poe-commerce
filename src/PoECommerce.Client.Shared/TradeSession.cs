using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using PoECommerce.Core;
using PoECommerce.Core.Model.Search;
using PoECommerce.Core.Model.Trade;

namespace PoECommerce.Client.Shared
{
    public class TradeSession : IDisposable
    {
        private readonly ITradeService _tradeService;
        private readonly Action<TradeSession> _onDispose;

        public enum TradeSessionState
        {
            New,
            Pending,
            Closed,
            ServiceUnavailable
        }

        private readonly List<ListedItem> _result;
        private const int MaximumItemsPerRequest = 10;

        public Query Query { get; }

        public string Id { get; }

        public IReadOnlyCollection<ListedItem> Result => _result;

        public uint Total { get; private set; }

        public TradeSessionState State { get; set; }

        public TradeSession(Query query, ITradeService tradeService, Action<TradeSession> onDispose)
        {
            _tradeService = tradeService;
            _onDispose = onDispose;
            _result = new List<ListedItem>();

            Id = Guid.NewGuid().ToString("N");
            State = TradeSessionState.New;
            Query = query;
        }

        public async IAsyncEnumerable<ListedItem> Begin()
        {
            if (State != TradeSessionState.New)
            {
                throw new Exception($"Method '{nameof(Begin)}' was already called.");
            }


            State = TradeSessionState.Pending;
            SearchResult searchResult;

            try
            {
                searchResult = await _tradeService.Search(Query);
            }
            catch (HttpRequestException)
            {
                State = TradeSessionState.ServiceUnavailable;
                yield break;
            }

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

                ListedItem[] listedItems;

                try
                {
                    listedItems = await _tradeService.Fetch(searchResult.QueryId, ids);
                }
                catch (HttpRequestException)
                {
                    State = TradeSessionState.ServiceUnavailable;
                    yield break;
                }

                foreach (ListedItem item in listedItems)
                {
                    _result.Add(item);
                    yield return item;
                }
            }

            State = TradeSessionState.Closed;
        }

        public void Dispose()
        {
            _onDispose?.Invoke(this);
        }
    }
}