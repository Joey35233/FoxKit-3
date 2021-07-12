//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using CsSystem = System;
using Fox;

namespace Fox.Core
{
    public partial class FilePtrArrayPropertyDifference : Fox.Core.PropertyDifference 
    {
        // Properties
        public Fox.Core.DynamicArray<Fox.Core.FilePtr<Fox.Core.File>> originalValues = new Fox.Core.DynamicArray<Fox.Core.FilePtr<Fox.Core.File>>();
        
        public Fox.Core.DynamicArray<Fox.Core.FilePtr<Fox.Core.File>> values = new Fox.Core.DynamicArray<Fox.Core.FilePtr<Fox.Core.File>>();
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public  override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static FilePtrArrayPropertyDifference()
        {
            classInfo = new Fox.EntityInfo("FilePtrArrayPropertyDifference", new Fox.Core.PropertyDifference(0, 0, 0).GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert("originalValues", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 72, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("values", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 88, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public FilePtrArrayPropertyDifference(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                case "originalValues":
                    while(this.originalValues.Count <= index) { this.originalValues.Add(default(Fox.Core.FilePtr<Fox.Core.File>)); }
                    this.originalValues[index] = value.GetValueAsFilePtr();
                    return;
                case "values":
                    while(this.values.Count <= index) { this.values.Add(default(Fox.Core.FilePtr<Fox.Core.File>)); }
                    this.values[index] = value.GetValueAsFilePtr();
                    return;
                default:
					
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}