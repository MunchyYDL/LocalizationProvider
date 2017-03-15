using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;

namespace DbLocalizationProvider.Cache
{
    public class InMemoryCacheManager : ICacheManager
    {
        private static readonly ConcurrentDictionary<string, byte> _entries = new ConcurrentDictionary<string, byte>();
        private readonly IMemoryCache _cache;

        public InMemoryCacheManager(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Insert(string key, object value)
        {
            _entries.TryAdd(key, 1);
            _cache.Set(key, value);
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
            _entries.TryRemove(key, out byte v);
        }

        public IEnumerable<string> Keys => _entries.Select(x => x.Key).ToList();
    }
}
