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

namespace Fox.Ui
{
    public partial class UiGraphEntry : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.DynamicArray<Fox.Core.FilePtr<Fox.Core.File>> files = new Fox.Core.DynamicArray<Fox.Core.FilePtr<Fox.Core.File>>();
        
        public Fox.Core.DynamicArray<Fox.Core.FilePtr<Fox.Core.File>> rawFiles = new Fox.Core.DynamicArray<Fox.Core.FilePtr<Fox.Core.File>>();
        
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
        static UiGraphEntry()
        {
            classInfo = new Fox.EntityInfo("UiGraphEntry", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 96, "Ui", 1);
			
			classInfo.StaticProperties.Insert("files", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rawFiles", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public UiGraphEntry(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
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
                case "files":
                    while(this.files.Count <= index) { this.files.Add(default(Fox.Core.FilePtr<Fox.Core.File>)); }
                    this.files[index] = value.GetValueAsFilePtr();
                    return;
                case "rawFiles":
                    while(this.rawFiles.Count <= index) { this.rawFiles.Add(default(Fox.Core.FilePtr<Fox.Core.File>)); }
                    this.rawFiles[index] = value.GetValueAsFilePtr();
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