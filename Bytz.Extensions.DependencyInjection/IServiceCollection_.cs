using Bytz.Extensions.DependencyInjection.Configuration;
using Bytz.Extensions.DependencyInjection.Contracts;
using Bytz.Extensions.DependencyInjection.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Bytz.Extensions.DependencyInjection
{
    /// <summary>
    /// IServiceCollection registration extensions.
    /// </summary>
    static public class IServiceCollection_
    {
        /// <summary>
        /// Register components with IServiceCollection.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="setup">Method chain to configure IServiceCollection.</param>
        /// <returns>Instance of IServiceCollection.</returns>
        static public IServiceCollection Register
        (
            this IServiceCollection services,
            Action<IAssembly> setup
        )
        {
            setup.Invoke(Registrar.Configure(services));

            return services;
        }

        /// <summary>
        /// Assert that all of the registered compontents for TService are of the expected lifetime.
        /// </summary>
        /// <typeparam name="TService">Type of service for the components.</typeparam>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="expected">The expected lifetime.</param>
        /// <exception cref="AssertLifetimeException">thrown if not all of the registered components for TService are the expected lifetime.</exception>
        static public void AssertLifetime<TService>(this IServiceCollection services, ServiceLifetime expected)
        where TService : class
        {
            if (services
                .Where(s => s.ServiceType == typeof(TService))
                .All(s => s.Lifetime == expected) == false
            )
            {
                throw new AssertLifetimeException($"Component(s) registered for {nameof(TService)}={typeof(TService).FullName} are not registered with the expected lifetime of {expected.ToString()}");
            }
        }
    }
}