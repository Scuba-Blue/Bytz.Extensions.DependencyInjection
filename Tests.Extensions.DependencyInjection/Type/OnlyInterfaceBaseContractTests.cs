using Bitz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Samples.Extensions.DependencyInjection.Contracts;
using Samples.Extensions.DependencyInjection.Engines.Contracts;
using System;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Type
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
                   .ConfigureOrThrow()
               );
        }

        [Fact]
        public void Type_OnlyInterfaceBaseContract_BaseContract()
        {
            this.AssertInstance<IEngine>();
        }

        [Fact]
        public void Type_OnlyInterfaceBaseContract_SpecificContract_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => this.AssertInstance<ITaxEngine>());
        }
    }
}
