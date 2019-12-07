using System.Collections.Generic;
using PoECommerce.Core;
using CoreDataModels = PoECommerce.Core.Model.Data;
using PoEModels = PoECommerce.PathOfExile.Models;
using CoreModels = PoECommerce.Core.Model;
using ItemCategory = PoECommerce.PathOfExile.Models.Enums.ItemCategory;

namespace PoECommerce.TradeService.PathOfExile.Mappers
{
    internal class MapperFacade : IMapperFacade
    {
        private readonly IModelMapper<PoEModels.Trade.ListedItem, CoreModels.Search.ListedItem> _listedItemMapper;
        private readonly IModelMapper<CoreModels.Search.Query, PoEModels.Search.Query> _queryMapper;
        private readonly IModelMapper<PoEModels.Search.QueryResult, CoreModels.Search.SearchResult> _searchResultMapper;
        private readonly IModelMapper<PoEModels.Data.League, CoreDataModels.League> _leagueMapper;
        private readonly IModelMapper<PoEModels.Data.Modifier, CoreDataModels.Modifier> _modifierMapper;
        private readonly IModelMapper<PoEModels.Enums.ModifierType, CoreDataModels.ModifierType> _modifierTypeMapper;
        private readonly IModelMapper<KeyValuePair<ItemCategory, PoEModels.Data.Item>, CoreDataModels.Item> _itemsMapper;
        private readonly IModelMapper<ItemCategory, CoreDataModels.ItemCategory> _itemCategoryMapper;

        public MapperFacade
        (
        IModelMapper<PoEModels.Trade.ListedItem, CoreModels.Search.ListedItem> listedItemMapper,
        IModelMapper<CoreModels.Search.Query, PoEModels.Search.Query> queryMapper,
        IModelMapper<PoEModels.Search.QueryResult, CoreModels.Search.SearchResult> searchResultMapper,
        IModelMapper<PoEModels.Data.League, CoreDataModels.League> leagueMapper,
        IModelMapper<PoEModels.Data.Modifier, CoreDataModels.Modifier> modifierMapper,
        IModelMapper<PoEModels.Enums.ModifierType, CoreDataModels.ModifierType> modifierTypeMapper,
        IModelMapper<KeyValuePair<ItemCategory, PoEModels.Data.Item>, CoreDataModels.Item> itemsMapper,
        IModelMapper<ItemCategory, CoreDataModels.ItemCategory> itemCategoryMapper
        )
        {
            _queryMapper = queryMapper;
            _listedItemMapper = listedItemMapper;
            _searchResultMapper = searchResultMapper;
            _leagueMapper = leagueMapper;
            _modifierMapper = modifierMapper;
            _modifierTypeMapper = modifierTypeMapper;
            _itemsMapper = itemsMapper;
            _itemCategoryMapper = itemCategoryMapper;
        }

        public PoEModels.Search.Query Map(CoreModels.Search.Query mapOperand)
        {
            return _queryMapper.Map(mapOperand);
        }

        public CoreModels.Search.ListedItem Map(PoEModels.Trade.ListedItem mapOperand)
        {
            return _listedItemMapper.Map(mapOperand);
        }

        public CoreModels.Search.SearchResult Map(PoEModels.Search.QueryResult mapOperand)
        {
            return _searchResultMapper.Map(mapOperand);
        }

        public CoreDataModels.League Map(PoEModels.Data.League mapOperand)
        {
            return _leagueMapper.Map(mapOperand);
        }

        public CoreDataModels.Modifier Map(PoEModels.Data.Modifier mapOperand)
        {
            return _modifierMapper.Map(mapOperand);
        }

        public CoreDataModels.ModifierType Map(PoEModels.Enums.ModifierType mapOperand)
        {
            return _modifierTypeMapper.Map(mapOperand);
        }

        public CoreModels.Data.Item Map(KeyValuePair<ItemCategory, PoEModels.Data.Item> mapOperand)
        {
            return _itemsMapper.Map(mapOperand);
        }

        public CoreDataModels.ItemCategory Map(ItemCategory mapOperand)
        {
            return _itemCategoryMapper.Map(mapOperand);
        }
    }
}