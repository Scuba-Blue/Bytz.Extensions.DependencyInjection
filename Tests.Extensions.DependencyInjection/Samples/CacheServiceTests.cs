using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitz.Extensions.DependencyInjection;
using Samples.Extensions.DependencyInjection.Contracts;
using Samples.Extensions.DependencyInjection.Services.Contracts;
using Samples.Extensions.DependencyInjection.Domain.Customers;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Samples
{
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
                .ConfigureOrThrow()
            );
        }

        protected override void OnConfigure()
        {
            this.Cache.Add(KEY, Customer.Samples);
        }

        private ICacheService Cache => this.Provider.GetRequiredService<ICacheService>();

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
}