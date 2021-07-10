//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Grx
{
    public partial class ColorCorrectionData : Fox.Core.Data 
    {
        // Properties
        public Path textureLUT { get; set; }
        
        public float startSlope { get; set; }
        
        public float endSlope { get; set; }
        
        public bool showBaseLUT { get; set; }
        
        public bool showFilterLUT { get; set; }
        
        public Color colorScale { get; set; }
        
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
        static ColorCorrectionData()
        {
            classInfo = new EntityInfo(new String("ColorCorrectionData"), base.GetClassEntityInfo(), 112, "Config", 5);
			
			classInfo.StaticProperties.Insert(new String("textureLUT"), new PropertyInfo(PropertyInfo.PropertyType.Path, 152, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("startSlope"), new PropertyInfo(PropertyInfo.PropertyType.Float, 144, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("endSlope"), new PropertyInfo(PropertyInfo.PropertyType.Float, 148, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("showBaseLUT"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 160, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("showFilterLUT"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 161, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("colorScale"), new PropertyInfo(PropertyInfo.PropertyType.Color, 128, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public ColorCorrectionData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "textureLUT":
                    this.textureLUT = value.GetValueAsPath();
                    return;
                case "startSlope":
                    this.startSlope = value.GetValueAsFloat();
                    return;
                case "endSlope":
                    this.endSlope = value.GetValueAsFloat();
                    return;
                case "showBaseLUT":
                    this.showBaseLUT = value.GetValueAsBool();
                    return;
                case "showFilterLUT":
                    this.showFilterLUT = value.GetValueAsBool();
                    return;
                case "colorScale":
                    this.colorScale = value.GetValueAsColor();
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