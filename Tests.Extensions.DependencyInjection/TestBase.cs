using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Xunit;

namespace Tests.Extensions.DependencyInjection
{
    /// <summary>
    /// base for all bytz di tests.
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// service collection instance.
        /// </summary>
        protected IServiceCollection ServiceCollection { get; } = new ServiceCollection();

        /// <summary>
        /// hold onto the instance of IServiceProvider once built for this test instance.
        /// </summary>
        private IServiceProvider _serviceProvider;

        /// <summary>
        /// configured service provider.
        /// </summary>
        protected IServiceProvider Provider 
        {
            get { return _serviceProvider ??= this.ServiceCollection.BuildServiceProvider(); }
        }

        /// <summary>
        /// each test must configure its own di provider.
        /// </summary>
        /// <param name="services">instance of a service collection.</param>
        protected abstract void OnRegister(IServiceCollection services);

        /// <summary>
        /// allow custom configuration by the test class.
        /// </summary>
        protected virtual void OnConfigure()
        { }

        /// <summary>
        /// configure the service provider upon creation.
        /// </summary>
        protected TestBase()
        {
            this.OnRegister(this.ServiceCollection);

            this.OnConfigure();
        }

        /// <summary>
        /// assert that we can get an instance of TService.
        /// </summary>
        /// <typeparam name="TService">Type of service to resolve.</typeparam>
        protected void AssertInstance<TService>()
        where TService : class
        {
            Assert.NotNull
            (
                this.Provider.GetRequiredService<TService>()
            );
        }

        /// <summary>
        /// assert all registrations of TService have the expected lifetime.
        /// </summary>
        /// <typeparam name="TService">Service type to be validated.</typeparam>
        /// <param name="lifetime">Expected service lifetime.</param>
        protected void AssertLifeTime<TService>(ServiceLifetime lifetime)
        where TService : class
        {
            Assert.True
            (
                this.ServiceCollection
                    .Where(s => s.ServiceType == typeof(TService))
                    .All(s => s.Lifetime == lifetime)
            );
        }
    }
}