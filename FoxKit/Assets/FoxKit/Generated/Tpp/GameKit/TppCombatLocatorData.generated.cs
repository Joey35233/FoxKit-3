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
    public partial class TppCombatLocatorData : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public float radius { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float lostSearchRadius { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isUseWaitPrioirty { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isReinforcePoint { get; set; }
        
        [field: UnityEngine.SerializeField]
        public byte memberCount { get; set; }
        
        [field: UnityEngine.SerializeField]
        public byte memberCountFront { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<Fox.Core.EntityLink> subLocators { get; set; } = new Fox.Core.DynamicArray<Fox.Core.EntityLink>();
        
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
        static TppCombatLocatorData()
        {
            classInfo = new Fox.EntityInfo("TppCombatLocatorData", typeof(TppCombatLocatorData), new Fox.Core.TransformData().GetClassEntityInfo(), 288, "Locator", 5);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("radius", Fox.Core.PropertyInfo.PropertyType.Float, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lostSearchRadius", Fox.Core.PropertyInfo.PropertyType.Float, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isUseWaitPrioirty", Fox.Core.PropertyInfo.PropertyType.Bool, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isReinforcePoint", Fox.Core.PropertyInfo.PropertyType.Bool, 313, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("memberCount", Fox.Core.PropertyInfo.PropertyType.UInt8, 314, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("memberCountFront", Fox.Core.PropertyInfo.PropertyType.UInt8, 315, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("subLocators", Fox.Core.PropertyInfo.PropertyType.EntityLink, 320, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppCombatLocatorData(ulong id) : base(id) { }
		public TppCombatLocatorData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "radius":
                    this.radius = value.GetValueAsFloat();
                    return;
                case "lostSearchRadius":
                    this.lostSearchRadius = value.GetValueAsFloat();
                    return;
                case "isUseWaitPrioirty":
                    this.isUseWaitPrioirty = value.GetValueAsBool();
                    return;
                case "isReinforcePoint":
                    this.isReinforcePoint = value.GetValueAsBool();
                    return;
                case "memberCount":
                    this.memberCount = value.GetValueAsUInt8();
                    return;
                case "memberCountFront":
                    this.memberCountFront = value.GetValueAsUInt8();
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
                case "subLocators":
                    while(this.subLocators.Count <= index) { this.subLocators.Add(default(Fox.Core.EntityLink)); }
                    this.subLocators[index] = value.GetValueAsEntityLink();
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