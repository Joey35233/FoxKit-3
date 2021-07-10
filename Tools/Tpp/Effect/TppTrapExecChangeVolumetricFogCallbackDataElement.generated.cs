//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Tpp.Effect
{
    public partial class TppTrapExecChangeVolumetricFogCallbackDataElement : Fox.Geo.GeoTrapModuleCallbackDataElement 
    {
        // Properties
        public bool ignoreYAxis { get; set; }
        
        public bool ignoreZAxis { get; set; }
        
        public float interpRange { get; set; }
        
        public bool restoreFogParameters { get; set; }
        
        public Color color { get; set; }
        
        public float luminance { get; set; }
        
        public Color albedo { get; set; }
        
        public float density { get; set; }
        
        public float nearDistance { get; set; }
        
        public float falloff { get; set; }
        
        public bool changeColor { get; set; }
        
        public bool changeAlbedo { get; set; }
        
        public bool changeLuminance { get; set; }
        
        public bool changeDensity { get; set; }
        
        public bool changeNearDistance { get; set; }
        
        public bool changeFalloff { get; set; }
        
        public EntityLink areaVolumetricFog { get; set; }
        
        // PropertyInfo
        private static EntityInfo classInfo;
        public static new EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static TppTrapExecChangeVolumetricFogCallbackDataElement()
        {
            classInfo = new EntityInfo(new String("TppTrapExecChangeVolumetricFogCallbackDataElement"), base.GetClassEntityInfo(), 0, null, 4);
			
			classInfo.StaticProperties.Insert(new String("ignoreYAxis"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 164, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("ignoreZAxis"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 165, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("interpRange"), new PropertyInfo(PropertyInfo.PropertyType.Float, 160, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("restoreFogParameters"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 172, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("color"), new PropertyInfo(PropertyInfo.PropertyType.Color, 112, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("luminance"), new PropertyInfo(PropertyInfo.PropertyType.Float, 144, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("albedo"), new PropertyInfo(PropertyInfo.PropertyType.Color, 128, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("density"), new PropertyInfo(PropertyInfo.PropertyType.Float, 148, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("nearDistance"), new PropertyInfo(PropertyInfo.PropertyType.Float, 152, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("falloff"), new PropertyInfo(PropertyInfo.PropertyType.Float, 156, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("changeColor"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 166, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("changeAlbedo"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 167, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("changeLuminance"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 168, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("changeDensity"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 169, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("changeNearDistance"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 170, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("changeFalloff"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 171, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("areaVolumetricFog"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 64, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppTrapExecChangeVolumetricFogCallbackDataElement(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "ignoreYAxis":
                    this.ignoreYAxis = value.GetValueAsBool();
                    return;
                case "ignoreZAxis":
                    this.ignoreZAxis = value.GetValueAsBool();
                    return;
                case "interpRange":
                    this.interpRange = value.GetValueAsFloat();
                    return;
                case "restoreFogParameters":
                    this.restoreFogParameters = value.GetValueAsBool();
                    return;
                case "color":
                    this.color = value.GetValueAsColor();
                    return;
                case "luminance":
                    this.luminance = value.GetValueAsFloat();
                    return;
                case "albedo":
                    this.albedo = value.GetValueAsColor();
                    return;
                case "density":
                    this.density = value.GetValueAsFloat();
                    return;
                case "nearDistance":
                    this.nearDistance = value.GetValueAsFloat();
                    return;
                case "falloff":
                    this.falloff = value.GetValueAsFloat();
                    return;
                case "changeColor":
                    this.changeColor = value.GetValueAsBool();
                    return;
                case "changeAlbedo":
                    this.changeAlbedo = value.GetValueAsBool();
                    return;
                case "changeLuminance":
                    this.changeLuminance = value.GetValueAsBool();
                    return;
                case "changeDensity":
                    this.changeDensity = value.GetValueAsBool();
                    return;
                case "changeNearDistance":
                    this.changeNearDistance = value.GetValueAsBool();
                    return;
                case "changeFalloff":
                    this.changeFalloff = value.GetValueAsBool();
                    return;
                case "areaVolumetricFog":
                    this.areaVolumetricFog = value.GetValueAsEntityLink();
                    return;
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(String propertyName, ushort index, Value value)
        {
            switch(propertyName.CString())
            {
                default:
					
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(String propertyName, String key, Value value)
        {
            switch(propertyName.CString())
            {
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}