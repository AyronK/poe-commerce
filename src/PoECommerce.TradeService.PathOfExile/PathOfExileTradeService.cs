using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoECommerce.Core;
using PoECommerce.PathOfExile.Models.Search;
using PoECommerce.PathOfExile.Models.Search.Enums;
using PoECommerce.PathOfExile.Models.Trade;
using PoECommerce.PathOfExile.Web.Abstractions;
using PoECommerce.TradeService.PathOfExile.Mappers;
using CoreModels = PoECommerce.Core.Model.Search;

namespace PoECommerce.TradeService.PathOfExile
{
    internal class PathOfExileTradeService : ITradeService
    {
        private readonly IMapperFacade _mapper;
        private readonly IPathOfExileTradeService _tradeService;

        public PathOfExileTradeService(IMapperFacade mapper, IPathOfExileTradeService tradeService)
        {
            _mapper = mapper;
            _tradeService = tradeService;
        }

        public async Task<CoreModels.SearchResult> Search(CoreModels.Query query)
        {
            Query mappedQuery = _mapper.Map(query);
            IDictionary<string, SortType> mappedSort = query.Sort.ToDictionary(s => s.Key, s => _mapper.Map(s.Value));
            QueryResult result = await _tradeService.Search(mappedQuery, mappedSort, query.League);
            CoreModels.SearchResult mappedResult = _mapper.Map(result);
            mappedResult.Query = query;
            return mappedResult;
        }

        public async Task<Core.Model.Trade.ListedItem[]> Fetch(string queryId, string[] itemsIds)
        {
            ListedItem[] result = await _tradeService.Fetch(queryId, itemsIds);
            Core.Model.Trade.ListedItem[] mappedResult = result.Where(i => i != null).Select(i => _mapper.Map(i)).ToArray();
            return mappedResult;
        }
    }
}