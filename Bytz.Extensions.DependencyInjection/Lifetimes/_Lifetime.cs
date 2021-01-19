using Microsoft.Extensions.DependencyInjection;

namespace Bytz.Extensions.DependencyInjection.Lifetimes
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
        /// <typeparam name="TImplementation">Concrete type implementing TInterface.</typeparam>
        /// <param name="services">Instance of a service collection.</param>
        /// <returns></returns>
        abstract public IServiceCollection AddLifetime<TInterface, TImplementation>
        (
            IServiceCollection services
        )
        where TInterface : class
        where TImplementation : class, TInterface;
    }
}