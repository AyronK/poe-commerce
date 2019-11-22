using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using PoECommerce.TradeService;
using PoECommerce.TradeService.Models.Data;
using PoECommerce.TradeService.Models.Enums;

namespace PoECommerce.Client.Cache.TradeService
{
    public class CachedDataService : CachedServiceBase, IPoEDataService
    {
        private readonly Func<IPoEDataService> _dataServiceFactory;

        public CachedDataService(Func<IPoEDataService> dataServiceFactory, MemoryCacheOptions cacheOptions = null) : base(cacheOptions)
        {
            _dataServiceFactory = dataServiceFactory;
        }

        public Task<League[]> GetLeagues()
        {
            return GetOrCreate(nameof(IPoEDataService.GetLeagues), _dataServiceFactory().GetLeagues, new MemoryCacheEntryOptions {Priority = CacheItemPriority.NeverRemove});
        }

        public Task<IReadOnlyDictionary<ItemCategory, Item[]>> GetItems()
        {
            return GetOrCreate(nameof(IPoEDataService.GetItems), _dataServiceFactory().GetItems, new MemoryCacheEntryOptions {Priority = CacheItemPriority.NeverRemove});
        }

        public Task<IReadOnlyDictionary<ModifierType, Modifier[]>> GetModifiers()
        {
            return GetOrCreate(nameof(IPoEDataService.GetModifiers), _dataServiceFactory().GetModifiers, new MemoryCacheEntryOptions {Priority = CacheItemPriority.NeverRemove});
        }

        public Task<IReadOnlyDictionary<ItemCategory, StaticData[]>> GetStaticData()
        {
            return GetOrCreate(nameof(IPoEDataService.GetStaticData), _dataServiceFactory().GetStaticData, new MemoryCacheEntryOptions {Priority = CacheItemPriority.NeverRemove});
        }
    }
}