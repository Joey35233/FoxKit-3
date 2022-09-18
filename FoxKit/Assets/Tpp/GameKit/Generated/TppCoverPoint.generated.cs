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
    public partial class TppCoverPoint : Fox.Tactical.GkTacticalPoint 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public bool isLeftOpen { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isRightOpen { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isUpOpen { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isUnVaultable { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isUseVip { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isUseSniper { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isBreakDisable { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isBreakEnable { get; set; }
        
        // PropertyInfo
        private static Fox.Core.EntityInfo classInfo;
        public static new Fox.Core.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override Fox.Core.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static TppCoverPoint()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppCoverPoint"), typeof(TppCoverPoint), new Fox.Tactical.GkTacticalPoint().GetClassEntityInfo(), 0, "TacticalPoint", 5);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isLeftOpen"), Fox.Core.PropertyInfo.PropertyType.Bool, 400, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isRightOpen"), Fox.Core.PropertyInfo.PropertyType.Bool, 401, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isUpOpen"), Fox.Core.PropertyInfo.PropertyType.Bool, 402, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isUnVaultable"), Fox.Core.PropertyInfo.PropertyType.Bool, 403, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isUseVip"), Fox.Core.PropertyInfo.PropertyType.Bool, 404, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isUseSniper"), Fox.Core.PropertyInfo.PropertyType.Bool, 405, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isBreakDisable"), Fox.Core.PropertyInfo.PropertyType.Bool, 406, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isBreakEnable"), Fox.Core.PropertyInfo.PropertyType.Bool, 407, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppCoverPoint(ulong id) : base(id) { }
		public TppCoverPoint() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "isLeftOpen":
                    this.isLeftOpen = value.GetValueAsBool();
                    return;
                case "isRightOpen":
                    this.isRightOpen = value.GetValueAsBool();
                    return;
                case "isUpOpen":
                    this.isUpOpen = value.GetValueAsBool();
                    return;
                case "isUnVaultable":
                    this.isUnVaultable = value.GetValueAsBool();
                    return;
                case "isUseVip":
                    this.isUseVip = value.GetValueAsBool();
                    return;
                case "isUseSniper":
                    this.isUseSniper = value.GetValueAsBool();
                    return;
                case "isBreakDisable":
                    this.isBreakDisable = value.GetValueAsBool();
                    return;
                case "isBreakEnable":
                    this.isBreakEnable = value.GetValueAsBool();
                    return;
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}