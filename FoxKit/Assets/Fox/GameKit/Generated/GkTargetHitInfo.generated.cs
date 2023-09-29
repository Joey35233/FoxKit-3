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
	[UnityEditor.InitializeOnLoad]
	public partial class GkTargetHitInfo : Fox.Core.Entity
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityPtr<Fox.GameKit.GkTargetData> offense { get; set; } = new Fox.Core.EntityPtr<Fox.GameKit.GkTargetData>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityPtr<Fox.GameKit.GkTargetData> defense { get; set; } = new Fox.Core.EntityPtr<Fox.GameKit.GkTargetData>();
		
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
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("GkTargetHitInfo"), typeof(GkTargetHitInfo), Fox.Core.Entity.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("offense"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 48, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.GameKit.GkTargetData), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("defense"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.GameKit.GkTargetData), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("hitPosition"), Fox.Core.PropertyInfo.PropertyType.Vector3, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("hitNormal"), Fox.Core.PropertyInfo.PropertyType.Vector3, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("hitDirection"), Fox.Core.PropertyInfo.PropertyType.Vector3, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("attackDirection"), Fox.Core.PropertyInfo.PropertyType.Vector3, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public GkTargetHitInfo(ulong id) : base(id) { }
		public GkTargetHitInfo() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
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

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key)
		{
			switch (propertyName.CString)
			{
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch (propertyName.CString)
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

		public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}