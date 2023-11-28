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
	public partial class CheckpointUnit : Fox.Core.Entity
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected Fox.Core.Entity checkPointParam { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.StringMap<Fox.Core.Entity> checkPointData { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.Entity>();
		
		[field: UnityEngine.SerializeField]
		protected bool isReplacable { get; set; }
		
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
		static CheckpointUnit()
		{
			if (Fox.Core.Entity.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("CheckpointUnit"), typeof(CheckpointUnit), Fox.Core.Entity.ClassInfo, 0, "GameKit", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("checkPointParam"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 48, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.Entity), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("checkPointData"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 56, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.Entity), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isReplacable"), Fox.Core.PropertyInfo.PropertyType.Bool, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public CheckpointUnit(ulong id) : base(id) { }
		public CheckpointUnit() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "checkPointParam":
					return new Fox.Core.Value(checkPointParam);
				case "checkPointData":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)checkPointData);
				case "isReplacable":
					return new Fox.Core.Value(isReplacable);
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
				case "checkPointData":
					return new Fox.Core.Value(this.checkPointData[key]);
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "checkPointParam":
					this.checkPointParam = value.GetValueAsEntityPtr<Fox.Core.Entity>();
					return;
				case "isReplacable":
					this.isReplacable = value.GetValueAsBool();
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
				case "checkPointData":
					if (this.checkPointData.ContainsKey(key))
						this.checkPointData[key] = value.GetValueAsEntityPtr<Fox.Core.Entity>();
					else
						this.checkPointData.Insert(key, value.GetValueAsEntityPtr<Fox.Core.Entity>());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}