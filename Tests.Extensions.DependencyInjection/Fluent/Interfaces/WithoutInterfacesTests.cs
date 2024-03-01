using Bytz.Extensions.DependencyInjection;
using Bytz.Extensions.DependencyInjection.Exceptions;
using Examples.Extensions.DependencyInjection.Contracts;
using Examples.Extensions.DependencyInjection.Engines;
using Examples.Extensions.DependencyInjection.Engines.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Fluent.Interfaces;

public class WithoutInterfacesTests : TestBase
{
    protected override void OnRegister(IServiceCollection services)
    {
        services.Register
        (r => r
            .InAssemblyOf(typeof(IEngine))
            .Implementing<IShippingEngine>()
            .WithoutInterfaces()
            .AsTransient()
            .Configure()
        );
    }

    [Fact]
    public void Interfaces_WithoutInterface_BaseContract()
    {
        Assert.Throws<AssertResolutionException>(() => this.ServiceProvider.AssertResolution<IEngine>());
    }

    [Fact]
    public void Interfaces_WithoutInterface_Contract()
    {
        Assert.Throws<AssertResolutionException>(() => this.ServiceProvider.AssertResolution<IShippingEngine>());
    }

    [Fact]
    public void InterfaceS_WithoutInterface_ConcreteClass()
    {
        this.ServiceProvider.AssertResolution<ShippingEngine>();
    }
}