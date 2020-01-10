using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using PoECommerce.Core;
using PoECommerce.PathOfExile.Models.Data;
using PoECommerce.PathOfExile.Models.Enums;
using PoECommerce.PathOfExile.Models.Search;
using PoECommerce.PathOfExile.Models.Search.Enums;
using PoECommerce.PathOfExile.Models.Trade;
using PoECommerce.PathOfExile.Web.Abstractions;
using PoECommerce.TradeService.PathOfExile.Mappers;
using PoECommerce.TradeService.PathOfExile.Mappers.FromCore;
using PoECommerce.TradeService.PathOfExile.Mappers.ToCore;
using CoreModels = PoECommerce.Core.Model.Search;
using CoreDataModels = PoECommerce.Core.Model.Data;

namespace PoECommerce.TradeService.PathOfExile.Extensions
{
    public static class PathOfExileRegistrationExtensions
    {
        /// <summary>
        ///     Registers official's Path of Exile API implementation of <see cref="ITradeService" />. Service requires
        ///     <see cref="IPathOfExileTradeService" /> and <see cref="IPathOfExileDataService" />
        ///     implementations.
        /// </summary>
        /// <exception cref="ArgumentException">
        ///     When service of type <see cref="IPathOfExileTradeService" /> or <see cref="IPathOfExileDataService" /> is not
        ///     registered in the
        ///     collection.
        /// </exception>
        public static void AddPathOfExileCoreServices(this IServiceCollection services)
        {
            if (services.All(s => s.ServiceType != typeof(IPathOfExileTradeService)))
            {
                throw new ArgumentException($"Collection services must contain service of type {typeof(IPathOfExileTradeService)}.", nameof(services));
            }

            if (services.All(s => s.ServiceType != typeof(IPathOfExileDataService)))
            {
                throw new ArgumentException($"Collection services must contain service of type {typeof(IPathOfExileTradeService)}.", nameof(services));
            }

            services.AddSingleton<IModelMapper<CoreModels.Query, Query>, QueryToQueryMapper>();
            services.AddSingleton<IModelMapper<CoreModels.SortType, SortType>, QueryToQueryMapper>();
            services.AddSingleton<IModelMapper<ListedItem, Core.Model.Trade.ListedItem>, ListedItemToListedItemMapper>();
            services.AddSingleton<IModelMapper<QueryResult, CoreModels.SearchResult>, QueryResultToSearchResultMapper>();
            services.AddSingleton<IModelMapper<League, CoreDataModels.League>, LeagueToLeagueMapper>();
            services.AddSingleton<IModelMapper<Modifier, CoreDataModels.Modifier>, ModifierToModifierMapper>();
            services.AddSingleton<IModelMapper<KeyValuePair<ItemCategory, Item>, CoreDataModels.Item>, ItemToItemMapper>();
            services.AddSingleton<IModelMapper<ItemCategory, Core.Model.Data.ItemCategory>, ItemToItemMapper>();
            services.AddSingleton<IModelMapper<ModifierType, CoreDataModels.ModifierType>, ModifierToModifierMapper>();
            services.AddSingleton<IMapperFacade, MapperFacade>();
            services.AddTransient<ITradeService, PathOfExileTradeService>();
            services.AddTransient<IStaticDataService, PathOfExileStaticDataService>();
        }
    }
}