using Bitz.Extensions.DependencyInjection.Contracts;
using Bitz.Extensions.DependencyInjection.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bitz.Extensions.DependencyInjection
{
    /// <summary>
    /// IServiceCollection registration extensions.
    /// </summary>
    static public class IServiceCollection_
    {
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