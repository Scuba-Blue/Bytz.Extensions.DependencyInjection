using Bytz.Extensions.DependencyInjection;
using Bytz.Extensions.DependencyInjection.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Engines.Contracts;
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
            Assert.Throws<AssertResolutionException>(() => this.Provider.AssertResolution<IEngine>());
        }

        [Fact]
        public void Type_OnlyInterface_SpecificContract()
        {
            this.Provider.AssertResolution<ITaxEngine>();
        }
    }
}