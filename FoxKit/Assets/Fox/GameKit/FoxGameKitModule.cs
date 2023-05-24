using UnityEditor;

namespace Fox.GameKit
{
    [InitializeOnLoad]
    public static class FoxGameKitModule
    {
        //internal static Dictionary<GeoPrimType, Func<GeomHeaderContext, TransformData>> ObjBrushPluginDeserializationMap = new();

        /*public static void RegisterObjBrushPluginDeserializationCallback(GeoPrimType type, Func<GeomHeaderContext, TransformData> deserializeFunc)
        {
            Debug.Assert(Enum.IsDefined(typeof(GeoPrimType), type));
            Debug.Assert(deserializeFunc != null);

            Debug.Assert(ObjBrushPluginDeserializationMap.TryAdd(type, deserializeFunc));
        }*/

        static FoxGameKitModule()
        {
        }
    }
}
