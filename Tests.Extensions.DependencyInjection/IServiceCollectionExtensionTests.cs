using Bytz.Extensions.DependencyInjection;
using Bytz.Extensions.DependencyInjection.Exceptions;
using Examples.Extensions.DependencyInjection.Contracts;
using Examples.Extensions.DependencyInjection.Registration;
using Examples.Extensions.DependencyInjection.Services.Abstractions;
using Examples.Extensions.DependencyInjection.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Extensions.DependencyInjection;

public class IServiceCollectionExtensionTests
{
    [Fact]
    public async Task Extensions_IServiceCollection_Register()
    {
        var services = new ServiceCollection()
            .Register
            (r => r
                .InAssemblyOf<IService>()
                .Implementing<IService>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );

        Assert.Equal(6, services.Count);

        await Task.CompletedTask;
    }

    [Fact]
    public async Task Extensions_IServiceCollection_AssertLifetime_T_True()
    {
        var services = new ServiceCollection()
            .Register
            (r => r
                .InAssemblyOf<IService>()
                .Implementing<IService>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );

        services.AssertLifetime<ICustomerService>(ServiceLifetime.Transient);

        await Task.CompletedTask;
    }

    [Fact]
    public async Task Extensions_IServiceCollection_AssertLifetime_T_False_THROWS()
    {
        var services = new ServiceCollection()
            .Register
            (r => r
                .InAssemblyOf<IService>()
                .Implementing<IService>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );

        Assert.Throws<AssertLifetimeException>(() =>
        {
            services.AssertLifetime<ICustomerService>(ServiceLifetime.Scoped);
        });

        await Task.CompletedTask;
    }

    [Fact]
    public async Task Extensions_IServiceCollection_Register_T()
    {
        var services = new ServiceCollection()
            .Register<ExamplesRegistry>();

        Assert.Equal(40, services.Count);

        await Task.CompletedTask;
    }

    [Fact]
    public async Task Extensions_IServiceCollection_RemoveSingle_BasedClass_Throws_NotAnInterface()
    {
        var services = new ServiceCollection()
            .Register
            (r => r
                .InAssemblyOf<IService>()
                .Implementing<IService>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );

        Assert.Throws<NotAnInterfaceException>
        (
            () => services.Remove<ServiceBase>()
        );

        await Task.CompletedTask;
    }

    [Fact]
    public async Task Extensions_IServiceCollection_RemoveSingle_Interface_OnlyOneFound()
    {
        var services = new ServiceCollection()
            .Register
            (r => r
                .InAssemblyOf<IService>()
                .Implementing<IService>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );

        Assert.Equal(6, services.Count);

        _ = services.Remove<IOrderService>();

        Assert.Equal(5, services.Count);

        await Task.CompletedTask;
    }

    [Fact]
    public async Task Extensions_IServiceCollection_RemoveSingle_Interface_MoreThanOneFound_Throws_InvalidOperationException()
    {
        var services = new ServiceCollection()
            .Register
            (r => r
                .InAssemblyOf<IService>()
                .Implementing<IService>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );

        Assert.Throws<InvalidOperationException>
        (
            () => services.Remove<IService>()
        );

        await Task.CompletedTask;
    }

    [Fact]
    public async Task Extensions_IServiceCollection_RemoveSingle_Interface_MoreThanOneFound_Throws_NoServiceTypeFound()
    {
        var services = new ServiceCollection()
            .Register
            (r => r
                .InAssemblyOf<IService>()
                .Implementing<IService>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );

        Assert.Throws<NoServiceTypeFound>
        (
            () => services.Remove<INotFound>()
        );

        await Task.CompletedTask;
    }
}
