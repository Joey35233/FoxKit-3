using System.Collections.Generic;

namespace Fox.GameKit
{
    public class FoxGameKitModule : Module
    {
        public static FoxGameKitModule Instance { get; private set; }

        public static Dictionary<string, ObjectBrush> ObjectBrushRegistry = new();

        public FoxGameKitModule() : base("Fox.GameKit")
        {
            Instance = this;
        }
    }
}
