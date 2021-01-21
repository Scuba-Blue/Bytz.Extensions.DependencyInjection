using Bytz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Engines.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.ImplementationType
{
    public class ImplementingTests : TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            services.Register
            (r => r
                .InAssemblyOf<IEngine>()
                .Implementing<ITaxEngine>()
                .AllInterfaces()
                .AsTransient()
                .Configure()
            );
        }

        [Fact]
        public void Type_Implementing_GetInstanceByContract()
        {
            this.Provider.AssertResolution<ITaxEngine>();
        }

        [Fact]
        public void Type_Implementing_GetInstanceByBaseContract()
        {
            this.Provider.AssertResolution<IEngine>();
        }
    }
}