using Bytz.Extensions.DependencyInjection;
using Bytz.Extensions.DependencyInjection.Registration;
using Examples.Extensions.DependencyInjection.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Examples.Extensions.DependencyInjection.Registration;

public class ExamplesRegistry
: RegistryBase
{
    protected override void OnRegister
    (
        IServiceCollection services
    )
    {
        services.Register(r => r.InThisAssembly().Implementing<IEngine>().AllInterfaces().AsTransient().ConfigureOrThrow());
        services.Register(r => r.InThisAssembly().Implementing<IService>().AllInterfaces().AsTransient().ConfigureOrThrow());
        services.Register(r => r.InThisAssembly().Implementing<IRepository>().AllInterfaces().AsTransient().ConfigureOrThrow());

        services.AddLogging
        (l =>
            l.AddConsole()
        );
    }
}