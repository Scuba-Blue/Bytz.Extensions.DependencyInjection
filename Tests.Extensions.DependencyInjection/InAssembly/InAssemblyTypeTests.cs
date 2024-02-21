using Bytz.Extensions.DependencyInjection;
using Examples.Extensions.DependencyInjection.Contracts;
using Examples.Extensions.DependencyInjection.Engines.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests.Extensions.DependencyInjection.InAssembly;

public class InAssemblyTypeTests : TestBase
{
    protected override void OnRegister(IServiceCollection services)
    {
        services.Register
        (r => r
            .InAssemblyOf(typeof(IEngine))
            .Implementing<IShippingEngine>()
            .AllInterfaces()
            .AsTransient()
            .Configure()
        );
    }

    [Fact]
    public void InAssemblyOf_Type_GetInstanceByContract()
    {
        this.ServiceProvider.AssertResolution<IShippingEngine>();
    }

    [Fact]
    public void InAssemblyOf_Type_GetInstanceByBaseContract()
    {
        this.ServiceProvider.AssertResolution<IEngine>();
    }
}