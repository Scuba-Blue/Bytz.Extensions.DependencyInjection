using Bytz.Extensions.DependencyInjection;
using Bytz.Extensions.DependencyInjection.Registration;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Bytz.Extensions.DependencyInjection.Moq.Abstractions;

public abstract class TestBase<TRegistry>
where TRegistry : RegistryBase, new()
{
    /// <summary>
    /// get a new service every time, with the examples registered.
    /// </summary>
    public IServiceCollection Services => new ServiceCollection().Register<TRegistry>();
}