using Bytz.Extensions.DependencyInjection.Contracts;
using Bytz.Extensions.DependencyInjection.Lifetimes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bytz.Extensions.DependencyInjection
{
    /// <summary>
    /// Configures the service collection.
    /// </summary>
    internal partial class Configurator
    {
        /// <summary>
        /// Configure the service collection.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="implementations">Various implementations.</param>
        /// <param name="contracts">Various interfaces.</param>
        /// <param name="lifetimes">Various lifetimes.</param>
        internal void Configure
        (
            IServiceCollection services,
            List<Type> implementations,
            _Contract contracts,
            _Lifetime lifetimes
        )
        {
            implementations
                .ForEach(t =>
                {
                    Configure(services, t, contracts, lifetimes);
                });
        }

        /// <summary>
        /// Configure 
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="concreteType">Concrete type to configure</param>
        /// <param name="contracts">Single contract type to implement.</param>
        /// <param name="lifetimes">Various lifetimes.</param>
        private void Configure
        (
            IServiceCollection services, 
            Type concreteType, 
            _Contract contracts, 
            _Lifetime lifetimes
        )
        {
            //  todo:   this needs thought
            ConfigureConcrete(services, concreteType, lifetimes);

            Configure(services, concreteType, contracts as AllContracts, lifetimes);
            Configure(services, concreteType, contracts as OnlyContract, lifetimes);
            Configure(services, concreteType, contracts as NoContracts, lifetimes);
        }

        /// <summary>
        /// Configure a concrete type for various lifetimes.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="concreteType">Concrete type to be configured for the lifetime.</param>
        /// <param name="lifetime">Various lifetimes.</param>
        private void ConfigureConcrete
        (
            IServiceCollection services, 
            Type concreteType,
            _Lifetime lifetime
        )
        {
            ConfigureConcrete(services, concreteType, lifetime as Transient);
            ConfigureConcrete(services, concreteType, lifetime as Scoped);
            ConfigureConcrete(services, concreteType, lifetime as Singleton);
        }

        /// <summary>
        /// Configure a concrete type as transient lifetime.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="concreteType">Concrete type to be configured for the lifetime.</param>
        /// <param name="lifetime">Transient lifetime.</param>
        private void ConfigureConcrete
        (
            IServiceCollection services,
            Type concreteType,
            Transient lifetime
        )
        {
            if (lifetime != null) services.AddTransient(concreteType);
        }

        /// <summary>
        /// Configure a concrete type as a scoped lifetime.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="concreteType">Concrete type to be configured for the lifetime.</param>
        /// <param name="lifetime">Scoped lifetime.</param>
        private void ConfigureConcrete
        (
            IServiceCollection services,
            Type concreteType,
            Scoped lifetime
        )
        {
            if (lifetime != null) services.AddScoped(concreteType);
        }

        /// <summary>
        /// Configure a concrete type as a singleton with no interfaces.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="concreteType">Concrete type to be configured for the lifetime.</param>
        /// <param name="lifetime">Singleton lifetime.</param>
        private void Configure
        (
            IServiceCollection services,
            Type concreteType,
            Singleton lifetime
        )
        {
            if (lifetime != null) services.AddSingleton(concreteType);
        }

        /// <summary>
        /// Configure a concrete type with all interfaces.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="concreteType">Concrete type to be configured for the lifetime.</param>
        /// <param name="interfaces">Configure the concrete type for all interfaces.</param>
        /// <param name="lifetime">Various lifetimes.</param>
        private void Configure
        (
            IServiceCollection services, 
            Type concreteType, 
            AllContracts interfaces, 
            _Lifetime lifetime)
        {
            if (interfaces != null)
            {
                concreteType
                    .GetInterfaces()
                    .ToList()
                    .ForEach(i =>
                    {
                        Configure(services, concreteType, i, lifetime);
                    });
            }
        }

        /// <summary>
        /// Configure a concrete type with all interfaces.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="concreteType">Concrete type to be configured for the lifetime.</param>
        /// <param name="contractType">specific contract to configure the concrete type as.</param>
        /// <param name="lifetime">Various lifetimes.</param>
        private void Configure
        (
            IServiceCollection services, 
            Type concreteType, 
            Type contractType, 
            _Lifetime lifetime
        )
        {
            Configure(services, concreteType, contractType, lifetime as Transient);
            Configure(services, concreteType, contractType, lifetime as Scoped);
            Configure(services, concreteType, contractType, lifetime as Singleton);
        }

        /// <summary>
        /// Configure a concrete type for a specific contract type for a transient lifetime.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="concreteType">Concrete type to be configured for the lifetime.</param>
        /// <param name="contractType">Various contract types.</param>
        /// <param name="lifetime">Transient lifetime.</param>
        private void Configure
        (
            IServiceCollection services, 
            Type concreteType, 
            Type contractType, 
            Transient lifetime
        )
        {
            if (lifetime != null) services.AddTransient(contractType, concreteType);
        }

        /// <summary>
        /// Configure a concrete type for a specific contract type for a scoped lifetime.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="concreteType">Implementation type.</param>
        /// <param name="contractType">Contract type.</param>
        /// <param name="lifetime">Scoped lifetime.</param>
        private void Configure
        (
            IServiceCollection services, 
            Type concreteType, 
            Type contractType, 
            Scoped lifetime
        )
        {
            if (lifetime != null) services.AddScoped(contractType, concreteType);
        }

        /// <summary>
        /// Configure a concrete type for a specific contract type for a singleton lifetime.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="concreteType">Concrete type to be configured for the lifetime.</param>
        /// <param name="contractType">specific contract to configure the concrete type as.</param>
        /// <param name="lifetime">Singleton lifetime.</param>
        private void Configure
        (
            IServiceCollection services, 
            Type concreteType, 
            Type contractType, 
            Singleton lifetime
        )
        {
            if (lifetime != null) services.AddSingleton(contractType, concreteType);
        }

        /// <summary>
        /// Configure a concrete type for only single contract type for various lifetimes.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="concreteType">Concrete type to be configured for the lifetime.</param>
        /// <param name="contracts">only a single contract.</param>
        /// <param name="lifetime">various lifetimes.</param>

        private void Configure
        (
            IServiceCollection services, 
            Type concreteType, 
            OnlyContract contracts, 
            _Lifetime lifetime
        )
        {
            if (contracts != null)
            {
                Configure(services, concreteType, contracts.Interface, lifetime);
            }
        }

        #region no interface

        /// <summary>
        /// Configure a concrete type with no interface for for various lifetimes.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="concreteType">Concrete type to be configured for the lifetime.</param>
        /// <param name="contract">only a single contract.</param>
        /// <param name="lifetime"></param>
        private void Configure
        (
            IServiceCollection services, 
            Type concreteType, 
            NoContracts contract, 
            _Lifetime lifetime
        )
        {
            if (contract != null)
            {
                Configure(services, concreteType, lifetime);
            }
        }

        /// <summary>
        /// Configure a concrete type with no interface for various lifetimes.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="concreteType">Concrete type to be configured for the lifetime.</param>
        /// <param name="lifetime">various lifetimes.</param>
        private void Configure
        (
            IServiceCollection services, 
            Type concreteType, 
            _Lifetime lifetime
        )
        {
            Configure(services, concreteType, lifetime as Transient);
            Configure(services, concreteType, lifetime as Scoped);
            Configure(services, concreteType, lifetime as Singleton);
        }

        /// <summary>
        /// Configure a concrete type with a transient lifetime.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="concreteType">Concrete type to be configured for the lifetime.</param>
        /// <param name="lifetime">Transient lifetime.</param>
        private void Configure
        (
            IServiceCollection services, 
            Type concreteType, 
            Transient lifetime
        )
        {
            if (lifetime != null) services.AddTransient(concreteType);
        }

        /// <summary>
        /// Configure a concrete type with a scoped lifetime.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="concreteType">Concrete type to be configured for the lifetime.</param>
        /// <param name="lifetime">Scoped lifetime.</param>
        private void Configure
        (
            IServiceCollection services, 
            Type concreteType, 
            Scoped lifetime
        )
        {
            if (lifetime != null) services.AddScoped(concreteType);
        }

        /// <summary>
        /// Configure a concrete type with a singleton lifetime.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <param name="concreteType">Concrete type to be configured for the lifetime.</param>
        /// <param name="lifetime">Singleton lifetime.</param>
        private void ConfigureConcrete
        (
            IServiceCollection services, 
            Type concreteType, 
            Singleton lifetime
        )
        {
            if (lifetime != null) services.AddSingleton(concreteType);
        }

        #endregion no interface
    }
}