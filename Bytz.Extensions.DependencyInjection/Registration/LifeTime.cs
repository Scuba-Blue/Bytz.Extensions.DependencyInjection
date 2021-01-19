using Bytz.Extensions.DependencyInjection.Contracts;
using Bytz.Extensions.DependencyInjection.Lifetimes;

namespace Bytz.Extensions.DependencyInjection.Configuration
{
    internal partial class Registrar
    : ILifetime
    {
        public IConfigure AsSingleton()
        {
            _lifetime = new Singleton();

            return this;
        }

        public IConfigure AsScoped()
        {
            _lifetime = new Scoped();

            return this;
        }

        public IConfigure AsTransient()
        {
            _lifetime = new Transient();

            return this;
        }
    }
}