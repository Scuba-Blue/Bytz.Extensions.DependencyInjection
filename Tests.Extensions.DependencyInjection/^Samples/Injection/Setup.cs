using Bytz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Services.Contracts;

namespace Tests.Extensions.DependencyInjection.Samples.Injection
{
    /// <summary>
    /// setup the components with the service collection.
    /// </summary>
    internal static class Setup
    {
        /// <summary>
        /// add all engines as transient.
        /// </summary>
        /// <param name="services">instance of the service collection.</param>
        /// <returns>instance of the service collection.</returns>
        public static IServiceCollection AddEngines(this IServiceCollection services)
        {
            return services.Register
            (r => r
                .InThisAssembly()
                .Implementing<IEngine>()
                .AllInterfaces()
                .AsTransient()
                .Configure())
            ;
        }

        /// <summary>
        /// add all services as transient.
        /// </summary>
        /// <param name="services">instance of the service collection.</param>
        /// <returns>instance of the service collection.</returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.Register
            (r => r
                .InThisAssembly()
                .Implementing<IService>()
                .AllInterfaces()
                .AsTransient()
                .Configure())
            ;
        }

        /// <summary>
        /// add all repositories as transient.
        /// </summary>
        /// <param name="services">instance of the service collection.</param>
        /// <returns>instance of the service collection.</returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.Register
            (r => r
                .InThisAssembly()
                .Implementing<IRepository>()
                .AllInterfaces()
                .AsTransient()
                .Configure())
            ;
        }

        /// <summary>
        /// add the cache service as singleton.
        /// </summary>
        /// <param name="services">instance of the service collection.</param>
        /// <returns>instance of the service collection.</returns>
        public static IServiceCollection AddCache(this IServiceCollection services)
        {
            return services.Register
            (r => r
                .InThisAssembly()
                .Implementing<ICacheService>()
                .OnlyInterface<ICacheService>()
                .AsSingleton()
                .Configure()
            );
        }
    }
}