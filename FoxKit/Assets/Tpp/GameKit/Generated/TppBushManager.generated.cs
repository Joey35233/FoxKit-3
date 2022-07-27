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
    public partial class TppBushManager : Fox.Core.Entity 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected uint flag { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected uint totalBlockNum { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected uint totalUnitNum { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected uint maxBlockNum { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected uint maxUnitNum { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected uint maxTotalBlockNum { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected uint maxTotalUnitNum { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float realizeRange { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float windShakeRange { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected UnityEngine.Vector3 cameraPos { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.DynamicArray<Fox.Kernel.String> existMaterials { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
        
        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.DynamicArray<Fox.Kernel.String> noiseSeType { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
        
        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.StringMap<Fox.Kernel.String> noiseSeEventNames { get; set; } = new Fox.Kernel.StringMap<Fox.Kernel.String>();
        
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
        static TppBushManager()
        {
            classInfo = new Fox.Core.EntityInfo("TppBushManager", typeof(TppBushManager), new Fox.Core.Entity().GetClassEntityInfo(), 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("flag", Fox.Core.PropertyInfo.PropertyType.UInt32, 48, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("totalBlockNum", Fox.Core.PropertyInfo.PropertyType.UInt32, 52, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("totalUnitNum", Fox.Core.PropertyInfo.PropertyType.UInt32, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("maxBlockNum", Fox.Core.PropertyInfo.PropertyType.UInt32, 60, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("maxUnitNum", Fox.Core.PropertyInfo.PropertyType.UInt32, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("maxTotalBlockNum", Fox.Core.PropertyInfo.PropertyType.UInt32, 68, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("maxTotalUnitNum", Fox.Core.PropertyInfo.PropertyType.UInt32, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("realizeRange", Fox.Core.PropertyInfo.PropertyType.Float, 76, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("windShakeRange", Fox.Core.PropertyInfo.PropertyType.Float, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("cameraPos", Fox.Core.PropertyInfo.PropertyType.Vector3, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("existMaterials", Fox.Core.PropertyInfo.PropertyType.String, 536, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("noiseSeType", Fox.Core.PropertyInfo.PropertyType.String, 552, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("noiseSeEventNames", Fox.Core.PropertyInfo.PropertyType.String, 568, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppBushManager(ulong id) : base(id) { }
		public TppBushManager() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "flag":
                    this.flag = value.GetValueAsUInt32();
                    return;
                case "totalBlockNum":
                    this.totalBlockNum = value.GetValueAsUInt32();
                    return;
                case "totalUnitNum":
                    this.totalUnitNum = value.GetValueAsUInt32();
                    return;
                case "maxBlockNum":
                    this.maxBlockNum = value.GetValueAsUInt32();
                    return;
                case "maxUnitNum":
                    this.maxUnitNum = value.GetValueAsUInt32();
                    return;
                case "maxTotalBlockNum":
                    this.maxTotalBlockNum = value.GetValueAsUInt32();
                    return;
                case "maxTotalUnitNum":
                    this.maxTotalUnitNum = value.GetValueAsUInt32();
                    return;
                case "realizeRange":
                    this.realizeRange = value.GetValueAsFloat();
                    return;
                case "windShakeRange":
                    this.windShakeRange = value.GetValueAsFloat();
                    return;
                case "cameraPos":
                    this.cameraPos = value.GetValueAsVector3();
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
                case "existMaterials":
                    while(this.existMaterials.Count <= index) { this.existMaterials.Add(default(Fox.Kernel.String)); }
                    this.existMaterials[index] = value.GetValueAsString();
                    return;
                case "noiseSeType":
                    while(this.noiseSeType.Count <= index) { this.noiseSeType.Add(default(Fox.Kernel.String)); }
                    this.noiseSeType[index] = value.GetValueAsString();
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
                case "noiseSeEventNames":
                    this.noiseSeEventNames.Insert(key, value.GetValueAsString());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}