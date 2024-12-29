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

namespace Fox.Sdx
{
	[UnityEditor.InitializeOnLoad]
	public partial class SoundPhysicsParameter : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public string hitEvent { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string rollStartEvent { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string rollEndEvent { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string hitRtpcName { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string rollRtpcName { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string switchName { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string generalEvent1 { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string generalEvent2 { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float hitLowerPower { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float hitUpperPower { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float hitIntervalSeconds { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float hitLowerRtpc { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float hitUpperRtpc { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float rollLowerPower { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float rollUpperPower { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float rollStartSeconds { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float rollEndSeconds { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float rollLowerRtpc { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float rollUpperRtpc { get; set; }
		
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
		static SoundPhysicsParameter()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("SoundPhysicsParameter", typeof(SoundPhysicsParameter), Fox.Core.Data.ClassInfo, 140, "Sound", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("hitEvent", Fox.Core.PropertyInfo.PropertyType.String, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rollStartEvent", Fox.Core.PropertyInfo.PropertyType.String, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rollEndEvent", Fox.Core.PropertyInfo.PropertyType.String, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("hitRtpcName", Fox.Core.PropertyInfo.PropertyType.String, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rollRtpcName", Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("switchName", Fox.Core.PropertyInfo.PropertyType.String, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("generalEvent1", Fox.Core.PropertyInfo.PropertyType.String, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("generalEvent2", Fox.Core.PropertyInfo.PropertyType.String, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("hitLowerPower", Fox.Core.PropertyInfo.PropertyType.Float, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("hitUpperPower", Fox.Core.PropertyInfo.PropertyType.Float, 188, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("hitIntervalSeconds", Fox.Core.PropertyInfo.PropertyType.Float, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("hitLowerRtpc", Fox.Core.PropertyInfo.PropertyType.Float, 196, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("hitUpperRtpc", Fox.Core.PropertyInfo.PropertyType.Float, 200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rollLowerPower", Fox.Core.PropertyInfo.PropertyType.Float, 204, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rollUpperPower", Fox.Core.PropertyInfo.PropertyType.Float, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rollStartSeconds", Fox.Core.PropertyInfo.PropertyType.Float, 212, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rollEndSeconds", Fox.Core.PropertyInfo.PropertyType.Float, 216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rollLowerRtpc", Fox.Core.PropertyInfo.PropertyType.Float, 220, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rollUpperRtpc", Fox.Core.PropertyInfo.PropertyType.Float, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "hitEvent":
					return new Fox.Core.Value(hitEvent);
				case "rollStartEvent":
					return new Fox.Core.Value(rollStartEvent);
				case "rollEndEvent":
					return new Fox.Core.Value(rollEndEvent);
				case "hitRtpcName":
					return new Fox.Core.Value(hitRtpcName);
				case "rollRtpcName":
					return new Fox.Core.Value(rollRtpcName);
				case "switchName":
					return new Fox.Core.Value(switchName);
				case "generalEvent1":
					return new Fox.Core.Value(generalEvent1);
				case "generalEvent2":
					return new Fox.Core.Value(generalEvent2);
				case "hitLowerPower":
					return new Fox.Core.Value(hitLowerPower);
				case "hitUpperPower":
					return new Fox.Core.Value(hitUpperPower);
				case "hitIntervalSeconds":
					return new Fox.Core.Value(hitIntervalSeconds);
				case "hitLowerRtpc":
					return new Fox.Core.Value(hitLowerRtpc);
				case "hitUpperRtpc":
					return new Fox.Core.Value(hitUpperRtpc);
				case "rollLowerPower":
					return new Fox.Core.Value(rollLowerPower);
				case "rollUpperPower":
					return new Fox.Core.Value(rollUpperPower);
				case "rollStartSeconds":
					return new Fox.Core.Value(rollStartSeconds);
				case "rollEndSeconds":
					return new Fox.Core.Value(rollEndSeconds);
				case "rollLowerRtpc":
					return new Fox.Core.Value(rollLowerRtpc);
				case "rollUpperRtpc":
					return new Fox.Core.Value(rollUpperRtpc);
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
				case "hitEvent":
					this.hitEvent = value.GetValueAsString();
					return;
				case "rollStartEvent":
					this.rollStartEvent = value.GetValueAsString();
					return;
				case "rollEndEvent":
					this.rollEndEvent = value.GetValueAsString();
					return;
				case "hitRtpcName":
					this.hitRtpcName = value.GetValueAsString();
					return;
				case "rollRtpcName":
					this.rollRtpcName = value.GetValueAsString();
					return;
				case "switchName":
					this.switchName = value.GetValueAsString();
					return;
				case "generalEvent1":
					this.generalEvent1 = value.GetValueAsString();
					return;
				case "generalEvent2":
					this.generalEvent2 = value.GetValueAsString();
					return;
				case "hitLowerPower":
					this.hitLowerPower = value.GetValueAsFloat();
					return;
				case "hitUpperPower":
					this.hitUpperPower = value.GetValueAsFloat();
					return;
				case "hitIntervalSeconds":
					this.hitIntervalSeconds = value.GetValueAsFloat();
					return;
				case "hitLowerRtpc":
					this.hitLowerRtpc = value.GetValueAsFloat();
					return;
				case "hitUpperRtpc":
					this.hitUpperRtpc = value.GetValueAsFloat();
					return;
				case "rollLowerPower":
					this.rollLowerPower = value.GetValueAsFloat();
					return;
				case "rollUpperPower":
					this.rollUpperPower = value.GetValueAsFloat();
					return;
				case "rollStartSeconds":
					this.rollStartSeconds = value.GetValueAsFloat();
					return;
				case "rollEndSeconds":
					this.rollEndSeconds = value.GetValueAsFloat();
					return;
				case "rollLowerRtpc":
					this.rollLowerRtpc = value.GetValueAsFloat();
					return;
				case "rollUpperRtpc":
					this.rollUpperRtpc = value.GetValueAsFloat();
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