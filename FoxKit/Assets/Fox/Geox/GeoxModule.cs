using Fox.Geo;

namespace Fox.Geox
{
    public class GeoxModule : Module
    {
        public static GeoxModule Instance { get; private set; }

        public GeoxModule() : base("Fox.Geox")
        {
            Instance = this;
            AddDependencyModule("Fox.Geo");
        }

        public override void Init()
        {
            GeoModule.RegisterGeomHeaderDeserializationCallback(GeoPrimType.Path, GeoxPath2.Deserialize);
            GeoModule.RegisterGeomHeaderDeserializationCallback(GeoPrimType.AreaPath, GeoxTrapAreaPath.Deserialize);
        }
    }
}
