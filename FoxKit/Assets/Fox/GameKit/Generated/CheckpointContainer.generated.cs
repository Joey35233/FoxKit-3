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
	public partial class CheckpointContainer : Fox.Core.Entity
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected Fox.StringMap<Fox.GameKit.CheckpointUnit> checkPointUnits { get; private set; } = new Fox.StringMap<Fox.GameKit.CheckpointUnit>();
		
		[field: UnityEngine.SerializeField]
		protected CsSystem.Collections.Generic.List<string> passedCheckpoints { get; private set; } = new CsSystem.Collections.Generic.List<string>();
		
		[field: UnityEngine.SerializeField]
		protected string latestCheckpointTag { get; set; }
		
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
		static CheckpointContainer()
		{
			if (Fox.Core.Entity.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("CheckpointContainer", typeof(CheckpointContainer), Fox.Core.Entity.ClassInfo, 0, "GameKit", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("checkPointUnits", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 48, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.GameKit.CheckpointUnit), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("passedCheckpoints", Fox.Core.PropertyInfo.PropertyType.String, 96, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("latestCheckpointTag", Fox.Core.PropertyInfo.PropertyType.String, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "checkPointUnits":
					return new Fox.Core.Value((Fox.IStringMap)checkPointUnits);
				case "passedCheckpoints":
					return new Fox.Core.Value(passedCheckpoints);
				case "latestCheckpointTag":
					return new Fox.Core.Value(latestCheckpointTag);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "passedCheckpoints":
					return new Fox.Core.Value(this.passedCheckpoints[index]);
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, string key)
		{
			switch (propertyName)
			{
				case "checkPointUnits":
					return new Fox.Core.Value(this.checkPointUnits[key]);
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(string propertyName, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "latestCheckpointTag":
					this.latestCheckpointTag = value.GetValueAsString();
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
				case "passedCheckpoints":
					while(this.passedCheckpoints.Count <= index) { this.passedCheckpoints.Add(default(string)); }
					this.passedCheckpoints[index] = value.GetValueAsString();
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
				case "checkPointUnits":
					if (this.checkPointUnits.ContainsKey(key))
						this.checkPointUnits[key] = value.GetValueAsEntityPtr<Fox.GameKit.CheckpointUnit>();
					else
						this.checkPointUnits.Insert(key, value.GetValueAsEntityPtr<Fox.GameKit.CheckpointUnit>());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}