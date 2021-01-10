using System;

namespace Bitz.Extensions.DependencyInjection.Implementation
{
    /// <summary>
    /// 
    /// </summary>
    internal class BasedOn
    : _ImplementationType
    {
        public BasedOn
        (
            Type type
        )
        : base(type)
        { }
    }
}