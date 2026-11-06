namespace Fox
{
	public class KernelModule : Module
	{
		public static KernelModule Instance { get; private set; }

		public KernelModule() : base("Fox.Kernel")
		{
			Instance = this;
		}

		public const float NTSC_RATE = 60f * 1000f / 1001f;
	}
}