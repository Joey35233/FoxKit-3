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
    public partial class TppVehicle2AttachmentData : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected byte vehicleTypeCode { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected byte attachmentImplTypeIndex { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected Fox.Core.FilePtr attachmentFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected byte attachmentInstanceCount { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.String bodyCnpName { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.String attachmentBoneName { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Tpp.GameCore.TppVehicle2WeaponParameter>> weaponParams { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Tpp.GameCore.TppVehicle2WeaponParameter>>();
        
        // ClassInfos
        public static new bool ClassInfoInitialized = false;
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
        static TppVehicle2AttachmentData()
        {
            if (Fox.Core.Data.ClassInfoInitialized)
                classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppVehicle2AttachmentData"), typeof(TppVehicle2AttachmentData), Fox.Core.Data.ClassInfo, 120, null, 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("vehicleTypeCode"), Fox.Core.PropertyInfo.PropertyType.UInt8, 177, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("attachmentImplTypeIndex"), Fox.Core.PropertyInfo.PropertyType.UInt8, 178, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("attachmentFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("attachmentInstanceCount"), Fox.Core.PropertyInfo.PropertyType.UInt8, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("bodyCnpName"), Fox.Core.PropertyInfo.PropertyType.String, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("attachmentBoneName"), Fox.Core.PropertyInfo.PropertyType.String, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("weaponParams"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Tpp.GameCore.TppVehicle2WeaponParameter), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

            ClassInfoInitialized = true;
        }

        // Constructors
		public TppVehicle2AttachmentData(ulong id) : base(id) { }
		public TppVehicle2AttachmentData() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "vehicleTypeCode":
                    this.vehicleTypeCode = value.GetValueAsUInt8();
                    return;
                case "attachmentImplTypeIndex":
                    this.attachmentImplTypeIndex = value.GetValueAsUInt8();
                    return;
                case "attachmentFile":
                    this.attachmentFile = value.GetValueAsFilePtr();
                    return;
                case "attachmentInstanceCount":
                    this.attachmentInstanceCount = value.GetValueAsUInt8();
                    return;
                case "bodyCnpName":
                    this.bodyCnpName = value.GetValueAsString();
                    return;
                case "attachmentBoneName":
                    this.attachmentBoneName = value.GetValueAsString();
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
                case "weaponParams":
                    while(this.weaponParams.Count <= index) { this.weaponParams.Add(default(Fox.Core.EntityPtr<Tpp.GameCore.TppVehicle2WeaponParameter>)); }
                    this.weaponParams[index] = value.GetValueAsEntityPtr<Tpp.GameCore.TppVehicle2WeaponParameter>();
                    return;
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