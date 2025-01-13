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

namespace Tpp.Sound
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppSound/TppAmbientParameter")]
	public partial class TppAmbientParameter : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public string ambientEvent { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string objectRtpcName { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float objectRtpcValue { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.StringMap<float> auxSends { get; private set; } = new Fox.StringMap<float>();
		
		[field: UnityEngine.SerializeField]
		public float dryVolume { get; set; }
		
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
		static TppAmbientParameter()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppAmbientParameter", typeof(TppAmbientParameter), Fox.Core.Data.ClassInfo, 136, "Sound", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("ambientEvent", Fox.Core.PropertyInfo.PropertyType.String, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("objectRtpcName", Fox.Core.PropertyInfo.PropertyType.String, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("objectRtpcValue", Fox.Core.PropertyInfo.PropertyType.Float, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("auxSends", Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dryVolume", Fox.Core.PropertyInfo.PropertyType.Float, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "ambientEvent":
					return new Fox.Core.Value(ambientEvent);
				case "objectRtpcName":
					return new Fox.Core.Value(objectRtpcName);
				case "objectRtpcValue":
					return new Fox.Core.Value(objectRtpcValue);
				case "auxSends":
					return new Fox.Core.Value((Fox.IStringMap)auxSends);
				case "dryVolume":
					return new Fox.Core.Value(dryVolume);
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
				case "auxSends":
					return new Fox.Core.Value(this.auxSends[key]);
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(string propertyName, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "ambientEvent":
					this.ambientEvent = value.GetValueAsString();
					return;
				case "objectRtpcName":
					this.objectRtpcName = value.GetValueAsString();
					return;
				case "objectRtpcValue":
					this.objectRtpcValue = value.GetValueAsFloat();
					return;
				case "dryVolume":
					this.dryVolume = value.GetValueAsFloat();
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
				case "auxSends":
					if (this.auxSends.ContainsKey(key))
						this.auxSends[key] = value.GetValueAsFloat();
					else
						this.auxSends.Insert(key, value.GetValueAsFloat());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}