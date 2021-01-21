using Bytz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Engines.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Lifetimes
{
    public class TransientTests : TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            services.Register
            (r => r
                .InAssemblyOf<IEngine>()
                .Implementing<IShippingEngine>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );
        }

        [Fact]
        public void Lifetime_Transient_GetInstanceByContract()
        {
            this.Provider.AssertResolution<IShippingEngine>();
        }

        [Fact]
        public void Lifetime_Transient_GetInstanceByBaseContract()
        {
            this.Provider.AssertResolution<IEngine>();
        }

        [Fact]
        public void Lifetime_Transient_AssertLifetime()
        {
            this.ServiceCollection.AssertLifetime<IShippingEngine>(ServiceLifetime.Transient);
        }
    }
}