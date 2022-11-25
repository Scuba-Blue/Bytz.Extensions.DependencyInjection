using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Tests.Extensions.DependencyInjection
{
    /// <summary>
    /// Base for all bytz di tests.
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// Service collection instance.
        /// </summary>
        protected IServiceCollection ServiceCollection { get; } = new ServiceCollection();

        /// <summary>
        /// Hold onto the instance of IServiceProvider once built for this test instance.
        /// </summary>
        private IServiceProvider _serviceProvider;

        /// <summary>
        /// Configured service provider.
        /// </summary>
        protected IServiceProvider ServiceProvider 
        {
            get { return _serviceProvider ??= this.ServiceCollection.BuildServiceProvider(); }
        }

        /// <summary>
        /// Each test must configure its own di provider.
        /// </summary>
        /// <param name="services">Instance of a service collection.</param>
        protected abstract void OnRegister(IServiceCollection services);

        /// <summary>
        /// Allow custom configuration by the test class.
        /// </summary>
        protected virtual void OnConfigure()
        { }

        /// <summary>
        /// Configure the service provider upon creation.
        /// </summary>
        protected TestBase()
        {
            this.OnRegister(this.ServiceCollection);

            this.OnConfigure();
        }
    }
}