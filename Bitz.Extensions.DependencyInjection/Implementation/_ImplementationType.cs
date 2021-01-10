using System;

namespace Bitz.Extensions.DependencyInjection.Implementation
{
    /// <summary>
    /// 
    /// </summary>
    abstract public class _ImplementationType
    {
        /// <summary>
        /// instant
        /// </summary>
        readonly public Type Type;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        internal _ImplementationType
        (
            Type type
        )
        {
            this.Type = type; 
        }
    }
}