using Bytz.Extensions.DependencyInjection;
using Bytz.Extensions.DependencyInjection.Exceptions;
using Examples.Extensions.DependencyInjection.Contracts;
using Examples.Extensions.DependencyInjection.Engines.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Fluent.Implementation;

public class OnlyInterfaceTests : TestBase<ITaxEngine>
{
    protected override void OnRegister(IServiceCollection services)
    {
        services.Register
            (r => r
                .InAssemblyOf<IEngine>()
                .Implementing<ITaxEngine>()
                .OnlyInterface<ITaxEngine>()
                .AsTransient()
                .Configure()
            );
    }

    [Fact]
    public void Type_OnlyInterface_BaseContract()
    {
        Assert.Throws<AssertResolutionException>(() => this.ServiceProvider.AssertResolution<IEngine>());
    }

    [Fact]
    public void Type_OnlyInterface_SpecificContract()
    {
        this.ServiceProvider.AssertResolution<ITaxEngine>();
    }
}