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
    public partial class TppVehicle2BodyData : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected byte vehicleTypeIndex { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected byte proxyVehicleTypeIndex { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected byte bodyImplTypeIndex { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected Fox.Core.FilePtr partsFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected byte bodyInstanceCount { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Tpp.GameCore.TppVehicle2WeaponParameter>> weaponParams { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Tpp.GameCore.TppVehicle2WeaponParameter>>();
        
        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.DynamicArray<Fox.Core.FilePtr> fovaFiles { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.FilePtr>();
        
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
        static TppVehicle2BodyData()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppVehicle2BodyData"), typeof(TppVehicle2BodyData), new Fox.Core.Data().GetClassEntityInfo(), 128, null, 3);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("vehicleTypeIndex"), Fox.Core.PropertyInfo.PropertyType.UInt8, 177, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("proxyVehicleTypeIndex"), Fox.Core.PropertyInfo.PropertyType.UInt8, 178, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("bodyImplTypeIndex"), Fox.Core.PropertyInfo.PropertyType.UInt8, 179, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("partsFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("bodyInstanceCount"), Fox.Core.PropertyInfo.PropertyType.UInt8, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("weaponParams"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Tpp.GameCore.TppVehicle2WeaponParameter), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("fovaFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppVehicle2BodyData(ulong id) : base(id) { }
		public TppVehicle2BodyData() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "vehicleTypeIndex":
                    this.vehicleTypeIndex = value.GetValueAsUInt8();
                    return;
                case "proxyVehicleTypeIndex":
                    this.proxyVehicleTypeIndex = value.GetValueAsUInt8();
                    return;
                case "bodyImplTypeIndex":
                    this.bodyImplTypeIndex = value.GetValueAsUInt8();
                    return;
                case "partsFile":
                    this.partsFile = value.GetValueAsFilePtr();
                    return;
                case "bodyInstanceCount":
                    this.bodyInstanceCount = value.GetValueAsUInt8();
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
                case "fovaFiles":
                    while(this.fovaFiles.Count <= index) { this.fovaFiles.Add(default(Fox.Core.FilePtr)); }
                    this.fovaFiles[index] = value.GetValueAsFilePtr();
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