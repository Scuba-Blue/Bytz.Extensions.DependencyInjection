using Bytz.Extensions.DependencyInjection.Contracts;
using Bytz.Extensions.DependencyInjection.Implementation;
using System;

namespace Bytz.Extensions.DependencyInjection.Configuration
{
    internal partial class Registrar
    : IType
    {
        public IImplementing BasedOn<TClass>
        () 
        where TClass : class
        {
            AssertNotString<TClass>();
            SetType<BasedOn, TClass>();

            return this;
        }

        private void AssertNotString<TClass>
        ()
        {
            this.AssertNotString(typeof(TClass));
        }

        private void AssertNotString(Type type)
        {
            if (type == typeof(string))
                throw new ArgumentException($"Type cannot be a string.");
        }

        private void SetType<TType, TClass>
        ()
        where TType : _ImplementationType
        where TClass : class
        {
            _basedOn = (TType)Activator.CreateInstance
            (
                typeof(TType),
                new object[] { typeof(TClass) }
            );
        }

        public IImplementing BasedOn
        (
            Type type
        )
        {
            AssertNotString(type); 

            _basedOn = (BasedOn)Activator.CreateInstance
            (
                typeof(BasedOn), 
                new[] 
                { 
                    type.IsGenericType == true
                    ? type.GetGenericTypeDefinition()
                    : type 
                }
            );

            return this;
        }

        public IImplementing Implementing<TInterface>
        ()
        where TInterface : class
        {
            AssertNotString<TInterface>();

            SetType<Implementing, TInterface>();

            return this;
        }

        public IImplementing Only<TClass>
        ()
        where TClass : class
        {
            SetType<Only, TClass>();

            return this;
        }
    }
}