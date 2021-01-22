using Bytz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Engines.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Exceptions
{
    public class AssertCountExceptionTests : TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            services.Register
            (r => r
                .InAssemblyOf<IEngine>()
                .Implementing<IEngine>()
                .AllInterfaces()
                .AsTransient()
                .Configure()
            );
        }

        private interface ISee { }

        [Fact]
        public void Exceptions_Count_UnregisteredInterface()
        {
            this.ServiceProvider.AssertCount<ISee>(0);
        }

        [Fact]
        public void Exceptions_Count_SpecificInterface()
        {
            this.ServiceProvider.AssertCount<IShippingEngine>(1);
        }

        [Fact]
        public void Exceptions_Count_BaseInterface()
        {
            this.ServiceProvider.AssertCount<IEngine>(2);
        }
    }
}