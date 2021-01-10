using Bitz.Extensions.DependencyInjection.Exceptions;

namespace Bitz.Extensions.DependencyInjection.Contracts
{
    /// <summary>
    /// Configure the service collection with configured services.
    /// </summary>
    public interface IConfigure
    : IBitz
    {
        /// <summary>
        /// Configure the service collection
        /// </summary>
        void Configure();

        /// <summary>
        /// Ensures that the configuration is valid.
        /// </summary>
        /// <exception cref="OnlyInterfaceException">thrown if the configuration finds no types to register.</exception>
        void ConfigureOrThrow();
    }
}