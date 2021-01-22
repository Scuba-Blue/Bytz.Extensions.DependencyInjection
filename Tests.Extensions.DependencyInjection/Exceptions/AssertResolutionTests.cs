using Bytz.Extensions.DependencyInjection;
using Bytz.Extensions.DependencyInjection.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Engines.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Exceptions
{
    public class AssertResolutionTests : TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            services.Register
                (r => r
                    .InAssemblyOf<IEngine>()
                    .Implementing<ITaxEngine>()
                    .OnlyInterface<ITaxEngine>()
                    .AsTransient()
                    .Configure()
                );
        }

        [Fact]
        public void Exceptions_Resolution_Expected()
        {
            this.ServiceProvider.AssertResolution<ITaxEngine>();
        }

        [Fact]
        public void Exceptions_Resolution_Not_Expected()
        {
            Assert.Throws<AssertResolutionException>(() => this.ServiceProvider.AssertResolution<IEngine>());
        }
    }
}