namespace Fox.As
{
    public class AsModule : Module
    {
        public static AsModule Instance { get; private set; }

        public AsModule() : base("Fox.As")
        {
            Instance = this;
        }
    }
}
