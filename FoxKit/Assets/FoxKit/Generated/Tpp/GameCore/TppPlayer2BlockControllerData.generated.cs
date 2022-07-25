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

namespace Tpp.GameCore
{
    [UnityEditor.InitializeOnLoad]
    public partial class TppPlayer2BlockControllerData : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public uint configuration_commonMotionBlockSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint configuration_commonMotionBlockSizePs3 { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint configuration_additiveMotionBlockCount { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint configuration_additiveMotionBlockSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint configuration_partsBlockCount { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint configuration_partsBlockSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.String instanceSettings_instancePackagePath { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint instanceSettings_instanceBlockSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.String instanceSettings_commonMotionTypeName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.DynamicArray<Fox.FoxKernel.String> instanceSettings_partsTypeNames { get; set; } = new Fox.FoxKernel.DynamicArray<Fox.FoxKernel.String>();
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.DynamicArray<Fox.FoxKernel.String> instanceSettings_partsTypeInitial { get; set; } = new Fox.FoxKernel.DynamicArray<Fox.FoxKernel.String>();
        
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
        static TppPlayer2BlockControllerData()
        {
            classInfo = new Fox.EntityInfo("TppPlayer2BlockControllerData", typeof(TppPlayer2BlockControllerData), new Fox.Core.Data().GetClassEntityInfo(), 136, null, 3);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("configuration_commonMotionBlockSize", Fox.Core.PropertyInfo.PropertyType.UInt32, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("configuration_commonMotionBlockSizePs3", Fox.Core.PropertyInfo.PropertyType.UInt32, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("configuration_additiveMotionBlockCount", Fox.Core.PropertyInfo.PropertyType.UInt32, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("configuration_additiveMotionBlockSize", Fox.Core.PropertyInfo.PropertyType.UInt32, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("configuration_partsBlockCount", Fox.Core.PropertyInfo.PropertyType.UInt32, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("configuration_partsBlockSize", Fox.Core.PropertyInfo.PropertyType.UInt32, 140, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("instanceSettings_instancePackagePath", Fox.Core.PropertyInfo.PropertyType.String, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("instanceSettings_instanceBlockSize", Fox.Core.PropertyInfo.PropertyType.UInt32, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("instanceSettings_commonMotionTypeName", Fox.Core.PropertyInfo.PropertyType.String, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("instanceSettings_partsTypeNames", Fox.Core.PropertyInfo.PropertyType.String, 168, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("instanceSettings_partsTypeInitial", Fox.Core.PropertyInfo.PropertyType.String, 184, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppPlayer2BlockControllerData(ulong id) : base(id) { }
		public TppPlayer2BlockControllerData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "configuration_commonMotionBlockSize":
                    this.configuration_commonMotionBlockSize = value.GetValueAsUInt32();
                    return;
                case "configuration_commonMotionBlockSizePs3":
                    this.configuration_commonMotionBlockSizePs3 = value.GetValueAsUInt32();
                    return;
                case "configuration_additiveMotionBlockCount":
                    this.configuration_additiveMotionBlockCount = value.GetValueAsUInt32();
                    return;
                case "configuration_additiveMotionBlockSize":
                    this.configuration_additiveMotionBlockSize = value.GetValueAsUInt32();
                    return;
                case "configuration_partsBlockCount":
                    this.configuration_partsBlockCount = value.GetValueAsUInt32();
                    return;
                case "configuration_partsBlockSize":
                    this.configuration_partsBlockSize = value.GetValueAsUInt32();
                    return;
                case "instanceSettings_instancePackagePath":
                    this.instanceSettings_instancePackagePath = value.GetValueAsString();
                    return;
                case "instanceSettings_instanceBlockSize":
                    this.instanceSettings_instanceBlockSize = value.GetValueAsUInt32();
                    return;
                case "instanceSettings_commonMotionTypeName":
                    this.instanceSettings_commonMotionTypeName = value.GetValueAsString();
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
                case "instanceSettings_partsTypeNames":
                    while(this.instanceSettings_partsTypeNames.Count <= index) { this.instanceSettings_partsTypeNames.Add(default(Fox.FoxKernel.String)); }
                    this.instanceSettings_partsTypeNames[index] = value.GetValueAsString();
                    return;
                case "instanceSettings_partsTypeInitial":
                    while(this.instanceSettings_partsTypeInitial.Count <= index) { this.instanceSettings_partsTypeInitial.Add(default(Fox.FoxKernel.String)); }
                    this.instanceSettings_partsTypeInitial[index] = value.GetValueAsString();
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