using Bytz.Extensions.DependencyInjection;
using Examples.Extensions.DependencyInjection.Contracts;
using Examples.Extensions.DependencyInjection.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Fluent.Lifetimes;

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