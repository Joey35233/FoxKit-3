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

namespace Fox.Demo
{
    public partial class DemoFileProxy : Fox.Core.Data 
    {
        // Properties
        public CsSystem.Collections.Generic.List<Fox.Core.FilePtr<Fox.Core.File>> fmdlFiles = new CsSystem.Collections.Generic.List<Fox.Core.FilePtr<Fox.Core.File>>();
        
        public CsSystem.Collections.Generic.List<Fox.Core.FilePtr<Fox.Core.File>> partsFiles = new CsSystem.Collections.Generic.List<Fox.Core.FilePtr<Fox.Core.File>>();
        
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
        static DemoFileProxy()
        {
            classInfo = new Fox.EntityInfo("DemoFileProxy", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert("fmdlFiles", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("partsFiles", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public DemoFileProxy(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
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
                case "fmdlFiles":
                    while(this.fmdlFiles.Count <= index) { this.fmdlFiles.Add(default(Fox.Core.FilePtr<Fox.Core.File>)); }
                    this.fmdlFiles[index] = value.GetValueAsFilePtr();
                    return;
                case "partsFiles":
                    while(this.partsFiles.Count <= index) { this.partsFiles.Add(default(Fox.Core.FilePtr<Fox.Core.File>)); }
                    this.partsFiles[index] = value.GetValueAsFilePtr();
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