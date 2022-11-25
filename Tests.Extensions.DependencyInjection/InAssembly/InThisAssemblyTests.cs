using Bytz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Tests.Extensions.DependencyInjection.InAssembly.Services.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.InAssembly
{
    public class InThisAssemblyTests : TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            services.Register
            (r => r
                .InThisAssembly()
                .Implementing<IMessageService>()
                .AllInterfaces()
                .AsTransient()
                .Configure()
            );
        }

        [Fact]
        public void InThisAssemblyGetInstanceByContract()
        {
            this.ServiceProvider.AssertResolution<IMessageService>();
        }

        [Fact]
        public void InThisAssembly_GetInstanceByBaseContract()
        {
            this.ServiceProvider.AssertResolution<IService>();
        }
    }
}