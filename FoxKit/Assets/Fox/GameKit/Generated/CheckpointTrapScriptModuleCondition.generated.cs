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
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("FoxGameKit/CheckpointTrapScriptModuleCondition")]
	public partial class CheckpointTrapScriptModuleCondition : Fox.Geo.GeoTrapScriptModuleCondition
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.Path> checkpointScriptArray { get; private set; } = new CsSystem.Collections.Generic.List<Fox.Path>();
		
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
		static CheckpointTrapScriptModuleCondition()
		{
			if (Fox.Geo.GeoTrapScriptModuleCondition.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("CheckpointTrapScriptModuleCondition", typeof(CheckpointTrapScriptModuleCondition), Fox.Geo.GeoTrapScriptModuleCondition.ClassInfo, 0, "GameKit", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("checkpointScriptArray", Fox.Core.PropertyInfo.PropertyType.Path, 368, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "checkpointScriptArray":
					return new Fox.Core.Value(checkpointScriptArray);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "checkpointScriptArray":
					return new Fox.Core.Value(this.checkpointScriptArray[index]);
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
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "checkpointScriptArray":
					while(this.checkpointScriptArray.Count <= index) { this.checkpointScriptArray.Add(default(Fox.Path)); }
					this.checkpointScriptArray[index] = value.GetValueAsPath();
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