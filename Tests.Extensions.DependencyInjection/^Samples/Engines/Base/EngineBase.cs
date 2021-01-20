using Tests.Extensions.DependencyInjection.Samples.Contracts;

namespace Tests.Extensions.DependencyInjection.Samples.Engines.Base
{
    public abstract class EngineBase : IEngine
    {
        abstract public void OnStart();

        public void Start()
        {
            this.OnStart();
        }

        public string Make { get; set; }
    }
}