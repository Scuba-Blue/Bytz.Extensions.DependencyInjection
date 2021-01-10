using System;

namespace Samples.Extensions.DependencyInjection.Services.Contracts
{
    /// <summary>
    /// singleton caching service
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        /// add the value to the cache with a key.
        /// </summary>
        /// <typeparam name="TType">type of the value.</typeparam>
        /// <param name="key">key for the value.</param>
        /// <param name="value">value to be added.</param>
        void Add<TType>(string key, TType value);

        /// <summary>
        /// get the typed value from the cache.
        /// </summary>
        /// <typeparam name="TType">type of the value to return.</typeparam>
        /// <param name="key">key for the value.</param>
        /// <returns>value from cache typed to TType.</returns>
        /// <remarks>not checking if exists or not in the sample.</remarks>
        /// <exception cref="InvalidCastException">If wrong TType specified for the value for the key.</exception>
        TType Get<TType>(string key);
    }
}