using Microsoft.Extensions.DependencyInjection;

namespace Bytz.Extensions.DependencyInjection.Lifetimes
{
    /// <summary>
    /// 
    /// </summary>
    internal class Singleton
    : LifetimeBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInterface">Type of the interface implementation.</typeparam>
        /// <typeparam name="TImplementation">Concrete type implementing TInterface.</typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public override IServiceCollection AddLifetime<TInterface, TImplementation>
        (
            IServiceCollection services
        )
        {
            return services.AddSingleton<TInterface, TImplementation>();
        }
    }
}