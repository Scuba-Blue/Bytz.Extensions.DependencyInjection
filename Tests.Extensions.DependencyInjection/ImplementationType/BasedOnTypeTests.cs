using Bytz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Engines.Base;
using Tests.Extensions.DependencyInjection.Samples.Engines.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.ImplementationType
{
    public class BasedOnTypeTests : TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            services.Register
            (r => r
                .InAssemblyOf<IEngine>()
                .BasedOn(typeof(EngineBase))
                .AllInterfaces()
                .AsTransient()
                .Configure()
            );
        }

        [Fact]
        public void Type_BasedOnType_GetInstanceByContract()
        {
            this.ServiceProvider.AssertResolution<IShippingEngine>();
        }
    }
}