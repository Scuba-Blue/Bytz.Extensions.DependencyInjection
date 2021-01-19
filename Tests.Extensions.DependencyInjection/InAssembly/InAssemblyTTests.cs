﻿using Bytz.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Engines.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.InAssembly
{
    public class InAssemblyTTests : TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            services.Register
            (r => r
                .InAssemblyOf<IEngine>()
                .Implementing<IShippingEngine>()
                .AllInterfaces()
                .AsTransient()
                .ConfigureOrThrow()
            );
        }

        [Fact]
        public void InAssemblyOf_T_GetInstanceByContract()
        {
            this.AssertInstance<IShippingEngine>();
        }
        
        [Fact]
        public void InAssemblyOf_T_GetInstanceByBaseContract()
        {
            this.AssertInstance<IEngine>();
        }
    }
}