using Bitz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Samples.Extensions.DependencyInjection.Contracts;
using Samples.Extensions.DependencyInjection.Engines;
using Samples.Extensions.DependencyInjection.Engines.Contracts;
using System;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Interfaces
{
    public class WithoutInterfacesTests : TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            services.Register
            (r => r
                .InAssemblyOf(typeof(IEngine))
                .Implementing<IShippingEngine>()
                .WithoutInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );
        }

        [Fact]
        public void Interfaces_WithoutInterface_BaseContract()
        {
            Assert.Throws<InvalidOperationException>(() => this.AssertInstance<IEngine>());
        }

        [Fact]
        public void Interfaces_WithoutInterface_Contract()
        {
            Assert.Throws<InvalidOperationException>(() => this.AssertInstance<IShippingEngine>());
        }

        [Fact]
        public void InterfaceS_WithoutInterface_ConcreteClass()
        {
            this.AssertInstance<ShippingEngine>();
        }
    }
}