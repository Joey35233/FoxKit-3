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
    public partial class PhShoulderConstraint : Fox.Ph.PhConstraint 
    {
        // Properties
        public bool limitedFlag { get; set; }
        
        public System.Numerics.Vector3 refA { get; set; }
        
        public System.Numerics.Vector3 refB { get; set; }
        
        public float limit { get; set; }
        
        public bool limitedFlag1 { get; set; }
        
        public System.Numerics.Vector3 refA1 { get; set; }
        
        public System.Numerics.Vector3 refB1 { get; set; }
        
        public float limit1 { get; set; }
        
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
        static PhShoulderConstraint()
        {
            classInfo = new EntityInfo(new String("PhShoulderConstraint"), base.GetClassEntityInfo(), 0, "Ph", 0);
			
			classInfo.StaticProperties.Insert(new String("limitedFlag"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("refA"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("refB"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("limit"), new PropertyInfo(PropertyInfo.PropertyType.Float, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("limitedFlag1"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("refA1"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("refB1"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("limit1"), new PropertyInfo(PropertyInfo.PropertyType.Float, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public PhShoulderConstraint(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "limitedFlag":
                    this.limitedFlag = value.GetValueAsBool();
                    return;
                case "refA":
                    this.refA = value.GetValueAsVector3();
                    return;
                case "refB":
                    this.refB = value.GetValueAsVector3();
                    return;
                case "limit":
                    this.limit = value.GetValueAsFloat();
                    return;
                case "limitedFlag1":
                    this.limitedFlag1 = value.GetValueAsBool();
                    return;
                case "refA1":
                    this.refA1 = value.GetValueAsVector3();
                    return;
                case "refB1":
                    this.refB1 = value.GetValueAsVector3();
                    return;
                case "limit1":
                    this.limit1 = value.GetValueAsFloat();
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