using Microsoft.Extensions.DependencyInjection;

namespace Bitz.Extensions.DependencyInjection.Lifetimes
{
    /// <summary>
    /// Register with a scoped lifetime.
    /// </summary>
    internal class Scoped
    : _Lifetime
    {
        /// <summary>
        /// Add a concrete type with a specific interface.
        /// </summary>
        /// <typeparam name="TInterface">Type of the interface implementation.</typeparam>
        /// <typeparam name="TConcrete">Concrete type implementing TInterface.</typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public override IServiceCollection AddLifetime<TInterface, TConcrete>
        (
            IServiceCollection services
        )
        {
            return services.AddScoped<TInterface, TConcrete>();
        }
    }
}