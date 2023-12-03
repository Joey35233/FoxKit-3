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

namespace Fox.Gr
{
	[UnityEditor.InitializeOnLoad]
	public partial class GrFilmicTonemap : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public bool enable { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float sholderStrength { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float linearStrength { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float linearAngle { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float toeStrength { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float toeNumerator { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float toeDenominator { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float whitePointValue { get; set; }
		
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
		static GrFilmicTonemap()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("GrFilmicTonemap"), typeof(GrFilmicTonemap), Fox.Core.Data.ClassInfo, 0, null, 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("enable"), Fox.Core.PropertyInfo.PropertyType.Bool, 148, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("sholderStrength"), Fox.Core.PropertyInfo.PropertyType.Float, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("linearStrength"), Fox.Core.PropertyInfo.PropertyType.Float, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("linearAngle"), Fox.Core.PropertyInfo.PropertyType.Float, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("toeStrength"), Fox.Core.PropertyInfo.PropertyType.Float, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("toeNumerator"), Fox.Core.PropertyInfo.PropertyType.Float, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("toeDenominator"), Fox.Core.PropertyInfo.PropertyType.Float, 140, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("whitePointValue"), Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "enable":
					return new Fox.Core.Value(enable);
				case "sholderStrength":
					return new Fox.Core.Value(sholderStrength);
				case "linearStrength":
					return new Fox.Core.Value(linearStrength);
				case "linearAngle":
					return new Fox.Core.Value(linearAngle);
				case "toeStrength":
					return new Fox.Core.Value(toeStrength);
				case "toeNumerator":
					return new Fox.Core.Value(toeNumerator);
				case "toeDenominator":
					return new Fox.Core.Value(toeDenominator);
				case "whitePointValue":
					return new Fox.Core.Value(whitePointValue);
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
				case "enable":
					this.enable = value.GetValueAsBool();
					return;
				case "sholderStrength":
					this.sholderStrength = value.GetValueAsFloat();
					return;
				case "linearStrength":
					this.linearStrength = value.GetValueAsFloat();
					return;
				case "linearAngle":
					this.linearAngle = value.GetValueAsFloat();
					return;
				case "toeStrength":
					this.toeStrength = value.GetValueAsFloat();
					return;
				case "toeNumerator":
					this.toeNumerator = value.GetValueAsFloat();
					return;
				case "toeDenominator":
					this.toeDenominator = value.GetValueAsFloat();
					return;
				case "whitePointValue":
					this.whitePointValue = value.GetValueAsFloat();
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