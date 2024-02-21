using Examples.Extensions.DependencyInjection.Contracts;

namespace Examples.Extensions.DependencyInjection.Engines.Abstractions;

public abstract class EngineBase : IEngine
{
    abstract public void OnStart();

    public void Start()
    {
        this.OnStart();
    }

    public string Make { get; set; }
}