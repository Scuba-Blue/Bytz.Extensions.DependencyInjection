using Bytz.Extensions.DependencyInjection.Exceptions;
using System;

namespace Bytz.Extensions.DependencyInjection.Contracts
{
    /// <summary>
    /// Register only as the specified contract.
    /// </summary>
    internal class OnlyContract
    : _Contract
    {
        /// <summary>
        /// Only the specific contract interface.
        /// </summary>
        readonly public Type Interface;

        /// <summary>
        /// only can be created internally, must have contract type
        /// </summary>
        /// <param name="type"></param>
        internal OnlyContract
        (
            Type type
        )
        {
            this.Interface = type;
        }

        private void AssertContract(Type type)
        {
            if (type.IsInterface == false)
            {
                throw new OnlyInterfaceException("the type must be an interface.");
            }
        }
    }
}