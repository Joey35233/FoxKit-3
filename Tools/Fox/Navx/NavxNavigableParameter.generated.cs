//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Navx
{
    public partial class NavxNavigableParameter : Fox.Core.DataElement 
    {
        // Properties
        public String name { get; set; }
        
        public bool isDefault { get; set; }
        
        public float radius { get; set; }
        
        public float simplificationThreshold { get; set; }
        
        public float height { get; set; }
        
        public float maxClimbableAngle { get; set; }
        
        public float maxStepSize { get; set; }
        
        public float minArea { get; set; }
        
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
        static NavxNavigableParameter()
        {
            classInfo = new EntityInfo(new String("NavxNavigableParameter"), base.GetClassEntityInfo(), 60, "Navx", 9);
			
			classInfo.StaticProperties.Insert(new String("name"), new PropertyInfo(PropertyInfo.PropertyType.String, 56, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isDefault"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 64, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("radius"), new PropertyInfo(PropertyInfo.PropertyType.Float, 68, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("simplificationThreshold"), new PropertyInfo(PropertyInfo.PropertyType.Float, 72, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("height"), new PropertyInfo(PropertyInfo.PropertyType.Float, 76, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("maxClimbableAngle"), new PropertyInfo(PropertyInfo.PropertyType.Float, 80, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("maxStepSize"), new PropertyInfo(PropertyInfo.PropertyType.Float, 84, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("minArea"), new PropertyInfo(PropertyInfo.PropertyType.Float, 88, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public NavxNavigableParameter(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "name":
                    this.name = value.GetValueAsString();
                    return;
                case "isDefault":
                    this.isDefault = value.GetValueAsBool();
                    return;
                case "radius":
                    this.radius = value.GetValueAsFloat();
                    return;
                case "simplificationThreshold":
                    this.simplificationThreshold = value.GetValueAsFloat();
                    return;
                case "height":
                    this.height = value.GetValueAsFloat();
                    return;
                case "maxClimbableAngle":
                    this.maxClimbableAngle = value.GetValueAsFloat();
                    return;
                case "maxStepSize":
                    this.maxStepSize = value.GetValueAsFloat();
                    return;
                case "minArea":
                    this.minArea = value.GetValueAsFloat();
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