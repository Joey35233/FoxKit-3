namespace Fox.Quark
{
    public class QuarkModule : Module
    {
        public static QuarkModule Instance { get; private set; }

        public QuarkModule() : base("Fox.Quark")
        {
            Instance = this;
        }
    }
}
