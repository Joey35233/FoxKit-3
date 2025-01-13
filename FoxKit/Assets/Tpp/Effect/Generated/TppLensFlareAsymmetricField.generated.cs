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

namespace Tpp.Effect
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppEffect/TppLensFlareAsymmetricField")]
	public partial class TppLensFlareAsymmetricField : Tpp.Effect.TppLensFlareField
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public float verticalInnerScale { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float verticalCenterScale { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float verticalOuterScale { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float verticalInnerValue { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float verticalCenterValue { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float verticalOuterValue { get; set; }
		
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
		static TppLensFlareAsymmetricField()
		{
			if (Tpp.Effect.TppLensFlareField.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppLensFlareAsymmetricField", typeof(TppLensFlareAsymmetricField), Tpp.Effect.TppLensFlareField.ClassInfo, 176, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("verticalInnerScale", Fox.Core.PropertyInfo.PropertyType.Float, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("verticalCenterScale", Fox.Core.PropertyInfo.PropertyType.Float, 216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("verticalOuterScale", Fox.Core.PropertyInfo.PropertyType.Float, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("verticalInnerValue", Fox.Core.PropertyInfo.PropertyType.Float, 212, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("verticalCenterValue", Fox.Core.PropertyInfo.PropertyType.Float, 220, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("verticalOuterValue", Fox.Core.PropertyInfo.PropertyType.Float, 228, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "verticalInnerScale":
					return new Fox.Core.Value(verticalInnerScale);
				case "verticalCenterScale":
					return new Fox.Core.Value(verticalCenterScale);
				case "verticalOuterScale":
					return new Fox.Core.Value(verticalOuterScale);
				case "verticalInnerValue":
					return new Fox.Core.Value(verticalInnerValue);
				case "verticalCenterValue":
					return new Fox.Core.Value(verticalCenterValue);
				case "verticalOuterValue":
					return new Fox.Core.Value(verticalOuterValue);
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
				case "verticalInnerScale":
					this.verticalInnerScale = value.GetValueAsFloat();
					return;
				case "verticalCenterScale":
					this.verticalCenterScale = value.GetValueAsFloat();
					return;
				case "verticalOuterScale":
					this.verticalOuterScale = value.GetValueAsFloat();
					return;
				case "verticalInnerValue":
					this.verticalInnerValue = value.GetValueAsFloat();
					return;
				case "verticalCenterValue":
					this.verticalCenterValue = value.GetValueAsFloat();
					return;
				case "verticalOuterValue":
					this.verticalOuterValue = value.GetValueAsFloat();
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