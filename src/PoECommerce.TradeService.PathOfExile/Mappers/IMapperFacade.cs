using PoECommerce.Core;
using PoECommerce.PathOfExile.Models.Search;
using PoECommerce.PathOfExile.Models.Trade;
using CoreModels = PoECommerce.Core.Model.Search;

namespace PoECommerce.TradeService.PathOfExile.Mappers
{
    internal interface IMapperFacade : IModelMapper<CoreModels.Query, Query>, IModelMapper<ListedItem, CoreModels.ListedItem>, IModelMapper<QueryResult, CoreModels.SearchResult>
    {
    }

    internal class MapperFacade : IMapperFacade
    {
        private readonly IModelMapper<ListedItem, CoreModels.ListedItem> _listedItemMapper;
        private readonly IModelMapper<CoreModels.Query, Query> _queryMapper;
        private readonly IModelMapper<QueryResult, CoreModels.SearchResult> _searchResultMapper;

        public MapperFacade
        (
            IModelMapper<CoreModels.Query, Query> queryMapper,
            IModelMapper<ListedItem, CoreModels.ListedItem> listedItemMapper,
            IModelMapper<QueryResult, CoreModels.SearchResult> searchResultMapper
        )
        {
            _queryMapper = queryMapper;
            _listedItemMapper = listedItemMapper;
            _searchResultMapper = searchResultMapper;
        }

        public Query Map(CoreModels.Query mapOperand)
        {
            return _queryMapper.Map(mapOperand);
        }

        public CoreModels.ListedItem Map(ListedItem mapOperand)
        {
            return _listedItemMapper.Map(mapOperand);
        }

        public CoreModels.SearchResult Map(QueryResult mapOperand)
        {
            return _searchResultMapper.Map(mapOperand);
        }
    }
}