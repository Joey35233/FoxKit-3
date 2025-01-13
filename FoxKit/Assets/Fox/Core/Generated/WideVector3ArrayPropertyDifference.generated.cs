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

namespace Fox.Core
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("FoxCore/WideVector3ArrayPropertyDifference")]
	public partial class WideVector3ArrayPropertyDifference : Fox.Core.PropertyDifference
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.WideVector3> originalValues { get; private set; } = new CsSystem.Collections.Generic.List<Fox.WideVector3>();
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.WideVector3> values { get; private set; } = new CsSystem.Collections.Generic.List<Fox.WideVector3>();
		
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
		static WideVector3ArrayPropertyDifference()
		{
			if (Fox.Core.PropertyDifference.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("WideVector3ArrayPropertyDifference", typeof(WideVector3ArrayPropertyDifference), Fox.Core.PropertyDifference.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("originalValues", Fox.Core.PropertyInfo.PropertyType.WideVector3, 72, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("values", Fox.Core.PropertyInfo.PropertyType.WideVector3, 88, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "originalValues":
					return new Fox.Core.Value(originalValues);
				case "values":
					return new Fox.Core.Value(values);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "originalValues":
					return new Fox.Core.Value(this.originalValues[index]);
				case "values":
					return new Fox.Core.Value(this.values[index]);
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
				case "originalValues":
					while(this.originalValues.Count <= index) { this.originalValues.Add(default(Fox.WideVector3)); }
					this.originalValues[index] = value.GetValueAsWideVector3();
					return;
				case "values":
					while(this.values.Count <= index) { this.values.Add(default(Fox.WideVector3)); }
					this.values[index] = value.GetValueAsWideVector3();
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