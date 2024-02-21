using Examples.Extensions.DependencyInjection.Services.Contracts;
using System.Collections.Concurrent;

namespace Examples.Extensions.DependencyInjection.Services;

/// <summary>
/// simple caching service example.
/// </summary>
public class CacheService : ICacheService
{
    /// <summary>
    /// use a threadsafe dictionary.
    /// </summary>
    private readonly ConcurrentDictionary<string, object> _cache = new();

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