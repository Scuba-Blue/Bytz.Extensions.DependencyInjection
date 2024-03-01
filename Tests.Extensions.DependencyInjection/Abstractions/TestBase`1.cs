using Microsoft.Extensions.DependencyInjection;

namespace Tests.Extensions.DependencyInjection;

abstract public class TestBase<TService> : TestBase
where TService : class
{
    protected TService Service => this.ServiceProvider.GetService<TService>();
}
