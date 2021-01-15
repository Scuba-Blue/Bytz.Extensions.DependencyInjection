namespace Tests.Extensions.DependencyInjection.Samples.Bases
{
    abstract public class EngineBase
    {
        abstract public void OnStart();

        public void Start()
        {
            this.OnStart();
        }

        public string Make { get; set; }
    }
}