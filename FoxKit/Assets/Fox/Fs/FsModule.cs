using Fox;

namespace Fox.Fs
{
    public class FsModule : Module
    {
        public static FsModule Instance { get; private set; }

        public static string UnityBasePath;
        public static string ExternalBasePath;
        public static string LooseBasePath;

        public FsModule() : base("Fox.Fs")
        {
            Instance = this;
        }
    }
}
