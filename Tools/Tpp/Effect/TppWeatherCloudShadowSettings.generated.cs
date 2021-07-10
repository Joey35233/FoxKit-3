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
    public partial class TppWeatherCloudShadowSettings : Fox.Core.Data 
    {
        // Properties
        public bool enable { get; set; }
        
        public Path texture { get; set; }
        
        public float textureMappingRange { get; set; }
        
        public float windInfluence { get; set; }
        
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
        static TppWeatherCloudShadowSettings()
        {
            classInfo = new EntityInfo(new String("TppWeatherCloudShadowSettings"), base.GetClassEntityInfo(), 88, "TppEffect", 2);
			
			classInfo.StaticProperties.Insert(new String("enable"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 136, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("texture"), new PropertyInfo(PropertyInfo.PropertyType.Path, 120, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("textureMappingRange"), new PropertyInfo(PropertyInfo.PropertyType.Float, 132, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("windInfluence"), new PropertyInfo(PropertyInfo.PropertyType.Float, 128, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppWeatherCloudShadowSettings(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "texture":
                    this.texture = value.GetValueAsPath();
                    return;
                case "textureMappingRange":
                    this.textureMappingRange = value.GetValueAsFloat();
                    return;
                case "windInfluence":
                    this.windInfluence = value.GetValueAsFloat();
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