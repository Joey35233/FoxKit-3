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

namespace Fox.Geox
{
    [UnityEditor.InitializeOnLoad]
    public partial class GeoxTargetDesc : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<UnityEngine.Vector3> posArray { get; set; } = new Fox.Kernel.DynamicArray<UnityEngine.Vector3>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<UnityEngine.Vector3> scaleArray { get; set; } = new Fox.Kernel.DynamicArray<UnityEngine.Vector3>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<UnityEngine.Quaternion> rotArray { get; set; } = new Fox.Kernel.DynamicArray<UnityEngine.Quaternion>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<uint> primTypeArray { get; set; } = new Fox.Kernel.DynamicArray<uint>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<ulong> systemAttributeArray { get; set; } = new Fox.Kernel.DynamicArray<ulong>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<uint> throughValueArray { get; set; } = new Fox.Kernel.DynamicArray<uint>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<uint> flagArray { get; set; } = new Fox.Kernel.DynamicArray<uint>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String categoryTag { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Kernel.String> nameArray { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Kernel.String> attachSkeletonArray { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Kernel.String> groupArray { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<uint> objIndexForgroupTagArray { get; set; } = new Fox.Kernel.DynamicArray<uint>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.EntityLink> applicationDataLinkArray { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityLink>();
        
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
        static GeoxTargetDesc()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("GeoxTargetDesc"), typeof(GeoxTargetDesc), new Fox.Core.Data().GetClassEntityInfo(), 264, "Target", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("posArray"), Fox.Core.PropertyInfo.PropertyType.Vector3, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("scaleArray"), Fox.Core.PropertyInfo.PropertyType.Vector3, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rotArray"), Fox.Core.PropertyInfo.PropertyType.Quat, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("primTypeArray"), Fox.Core.PropertyInfo.PropertyType.UInt32, 168, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("systemAttributeArray"), Fox.Core.PropertyInfo.PropertyType.UInt64, 184, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("throughValueArray"), Fox.Core.PropertyInfo.PropertyType.UInt32, 200, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("flagArray"), Fox.Core.PropertyInfo.PropertyType.UInt32, 216, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("categoryTag"), Fox.Core.PropertyInfo.PropertyType.String, 232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("nameArray"), Fox.Core.PropertyInfo.PropertyType.String, 240, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("attachSkeletonArray"), Fox.Core.PropertyInfo.PropertyType.String, 256, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("groupArray"), Fox.Core.PropertyInfo.PropertyType.String, 272, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("objIndexForgroupTagArray"), Fox.Core.PropertyInfo.PropertyType.UInt32, 288, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("applicationDataLinkArray"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 304, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public GeoxTargetDesc(ulong id) : base(id) { }
		public GeoxTargetDesc() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "categoryTag":
                    this.categoryTag = value.GetValueAsString();
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
                case "posArray":
                    while(this.posArray.Count <= index) { this.posArray.Add(default(UnityEngine.Vector3)); }
                    this.posArray[index] = value.GetValueAsVector3();
                    return;
                case "scaleArray":
                    while(this.scaleArray.Count <= index) { this.scaleArray.Add(default(UnityEngine.Vector3)); }
                    this.scaleArray[index] = value.GetValueAsVector3();
                    return;
                case "rotArray":
                    while(this.rotArray.Count <= index) { this.rotArray.Add(default(UnityEngine.Quaternion)); }
                    this.rotArray[index] = value.GetValueAsQuat();
                    return;
                case "primTypeArray":
                    while(this.primTypeArray.Count <= index) { this.primTypeArray.Add(default(uint)); }
                    this.primTypeArray[index] = value.GetValueAsUInt32();
                    return;
                case "systemAttributeArray":
                    while(this.systemAttributeArray.Count <= index) { this.systemAttributeArray.Add(default(ulong)); }
                    this.systemAttributeArray[index] = value.GetValueAsUInt64();
                    return;
                case "throughValueArray":
                    while(this.throughValueArray.Count <= index) { this.throughValueArray.Add(default(uint)); }
                    this.throughValueArray[index] = value.GetValueAsUInt32();
                    return;
                case "flagArray":
                    while(this.flagArray.Count <= index) { this.flagArray.Add(default(uint)); }
                    this.flagArray[index] = value.GetValueAsUInt32();
                    return;
                case "nameArray":
                    while(this.nameArray.Count <= index) { this.nameArray.Add(default(Fox.Kernel.String)); }
                    this.nameArray[index] = value.GetValueAsString();
                    return;
                case "attachSkeletonArray":
                    while(this.attachSkeletonArray.Count <= index) { this.attachSkeletonArray.Add(default(Fox.Kernel.String)); }
                    this.attachSkeletonArray[index] = value.GetValueAsString();
                    return;
                case "groupArray":
                    while(this.groupArray.Count <= index) { this.groupArray.Add(default(Fox.Kernel.String)); }
                    this.groupArray[index] = value.GetValueAsString();
                    return;
                case "objIndexForgroupTagArray":
                    while(this.objIndexForgroupTagArray.Count <= index) { this.objIndexForgroupTagArray.Add(default(uint)); }
                    this.objIndexForgroupTagArray[index] = value.GetValueAsUInt32();
                    return;
                case "applicationDataLinkArray":
                    while(this.applicationDataLinkArray.Count <= index) { this.applicationDataLinkArray.Add(default(Fox.Core.EntityLink)); }
                    this.applicationDataLinkArray[index] = value.GetValueAsEntityLink();
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