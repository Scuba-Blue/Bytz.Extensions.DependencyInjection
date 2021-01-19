using Bytz.Extensions.DependencyInjection.Contracts;
using Bytz.Extensions.DependencyInjection.Implementation;
using Bytz.Extensions.DependencyInjection.Lifetimes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bytz.Extensions.DependencyInjection.Configuration
{
    internal partial class Registrar
    : IConfigure
    {
        private IServiceCollection _services = null;

        private Assembly _assembly = null;
        private _ImplementationType _basedOn = null;
        private _Contract _interfaces = null; 
        private _Lifetime _lifetime = null;

        private Registrar()
        { }

        public static IAssembly Configure
        (
            IServiceCollection services
        )
        {
            return new Registrar
            {
                _services = services
            };
        }
    }
}