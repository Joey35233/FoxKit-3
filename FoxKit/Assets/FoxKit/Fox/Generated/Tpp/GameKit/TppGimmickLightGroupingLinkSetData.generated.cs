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

namespace Tpp.GameKit
{
    public partial class TppGimmickLightGroupingLinkSetData : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.DynamicArray<Fox.Core.EntityLink> ownerGimmickList = new Fox.Core.DynamicArray<Fox.Core.EntityLink>();
        
        public Fox.Core.DynamicArray<Fox.String> gimmickNameList = new Fox.Core.DynamicArray<Fox.String>();
        
        public Fox.Core.EntityLink light;
        
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
        static TppGimmickLightGroupingLinkSetData()
        {
            classInfo = new Fox.EntityInfo("TppGimmickLightGroupingLinkSetData", new Fox.Core.Data().GetClassEntityInfo(), 144, "Gimmick", 0);
			
			classInfo.StaticProperties.Insert("ownerGimmickList", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("gimmickNameList", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("light", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppGimmickLightGroupingLinkSetData(ulong address, ulong id) : base(address, id) { }
		public TppGimmickLightGroupingLinkSetData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "light":
                    this.light = value.GetValueAsEntityLink();
                    return;
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                case "ownerGimmickList":
                    while(this.ownerGimmickList.Count <= index) { this.ownerGimmickList.Add(default(Fox.Core.EntityLink)); }
                    this.ownerGimmickList[index] = value.GetValueAsEntityLink();
                    return;
                case "gimmickNameList":
                    while(this.gimmickNameList.Count <= index) { this.gimmickNameList.Add(default(Fox.String)); }
                    this.gimmickNameList[index] = value.GetValueAsString();
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