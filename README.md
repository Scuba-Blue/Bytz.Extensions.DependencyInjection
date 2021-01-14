![.NET](https://github.com/Scuba-Blue/Bitz.Extensions.DependencyInjection/workflows/.NET/badge.svg)

# Bitz.Extensions.DependencyInjection

A library of .NET Standard Extensions for IServiceCollection to increase productivity and code quality by allowing multiple registerations to be performed within a single statement.


        /// <summary>
        /// add all services as transient.
        /// </summary>
        /// <param name="services">instance of the service collection.</param>
        /// <returns>instance of the service collection.</returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return 
                services.Register(r => r
                    .InThisAssembly()
                    .Implementing<IService>()
                    .AllInterfaces()
                    .AsTransient()
                    .Configure());
        }
        
        
c
