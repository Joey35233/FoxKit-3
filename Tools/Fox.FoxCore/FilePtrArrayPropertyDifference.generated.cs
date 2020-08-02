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
    public partial class FilePtrArrayPropertyDifference : FoxCore.PropertyDifference 
    {
        // Properties
        public System.Collections.Generic.IList<FilePtr<File>> originalValues { get; } = new System.Collections.Generic.List<FilePtr<File>>();
        
        public System.Collections.Generic.IList<FilePtr<File>> values { get; } = new System.Collections.Generic.List<FilePtr<File>>();
        
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
        static FilePtrArrayPropertyDifference()
        {
            classInfo = new EntityInfo(new String("FilePtrArrayPropertyDifference"), base.GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert(new String("originalValues"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 72, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("values"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 88, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public FilePtrArrayPropertyDifference(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
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
                    while(this.originalValues.Count <= index) { this.originalValues.Add(default(FilePtr<File>)); }
                    this.originalValues[index] = value.GetValueAsFilePtr();
                    return;
                case "values":
                    while(this.values.Count <= index) { this.values.Add(default(FilePtr<File>)); }
                    this.values[index] = value.GetValueAsFilePtr();
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