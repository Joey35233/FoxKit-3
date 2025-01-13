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
	[UnityEditor.InitializeOnLoad]
	public partial class TppSoundWorld : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public uint updateSeconds { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float startMorning { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float midMorning { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float endMorning { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float startEvening { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float midEvening { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float endEvening { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string situationEvent { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string clockRtpc { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string windVelocityRtpc { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string windDirectionRtpc { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string rainRtpc { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string heightRtpc { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink[] ambientParameter { get; private set; } = new Fox.Core.EntityLink[8];
		
		[field: UnityEngine.SerializeField]
		public string categoryFpvStateGroup { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string categoryFpvStateValue { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string dashStartEventName { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string dashFinishEventName { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float blockedObstruction { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float blockedOcclusion { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float unlinkedObstruction { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float unlinkedOcclusion { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float interferenceSlope { get; set; }
		
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
		static TppSoundWorld()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppSoundWorld", typeof(TppSoundWorld), Fox.Core.Data.ClassInfo, 408, "Sound", 8);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("updateSeconds", Fox.Core.PropertyInfo.PropertyType.UInt32, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("startMorning", Fox.Core.PropertyInfo.PropertyType.Float, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("midMorning", Fox.Core.PropertyInfo.PropertyType.Float, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("endMorning", Fox.Core.PropertyInfo.PropertyType.Float, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("startEvening", Fox.Core.PropertyInfo.PropertyType.Float, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("midEvening", Fox.Core.PropertyInfo.PropertyType.Float, 140, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("endEvening", Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("situationEvent", Fox.Core.PropertyInfo.PropertyType.String, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("clockRtpc", Fox.Core.PropertyInfo.PropertyType.String, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("windVelocityRtpc", Fox.Core.PropertyInfo.PropertyType.String, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("windDirectionRtpc", Fox.Core.PropertyInfo.PropertyType.String, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rainRtpc", Fox.Core.PropertyInfo.PropertyType.String, 200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("heightRtpc", Fox.Core.PropertyInfo.PropertyType.String, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("ambientParameter", Fox.Core.PropertyInfo.PropertyType.EntityLink, 216, 8, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("categoryFpvStateGroup", Fox.Core.PropertyInfo.PropertyType.String, 536, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("categoryFpvStateValue", Fox.Core.PropertyInfo.PropertyType.String, 544, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dashStartEventName", Fox.Core.PropertyInfo.PropertyType.String, 552, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dashFinishEventName", Fox.Core.PropertyInfo.PropertyType.String, 560, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("blockedObstruction", Fox.Core.PropertyInfo.PropertyType.Float, 148, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("blockedOcclusion", Fox.Core.PropertyInfo.PropertyType.Float, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("unlinkedObstruction", Fox.Core.PropertyInfo.PropertyType.Float, 156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("unlinkedOcclusion", Fox.Core.PropertyInfo.PropertyType.Float, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("interferenceSlope", Fox.Core.PropertyInfo.PropertyType.Float, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "updateSeconds":
					return new Fox.Core.Value(updateSeconds);
				case "startMorning":
					return new Fox.Core.Value(startMorning);
				case "midMorning":
					return new Fox.Core.Value(midMorning);
				case "endMorning":
					return new Fox.Core.Value(endMorning);
				case "startEvening":
					return new Fox.Core.Value(startEvening);
				case "midEvening":
					return new Fox.Core.Value(midEvening);
				case "endEvening":
					return new Fox.Core.Value(endEvening);
				case "situationEvent":
					return new Fox.Core.Value(situationEvent);
				case "clockRtpc":
					return new Fox.Core.Value(clockRtpc);
				case "windVelocityRtpc":
					return new Fox.Core.Value(windVelocityRtpc);
				case "windDirectionRtpc":
					return new Fox.Core.Value(windDirectionRtpc);
				case "rainRtpc":
					return new Fox.Core.Value(rainRtpc);
				case "heightRtpc":
					return new Fox.Core.Value(heightRtpc);
				case "ambientParameter":
					return new Fox.Core.Value(ambientParameter);
				case "categoryFpvStateGroup":
					return new Fox.Core.Value(categoryFpvStateGroup);
				case "categoryFpvStateValue":
					return new Fox.Core.Value(categoryFpvStateValue);
				case "dashStartEventName":
					return new Fox.Core.Value(dashStartEventName);
				case "dashFinishEventName":
					return new Fox.Core.Value(dashFinishEventName);
				case "blockedObstruction":
					return new Fox.Core.Value(blockedObstruction);
				case "blockedOcclusion":
					return new Fox.Core.Value(blockedOcclusion);
				case "unlinkedObstruction":
					return new Fox.Core.Value(unlinkedObstruction);
				case "unlinkedOcclusion":
					return new Fox.Core.Value(unlinkedOcclusion);
				case "interferenceSlope":
					return new Fox.Core.Value(interferenceSlope);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "ambientParameter":
					return new Fox.Core.Value(this.ambientParameter[index]);
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
				case "updateSeconds":
					this.updateSeconds = value.GetValueAsUInt32();
					return;
				case "startMorning":
					this.startMorning = value.GetValueAsFloat();
					return;
				case "midMorning":
					this.midMorning = value.GetValueAsFloat();
					return;
				case "endMorning":
					this.endMorning = value.GetValueAsFloat();
					return;
				case "startEvening":
					this.startEvening = value.GetValueAsFloat();
					return;
				case "midEvening":
					this.midEvening = value.GetValueAsFloat();
					return;
				case "endEvening":
					this.endEvening = value.GetValueAsFloat();
					return;
				case "situationEvent":
					this.situationEvent = value.GetValueAsString();
					return;
				case "clockRtpc":
					this.clockRtpc = value.GetValueAsString();
					return;
				case "windVelocityRtpc":
					this.windVelocityRtpc = value.GetValueAsString();
					return;
				case "windDirectionRtpc":
					this.windDirectionRtpc = value.GetValueAsString();
					return;
				case "rainRtpc":
					this.rainRtpc = value.GetValueAsString();
					return;
				case "heightRtpc":
					this.heightRtpc = value.GetValueAsString();
					return;
				case "categoryFpvStateGroup":
					this.categoryFpvStateGroup = value.GetValueAsString();
					return;
				case "categoryFpvStateValue":
					this.categoryFpvStateValue = value.GetValueAsString();
					return;
				case "dashStartEventName":
					this.dashStartEventName = value.GetValueAsString();
					return;
				case "dashFinishEventName":
					this.dashFinishEventName = value.GetValueAsString();
					return;
				case "blockedObstruction":
					this.blockedObstruction = value.GetValueAsFloat();
					return;
				case "blockedOcclusion":
					this.blockedOcclusion = value.GetValueAsFloat();
					return;
				case "unlinkedObstruction":
					this.unlinkedObstruction = value.GetValueAsFloat();
					return;
				case "unlinkedOcclusion":
					this.unlinkedOcclusion = value.GetValueAsFloat();
					return;
				case "interferenceSlope":
					this.interferenceSlope = value.GetValueAsFloat();
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
				case "ambientParameter":
					
					this.ambientParameter[index] = value.GetValueAsEntityLink();
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