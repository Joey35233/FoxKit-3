namespace Fox.Uix
{
    public class UixModule : Module
    {
        public static UixModule Instance { get; private set; }

        public UixModule() : base("Fox.Uix")
        {
            Instance = this;
        }
    }
}
