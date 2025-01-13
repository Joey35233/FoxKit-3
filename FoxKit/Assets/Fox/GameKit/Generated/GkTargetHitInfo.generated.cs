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

namespace Fox.GameKit
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("FoxGameKit/GkTargetHitInfo")]
	public partial class GkTargetHitInfo : Fox.Core.Entity
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.GameKit.GkTargetData offense { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.GameKit.GkTargetData defense { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Vector3 hitPosition { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Vector3 hitNormal { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Vector3 hitDirection { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Vector3 attackDirection { get; set; }
		
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
		static GkTargetHitInfo()
		{
			if (Fox.Core.Entity.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("GkTargetHitInfo", typeof(GkTargetHitInfo), Fox.Core.Entity.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("offense", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 48, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.GameKit.GkTargetData), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("defense", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.GameKit.GkTargetData), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("hitPosition", Fox.Core.PropertyInfo.PropertyType.Vector3, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("hitNormal", Fox.Core.PropertyInfo.PropertyType.Vector3, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("hitDirection", Fox.Core.PropertyInfo.PropertyType.Vector3, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("attackDirection", Fox.Core.PropertyInfo.PropertyType.Vector3, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "offense":
					return new Fox.Core.Value(offense);
				case "defense":
					return new Fox.Core.Value(defense);
				case "hitPosition":
					return new Fox.Core.Value(hitPosition);
				case "hitNormal":
					return new Fox.Core.Value(hitNormal);
				case "hitDirection":
					return new Fox.Core.Value(hitDirection);
				case "attackDirection":
					return new Fox.Core.Value(attackDirection);
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
				case "offense":
					this.offense = value.GetValueAsEntityPtr<Fox.GameKit.GkTargetData>();
					return;
				case "defense":
					this.defense = value.GetValueAsEntityPtr<Fox.GameKit.GkTargetData>();
					return;
				case "hitPosition":
					this.hitPosition = value.GetValueAsVector3();
					return;
				case "hitNormal":
					this.hitNormal = value.GetValueAsVector3();
					return;
				case "hitDirection":
					this.hitDirection = value.GetValueAsVector3();
					return;
				case "attackDirection":
					this.attackDirection = value.GetValueAsVector3();
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