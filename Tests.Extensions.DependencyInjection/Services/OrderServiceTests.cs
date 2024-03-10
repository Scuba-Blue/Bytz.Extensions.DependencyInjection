using Bytz.Extensions.DependencyInjection;
using Examples.Extensions.DependencyInjection.Contracts;
using Examples.Extensions.DependencyInjection.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Extensions.DependencyInjection.Services;

public class OrderServiceTests : TestBase
{
    protected override void OnRegister(IServiceCollection services)
    {
        //  register services
        services.Register
        (r => r
            .InAssemblyOf<IEngine>()
            .Implementing<IService>()
            .AllInterfaces()
            .AsTransient()
            .Configure()
        );

        //  register engines
        services.Register
        (r => r
            .InAssemblyOf<IEngine>()
            .Implementing<IEngine>()
            .AllInterfaces()
            .AsTransient()
            .Configure()
        );
    }

    private IOrderService Service => this.ServiceProvider.GetRequiredService<IOrderService>();
}