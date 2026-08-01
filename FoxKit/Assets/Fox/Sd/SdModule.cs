namespace Fox.Sd
{
    public class SdModule : Module
    {
        public static SdModule Instance { get; private set; }

        public SdModule() : base("Fox.Sd")
        {
            Instance = this;
        }
    }
}
