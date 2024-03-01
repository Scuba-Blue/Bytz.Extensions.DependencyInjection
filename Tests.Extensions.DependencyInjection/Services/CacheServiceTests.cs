using Bytz.Extensions.DependencyInjection;
using Examples.Extensions.DependencyInjection.Contracts;
using Examples.Extensions.DependencyInjection.Domain.Customers;
using Examples.Extensions.DependencyInjection.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Services;

/// <summary>
/// example of an implemented, singleton object cache
/// and retrieving values from
/// </summary>
public class CacheServiceTests : TestBase
{
    const string KEY = "Customers";

    protected override void OnRegister(IServiceCollection services)
    {
        services.Register
        (r => r
            .InAssemblyOf<IEngine>()
            .Implementing<ICacheService>()
            .OnlyInterface<ICacheService>()
            .AsSingleton()
            .Configure()
        );
    }

    protected override void OnConfigure()
    {
        this.Cache.Add(KEY, Customer.Samples);
    }

    private ICacheService Cache => this.ServiceProvider.GetRequiredService<ICacheService>();

    [Fact]
    public void Samples_CacheService_GetValue()
    {
        var value = this.Cache.Get<IEnumerable<Customer>>(KEY);

        Assert.NotNull(value);
        Assert.Equal(5, value.Count());
    }

    [Fact]
    public void Samples_CacheService_NonExistentValue()
    {
        var value = this.Cache.Get<string>("dummy");

        Assert.Null(value);
    }
}