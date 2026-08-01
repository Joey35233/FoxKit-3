namespace Fox.Graph
{
    public class GraphModule : Module
    {
        public static GraphModule Instance { get; private set; }

        public GraphModule() : base("Fox.Graph")
        {
            Instance = this;
        }
    }
}
