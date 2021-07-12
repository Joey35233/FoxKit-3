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

namespace Tpp.Collectible
{
    public partial class TppCollectionLocatorArray : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.DynamicArray<UnityEngine.Vector3> positions = new Fox.Core.DynamicArray<UnityEngine.Vector3>();
        
        public Fox.Core.DynamicArray<uint> rotations = new Fox.Core.DynamicArray<uint>();
        
        public Fox.Core.DynamicArray<uint> infos = new Fox.Core.DynamicArray<uint>();
        
        public Fox.Core.DynamicArray<ushort> segmentIndices = new Fox.Core.DynamicArray<ushort>();
        
        public Fox.Core.DynamicArray<ushort> locatorIndices = new Fox.Core.DynamicArray<ushort>();
        
        public Fox.Core.DynamicArray<ushort> locatorCounts = new Fox.Core.DynamicArray<ushort>();
        
        public Fox.Core.DynamicArray<byte> groupIds = new Fox.Core.DynamicArray<byte>();
        
        public Fox.Core.DynamicArray<ushort> segmentInfoIndices = new Fox.Core.DynamicArray<ushort>();
        
        public Fox.Core.DynamicArray<ushort> segmentInfoCounts = new Fox.Core.DynamicArray<ushort>();
        
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
        static TppCollectionLocatorArray()
        {
            classInfo = new Fox.EntityInfo("TppCollectionLocatorArray", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 208, null, 1);
			
			classInfo.StaticProperties.Insert("positions", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rotations", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("infos", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("segmentIndices", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt16, 168, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("locatorIndices", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt16, 184, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("locatorCounts", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt16, 200, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("groupIds", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 216, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("segmentInfoIndices", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt16, 232, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("segmentInfoCounts", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt16, 248, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppCollectionLocatorArray(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                case "positions":
                    while(this.positions.Count <= index) { this.positions.Add(default(UnityEngine.Vector3)); }
                    this.positions[index] = value.GetValueAsVector3();
                    return;
                case "rotations":
                    while(this.rotations.Count <= index) { this.rotations.Add(default(uint)); }
                    this.rotations[index] = value.GetValueAsUInt32();
                    return;
                case "infos":
                    while(this.infos.Count <= index) { this.infos.Add(default(uint)); }
                    this.infos[index] = value.GetValueAsUInt32();
                    return;
                case "segmentIndices":
                    while(this.segmentIndices.Count <= index) { this.segmentIndices.Add(default(ushort)); }
                    this.segmentIndices[index] = value.GetValueAsUInt16();
                    return;
                case "locatorIndices":
                    while(this.locatorIndices.Count <= index) { this.locatorIndices.Add(default(ushort)); }
                    this.locatorIndices[index] = value.GetValueAsUInt16();
                    return;
                case "locatorCounts":
                    while(this.locatorCounts.Count <= index) { this.locatorCounts.Add(default(ushort)); }
                    this.locatorCounts[index] = value.GetValueAsUInt16();
                    return;
                case "groupIds":
                    while(this.groupIds.Count <= index) { this.groupIds.Add(default(byte)); }
                    this.groupIds[index] = value.GetValueAsUInt8();
                    return;
                case "segmentInfoIndices":
                    while(this.segmentInfoIndices.Count <= index) { this.segmentInfoIndices.Add(default(ushort)); }
                    this.segmentInfoIndices[index] = value.GetValueAsUInt16();
                    return;
                case "segmentInfoCounts":
                    while(this.segmentInfoCounts.Count <= index) { this.segmentInfoCounts.Add(default(ushort)); }
                    this.segmentInfoCounts[index] = value.GetValueAsUInt16();
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