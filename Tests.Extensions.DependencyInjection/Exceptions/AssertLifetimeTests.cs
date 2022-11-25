using Bytz.Extensions.DependencyInjection;
using Bytz.Extensions.DependencyInjection.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Services.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Exceptions
{
    public class AssertLifetimeTests : TestBase
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
        public void Exceptions_Lifetime_Expected()
        {
            this.ServiceCollection.AssertLifetime<ICacheService>(ServiceLifetime.Singleton);
        }

        [Fact]
        public void Exceptions_Lifetime_Not_Expected()
        {
            Assert.Throws<AssertLifetimeException>(() => this.ServiceCollection.AssertLifetime<ICacheService>(ServiceLifetime.Scoped));
        }
    }
}