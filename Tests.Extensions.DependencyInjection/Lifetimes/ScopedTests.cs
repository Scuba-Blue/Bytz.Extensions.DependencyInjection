using Bitz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Samples.Extensions.DependencyInjection.Contracts;
using Samples.Extensions.DependencyInjection.Engines.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Lifetimes
{
    public class ScopedTests : TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            services.Register
            (r => r
                .InAssemblyOf<IEngine>()
                .Implementing<IShippingEngine>()
                .AllInterfaces()
                .AsScoped()
                .ConfigureOrThrow()
            );
        }

        [Fact]
        public void Lifetime_Scoped_GetInstanceByContract()
        {
            this.AssertInstance<IShippingEngine>();
        }

        [Fact]
        public void Lifetime_Scoped_GetInstanceByBaseContract()
        {
            this.AssertInstance<IEngine>();
        }

        [Fact]
        public void Lifetime_Scoped_AssertLifetime()
        {
            this.AssertLifeTime<IShippingEngine>(ServiceLifetime.Scoped);
        }
    }
}