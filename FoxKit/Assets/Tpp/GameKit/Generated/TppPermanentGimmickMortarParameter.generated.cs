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
	public partial class TppPermanentGimmickMortarParameter : Fox.Core.DataElement
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public float rotationLimitLeftRight { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float rotationLimitUp { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float rotationLimitDown { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr defaultShellPartsFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr flareShellPartsFile { get; set; }
		
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
		static TppPermanentGimmickMortarParameter()
		{
			if (Fox.Core.DataElement.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppPermanentGimmickMortarParameter", typeof(TppPermanentGimmickMortarParameter), Fox.Core.DataElement.ClassInfo, 88, null, 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rotationLimitLeftRight", Fox.Core.PropertyInfo.PropertyType.Float, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rotationLimitUp", Fox.Core.PropertyInfo.PropertyType.Float, 60, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rotationLimitDown", Fox.Core.PropertyInfo.PropertyType.Float, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("defaultShellPartsFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("flareShellPartsFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "rotationLimitLeftRight":
					return new Fox.Core.Value(rotationLimitLeftRight);
				case "rotationLimitUp":
					return new Fox.Core.Value(rotationLimitUp);
				case "rotationLimitDown":
					return new Fox.Core.Value(rotationLimitDown);
				case "defaultShellPartsFile":
					return new Fox.Core.Value(defaultShellPartsFile);
				case "flareShellPartsFile":
					return new Fox.Core.Value(flareShellPartsFile);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
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
				case "rotationLimitLeftRight":
					this.rotationLimitLeftRight = value.GetValueAsFloat();
					return;
				case "rotationLimitUp":
					this.rotationLimitUp = value.GetValueAsFloat();
					return;
				case "rotationLimitDown":
					this.rotationLimitDown = value.GetValueAsFloat();
					return;
				case "defaultShellPartsFile":
					this.defaultShellPartsFile = value.GetValueAsFilePtr();
					return;
				case "flareShellPartsFile":
					this.flareShellPartsFile = value.GetValueAsFilePtr();
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