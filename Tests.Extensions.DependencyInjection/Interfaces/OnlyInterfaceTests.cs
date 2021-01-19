using Bytz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Engines.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Interfaces
{
    public class OnlyInterfaceTests : TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            services.Register
            (r => r
                .InAssemblyOf<IEngine>()
                .Implementing<IShippingEngine>()
                .OnlyInterface<IShippingEngine>()
                .AsTransient()
                .ConfigureOrThrow()
            );
        }

        [Fact]
        public void Interfaces_OnlyInterface()
        {
            this.AssertInstance<IShippingEngine>();
        }

        [Fact]
        public void Interfaces_OnlyInterface_BaseInterface_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => this.AssertInstance<IEngine>());
        }
    }
}