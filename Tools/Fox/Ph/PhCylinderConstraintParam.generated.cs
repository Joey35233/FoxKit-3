//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Ph
{
    public partial class PhCylinderConstraintParam : Fox.Ph.PhConstraintParam 
    {
        // Properties
        public System.Numerics.Vector3 axis { get; set; }
        
        public float radius { get; set; }
        
        public float heightMin { get; set; }
        
        public float heightMax { get; set; }
        
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
        static PhCylinderConstraintParam()
        {
            classInfo = new EntityInfo(new String("PhCylinderConstraintParam"), base.GetClassEntityInfo(), 0, "Ph", 0);
			
			classInfo.StaticProperties.Insert(new String("axis"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 64, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("radius"), new PropertyInfo(PropertyInfo.PropertyType.Float, 80, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("heightMin"), new PropertyInfo(PropertyInfo.PropertyType.Float, 84, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("heightMax"), new PropertyInfo(PropertyInfo.PropertyType.Float, 88, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public PhCylinderConstraintParam(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "axis":
                    this.axis = value.GetValueAsVector3();
                    return;
                case "radius":
                    this.radius = value.GetValueAsFloat();
                    return;
                case "heightMin":
                    this.heightMin = value.GetValueAsFloat();
                    return;
                case "heightMax":
                    this.heightMax = value.GetValueAsFloat();
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