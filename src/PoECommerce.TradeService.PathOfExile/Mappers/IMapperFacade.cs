using System.Collections.Generic;
using PoECommerce.Core;
using PoECommerce.PathOfExile.Models.Data;
using PoECommerce.PathOfExile.Models.Enums;
using PoECommerce.PathOfExile.Models.Search;
using PoECommerce.PathOfExile.Models.Search.Enums;
using PoECommerce.PathOfExile.Models.Trade;
using CoreModels = PoECommerce.Core.Model.Search;
using CoreDataModels = PoECommerce.Core.Model.Data;

namespace PoECommerce.TradeService.PathOfExile.Mappers
{
    internal interface IMapperFacade : 
        IModelMapper<CoreModels.Query, Query>,
        IModelMapper<CoreModels.SortType, SortType>,
        IModelMapper<ListedItem, Core.Model.Trade.ListedItem>,
        IModelMapper<QueryResult, CoreModels.SearchResult>,
        IModelMapper<League, CoreDataModels.League>,
        IModelMapper<Modifier, CoreDataModels.Modifier>, 
        IModelMapper<ModifierType, CoreDataModels.ModifierType>,
        IModelMapper<KeyValuePair<ItemCategory, Item>, CoreDataModels.Item>,
        IModelMapper<ItemCategory, CoreDataModels.ItemCategory>
    {
    }
}