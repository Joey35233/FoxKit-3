namespace Fox.Cc
{
    public class CcModule : Module
    {
        public static CcModule Instance { get; private set; }

        public CcModule() : base("Fox.Cc")
        {
            Instance = this;
        }
    }
}
