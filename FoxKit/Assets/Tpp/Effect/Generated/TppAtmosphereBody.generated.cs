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
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppEffect/TppAtmosphereBody")]
	public partial class TppAtmosphereBody : Fox.Core.DataBody
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public uint hour { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint minute { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint second { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float daySkyLightScale { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float nightSkyLightScale { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float mieHeightScale { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float mieAnisotropy { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Vector3 mieScatteringCoefficient { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float cloudiness { get; set; }
		
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
		static TppAtmosphereBody()
		{
			if (Fox.Core.DataBody.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppAtmosphereBody", typeof(TppAtmosphereBody), Fox.Core.DataBody.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("hour", Fox.Core.PropertyInfo.PropertyType.UInt32, 188, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("minute", Fox.Core.PropertyInfo.PropertyType.UInt32, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("second", Fox.Core.PropertyInfo.PropertyType.UInt32, 196, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("daySkyLightScale", Fox.Core.PropertyInfo.PropertyType.Float, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("nightSkyLightScale", Fox.Core.PropertyInfo.PropertyType.Float, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("mieHeightScale", Fox.Core.PropertyInfo.PropertyType.Float, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("mieAnisotropy", Fox.Core.PropertyInfo.PropertyType.Float, 180, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("mieScatteringCoefficient", Fox.Core.PropertyInfo.PropertyType.Vector3, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("cloudiness", Fox.Core.PropertyInfo.PropertyType.Float, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "hour":
					return new Fox.Core.Value(hour);
				case "minute":
					return new Fox.Core.Value(minute);
				case "second":
					return new Fox.Core.Value(second);
				case "daySkyLightScale":
					return new Fox.Core.Value(daySkyLightScale);
				case "nightSkyLightScale":
					return new Fox.Core.Value(nightSkyLightScale);
				case "mieHeightScale":
					return new Fox.Core.Value(mieHeightScale);
				case "mieAnisotropy":
					return new Fox.Core.Value(mieAnisotropy);
				case "mieScatteringCoefficient":
					return new Fox.Core.Value(mieScatteringCoefficient);
				case "cloudiness":
					return new Fox.Core.Value(cloudiness);
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
				case "hour":
					this.hour = value.GetValueAsUInt32();
					return;
				case "minute":
					this.minute = value.GetValueAsUInt32();
					return;
				case "second":
					this.second = value.GetValueAsUInt32();
					return;
				case "daySkyLightScale":
					this.daySkyLightScale = value.GetValueAsFloat();
					return;
				case "nightSkyLightScale":
					this.nightSkyLightScale = value.GetValueAsFloat();
					return;
				case "mieHeightScale":
					this.mieHeightScale = value.GetValueAsFloat();
					return;
				case "mieAnisotropy":
					this.mieAnisotropy = value.GetValueAsFloat();
					return;
				case "mieScatteringCoefficient":
					this.mieScatteringCoefficient = value.GetValueAsVector3();
					return;
				case "cloudiness":
					this.cloudiness = value.GetValueAsFloat();
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