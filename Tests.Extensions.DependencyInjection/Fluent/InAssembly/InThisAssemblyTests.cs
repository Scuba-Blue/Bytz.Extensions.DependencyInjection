﻿using Bytz.Extensions.DependencyInjection;
using Examples.Extensions.DependencyInjection.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Tests.Extensions.DependencyInjection.Examples.Services.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Fluent.InAssembly;

public class InThisAssemblyTests : TestBase
{
    protected override void OnRegister(IServiceCollection services)
    {
        services.Register
        (r => r
            .InThisAssembly()
            .Implementing<IMessageService>()
            .AllInterfaces()
            .AsTransient()
            .Configure()
        );
    }

    [Fact]
    public void InThisAssemblyGetInstanceByContract()
    {
        this.ServiceProvider.AssertResolution<IMessageService>();
    }

    [Fact]
    public void InThisAssembly_GetInstanceByBaseContract()
    {
        this.ServiceProvider.AssertResolution<IService>();
    }
}