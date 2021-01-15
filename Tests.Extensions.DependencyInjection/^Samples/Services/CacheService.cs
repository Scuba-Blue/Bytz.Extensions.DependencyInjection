using System.Collections.Concurrent;
using Tests.Extensions.DependencyInjection.Samples.Services.Contracts;

namespace Tests.Extensions.DependencyInjection.Samples.Services
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
            _cache.TryGetValue(key, out object value);

            return (TType)value;
        }
    }
}