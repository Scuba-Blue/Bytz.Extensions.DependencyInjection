using Samples.Extensions.DependencyInjection.Services.Contracts;
using System.Collections.Concurrent;

namespace Samples.Extensions.DependencyInjection.Services
{
    /// <summary>
    /// simple caching service example.
    /// </summary>
    public class CacheService : ICacheService
    {
        /// <summary>
        /// use a threadsafe dictionary.
        /// </summary>
        private readonly ConcurrentDictionary<string, object> _cache = new ConcurrentDictionary<string, object>();

        public void Add<TType>(string key, TType value)
        {
            _cache.TryAdd(key, value);
        }

        public TType Get<TType>(string key)
        {
            TType value = default;

            if (_cache.TryGetValue(key, out _) == true)
            {
                value = (TType)_cache[key];
            }

            return value;
        }
    }
}