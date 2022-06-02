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
    public partial class GeoxTargetDesc : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.DynamicArray<UnityEngine.Vector3> posArray = new Fox.Core.DynamicArray<UnityEngine.Vector3>();
        
        public Fox.Core.DynamicArray<UnityEngine.Vector3> scaleArray = new Fox.Core.DynamicArray<UnityEngine.Vector3>();
        
        public Fox.Core.DynamicArray<UnityEngine.Quaternion> rotArray = new Fox.Core.DynamicArray<UnityEngine.Quaternion>();
        
        public Fox.Core.DynamicArray<uint> primTypeArray = new Fox.Core.DynamicArray<uint>();
        
        public Fox.Core.DynamicArray<ulong> systemAttributeArray = new Fox.Core.DynamicArray<ulong>();
        
        public Fox.Core.DynamicArray<uint> throughValueArray = new Fox.Core.DynamicArray<uint>();
        
        public Fox.Core.DynamicArray<uint> flagArray = new Fox.Core.DynamicArray<uint>();
        
        public Fox.String categoryTag;
        
        public Fox.Core.DynamicArray<Fox.String> nameArray = new Fox.Core.DynamicArray<Fox.String>();
        
        public Fox.Core.DynamicArray<Fox.String> attachSkeletonArray = new Fox.Core.DynamicArray<Fox.String>();
        
        public Fox.Core.DynamicArray<Fox.String> groupArray = new Fox.Core.DynamicArray<Fox.String>();
        
        public Fox.Core.DynamicArray<uint> objIndexForgroupTagArray = new Fox.Core.DynamicArray<uint>();
        
        public Fox.Core.DynamicArray<Fox.Core.EntityLink> applicationDataLinkArray = new Fox.Core.DynamicArray<Fox.Core.EntityLink>();
        
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
        static GeoxTargetDesc()
        {
            classInfo = new Fox.EntityInfo("GeoxTargetDesc", new Fox.Core.Data().GetClassEntityInfo(), 264, "Target", 0);
			
			classInfo.StaticProperties.Insert("posArray", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("scaleArray", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rotArray", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Quat, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("primTypeArray", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 168, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("systemAttributeArray", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt64, 184, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("throughValueArray", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 200, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("flagArray", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 216, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("categoryTag", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("nameArray", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 240, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("attachSkeletonArray", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 256, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("groupArray", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 272, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("objIndexForgroupTagArray", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 288, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("applicationDataLinkArray", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 304, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public GeoxTargetDesc(ulong address, ulong id) : base(address, id) { }
		public GeoxTargetDesc() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "categoryTag":
                    this.categoryTag = value.GetValueAsString();
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
                    while(this.nameArray.Count <= index) { this.nameArray.Add(default(Fox.String)); }
                    this.nameArray[index] = value.GetValueAsString();
                    return;
                case "attachSkeletonArray":
                    while(this.attachSkeletonArray.Count <= index) { this.attachSkeletonArray.Add(default(Fox.String)); }
                    this.attachSkeletonArray[index] = value.GetValueAsString();
                    return;
                case "groupArray":
                    while(this.groupArray.Count <= index) { this.groupArray.Add(default(Fox.String)); }
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