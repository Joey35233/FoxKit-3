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

namespace Fox.GameKit
{
    public partial class SubtitlesPackage : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.DynamicArray<Fox.Core.FilePtr<Fox.Core.File>> subtitlesPackage = new Fox.Core.DynamicArray<Fox.Core.FilePtr<Fox.Core.File>>();
        
        public Fox.Core.DynamicArray<Fox.Core.FilePtr<Fox.Core.File>> subtitlesStreamData = new Fox.Core.DynamicArray<Fox.Core.FilePtr<Fox.Core.File>>();
        
        public Fox.Core.DynamicArray<Fox.Core.Path> subtitlesStreamPath = new Fox.Core.DynamicArray<Fox.Core.Path>();
        
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
        static SubtitlesPackage()
        {
            classInfo = new Fox.EntityInfo("SubtitlesPackage", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 112, "Subtitles", 2);
			
			classInfo.StaticProperties.Insert("subtitlesPackage", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("subtitlesStreamData", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("subtitlesStreamPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public SubtitlesPackage(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
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
                case "subtitlesPackage":
                    while(this.subtitlesPackage.Count <= index) { this.subtitlesPackage.Add(default(Fox.Core.FilePtr<Fox.Core.File>)); }
                    this.subtitlesPackage[index] = value.GetValueAsFilePtr();
                    return;
                case "subtitlesStreamData":
                    while(this.subtitlesStreamData.Count <= index) { this.subtitlesStreamData.Add(default(Fox.Core.FilePtr<Fox.Core.File>)); }
                    this.subtitlesStreamData[index] = value.GetValueAsFilePtr();
                    return;
                case "subtitlesStreamPath":
                    while(this.subtitlesStreamPath.Count <= index) { this.subtitlesStreamPath.Add(default(Fox.Core.Path)); }
                    this.subtitlesStreamPath[index] = value.GetValueAsPath();
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