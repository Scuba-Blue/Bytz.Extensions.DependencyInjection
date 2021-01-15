using Bitz.Extensions.DependencyInjection;
using Bitz.Extensions.DependencyInjection.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Engines.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.ImplementationType
{
    public class OnlyInterfaceExceptionTests : TestBase
    {
        protected override void OnRegister(IServiceCollection services)
        {
            _exception = Assert.Throws<OnlyInterfaceException>
            (
                () => services.Register
                (r => r
                    .InAssemblyOf<IEngine>()
                    .Implementing<IEngine>()
                    .OnlyInterface<ITaxEngine>()
                    .AsTransient()
                    .ConfigureOrThrow()
                )
            );
        }

        private ITaxEngine Service => this.Provider.GetRequiredService<ITaxEngine>();

        private Exception _exception;

        [Fact]
        public void Type_OnlyInterfaceException_InvalidCast()
        {
            Assert.IsType<OnlyInterfaceException>(_exception);
        }
    }
}