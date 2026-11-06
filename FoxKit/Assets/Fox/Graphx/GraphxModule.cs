namespace Fox.Graphx
{
	public class GraphxModule : Module
	{
		public static GraphxModule Instance { get; private set; }

		public GraphxModule() : base("Fox.Graphx")
		{
			Instance = this;
		}
	}
}