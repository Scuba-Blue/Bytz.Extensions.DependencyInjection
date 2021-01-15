using Bitz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Services.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Services
{
    public class OrderServiceTests : TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            //  register services
            services.Register
            (r => r
                .InAssemblyOf<IEngine>()
                .Implementing<IService>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );

            //  register engines
            services.Register
            (r => r
                .InAssemblyOf<IEngine>()
                .Implementing<IEngine>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );
        }

        private IOrderService Service => this.Provider.GetRequiredService<IOrderService>();

        [Fact]
        public void Samples_OrderService_CheckDependency()
        { 
            Assert.NotNull(this.Service.TaxEngine);
        }
    }
}