using Bytz.Extensions.DependencyInjection;
using Bytz.Extensions.DependencyInjection.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tests.Extensions.DependencyInjection.Samples.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Engines.Contracts;
using Xunit;

namespace Tests.Extensions.DependencyInjection.Exceptions
{
    public class OnlyInterfaceTests : TestBase
    {
        private Exception _exception;

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
                    .Configure()
                )
            );
        }

        [Fact]
        public void Type_OnlyInterfaceException_InvalidCast()
        {
            Assert.IsType<OnlyInterfaceException>(_exception);
        }
    }
}
