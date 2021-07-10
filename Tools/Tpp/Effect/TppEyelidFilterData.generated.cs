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
    public partial class TppEyelidFilterData : Fox.Core.Data 
    {
        // Properties
        public bool debugDraw { get; set; }
        
        public Path texture { get; set; }
        
        public float centerX { get; set; }
        
        public float centerY { get; set; }
        
        public float rotation { get; set; }
        
        public float width { get; set; }
        
        public float openRate1 { get; set; }
        
        public float openRate2 { get; set; }
        
        public Color color1 { get; set; }
        
        public Color color2 { get; set; }
        
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
        static TppEyelidFilterData()
        {
            classInfo = new EntityInfo(new String("TppEyelidFilterData"), base.GetClassEntityInfo(), 0, null, 1);
			
			classInfo.StaticProperties.Insert(new String("debugDraw"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 120, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("texture"), new PropertyInfo(PropertyInfo.PropertyType.Path, 128, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("centerX"), new PropertyInfo(PropertyInfo.PropertyType.Float, 136, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("centerY"), new PropertyInfo(PropertyInfo.PropertyType.Float, 140, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rotation"), new PropertyInfo(PropertyInfo.PropertyType.Float, 144, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("width"), new PropertyInfo(PropertyInfo.PropertyType.Float, 148, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("openRate1"), new PropertyInfo(PropertyInfo.PropertyType.Float, 152, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("openRate2"), new PropertyInfo(PropertyInfo.PropertyType.Float, 156, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("color1"), new PropertyInfo(PropertyInfo.PropertyType.Color, 160, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("color2"), new PropertyInfo(PropertyInfo.PropertyType.Color, 176, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppEyelidFilterData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "debugDraw":
                    this.debugDraw = value.GetValueAsBool();
                    return;
                case "texture":
                    this.texture = value.GetValueAsPath();
                    return;
                case "centerX":
                    this.centerX = value.GetValueAsFloat();
                    return;
                case "centerY":
                    this.centerY = value.GetValueAsFloat();
                    return;
                case "rotation":
                    this.rotation = value.GetValueAsFloat();
                    return;
                case "width":
                    this.width = value.GetValueAsFloat();
                    return;
                case "openRate1":
                    this.openRate1 = value.GetValueAsFloat();
                    return;
                case "openRate2":
                    this.openRate2 = value.GetValueAsFloat();
                    return;
                case "color1":
                    this.color1 = value.GetValueAsColor();
                    return;
                case "color2":
                    this.color2 = value.GetValueAsColor();
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