namespace Fox
{
	public class CoreModule : Module
	{
		public static CoreModule Instance { get; private set; }

		public CoreModule() : base("Fox.Core")
		{
			Instance = this;
		}
	}
}