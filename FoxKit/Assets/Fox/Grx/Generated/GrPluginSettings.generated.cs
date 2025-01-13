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

namespace Fox.Grx
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("Grx/GrPluginSettings")]
	public partial class GrPluginSettings : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public uint motionBlurConvolutionLevel { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float exposureCompensation { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float minExposure { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float maxExposure { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float keyValue { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float bloomSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float bloomBrightnessExtraction { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float bloomWeight { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float tonemapSpeed { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float maxLuminanceValue { get; set; }
		
		[field: UnityEngine.SerializeField]
		public byte captureBounceCount { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint minDecalArea { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected uint flags { get; set; }
		
		public bool isTonemap { get => Get_isTonemap(); set { Set_isTonemap(value); } }
		private partial bool Get_isTonemap();
		private partial void Set_isTonemap(bool value);
		
		public bool isBloom { get => Get_isBloom(); set { Set_isBloom(value); } }
		private partial bool Get_isBloom();
		private partial void Set_isBloom(bool value);
		
		public bool isMotionBlur { get => Get_isMotionBlur(); set { Set_isMotionBlur(value); } }
		private partial bool Get_isMotionBlur();
		private partial void Set_isMotionBlur(bool value);
		
		public bool isDepthOfField { get => Get_isDepthOfField(); set { Set_isDepthOfField(value); } }
		private partial bool Get_isDepthOfField();
		private partial void Set_isDepthOfField(bool value);
		
		public bool isDOFVisualizeFocus { get => Get_isDOFVisualizeFocus(); set { Set_isDOFVisualizeFocus(value); } }
		private partial bool Get_isDOFVisualizeFocus();
		private partial void Set_isDOFVisualizeFocus(bool value);
		
		public bool isLocalReflections { get => Get_isLocalReflections(); set { Set_isLocalReflections(value); } }
		private partial bool Get_isLocalReflections();
		private partial void Set_isLocalReflections(bool value);
		
		public bool isTemporalAA { get => Get_isTemporalAA(); set { Set_isTemporalAA(value); } }
		private partial bool Get_isTemporalAA();
		private partial void Set_isTemporalAA(bool value);
		
		public bool isFixedShutterRatio { get => Get_isFixedShutterRatio(); set { Set_isFixedShutterRatio(value); } }
		private partial bool Get_isFixedShutterRatio();
		private partial void Set_isFixedShutterRatio(bool value);
		
		public bool isPatchVelocity { get => Get_isPatchVelocity(); set { Set_isPatchVelocity(value); } }
		private partial bool Get_isPatchVelocity();
		private partial void Set_isPatchVelocity(bool value);
		
		public bool isLightAdaptationFromLACC { get => Get_isLightAdaptationFromLACC(); set { Set_isLightAdaptationFromLACC(value); } }
		private partial bool Get_isLightAdaptationFromLACC();
		private partial void Set_isLightAdaptationFromLACC(bool value);
		
		public bool isShowDecals { get => Get_isShowDecals(); set { Set_isShowDecals(value); } }
		private partial bool Get_isShowDecals();
		private partial void Set_isShowDecals(bool value);
		
		public bool isShrinkSHBuffer { get => Get_isShrinkSHBuffer(); set { Set_isShrinkSHBuffer(value); } }
		private partial bool Get_isShrinkSHBuffer();
		private partial void Set_isShrinkSHBuffer(bool value);
		
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
		static GrPluginSettings()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("GrPluginSettings", typeof(GrPluginSettings), Fox.Core.Data.ClassInfo, 120, "Config", 25);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("motionBlurConvolutionLevel", Fox.Core.PropertyInfo.PropertyType.UInt32, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("exposureCompensation", Fox.Core.PropertyInfo.PropertyType.Float, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("minExposure", Fox.Core.PropertyInfo.PropertyType.Float, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("maxExposure", Fox.Core.PropertyInfo.PropertyType.Float, 140, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("keyValue", Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("bloomSize", Fox.Core.PropertyInfo.PropertyType.Float, 148, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("bloomBrightnessExtraction", Fox.Core.PropertyInfo.PropertyType.Float, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("bloomWeight", Fox.Core.PropertyInfo.PropertyType.Float, 156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("tonemapSpeed", Fox.Core.PropertyInfo.PropertyType.Float, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("maxLuminanceValue", Fox.Core.PropertyInfo.PropertyType.Float, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("captureBounceCount", Fox.Core.PropertyInfo.PropertyType.UInt8, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("minDecalArea", Fox.Core.PropertyInfo.PropertyType.UInt32, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("flags", Fox.Core.PropertyInfo.PropertyType.UInt32, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isTonemap", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isBloom", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isMotionBlur", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isDepthOfField", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isDOFVisualizeFocus", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isLocalReflections", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isTemporalAA", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isFixedShutterRatio", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isPatchVelocity", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isLightAdaptationFromLACC", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isShowDecals", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isShrinkSHBuffer", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "motionBlurConvolutionLevel":
					return new Fox.Core.Value(motionBlurConvolutionLevel);
				case "exposureCompensation":
					return new Fox.Core.Value(exposureCompensation);
				case "minExposure":
					return new Fox.Core.Value(minExposure);
				case "maxExposure":
					return new Fox.Core.Value(maxExposure);
				case "keyValue":
					return new Fox.Core.Value(keyValue);
				case "bloomSize":
					return new Fox.Core.Value(bloomSize);
				case "bloomBrightnessExtraction":
					return new Fox.Core.Value(bloomBrightnessExtraction);
				case "bloomWeight":
					return new Fox.Core.Value(bloomWeight);
				case "tonemapSpeed":
					return new Fox.Core.Value(tonemapSpeed);
				case "maxLuminanceValue":
					return new Fox.Core.Value(maxLuminanceValue);
				case "captureBounceCount":
					return new Fox.Core.Value(captureBounceCount);
				case "minDecalArea":
					return new Fox.Core.Value(minDecalArea);
				case "flags":
					return new Fox.Core.Value(flags);
				case "isTonemap":
					return new Fox.Core.Value(isTonemap);
				case "isBloom":
					return new Fox.Core.Value(isBloom);
				case "isMotionBlur":
					return new Fox.Core.Value(isMotionBlur);
				case "isDepthOfField":
					return new Fox.Core.Value(isDepthOfField);
				case "isDOFVisualizeFocus":
					return new Fox.Core.Value(isDOFVisualizeFocus);
				case "isLocalReflections":
					return new Fox.Core.Value(isLocalReflections);
				case "isTemporalAA":
					return new Fox.Core.Value(isTemporalAA);
				case "isFixedShutterRatio":
					return new Fox.Core.Value(isFixedShutterRatio);
				case "isPatchVelocity":
					return new Fox.Core.Value(isPatchVelocity);
				case "isLightAdaptationFromLACC":
					return new Fox.Core.Value(isLightAdaptationFromLACC);
				case "isShowDecals":
					return new Fox.Core.Value(isShowDecals);
				case "isShrinkSHBuffer":
					return new Fox.Core.Value(isShrinkSHBuffer);
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
				case "motionBlurConvolutionLevel":
					this.motionBlurConvolutionLevel = value.GetValueAsUInt32();
					return;
				case "exposureCompensation":
					this.exposureCompensation = value.GetValueAsFloat();
					return;
				case "minExposure":
					this.minExposure = value.GetValueAsFloat();
					return;
				case "maxExposure":
					this.maxExposure = value.GetValueAsFloat();
					return;
				case "keyValue":
					this.keyValue = value.GetValueAsFloat();
					return;
				case "bloomSize":
					this.bloomSize = value.GetValueAsFloat();
					return;
				case "bloomBrightnessExtraction":
					this.bloomBrightnessExtraction = value.GetValueAsFloat();
					return;
				case "bloomWeight":
					this.bloomWeight = value.GetValueAsFloat();
					return;
				case "tonemapSpeed":
					this.tonemapSpeed = value.GetValueAsFloat();
					return;
				case "maxLuminanceValue":
					this.maxLuminanceValue = value.GetValueAsFloat();
					return;
				case "captureBounceCount":
					this.captureBounceCount = value.GetValueAsUInt8();
					return;
				case "minDecalArea":
					this.minDecalArea = value.GetValueAsUInt32();
					return;
				case "flags":
					this.flags = value.GetValueAsUInt32();
					return;
				case "isTonemap":
					this.isTonemap = value.GetValueAsBool();
					return;
				case "isBloom":
					this.isBloom = value.GetValueAsBool();
					return;
				case "isMotionBlur":
					this.isMotionBlur = value.GetValueAsBool();
					return;
				case "isDepthOfField":
					this.isDepthOfField = value.GetValueAsBool();
					return;
				case "isDOFVisualizeFocus":
					this.isDOFVisualizeFocus = value.GetValueAsBool();
					return;
				case "isLocalReflections":
					this.isLocalReflections = value.GetValueAsBool();
					return;
				case "isTemporalAA":
					this.isTemporalAA = value.GetValueAsBool();
					return;
				case "isFixedShutterRatio":
					this.isFixedShutterRatio = value.GetValueAsBool();
					return;
				case "isPatchVelocity":
					this.isPatchVelocity = value.GetValueAsBool();
					return;
				case "isLightAdaptationFromLACC":
					this.isLightAdaptationFromLACC = value.GetValueAsBool();
					return;
				case "isShowDecals":
					this.isShowDecals = value.GetValueAsBool();
					return;
				case "isShrinkSHBuffer":
					this.isShrinkSHBuffer = value.GetValueAsBool();
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