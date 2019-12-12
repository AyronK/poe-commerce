using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using PoECommerce.PathOfExile;
using PoECommerce.PathOfExile.Models.Data;
using PoECommerce.PathOfExile.Models.Enums;

namespace PoECommerce.Client.Cache.TradeService
{
    public class CachedDataService : CachedServiceBase, IPathOfExileDataService
    {
        private readonly Func<IPathOfExileDataService> _dataServiceFactory;

        public CachedDataService(Func<IPathOfExileDataService> dataServiceFactory, MemoryCacheOptions cacheOptions = null) : base(cacheOptions)
        {
            _dataServiceFactory = dataServiceFactory;
        }

        public Task<League[]> GetLeagues()
        {
            return GetOrCreate(nameof(IPathOfExileDataService.GetLeagues), _dataServiceFactory().GetLeagues, new MemoryCacheEntryOptions {Priority = CacheItemPriority.NeverRemove});
        }

        public Task<IReadOnlyDictionary<ItemCategory, Item[]>> GetItems()
        {
            return GetOrCreate(nameof(IPathOfExileDataService.GetItems), _dataServiceFactory().GetItems, new MemoryCacheEntryOptions {Priority = CacheItemPriority.NeverRemove});
        }

        public Task<IReadOnlyDictionary<ModifierType, Modifier[]>> GetModifiers()
        {
            return GetOrCreate(nameof(IPathOfExileDataService.GetModifiers), _dataServiceFactory().GetModifiers, new MemoryCacheEntryOptions {Priority = CacheItemPriority.NeverRemove});
        }

        public Task<IReadOnlyDictionary<ItemCategory, StaticData[]>> GetStaticData()
        {
            return GetOrCreate(nameof(IPathOfExileDataService.GetStaticData), _dataServiceFactory().GetStaticData, new MemoryCacheEntryOptions {Priority = CacheItemPriority.NeverRemove});
        }
    }
}