using Bitz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Samples.Extensions.DependencyInjection.Contracts;
using Samples.Extensions.DependencyInjection.Engines.Contracts;
using System;
using Xunit;

namespace Tests.Extensions.DependencyInjection.ImplementationType
{
    public class OnlyInterfaceTests: TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            services.Register
                (r => r
                    .InAssemblyOf<IEngine>()
                    .Implementing<ITaxEngine>()
                    .OnlyInterface<ITaxEngine>()
                    .AsTransient()
                    .ConfigureOrThrow()
                );
        }

        private ITaxEngine Service => this.Provider.GetRequiredService<ITaxEngine>();

        [Fact]
        public void Type_OnlyInterface_BaseContract()
        {
            Assert.Throws<InvalidOperationException>(() => this.AssertInstance<IEngine>());
        }

        [Fact]
        public void Type_OnlyInterface_SpecificContract()
        {
            this.AssertInstance<ITaxEngine>();
        }
    }
}
