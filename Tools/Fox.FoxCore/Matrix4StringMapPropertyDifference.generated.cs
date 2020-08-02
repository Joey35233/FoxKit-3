//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.FoxCore
{
    public partial class Matrix4StringMapPropertyDifference : FoxCore.PropertyDifference 
    {
        // Properties
        public StringMap<System.Numerics.Matrix4x4> originalValues { get; } = new StringMap<System.Numerics.Matrix4x4>();
        
        public StringMap<System.Numerics.Matrix4x4> values { get; } = new StringMap<System.Numerics.Matrix4x4>();
        
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
        static Matrix4StringMapPropertyDifference()
        {
            classInfo = new EntityInfo(new String("Matrix4StringMapPropertyDifference"), base.GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert(new String("originalValues"), new PropertyInfo(PropertyInfo.PropertyType.Matrix4, 72, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("values"), new PropertyInfo(PropertyInfo.PropertyType.Matrix4, 120, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public Matrix4StringMapPropertyDifference(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
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
                case "originalValues":
                    this.originalValues.Add(key, value.GetValueAsMatrix4());
                    return;
                case "values":
                    this.values.Add(key, value.GetValueAsMatrix4());
                    return;
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}