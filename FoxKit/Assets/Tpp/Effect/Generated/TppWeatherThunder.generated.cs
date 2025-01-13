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
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppEffect/TppWeatherThunder")]
	public partial class TppWeatherThunder : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public bool enable { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Color color { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float probability { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float powerScale { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float decaySpeed { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr vfxFileStrong { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr vfxFileNormal { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr vfxFileWeak { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float fxThresholdStrong { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float fxThresholdNormal { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float fxThresholdWeak { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool enableSpotLight { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float spotLightLifeMin { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float spotLightLifeMax { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float spotLightLumen { get; set; }
		
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
		static TppWeatherThunder()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppWeatherThunder", typeof(TppWeatherThunder), Fox.Core.Data.ClassInfo, 0, "TppEffect", 4);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("enable", Fox.Core.PropertyInfo.PropertyType.Bool, 253, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("color", Fox.Core.PropertyInfo.PropertyType.Color, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("probability", Fox.Core.PropertyInfo.PropertyType.Float, 228, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("powerScale", Fox.Core.PropertyInfo.PropertyType.Float, 232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("decaySpeed", Fox.Core.PropertyInfo.PropertyType.Float, 236, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("vfxFileStrong", Fox.Core.PropertyInfo.PropertyType.FilePtr, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("vfxFileNormal", Fox.Core.PropertyInfo.PropertyType.FilePtr, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("vfxFileWeak", Fox.Core.PropertyInfo.PropertyType.FilePtr, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("fxThresholdStrong", Fox.Core.PropertyInfo.PropertyType.Float, 216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("fxThresholdNormal", Fox.Core.PropertyInfo.PropertyType.Float, 220, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("fxThresholdWeak", Fox.Core.PropertyInfo.PropertyType.Float, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("enableSpotLight", Fox.Core.PropertyInfo.PropertyType.Bool, 252, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("spotLightLifeMin", Fox.Core.PropertyInfo.PropertyType.Float, 240, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("spotLightLifeMax", Fox.Core.PropertyInfo.PropertyType.Float, 244, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("spotLightLumen", Fox.Core.PropertyInfo.PropertyType.Float, 248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "enable":
					return new Fox.Core.Value(enable);
				case "color":
					return new Fox.Core.Value(color);
				case "probability":
					return new Fox.Core.Value(probability);
				case "powerScale":
					return new Fox.Core.Value(powerScale);
				case "decaySpeed":
					return new Fox.Core.Value(decaySpeed);
				case "vfxFileStrong":
					return new Fox.Core.Value(vfxFileStrong);
				case "vfxFileNormal":
					return new Fox.Core.Value(vfxFileNormal);
				case "vfxFileWeak":
					return new Fox.Core.Value(vfxFileWeak);
				case "fxThresholdStrong":
					return new Fox.Core.Value(fxThresholdStrong);
				case "fxThresholdNormal":
					return new Fox.Core.Value(fxThresholdNormal);
				case "fxThresholdWeak":
					return new Fox.Core.Value(fxThresholdWeak);
				case "enableSpotLight":
					return new Fox.Core.Value(enableSpotLight);
				case "spotLightLifeMin":
					return new Fox.Core.Value(spotLightLifeMin);
				case "spotLightLifeMax":
					return new Fox.Core.Value(spotLightLifeMax);
				case "spotLightLumen":
					return new Fox.Core.Value(spotLightLumen);
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
				case "enable":
					this.enable = value.GetValueAsBool();
					return;
				case "color":
					this.color = value.GetValueAsColor();
					return;
				case "probability":
					this.probability = value.GetValueAsFloat();
					return;
				case "powerScale":
					this.powerScale = value.GetValueAsFloat();
					return;
				case "decaySpeed":
					this.decaySpeed = value.GetValueAsFloat();
					return;
				case "vfxFileStrong":
					this.vfxFileStrong = value.GetValueAsFilePtr();
					return;
				case "vfxFileNormal":
					this.vfxFileNormal = value.GetValueAsFilePtr();
					return;
				case "vfxFileWeak":
					this.vfxFileWeak = value.GetValueAsFilePtr();
					return;
				case "fxThresholdStrong":
					this.fxThresholdStrong = value.GetValueAsFloat();
					return;
				case "fxThresholdNormal":
					this.fxThresholdNormal = value.GetValueAsFloat();
					return;
				case "fxThresholdWeak":
					this.fxThresholdWeak = value.GetValueAsFloat();
					return;
				case "enableSpotLight":
					this.enableSpotLight = value.GetValueAsBool();
					return;
				case "spotLightLifeMin":
					this.spotLightLifeMin = value.GetValueAsFloat();
					return;
				case "spotLightLifeMax":
					this.spotLightLifeMax = value.GetValueAsFloat();
					return;
				case "spotLightLumen":
					this.spotLightLumen = value.GetValueAsFloat();
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