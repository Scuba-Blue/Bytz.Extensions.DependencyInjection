using Bytz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Engines.Contracts;
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
                .Configure()
            );
        }

        [Fact]
        public void Lifetime_Scoped_GetInstanceByContract()
        {
            this.ServiceProvider.AssertResolution<IShippingEngine>();
        }

        [Fact]
        public void Lifetime_Scoped_GetInstanceByBaseContract()
        {
            this.ServiceProvider.AssertResolution<IEngine>();
        }

        [Fact]
        public void Lifetime_Scoped_AssertLifetime()
        {
            this.ServiceCollection.AssertLifetime<IShippingEngine>(ServiceLifetime.Scoped);
        }
    }
}