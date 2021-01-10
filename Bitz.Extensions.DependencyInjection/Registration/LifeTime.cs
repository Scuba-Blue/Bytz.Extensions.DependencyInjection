using Bitz.Extensions.DependencyInjection.Contracts;
using Bitz.Extensions.DependencyInjection.Lifetimes;

namespace Bitz.Extensions.DependencyInjection.Configuration
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