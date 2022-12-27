using Fox.Geo;
using UnityEditor;

namespace Fox.Geox
{
    [InitializeOnLoad]
    public static class GeoxModule
    {
        static GeoxModule()
        {
            GeoModule.RegisterGeomHeaderDeserializationCallback(GeoPrimType.Path, GeoxPath2.Deserialize);
            GeoModule.RegisterGeomHeaderDeserializationCallback(GeoPrimType.AreaPath, GeoxTrapAreaPath.Deserialize);
        }
    }
}
