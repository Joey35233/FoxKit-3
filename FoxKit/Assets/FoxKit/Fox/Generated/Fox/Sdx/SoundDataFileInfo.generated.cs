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

namespace Fox.Sdx
{
    public partial class SoundDataFileInfo : Fox.Core.Data 
    {
        // Properties
        public CsSystem.Collections.Generic.List<string> loadBanks = new CsSystem.Collections.Generic.List<string>();
        
        public CsSystem.Collections.Generic.List<string> prepareBanks = new CsSystem.Collections.Generic.List<string>();
        
        public CsSystem.Collections.Generic.List<string> prepareEvents = new CsSystem.Collections.Generic.List<string>();
        
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
        static SoundDataFileInfo()
        {
            classInfo = new Fox.EntityInfo("SoundDataFileInfo", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 112, "Sound", 0);
			
			classInfo.StaticProperties.Insert("loadBanks", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("prepareBanks", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("prepareEvents", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public SoundDataFileInfo(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
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
                case "loadBanks":
                    while(this.loadBanks.Count <= index) { this.loadBanks.Add(default(string)); }
                    this.loadBanks[index] = value.GetValueAsString();
                    return;
                case "prepareBanks":
                    while(this.prepareBanks.Count <= index) { this.prepareBanks.Add(default(string)); }
                    this.prepareBanks[index] = value.GetValueAsString();
                    return;
                case "prepareEvents":
                    while(this.prepareEvents.Count <= index) { this.prepareEvents.Add(default(string)); }
                    this.prepareEvents[index] = value.GetValueAsString();
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