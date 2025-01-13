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

namespace Tpp.GameKit
{
	[UnityEditor.InitializeOnLoad]
	public partial class TppCombatLocatorData : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public float radius { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float lostSearchRadius { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool isUseWaitPrioirty { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool isReinforcePoint { get; set; }
		
		[field: UnityEngine.SerializeField]
		public byte memberCount { get; set; }
		
		[field: UnityEngine.SerializeField]
		public byte memberCountFront { get; set; }
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.Core.EntityLink> subLocators { get; private set; } = new CsSystem.Collections.Generic.List<Fox.Core.EntityLink>();
		
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
		static TppCombatLocatorData()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppCombatLocatorData", typeof(TppCombatLocatorData), Fox.Core.TransformData.ClassInfo, 288, "Locator", 5);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("radius", Fox.Core.PropertyInfo.PropertyType.Float, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lostSearchRadius", Fox.Core.PropertyInfo.PropertyType.Float, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isUseWaitPrioirty", Fox.Core.PropertyInfo.PropertyType.Bool, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isReinforcePoint", Fox.Core.PropertyInfo.PropertyType.Bool, 313, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("memberCount", Fox.Core.PropertyInfo.PropertyType.UInt8, 314, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("memberCountFront", Fox.Core.PropertyInfo.PropertyType.UInt8, 315, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("subLocators", Fox.Core.PropertyInfo.PropertyType.EntityLink, 320, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "radius":
					return new Fox.Core.Value(radius);
				case "lostSearchRadius":
					return new Fox.Core.Value(lostSearchRadius);
				case "isUseWaitPrioirty":
					return new Fox.Core.Value(isUseWaitPrioirty);
				case "isReinforcePoint":
					return new Fox.Core.Value(isReinforcePoint);
				case "memberCount":
					return new Fox.Core.Value(memberCount);
				case "memberCountFront":
					return new Fox.Core.Value(memberCountFront);
				case "subLocators":
					return new Fox.Core.Value(subLocators);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "subLocators":
					return new Fox.Core.Value(this.subLocators[index]);
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
				case "radius":
					this.radius = value.GetValueAsFloat();
					return;
				case "lostSearchRadius":
					this.lostSearchRadius = value.GetValueAsFloat();
					return;
				case "isUseWaitPrioirty":
					this.isUseWaitPrioirty = value.GetValueAsBool();
					return;
				case "isReinforcePoint":
					this.isReinforcePoint = value.GetValueAsBool();
					return;
				case "memberCount":
					this.memberCount = value.GetValueAsUInt8();
					return;
				case "memberCountFront":
					this.memberCountFront = value.GetValueAsUInt8();
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
				case "subLocators":
					while(this.subLocators.Count <= index) { this.subLocators.Add(default(Fox.Core.EntityLink)); }
					this.subLocators[index] = value.GetValueAsEntityLink();
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