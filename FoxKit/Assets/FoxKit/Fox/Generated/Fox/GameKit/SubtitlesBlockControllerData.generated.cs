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
    public partial class SubtitlesBlockControllerData : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.DynamicArray<Fox.String> packageFileNames = new Fox.Core.DynamicArray<Fox.String>();
        
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
        static SubtitlesBlockControllerData()
        {
            classInfo = new Fox.EntityInfo("SubtitlesBlockControllerData", new Fox.Core.Data().GetClassEntityInfo(), 88, "Subtitles", 1);
			
			classInfo.StaticProperties.Insert("packageFileNames", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public SubtitlesBlockControllerData(ulong address, ulong id) : base(address, id) { }
		public SubtitlesBlockControllerData() : base() { }
        
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
                case "packageFileNames":
                    while(this.packageFileNames.Count <= index) { this.packageFileNames.Add(default(Fox.String)); }
                    this.packageFileNames[index] = value.GetValueAsString();
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