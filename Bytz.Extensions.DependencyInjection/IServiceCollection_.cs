using Bytz.Extensions.DependencyInjection.Contracts;
using Bytz.Extensions.DependencyInjection.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bytz.Extensions.DependencyInjection
{
    /// <summary>
    /// IServiceCollection registration extensions.
    /// </summary>
    static public class IServiceCollection_
    {
        /// <summary>
        /// register components with IServiceCollection.
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
    }
}