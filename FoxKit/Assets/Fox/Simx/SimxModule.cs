namespace Fox.Simx
{
    public class SimxModule : Module
    {
        public static SimxModule Instance { get; private set; }

        public SimxModule() : base("Fox.Simx")
        {
            Instance = this;
        }
    }
}
