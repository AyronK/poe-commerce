using System.Linq;
using System.Threading.Tasks;
using PoECommerce.Core;
using PoECommerce.PathOfExile;
using PoECommerce.PathOfExile.Models.Search;
using PoECommerce.PathOfExile.Models.Trade;
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
            QueryResult result = await _tradeService.Search(mappedQuery, query.League);
            CoreModels.SearchResult mappedResult = _mapper.Map(result);
            return mappedResult;
        }

        public async Task<CoreModels.ListedItem[]> Fetch(string queryId, string[] itemsIds)
        {
            ListedItem[] result = await _tradeService.Fetch(queryId, itemsIds);
            CoreModels.ListedItem[] mappedResult = result.Select(i => _mapper.Map(i)).ToArray();
            return mappedResult;
        }
    }
}