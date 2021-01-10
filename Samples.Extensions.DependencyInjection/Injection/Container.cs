using Microsoft.Extensions.DependencyInjection;
using System;

namespace Samples.Extensions.DependencyInjection.Injection
{
    /// <summary>
    /// 
    /// </summary>
    public static class Container
    {
        private static readonly IServiceCollection _services = new ServiceCollection();

        public static IServiceProvider Provider { get; private set; }

        public static IServiceProvider Configure
        (Action<IServiceCollection> configure)
        {
            configure?.Invoke(_services);

            return 
            (Container.Provider = _services
                .AddEngines()
                .AddServices()
                .AddRepositories()
                .AddCache()
                .BuildServiceProvider()
            );
        }
    }
}
