using Bitz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Samples.Extensions.DependencyInjection.Contracts;
using Samples.Extensions.DependencyInjection.Engines.Base;
using Samples.Extensions.DependencyInjection.Engines.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.ImplementationType
{
    public class BasedOnTTests : TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            services.Register
            (r => r
                .InAssemblyOf<IEngine>()
                .BasedOn<EngineBase>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );
        }

        [Fact]
        public void Type_BasedOnT_GetInstanceByContract()
        {
            this.AssertInstance<IShippingEngine>();
        }
    }
}