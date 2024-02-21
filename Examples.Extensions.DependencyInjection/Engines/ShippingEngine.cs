using Examples.Extensions.DependencyInjection.Engines.Abstractions;
using Examples.Extensions.DependencyInjection.Engines.Contracts;

namespace Examples.Extensions.DependencyInjection.Engines;

public class ShippingEngine
: EngineBase, IShippingEngine
{
    public override void OnStart()
    {
        throw new System.NotImplementedException();
    }
}