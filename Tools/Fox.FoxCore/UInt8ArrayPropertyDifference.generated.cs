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
    public partial class UInt8ArrayPropertyDifference : FoxCore.PropertyDifference 
    {
        // Properties
        public System.Collections.Generic.IList<byte> originalValues { get; } = new System.Collections.Generic.List<byte>();
        
        public System.Collections.Generic.IList<byte> values { get; } = new System.Collections.Generic.List<byte>();
        
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
        static UInt8ArrayPropertyDifference()
        {
            classInfo = new EntityInfo(new String("UInt8ArrayPropertyDifference"), base.GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert(new String("originalValues"), new PropertyInfo(PropertyInfo.PropertyType.UInt8, 72, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("values"), new PropertyInfo(PropertyInfo.PropertyType.UInt8, 88, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public UInt8ArrayPropertyDifference(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
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
                case "originalValues":
                    while(this.originalValues.Count <= index) { this.originalValues.Add(default(byte)); }
                    this.originalValues[index] = value.GetValueAsUInt8();
                    return;
                case "values":
                    while(this.values.Count <= index) { this.values.Add(default(byte)); }
                    this.values[index] = value.GetValueAsUInt8();
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