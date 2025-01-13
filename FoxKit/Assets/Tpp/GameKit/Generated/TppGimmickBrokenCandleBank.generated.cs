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
	public partial class TppGimmickBrokenCandleBank : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.Path> referencePartsPathList { get; private set; } = new CsSystem.Collections.Generic.List<Fox.Path>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr modelFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr connectPointFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr soundFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public byte instanceCount { get; set; }
		
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
		static TppGimmickBrokenCandleBank()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppGimmickBrokenCandleBank", typeof(TppGimmickBrokenCandleBank), Fox.Core.Data.ClassInfo, 160, "Gimmick", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("referencePartsPathList", Fox.Core.PropertyInfo.PropertyType.Path, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("modelFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("connectPointFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("soundFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("instanceCount", Fox.Core.PropertyInfo.PropertyType.UInt8, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "referencePartsPathList":
					return new Fox.Core.Value(referencePartsPathList);
				case "modelFile":
					return new Fox.Core.Value(modelFile);
				case "connectPointFile":
					return new Fox.Core.Value(connectPointFile);
				case "soundFile":
					return new Fox.Core.Value(soundFile);
				case "instanceCount":
					return new Fox.Core.Value(instanceCount);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "referencePartsPathList":
					return new Fox.Core.Value(this.referencePartsPathList[index]);
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
				case "modelFile":
					this.modelFile = value.GetValueAsFilePtr();
					return;
				case "connectPointFile":
					this.connectPointFile = value.GetValueAsFilePtr();
					return;
				case "soundFile":
					this.soundFile = value.GetValueAsFilePtr();
					return;
				case "instanceCount":
					this.instanceCount = value.GetValueAsUInt8();
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
				case "referencePartsPathList":
					while(this.referencePartsPathList.Count <= index) { this.referencePartsPathList.Add(default(Fox.Path)); }
					this.referencePartsPathList[index] = value.GetValueAsPath();
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