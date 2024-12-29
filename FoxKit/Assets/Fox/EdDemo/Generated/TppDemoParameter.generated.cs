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

namespace Fox.EdDemo
{
	[UnityEditor.InitializeOnLoad]
	public partial class TppDemoParameter : Fox.Demo.DemoParameter
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public bool pauseEnable { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool fadeSerchLightEnable { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool fadeDirectionalLightEnable { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool fadeSandStormEnable { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float sandStormDensityMin { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float fadeTime { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool useSetTime { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint hour { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint minute { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint second { get; set; }
		
		[field: UnityEngine.SerializeField]
		public TppDemoParameter_WeatherType weatherType { get; set; }
		
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
		static TppDemoParameter()
		{
			if (Fox.Demo.DemoParameter.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppDemoParameter", typeof(TppDemoParameter), Fox.Demo.DemoParameter.ClassInfo, 68, null, 3);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("pauseEnable", Fox.Core.PropertyInfo.PropertyType.Bool, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("fadeSerchLightEnable", Fox.Core.PropertyInfo.PropertyType.Bool, 65, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("fadeDirectionalLightEnable", Fox.Core.PropertyInfo.PropertyType.Bool, 66, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("fadeSandStormEnable", Fox.Core.PropertyInfo.PropertyType.Bool, 67, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("sandStormDensityMin", Fox.Core.PropertyInfo.PropertyType.Float, 68, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("fadeTime", Fox.Core.PropertyInfo.PropertyType.Float, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("useSetTime", Fox.Core.PropertyInfo.PropertyType.Bool, 76, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("hour", Fox.Core.PropertyInfo.PropertyType.UInt32, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("minute", Fox.Core.PropertyInfo.PropertyType.UInt32, 84, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("second", Fox.Core.PropertyInfo.PropertyType.UInt32, 88, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("weatherType", Fox.Core.PropertyInfo.PropertyType.Int32, 92, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppDemoParameter_WeatherType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "pauseEnable":
					return new Fox.Core.Value(pauseEnable);
				case "fadeSerchLightEnable":
					return new Fox.Core.Value(fadeSerchLightEnable);
				case "fadeDirectionalLightEnable":
					return new Fox.Core.Value(fadeDirectionalLightEnable);
				case "fadeSandStormEnable":
					return new Fox.Core.Value(fadeSandStormEnable);
				case "sandStormDensityMin":
					return new Fox.Core.Value(sandStormDensityMin);
				case "fadeTime":
					return new Fox.Core.Value(fadeTime);
				case "useSetTime":
					return new Fox.Core.Value(useSetTime);
				case "hour":
					return new Fox.Core.Value(hour);
				case "minute":
					return new Fox.Core.Value(minute);
				case "second":
					return new Fox.Core.Value(second);
				case "weatherType":
					return new Fox.Core.Value(weatherType);
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
				case "pauseEnable":
					this.pauseEnable = value.GetValueAsBool();
					return;
				case "fadeSerchLightEnable":
					this.fadeSerchLightEnable = value.GetValueAsBool();
					return;
				case "fadeDirectionalLightEnable":
					this.fadeDirectionalLightEnable = value.GetValueAsBool();
					return;
				case "fadeSandStormEnable":
					this.fadeSandStormEnable = value.GetValueAsBool();
					return;
				case "sandStormDensityMin":
					this.sandStormDensityMin = value.GetValueAsFloat();
					return;
				case "fadeTime":
					this.fadeTime = value.GetValueAsFloat();
					return;
				case "useSetTime":
					this.useSetTime = value.GetValueAsBool();
					return;
				case "hour":
					this.hour = value.GetValueAsUInt32();
					return;
				case "minute":
					this.minute = value.GetValueAsUInt32();
					return;
				case "second":
					this.second = value.GetValueAsUInt32();
					return;
				case "weatherType":
					this.weatherType = (TppDemoParameter_WeatherType)value.GetValueAsInt32();
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