using System;

namespace Bitz.Extensions.DependencyInjection.Implementation
{
    /// <summary>
    /// Register classes 
    /// </summary>
    internal class Only
    : _ImplementationType
    {
        /// <summary>
        /// Register only the specified type.
        /// </summary>
        /// <param name="type">Concrete type to be registered.</param>
        /// <exception cref="ArgumentException">Thrown when the type is an interface.</exception>
        public Only
        (
            Type type
        )
        : base(type)
        {
            if (typeof(Type).IsInterface == true)
                throw new ArgumentException($"{nameof(type)} cannot be an interface.");
        }
    }
}