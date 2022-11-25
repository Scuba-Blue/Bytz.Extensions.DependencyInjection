using Bytz.Extensions.DependencyInjection.Contracts;
using Bytz.Extensions.DependencyInjection.Exceptions;

namespace Bytz.Extensions.DependencyInjection.Configuration
{
    internal partial class RegistrarBase
    : IImplementing
    {
        public ILifetime AllInterfaces()
        {
            _interfaces = new AllContracts();

            return this;
        }

        public ILifetime OnlyInterface<TInterface>()
        where TInterface : class
        {
            AssertInterface<TInterface>();

            _interfaces = new OnlyContract(typeof(TInterface));

            return this;
        }

        /// <summary>
        /// Assert that TInterface is actually an interface.
        /// </summary>
        /// <typeparam name="TInterface">Type to be asserted is a genuine interface.</typeparam>
        private void AssertInterface<TInterface>() 
        where TInterface : class
        {
            if (typeof(TInterface).IsInterface == false)
            {
                throw new OnlyInterfaceException("TInterface must be an interface.");
            }
        }

        public ILifetime WithoutInterfaces()
        {
            _interfaces = new NoInterfaces();

            return this;
        }
    }
}