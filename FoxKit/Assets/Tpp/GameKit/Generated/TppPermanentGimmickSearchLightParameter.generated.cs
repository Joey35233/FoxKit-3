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
	public partial class TppPermanentGimmickSearchLightParameter : Fox.Core.DataElement
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public float rotationLimitLeftRight { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float rotationLimitUp { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float rotationLimitDown { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float rangeDiscovery { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float rangeLeftRightDiscovery { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float rangeUpDownDiscovery { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float rangeDim { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float rangeLeftRightDim { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float rangeUpDownDim { get; set; }
		
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
		static TppPermanentGimmickSearchLightParameter()
		{
			if (Fox.Core.DataElement.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppPermanentGimmickSearchLightParameter"), typeof(TppPermanentGimmickSearchLightParameter), Fox.Core.DataElement.ClassInfo, 64, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rotationLimitLeftRight"), Fox.Core.PropertyInfo.PropertyType.Float, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rotationLimitUp"), Fox.Core.PropertyInfo.PropertyType.Float, 60, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rotationLimitDown"), Fox.Core.PropertyInfo.PropertyType.Float, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rangeDiscovery"), Fox.Core.PropertyInfo.PropertyType.Float, 68, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rangeLeftRightDiscovery"), Fox.Core.PropertyInfo.PropertyType.Float, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rangeUpDownDiscovery"), Fox.Core.PropertyInfo.PropertyType.Float, 76, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rangeDim"), Fox.Core.PropertyInfo.PropertyType.Float, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rangeLeftRightDim"), Fox.Core.PropertyInfo.PropertyType.Float, 84, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rangeUpDownDim"), Fox.Core.PropertyInfo.PropertyType.Float, 88, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "rotationLimitLeftRight":
					return new Fox.Core.Value(rotationLimitLeftRight);
				case "rotationLimitUp":
					return new Fox.Core.Value(rotationLimitUp);
				case "rotationLimitDown":
					return new Fox.Core.Value(rotationLimitDown);
				case "rangeDiscovery":
					return new Fox.Core.Value(rangeDiscovery);
				case "rangeLeftRightDiscovery":
					return new Fox.Core.Value(rangeLeftRightDiscovery);
				case "rangeUpDownDiscovery":
					return new Fox.Core.Value(rangeUpDownDiscovery);
				case "rangeDim":
					return new Fox.Core.Value(rangeDim);
				case "rangeLeftRightDim":
					return new Fox.Core.Value(rangeLeftRightDim);
				case "rangeUpDownDim":
					return new Fox.Core.Value(rangeUpDownDim);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
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
				case "rotationLimitLeftRight":
					this.rotationLimitLeftRight = value.GetValueAsFloat();
					return;
				case "rotationLimitUp":
					this.rotationLimitUp = value.GetValueAsFloat();
					return;
				case "rotationLimitDown":
					this.rotationLimitDown = value.GetValueAsFloat();
					return;
				case "rangeDiscovery":
					this.rangeDiscovery = value.GetValueAsFloat();
					return;
				case "rangeLeftRightDiscovery":
					this.rangeLeftRightDiscovery = value.GetValueAsFloat();
					return;
				case "rangeUpDownDiscovery":
					this.rangeUpDownDiscovery = value.GetValueAsFloat();
					return;
				case "rangeDim":
					this.rangeDim = value.GetValueAsFloat();
					return;
				case "rangeLeftRightDim":
					this.rangeLeftRightDim = value.GetValueAsFloat();
					return;
				case "rangeUpDownDim":
					this.rangeUpDownDim = value.GetValueAsFloat();
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