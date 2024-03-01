using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Bytz.Extensions.DependencyInjection.Moq;

/// <summary>
/// extensions for mocking interfaces via the MoQ library.
/// </summary>
public static class ExtensionMethods
{
    /// <summary>
    /// replace the entriy in IServiceCollection that implements TService with a MoQ implementation
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <param name="services">instance of iservicecollection for fluent extension</param>
    /// <param name="mocked">mock of TService</param>
    /// <returns>instance of iservicecollection</returns>
    /// <remarks>Behavior restricted to MockBehavior.Strict</remarks>
    public static IServiceCollection Mock<TService>
    (
        this IServiceCollection services,
        out Mock<TService> mocked
    )
    where TService : class
    {
        return Mock(services, out mocked, MockBehavior.Strict);
    }

    /// <summary>
    /// replace the entriy in IServiceCollection that implements TService with a MoQ implementation
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <param name="services">instance of iservicecollection for fluent extension</param>
    /// <param name="mocked">mock of TService</param>
    /// <param name="behavior">preferred MoQ.Behavior</param>
    /// <returns>instance of iservicecollection</returns>
    public static IServiceCollection Mock<TService>
    (
        this IServiceCollection services,
        out Mock<TService> mocked,
        MockBehavior behavior
    )
    where TService : class
    {
        mocked = new Mock<TService>(behavior);

        services.RemoveSingle<TService>().AddSingleton(mocked.Object);

        return services;
    }
}