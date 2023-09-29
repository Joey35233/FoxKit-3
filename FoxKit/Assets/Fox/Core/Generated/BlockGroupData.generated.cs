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

namespace Fox.Core
{
	[UnityEditor.InitializeOnLoad]
	public partial class BlockGroupData : Fox.Core.Data
	{
		// Properties
		public float blockMemorySize { get => Get_blockMemorySize(); set { Set_blockMemorySize(value); } }
		private partial float Get_blockMemorySize();
		private partial void Set_blockMemorySize(float value);
		
		[field: UnityEngine.SerializeField]
		public BlockGroupData_ByteOrder sizeOrder { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint blockSizeInBytes { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint blockCount { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Kernel.Path> block { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.Path>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Core.EntityLink> relatedBlockGroups { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityLink>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Core.EntityLink> prerequisiteBlockGroups { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityLink>();
		
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
		static BlockGroupData()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("BlockGroupData"), typeof(BlockGroupData), Fox.Core.Data.ClassInfo, 0, null, 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("blockMemorySize"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("sizeOrder"), Fox.Core.PropertyInfo.PropertyType.Int32, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(BlockGroupData_ByteOrder), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("blockSizeInBytes"), Fox.Core.PropertyInfo.PropertyType.UInt32, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("blockCount"), Fox.Core.PropertyInfo.PropertyType.UInt32, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("block"), Fox.Core.PropertyInfo.PropertyType.Path, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("relatedBlockGroups"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("prerequisiteBlockGroups"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 168, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public BlockGroupData(ulong id) : base(id) { }
		public BlockGroupData() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "blockMemorySize":
					return new Fox.Core.Value(blockMemorySize);
				case "sizeOrder":
					return new Fox.Core.Value(sizeOrder);
				case "blockSizeInBytes":
					return new Fox.Core.Value(blockSizeInBytes);
				case "blockCount":
					return new Fox.Core.Value(blockCount);
				case "block":
					return new Fox.Core.Value(block);
				case "relatedBlockGroups":
					return new Fox.Core.Value(relatedBlockGroups);
				case "prerequisiteBlockGroups":
					return new Fox.Core.Value(prerequisiteBlockGroups);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "block":
					return new Fox.Core.Value(this.block[index]);
				case "relatedBlockGroups":
					return new Fox.Core.Value(this.relatedBlockGroups[index]);
				case "prerequisiteBlockGroups":
					return new Fox.Core.Value(this.prerequisiteBlockGroups[index]);
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key)
		{
			switch (propertyName.CString)
			{
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "blockMemorySize":
					this.blockMemorySize = value.GetValueAsFloat();
					return;
				case "sizeOrder":
					this.sizeOrder = (BlockGroupData_ByteOrder)value.GetValueAsInt32();
					return;
				case "blockSizeInBytes":
					this.blockSizeInBytes = value.GetValueAsUInt32();
					return;
				case "blockCount":
					this.blockCount = value.GetValueAsUInt32();
					return;
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "block":
					while(this.block.Count <= index) { this.block.Add(default(Fox.Kernel.Path)); }
					this.block[index] = value.GetValueAsPath();
					return;
				case "relatedBlockGroups":
					while(this.relatedBlockGroups.Count <= index) { this.relatedBlockGroups.Add(default(Fox.Core.EntityLink)); }
					this.relatedBlockGroups[index] = value.GetValueAsEntityLink();
					return;
				case "prerequisiteBlockGroups":
					while(this.prerequisiteBlockGroups.Count <= index) { this.prerequisiteBlockGroups.Add(default(Fox.Core.EntityLink)); }
					this.prerequisiteBlockGroups[index] = value.GetValueAsEntityLink();
					return;
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}