namespace Fox.Vd
{
    public class VdModule : Module
    {
        public static VdModule Instance { get; private set; }

        public VdModule() : base("Fox.Vd")
        {
            Instance = this;
        }
    }
}
