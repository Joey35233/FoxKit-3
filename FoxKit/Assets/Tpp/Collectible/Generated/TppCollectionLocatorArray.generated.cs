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
	[UnityEditor.InitializeOnLoad]
	public partial class TppCollectionLocatorArray : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.DynamicArray<UnityEngine.Vector3> positions { get; set; } = new Fox.Kernel.DynamicArray<UnityEngine.Vector3>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.DynamicArray<uint> rotations { get; set; } = new Fox.Kernel.DynamicArray<uint>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.DynamicArray<uint> infos { get; set; } = new Fox.Kernel.DynamicArray<uint>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.DynamicArray<ushort> segmentIndices { get; set; } = new Fox.Kernel.DynamicArray<ushort>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.DynamicArray<ushort> locatorIndices { get; set; } = new Fox.Kernel.DynamicArray<ushort>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.DynamicArray<ushort> locatorCounts { get; set; } = new Fox.Kernel.DynamicArray<ushort>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.DynamicArray<byte> groupIds { get; set; } = new Fox.Kernel.DynamicArray<byte>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.DynamicArray<ushort> segmentInfoIndices { get; set; } = new Fox.Kernel.DynamicArray<ushort>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.DynamicArray<ushort> segmentInfoCounts { get; set; } = new Fox.Kernel.DynamicArray<ushort>();
		
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
		static TppCollectionLocatorArray()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppCollectionLocatorArray"), typeof(TppCollectionLocatorArray), Fox.Core.Data.ClassInfo, 208, null, 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("positions"), Fox.Core.PropertyInfo.PropertyType.Vector3, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rotations"), Fox.Core.PropertyInfo.PropertyType.UInt32, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("infos"), Fox.Core.PropertyInfo.PropertyType.UInt32, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("segmentIndices"), Fox.Core.PropertyInfo.PropertyType.UInt16, 168, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("locatorIndices"), Fox.Core.PropertyInfo.PropertyType.UInt16, 184, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("locatorCounts"), Fox.Core.PropertyInfo.PropertyType.UInt16, 200, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("groupIds"), Fox.Core.PropertyInfo.PropertyType.UInt8, 216, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("segmentInfoIndices"), Fox.Core.PropertyInfo.PropertyType.UInt16, 232, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("segmentInfoCounts"), Fox.Core.PropertyInfo.PropertyType.UInt16, 248, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public TppCollectionLocatorArray(ulong id) : base(id) { }
		public TppCollectionLocatorArray() : base() { }

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
		{
			switch(propertyName.CString)
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