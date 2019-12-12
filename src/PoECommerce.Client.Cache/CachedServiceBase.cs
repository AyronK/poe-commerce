using System;
using Microsoft.Extensions.Caching.Memory;

namespace PoECommerce.Client.Cache
{
    public class CachedServiceBase
    {
        private readonly string _typeName;

        public CachedServiceBase(MemoryCacheOptions cacheOptions)
        {
            Cache = new MemoryCache(cacheOptions ?? new MemoryCacheOptions());
            _typeName = GetType().FullName;
        }

        protected MemoryCache Cache { get; }

        protected TItem GetOrCreate<TItem>(string key, Func<TItem> createItem, MemoryCacheEntryOptions cacheEntryOptions = null)
        {
            string entryKey = $"{_typeName}.{key}";

            if (Cache.TryGetValue(entryKey, out TItem entryValue))
            {
                return entryValue;
            }

            entryValue = createItem();

            Cache.Set(entryKey, entryValue, cacheEntryOptions);

            return entryValue;
        }
    }
}