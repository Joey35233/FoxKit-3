using Fox;
using Fox.Geo;

namespace Tpp.GameCore
{
    public class GameCoreModule : Module
    {
        public static GameCoreModule Instance { get; private set; }

        public GameCoreModule() : base("Tpp.GameCore")
        {
            Instance = this;
            AddDependencyModule("Fox.Geo");
        }

        public override void Init()
        {
            GeoModule.RegisterRailNote(1, "leftWidth");
            GeoModule.RegisterRailNote(2, "rightWidth");
        }
    }
}
