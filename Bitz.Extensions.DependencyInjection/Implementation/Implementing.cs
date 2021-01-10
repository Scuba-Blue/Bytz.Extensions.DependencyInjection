using System;

namespace Bitz.Extensions.DependencyInjection.Implementation
{
    /// <summary>
    /// Register classes implementing a specific interface type.
    /// </summary>
    internal class Implementing
    : _ImplementationType
    {
        /// <summary>
        /// Register classes implementing a specific interface.
        /// </summary>
        /// <param name="type"></param>
        /// <exception cref="ArgumentException">Thrown when the type parameter is not an interface.</exception>
        public Implementing
        (
            Type type
        )
        : base(type)
        { 
            if (type.IsInterface == false)
            {
                throw new ArgumentException($"Type parameter must be an interface type.");
            }
        }
    }
}