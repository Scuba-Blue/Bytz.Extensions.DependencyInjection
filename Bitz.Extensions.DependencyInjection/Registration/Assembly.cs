using Bitz.Extensions.DependencyInjection.Contracts;
using System;
using System.Reflection;

namespace Bitz.Extensions.DependencyInjection.Configuration
{
    internal partial class Registrar
    : IAssembly
    {
        public IType InAssemblyOf<TClass>
        ()
        where TClass : class
        {
            if (typeof(TClass) == typeof(string))
                throw new ArgumentException($"{nameof(TClass)} cannot be a string type.");

            return InAssembly(typeof(TClass).Assembly);
        }

        public IType InAssemblyOf
        (
            Type type
        )
        {
            _assembly = type.Assembly;

            return this;
        }

        public IType InAssembly
        (
            Assembly assembly
        )
        {
            _assembly = assembly;

            return this;
        }

        public IType InThisAssembly()
        {
            _assembly = Assembly.GetCallingAssembly();

            return this;
        }
    }
}