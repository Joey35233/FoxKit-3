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
    public partial class TppStar : Fox.Core.TransformData 
    {
        // Properties
        public bool enable { get; set; }
        
        public Color color { get; set; }
        
        public float intensity { get; set; }
        
        public float direction { get; set; }
        
        public String bgModelName { get; set; }
        
        public System.Collections.Generic.IList<String> modelNameArray { get; } = new System.Collections.Generic.List<String>();
        
        public System.Collections.Generic.IList<String> nameArray { get; } = new System.Collections.Generic.List<String>();
        
        public System.Collections.Generic.IList<float> latitudeArray { get; } = new System.Collections.Generic.List<float>();
        
        public System.Collections.Generic.IList<float> longitudeArray { get; } = new System.Collections.Generic.List<float>();
        
        public System.Collections.Generic.IList<float> scaleArray { get; } = new System.Collections.Generic.List<float>();
        
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
        static TppStar()
        {
            classInfo = new EntityInfo(new String("TppStar"), base.GetClassEntityInfo(), 384, "TppEffect", 1);
			
			classInfo.StaticProperties.Insert(new String("enable"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 424, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("color"), new PropertyInfo(PropertyInfo.PropertyType.Color, 400, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("intensity"), new PropertyInfo(PropertyInfo.PropertyType.Float, 416, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("direction"), new PropertyInfo(PropertyInfo.PropertyType.Float, 420, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("bgModelName"), new PropertyInfo(PropertyInfo.PropertyType.String, 384, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("modelNameArray"), new PropertyInfo(PropertyInfo.PropertyType.String, 320, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("nameArray"), new PropertyInfo(PropertyInfo.PropertyType.String, 304, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("latitudeArray"), new PropertyInfo(PropertyInfo.PropertyType.Float, 336, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("longitudeArray"), new PropertyInfo(PropertyInfo.PropertyType.Float, 352, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("scaleArray"), new PropertyInfo(PropertyInfo.PropertyType.Float, 368, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppStar(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "color":
                    this.color = value.GetValueAsColor();
                    return;
                case "intensity":
                    this.intensity = value.GetValueAsFloat();
                    return;
                case "direction":
                    this.direction = value.GetValueAsFloat();
                    return;
                case "bgModelName":
                    this.bgModelName = value.GetValueAsString();
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
                case "modelNameArray":
                    while(this.modelNameArray.Count <= index) { this.modelNameArray.Add(default(String)); }
                    this.modelNameArray[index] = value.GetValueAsString();
                    return;
                case "nameArray":
                    while(this.nameArray.Count <= index) { this.nameArray.Add(default(String)); }
                    this.nameArray[index] = value.GetValueAsString();
                    return;
                case "latitudeArray":
                    while(this.latitudeArray.Count <= index) { this.latitudeArray.Add(default(float)); }
                    this.latitudeArray[index] = value.GetValueAsFloat();
                    return;
                case "longitudeArray":
                    while(this.longitudeArray.Count <= index) { this.longitudeArray.Add(default(float)); }
                    this.longitudeArray[index] = value.GetValueAsFloat();
                    return;
                case "scaleArray":
                    while(this.scaleArray.Count <= index) { this.scaleArray.Add(default(float)); }
                    this.scaleArray[index] = value.GetValueAsFloat();
                    return;
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