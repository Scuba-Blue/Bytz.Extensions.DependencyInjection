using Bytz.Extensions.DependencyInjection;
using Bytz.Extensions.DependencyInjection.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Exceptions;

public class NoTypeExceptionTests : TestBase
{
    private Exception _exception;

    private interface IKnow { }

    protected override void OnRegister(IServiceCollection services)
    {
        _exception = Assert.Throws<NoTypesException>
        (
            () => services.Register
            (r => r
                .InThisAssembly()
                .Implementing<IKnow>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            )
        );
    }

    [Fact]
    public void Exceptions_NoType_No_Registrations()
    {
        Assert.IsType<NoTypesException>(_exception);
    }
}