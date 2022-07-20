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
    [UnityEditor.InitializeOnLoad]
    public partial class TppGimmickLightLinkSetData : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public uint numLightGimmick { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink ownerGimmick { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<Fox.Core.EntityLink> lightList { get; set; } = new Fox.Core.DynamicArray<Fox.Core.EntityLink>();
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static TppGimmickLightLinkSetData()
        {
            classInfo = new Fox.EntityInfo("TppGimmickLightLinkSetData", typeof(TppGimmickLightLinkSetData), new Fox.Core.Data().GetClassEntityInfo(), 136, "Gimmick", 1);
			classInfo.StaticProperties.Insert("numLightGimmick", new Fox.Core.PropertyInfo("numLightGimmick", Fox.Core.PropertyInfo.PropertyType.UInt32, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("ownerGimmick", new Fox.Core.PropertyInfo("ownerGimmick", Fox.Core.PropertyInfo.PropertyType.EntityLink, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lightList", new Fox.Core.PropertyInfo("lightList", Fox.Core.PropertyInfo.PropertyType.EntityLink, 168, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppGimmickLightLinkSetData(ulong id) : base(id) { }
		public TppGimmickLightLinkSetData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "numLightGimmick":
                    this.numLightGimmick = value.GetValueAsUInt32();
                    return;
                case "ownerGimmick":
                    this.ownerGimmick = value.GetValueAsEntityLink();
                    return;
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "lightList":
                    while(this.lightList.Count <= index) { this.lightList.Add(default(Fox.Core.EntityLink)); }
                    this.lightList[index] = value.GetValueAsEntityLink();
                    return;
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
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