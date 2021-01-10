using Microsoft.Extensions.DependencyInjection;

namespace Bitz.Extensions.DependencyInjection.Lifetimes
{
    /// <summary>
    /// 
    /// </summary>
    internal class Transient
    : _Lifetime
    {
        /// <summary>
        /// 
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
            return services.AddTransient<TInterface, TConcrete>();
        }
    }
}