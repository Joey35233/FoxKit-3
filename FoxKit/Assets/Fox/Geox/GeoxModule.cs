using Fox.Geo;
using UnityEditor;

namespace Fox.Geox
{
    [InitializeOnLoad]
    public static class GeoxModule
    {
        static GeoxModule()
        {
            GeoModule.RegisterGeomHeaderDeserializationCallback(GeoGeom.GeoPrimType.Path, GeoxPath2.Deserialize);
            GeoModule.RegisterGeomHeaderDeserializationCallback(GeoGeom.GeoPrimType.AreaPath, GeoxTrapAreaPath.Deserialize);
        }
    }
}
