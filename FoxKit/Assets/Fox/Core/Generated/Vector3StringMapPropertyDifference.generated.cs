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
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("FoxCore/Vector3StringMapPropertyDifference")]
	public partial class Vector3StringMapPropertyDifference : Fox.Core.PropertyDifference
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.StringMap<UnityEngine.Vector3> originalValues { get; private set; } = new Fox.StringMap<UnityEngine.Vector3>();
		
		[field: UnityEngine.SerializeField]
		public Fox.StringMap<UnityEngine.Vector3> values { get; private set; } = new Fox.StringMap<UnityEngine.Vector3>();
		
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
		static Vector3StringMapPropertyDifference()
		{
			if (Fox.Core.PropertyDifference.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("Vector3StringMapPropertyDifference", typeof(Vector3StringMapPropertyDifference), Fox.Core.PropertyDifference.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("originalValues", Fox.Core.PropertyInfo.PropertyType.Vector3, 72, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("values", Fox.Core.PropertyInfo.PropertyType.Vector3, 120, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "originalValues":
					return new Fox.Core.Value((Fox.IStringMap)originalValues);
				case "values":
					return new Fox.Core.Value((Fox.IStringMap)values);
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
				case "originalValues":
					return new Fox.Core.Value(this.originalValues[key]);
				case "values":
					return new Fox.Core.Value(this.values[key]);
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
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "originalValues":
					if (this.originalValues.ContainsKey(key))
						this.originalValues[key] = value.GetValueAsVector3();
					else
						this.originalValues.Insert(key, value.GetValueAsVector3());
					return;
				case "values":
					if (this.values.ContainsKey(key))
						this.values[key] = value.GetValueAsVector3();
					else
						this.values.Insert(key, value.GetValueAsVector3());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}