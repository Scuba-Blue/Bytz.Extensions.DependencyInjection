using Bytz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Services.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Lifetimes
{
    public class SingletonTests : TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            services.Register
            (r => r
                .InAssemblyOf<IEngine>()
                .Implementing<ICacheService>()
                .OnlyInterface<ICacheService>()
                .AsSingleton()
                .Configure()
            );
        }

        [Fact]
        public void Lifetime_Singleton_GetInstanceByContract()
        {
            this.ServiceProvider.AssertResolution<ICacheService>();
        }

        [Fact]
        public void Lifetime_Singleton_AssertLifetime()
        {
            this.ServiceCollection.AssertLifetime<ICacheService>(ServiceLifetime.Singleton);
        }
    }
}