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
	[UnityEditor.InitializeOnLoad]
	public partial class TppGlobalVolumetricFogParam : Fox.Core.DataElement
	{
		// Properties
		public bool enable { get => Get_enable(); set { Set_enable(value); } }
		private partial bool Get_enable();
		private partial void Set_enable(bool value);
		
		[field: UnityEngine.SerializeField]
		public float selfLuminance { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Color selfColor { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Color skyAlbedo { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Color rayleighScattering { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Color mieScattering { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float mieAnisotropy { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float skyLightGain { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float dirLightGain { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float lightningGain { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float density { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float power { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float near { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float falloff { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float[] exposureOffsetValues { get; private set; } = new float[3];
		
		[field: UnityEngine.SerializeField]
		public float[] exposureOffsetTargets { get; private set; } = new float[3];
		
		[field: UnityEngine.SerializeField]
		protected uint flags { get; set; }
		
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
		static TppGlobalVolumetricFogParam()
		{
			if (Fox.Core.DataElement.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppGlobalVolumetricFogParam", typeof(TppGlobalVolumetricFogParam), Fox.Core.DataElement.ClassInfo, 192, null, 17);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("enable", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("selfLuminance", Fox.Core.PropertyInfo.PropertyType.Float, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("selfColor", Fox.Core.PropertyInfo.PropertyType.Color, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("skyAlbedo", Fox.Core.PropertyInfo.PropertyType.Color, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rayleighScattering", Fox.Core.PropertyInfo.PropertyType.Color, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("mieScattering", Fox.Core.PropertyInfo.PropertyType.Color, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("mieAnisotropy", Fox.Core.PropertyInfo.PropertyType.Float, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("skyLightGain", Fox.Core.PropertyInfo.PropertyType.Float, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dirLightGain", Fox.Core.PropertyInfo.PropertyType.Float, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lightningGain", Fox.Core.PropertyInfo.PropertyType.Float, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("density", Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("power", Fox.Core.PropertyInfo.PropertyType.Float, 148, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("near", Fox.Core.PropertyInfo.PropertyType.Float, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("falloff", Fox.Core.PropertyInfo.PropertyType.Float, 156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("exposureOffsetValues", Fox.Core.PropertyInfo.PropertyType.Float, 200, 3, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("exposureOffsetTargets", Fox.Core.PropertyInfo.PropertyType.Float, 188, 3, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("flags", Fox.Core.PropertyInfo.PropertyType.UInt32, 212, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "enable":
					return new Fox.Core.Value(enable);
				case "selfLuminance":
					return new Fox.Core.Value(selfLuminance);
				case "selfColor":
					return new Fox.Core.Value(selfColor);
				case "skyAlbedo":
					return new Fox.Core.Value(skyAlbedo);
				case "rayleighScattering":
					return new Fox.Core.Value(rayleighScattering);
				case "mieScattering":
					return new Fox.Core.Value(mieScattering);
				case "mieAnisotropy":
					return new Fox.Core.Value(mieAnisotropy);
				case "skyLightGain":
					return new Fox.Core.Value(skyLightGain);
				case "dirLightGain":
					return new Fox.Core.Value(dirLightGain);
				case "lightningGain":
					return new Fox.Core.Value(lightningGain);
				case "density":
					return new Fox.Core.Value(density);
				case "power":
					return new Fox.Core.Value(power);
				case "near":
					return new Fox.Core.Value(near);
				case "falloff":
					return new Fox.Core.Value(falloff);
				case "exposureOffsetValues":
					return new Fox.Core.Value(exposureOffsetValues);
				case "exposureOffsetTargets":
					return new Fox.Core.Value(exposureOffsetTargets);
				case "flags":
					return new Fox.Core.Value(flags);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "exposureOffsetValues":
					return new Fox.Core.Value(this.exposureOffsetValues[index]);
				case "exposureOffsetTargets":
					return new Fox.Core.Value(this.exposureOffsetTargets[index]);
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
				case "selfLuminance":
					this.selfLuminance = value.GetValueAsFloat();
					return;
				case "selfColor":
					this.selfColor = value.GetValueAsColor();
					return;
				case "skyAlbedo":
					this.skyAlbedo = value.GetValueAsColor();
					return;
				case "rayleighScattering":
					this.rayleighScattering = value.GetValueAsColor();
					return;
				case "mieScattering":
					this.mieScattering = value.GetValueAsColor();
					return;
				case "mieAnisotropy":
					this.mieAnisotropy = value.GetValueAsFloat();
					return;
				case "skyLightGain":
					this.skyLightGain = value.GetValueAsFloat();
					return;
				case "dirLightGain":
					this.dirLightGain = value.GetValueAsFloat();
					return;
				case "lightningGain":
					this.lightningGain = value.GetValueAsFloat();
					return;
				case "density":
					this.density = value.GetValueAsFloat();
					return;
				case "power":
					this.power = value.GetValueAsFloat();
					return;
				case "near":
					this.near = value.GetValueAsFloat();
					return;
				case "falloff":
					this.falloff = value.GetValueAsFloat();
					return;
				case "flags":
					this.flags = value.GetValueAsUInt32();
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
				case "exposureOffsetValues":
					
					this.exposureOffsetValues[index] = value.GetValueAsFloat();
					return;
				case "exposureOffsetTargets":
					
					this.exposureOffsetTargets[index] = value.GetValueAsFloat();
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