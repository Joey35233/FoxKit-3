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
    public partial class TppAreaVolumetricFogParam : Fox.Core.DataElement 
    {
        // Properties
        public bool enable { get; set; }
        
        public byte priority { get; set; }
        
        public Color color { get; set; }
        
        public float luminance { get; set; }
        
        public Color albedo { get; set; }
        
        public float density { get; set; }
        
        public float nearDistance { get; set; }
        
        public float falloff { get; set; }
        
        public bool inverseFalloff { get; set; }
        
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
        static TppAreaVolumetricFogParam()
        {
            classInfo = new EntityInfo(new String("TppAreaVolumetricFogParam"), base.GetClassEntityInfo(), 0, null, 1);
			
			classInfo.StaticProperties.Insert(new String("enable"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 146, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("priority"), new PropertyInfo(PropertyInfo.PropertyType.UInt8, 144, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("color"), new PropertyInfo(PropertyInfo.PropertyType.Color, 64, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("luminance"), new PropertyInfo(PropertyInfo.PropertyType.Float, 104, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("albedo"), new PropertyInfo(PropertyInfo.PropertyType.Color, 80, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("density"), new PropertyInfo(PropertyInfo.PropertyType.Float, 96, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("nearDistance"), new PropertyInfo(PropertyInfo.PropertyType.Float, 108, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("falloff"), new PropertyInfo(PropertyInfo.PropertyType.Float, 100, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("inverseFalloff"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 145, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppAreaVolumetricFogParam(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "priority":
                    this.priority = value.GetValueAsUInt8();
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
                case "inverseFalloff":
                    this.inverseFalloff = value.GetValueAsBool();
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