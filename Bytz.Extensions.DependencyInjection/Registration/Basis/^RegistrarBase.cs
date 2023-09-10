using Bytz.Extensions.DependencyInjection.Contracts;
using Bytz.Extensions.DependencyInjection.ContractTypes.Basis;
using Bytz.Extensions.DependencyInjection.Implementation;
using Bytz.Extensions.DependencyInjection.Lifetimes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bytz.Extensions.DependencyInjection.Configuration
{
    /// <summary>
    /// Partial implementation of the registrar.
    /// </summary>
    internal partial class RegistrarBase
    : IConfigure
    {
        private IServiceCollection _services = null;

        private Assembly _assembly = null;
        private ImplementationTypeBase _basedOn = null;
        private ContractBase _interfaces = null;
        private LifetimeBase _lifetime = null;

        private RegistrarBase()
        { }

        public static IAssembly Configure
        (
            IServiceCollection services
        )
        {
            return new RegistrarBase
            {
                _services = services
            };
        }
    }
}