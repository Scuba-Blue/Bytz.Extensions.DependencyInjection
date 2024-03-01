using Bytz.Extensions.DependencyInjection;
using Examples.Extensions.DependencyInjection.Contracts;
using Examples.Extensions.DependencyInjection.Engines.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Fluent.InAssembly;

public class InAssemblyAssemblyTests : TestBase
{
    protected override void OnRegister(IServiceCollection services)
    {
        services.Register
        (r => r
            .InAssembly(typeof(IEngine).Assembly)
            .Implementing<IShippingEngine>()
            .AllInterfaces()
            .AsTransient()
            .Configure()
        );
    }

    [Fact]
    public void InAssembly_Assembly_GetInstanceByContract()
    {
        this.ServiceProvider.AssertResolution<IShippingEngine>();
    }

    [Fact]
    public void InAssembly_Assembly_GetInstanceByBaseContract()
    {
        this.ServiceProvider.AssertResolution<IEngine>();
    }
}