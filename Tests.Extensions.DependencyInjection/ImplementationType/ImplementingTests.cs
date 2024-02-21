using Bytz.Extensions.DependencyInjection;
using Examples.Extensions.DependencyInjection.Contracts;
using Examples.Extensions.DependencyInjection.Engines.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests.Extensions.DependencyInjection.ImplementationType;

public class ImplementingTests : TestBase
{
    protected override void OnRegister(IServiceCollection services)
    {
        services.Register
        (r => r
            .InAssemblyOf<IEngine>()
            .Implementing<ITaxEngine>()
            .AllInterfaces()
            .AsTransient()
            .Configure()
        );
    }

    [Fact]
    public void Type_Implementing_GetInstanceByContract()
    {
        this.ServiceProvider.AssertResolution<ITaxEngine>();
    }

    [Fact]
    public void Type_Implementing_GetInstanceByBaseContract()
    {
        this.ServiceProvider.AssertResolution<IEngine>();
    }
}