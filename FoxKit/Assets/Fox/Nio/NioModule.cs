namespace Fox.Nio
{
    public class NioModule : Module
    {
        public static NioModule Instance { get; private set; }

        public NioModule() : base("Fox.Nio")
        {
            Instance = this;
        }
    }
}
