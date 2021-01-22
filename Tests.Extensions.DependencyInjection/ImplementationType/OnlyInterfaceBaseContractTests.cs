using Bytz.Extensions.DependencyInjection;
using Bytz.Extensions.DependencyInjection.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Engines.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.ImplementationType
{
    public class OnlyInterfaceBaseContractTests : TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            services.Register
               (r => r
                   .InAssemblyOf<IEngine>()
                   .Implementing<IEngine>()
                   .OnlyInterface<IEngine>()
                   .AsTransient()
                   .Configure()
               );
        }

        [Fact]
        public void Type_OnlyInterfaceBaseContract_BaseContract()
        {
            this.ServiceProvider.AssertResolution<IEngine>();
        }

        [Fact]
        public void Type_OnlyInterfaceBaseContract_SpecificContract_Exception()
        {
            Assert.Throws<AssertResolutionException>(() => this.ServiceProvider.AssertResolution<ITaxEngine>());
        }
    }
}