using Bytz.Extensions.DependencyInjection;
using Bytz.Extensions.DependencyInjection.Exceptions;
using Examples.Extensions.DependencyInjection.Contracts;
using Examples.Extensions.DependencyInjection.Engines.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Interfaces;

public class OnlyInterfaceTests : TestBase
{
    protected override void OnRegister(IServiceCollection services)
    {
        services.Register
        (r => r
            .InAssemblyOf<IEngine>()
            .Implementing<IShippingEngine>()
            .OnlyInterface<IShippingEngine>()
            .AsTransient()
            .Configure()
        );
    }

    [Fact]
    public void Interfaces_OnlyInterface()
    {
        this.ServiceProvider.AssertResolution<IShippingEngine>();
    }

    [Fact]
    public void Interfaces_OnlyInterface_BaseInterface_Exception()
    {
        Assert.Throws<AssertResolutionException>(() => this.ServiceProvider.AssertResolution<IEngine>());
    }
}