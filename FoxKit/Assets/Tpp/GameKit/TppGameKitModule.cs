using Fox.GameKit;
using Fox;
using UnityEditor;

namespace Tpp.GameKit
{
    [InitializeOnLoad]
    public static class TppGameKitModule
    {
        static TppGameKitModule()
        {
            FoxGameKitModule.RegisterObjBrushPluginDeserializationCallback(new StrCode32(TppObjectBrushPluginSkeletonModel.ClassInfo.Name), TppObjectBrushPluginSkeletonModel.Deserialize);
        }
    }
}
