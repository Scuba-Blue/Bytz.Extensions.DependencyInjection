using Microsoft.Extensions.DependencyInjection;

namespace Bitz.Extensions.DependencyInjection.Lifetimes
{
    /// <summary>
    /// Basis for lifetime registration.
    /// </summary>
    abstract internal class _Lifetime
    {
        /// <summary>
        /// Constructor for all lifetimes.
        /// </summary>
        protected _Lifetime()
        { }

        /// <summary>
        /// Add a specific lifetime for a concrete type.
        /// </summary>
        /// <typeparam name="TInterface">Type of the interface implementation.</typeparam>
        /// <typeparam name="TConcrete">Concrete type implementing TInterface.</typeparam>
        /// <param name="services">Instance of a service collection.</param>
        /// <returns></returns>
        abstract public IServiceCollection AddLifetime<TInterface, TConcrete>
        (
            IServiceCollection services
        )
        where TInterface : class
        where TConcrete : class, TInterface;
    }
}