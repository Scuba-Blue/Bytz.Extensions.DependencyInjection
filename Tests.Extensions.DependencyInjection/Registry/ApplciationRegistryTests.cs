using Bytz.Extensions.DependencyInjection;
using Examples.Extensions.DependencyInjection.Registration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Registry;

/// <summary>
/// 
/// </summary>
public class ApplciationRegistryTests
{
    [Fact]
    public void Register_ExampleRegistry()
    {
        IServiceCollection services =
            new ServiceCollection()
            .Register<ExamplesRegistry>();

        Assert.Equal(12, services.Count);
    }
}