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

namespace Fox.Fx
{
	[UnityEditor.InitializeOnLoad]
	public partial class FxLocatorData : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.String variationName { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.String effectInstanceName { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool enableUserRandomSeed { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint userRandomSeed { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool shapeKeep { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool createOnInitialize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool blockMemoryAllocation { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr vfxFile { get; set; }
		
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
		static FxLocatorData()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("FxLocatorData"), typeof(FxLocatorData), Fox.Core.TransformData.ClassInfo, 304, "Fx", 4);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("variationName"), Fox.Core.PropertyInfo.PropertyType.String, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("effectInstanceName"), Fox.Core.PropertyInfo.PropertyType.String, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("enableUserRandomSeed"), Fox.Core.PropertyInfo.PropertyType.Bool, 348, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("userRandomSeed"), Fox.Core.PropertyInfo.PropertyType.UInt32, 344, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shapeKeep"), Fox.Core.PropertyInfo.PropertyType.Bool, 349, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("createOnInitialize"), Fox.Core.PropertyInfo.PropertyType.Bool, 350, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("blockMemoryAllocation"), Fox.Core.PropertyInfo.PropertyType.Bool, 351, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("vfxFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public FxLocatorData(ulong id) : base(id) { }
		public FxLocatorData() : base() { }

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				case "variationName":
					this.variationName = value.GetValueAsString();
					return;
				case "effectInstanceName":
					this.effectInstanceName = value.GetValueAsString();
					return;
				case "enableUserRandomSeed":
					this.enableUserRandomSeed = value.GetValueAsBool();
					return;
				case "userRandomSeed":
					this.userRandomSeed = value.GetValueAsUInt32();
					return;
				case "shapeKeep":
					this.shapeKeep = value.GetValueAsBool();
					return;
				case "createOnInitialize":
					this.createOnInitialize = value.GetValueAsBool();
					return;
				case "blockMemoryAllocation":
					this.blockMemoryAllocation = value.GetValueAsBool();
					return;
				case "vfxFile":
					this.vfxFile = value.GetValueAsFilePtr();
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