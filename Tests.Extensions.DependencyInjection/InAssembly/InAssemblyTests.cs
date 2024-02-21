using Bytz.Extensions.DependencyInjection;
using Examples.Extensions.DependencyInjection.Contracts;
using Examples.Extensions.DependencyInjection.Engines.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests.Extensions.DependencyInjection.InAssembly;

public class InAssemblyTests : TestBase
{
    protected override void OnRegister(IServiceCollection services)
    {
        services.Register
        (r => r
            .InAssemblyOf<IEngine>()
            .Implementing<IShippingEngine>()
            .AllInterfaces()
            .AsTransient()
            .Configure()
        );
    }

    [Fact]
    public void InAssemblyOf_T_GetInstanceByContract()
    {
        this.ServiceProvider.AssertResolution<IShippingEngine>();
    }

    [Fact]
    public void InAssemblyOf_T_GetInstanceByBaseContract()
    {
        this.ServiceProvider.AssertResolution<IEngine>();
    }
}