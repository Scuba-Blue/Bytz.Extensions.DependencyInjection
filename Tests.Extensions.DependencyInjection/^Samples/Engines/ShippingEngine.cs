using Tests.Extensions.DependencyInjection.Samples.Engines.Base;
using Tests.Extensions.DependencyInjection.Samples.Engines.Contracts;

namespace Tests.Extensions.DependencyInjection.Samples.Engines
{
    public class ShippingEngine : EngineBase, IShippingEngine
    {
        public override void OnStart()
        {
            throw new System.NotImplementedException();
        }
    }
}