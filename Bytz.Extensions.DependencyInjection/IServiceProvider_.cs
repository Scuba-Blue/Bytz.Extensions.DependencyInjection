using Bytz.Extensions.DependencyInjection.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bytz.Extensions.DependencyInjection
{
    /// <summary>
    /// Extend the IServiceProvider interface.
    /// </summary>
    static public class IServiceProvider_
    {
        /// <summary>
        /// Assert that TService resolution yields results.
        /// </summary>
        /// <typeparam name="TService">Type of service for the components.</typeparam>
        /// <param name="provider"></param>
        static public void AssertResolution<TService>(this IServiceProvider provider)
        where TService : class
        {
            if (provider.GetService<TService>() == null)
            {
                throw new AssertResolutionException($"Request for component(s) registered for {nameof(TService)}={typeof(TService).FullName} yielded null.");
            }
        }
    }
}