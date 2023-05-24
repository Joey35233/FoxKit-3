using UnityEditor;

namespace Tpp.GameKit
{
    [InitializeOnLoad]
    public static class TppGameKitModule
    {
        static TppGameKitModule()
        {
            //FoxGameKitModule.RegisterObjBrushPluginDeserializationCallback(GeoPrimType.Path, TppObjectBrushPluginSkeletonModel.Deserialize);
        }
    }
}
