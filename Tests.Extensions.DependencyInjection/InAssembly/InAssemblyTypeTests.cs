using Bytz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Engines.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.InAssembly
{
    public class InAssemblyTypeTests : TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            services.Register
            (r => r
                .InAssemblyOf(typeof(IEngine))
                .Implementing<IShippingEngine>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );
        }

        [Fact]
        public void InAssemblyOf_Type_GetInstanceByContract()
        {
            this.Provider.AssertResolution<IShippingEngine>();
        }

        [Fact]
        public void InAssemblyOf_Type_GetInstanceByBaseContract()
        {
            this.Provider.AssertResolution<IEngine>();
        }
    }
}