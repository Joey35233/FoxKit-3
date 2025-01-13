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
		public string instanceSettings_instancePackagePath { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint instanceSettings_instanceBlockSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string instanceSettings_commonMotionTypeName { get; set; }
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<string> instanceSettings_partsTypeNames { get; private set; } = new CsSystem.Collections.Generic.List<string>();
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<string> instanceSettings_partsTypeInitial { get; private set; } = new CsSystem.Collections.Generic.List<string>();
		
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
		static TppPlayer2BlockControllerData()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppPlayer2BlockControllerData", typeof(TppPlayer2BlockControllerData), Fox.Core.Data.ClassInfo, 136, null, 3);
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

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "configuration_commonMotionBlockSize":
					return new Fox.Core.Value(configuration_commonMotionBlockSize);
				case "configuration_commonMotionBlockSizePs3":
					return new Fox.Core.Value(configuration_commonMotionBlockSizePs3);
				case "configuration_additiveMotionBlockCount":
					return new Fox.Core.Value(configuration_additiveMotionBlockCount);
				case "configuration_additiveMotionBlockSize":
					return new Fox.Core.Value(configuration_additiveMotionBlockSize);
				case "configuration_partsBlockCount":
					return new Fox.Core.Value(configuration_partsBlockCount);
				case "configuration_partsBlockSize":
					return new Fox.Core.Value(configuration_partsBlockSize);
				case "instanceSettings_instancePackagePath":
					return new Fox.Core.Value(instanceSettings_instancePackagePath);
				case "instanceSettings_instanceBlockSize":
					return new Fox.Core.Value(instanceSettings_instanceBlockSize);
				case "instanceSettings_commonMotionTypeName":
					return new Fox.Core.Value(instanceSettings_commonMotionTypeName);
				case "instanceSettings_partsTypeNames":
					return new Fox.Core.Value(instanceSettings_partsTypeNames);
				case "instanceSettings_partsTypeInitial":
					return new Fox.Core.Value(instanceSettings_partsTypeInitial);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "instanceSettings_partsTypeNames":
					return new Fox.Core.Value(this.instanceSettings_partsTypeNames[index]);
				case "instanceSettings_partsTypeInitial":
					return new Fox.Core.Value(this.instanceSettings_partsTypeInitial[index]);
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, string key)
		{
			switch (propertyName)
			{
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(string propertyName, Fox.Core.Value value)
		{
			switch (propertyName)
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
			switch (propertyName)
			{
				case "instanceSettings_partsTypeNames":
					while(this.instanceSettings_partsTypeNames.Count <= index) { this.instanceSettings_partsTypeNames.Add(default(string)); }
					this.instanceSettings_partsTypeNames[index] = value.GetValueAsString();
					return;
				case "instanceSettings_partsTypeInitial":
					while(this.instanceSettings_partsTypeInitial.Count <= index) { this.instanceSettings_partsTypeInitial.Add(default(string)); }
					this.instanceSettings_partsTypeInitial[index] = value.GetValueAsString();
					return;
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}