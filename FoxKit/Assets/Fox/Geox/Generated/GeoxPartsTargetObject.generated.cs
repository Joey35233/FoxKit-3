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

namespace Fox.Geox
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("Geox/GeoxPartsTargetObject")]
	public partial class GeoxPartsTargetObject : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public PrimType primType { get; set; }
		
		[field: UnityEngine.SerializeField]
		public AxisSort axisSortFlag { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected ulong systemAttribute { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint through { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool isValid { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string categoryTag { get; set; }
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<string> groupTags { get; private set; } = new CsSystem.Collections.Generic.List<string>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink applicationDataLink { get; set; }
		
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
		static GeoxPartsTargetObject()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("GeoxPartsTargetObject", typeof(GeoxPartsTargetObject), Fox.Core.TransformData.ClassInfo, 0, "Target", 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("primType", Fox.Core.PropertyInfo.PropertyType.Int32, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(PrimType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("axisSortFlag", Fox.Core.PropertyInfo.PropertyType.Int32, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(AxisSort), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("systemAttribute", Fox.Core.PropertyInfo.PropertyType.UInt64, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("through", Fox.Core.PropertyInfo.PropertyType.UInt32, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isValid", Fox.Core.PropertyInfo.PropertyType.Bool, 324, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("categoryTag", Fox.Core.PropertyInfo.PropertyType.String, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("groupTags", Fox.Core.PropertyInfo.PropertyType.String, 336, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("applicationDataLink", Fox.Core.PropertyInfo.PropertyType.EntityLink, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "primType":
					return new Fox.Core.Value(primType);
				case "axisSortFlag":
					return new Fox.Core.Value(axisSortFlag);
				case "systemAttribute":
					return new Fox.Core.Value(systemAttribute);
				case "through":
					return new Fox.Core.Value(through);
				case "isValid":
					return new Fox.Core.Value(isValid);
				case "categoryTag":
					return new Fox.Core.Value(categoryTag);
				case "groupTags":
					return new Fox.Core.Value(groupTags);
				case "applicationDataLink":
					return new Fox.Core.Value(applicationDataLink);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "groupTags":
					return new Fox.Core.Value(this.groupTags[index]);
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
				case "primType":
					this.primType = (PrimType)value.GetValueAsInt32();
					return;
				case "axisSortFlag":
					this.axisSortFlag = (AxisSort)value.GetValueAsInt32();
					return;
				case "systemAttribute":
					this.systemAttribute = value.GetValueAsUInt64();
					return;
				case "through":
					this.through = value.GetValueAsUInt32();
					return;
				case "isValid":
					this.isValid = value.GetValueAsBool();
					return;
				case "categoryTag":
					this.categoryTag = value.GetValueAsString();
					return;
				case "applicationDataLink":
					this.applicationDataLink = value.GetValueAsEntityLink();
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
				case "groupTags":
					while(this.groupTags.Count <= index) { this.groupTags.Add(default(string)); }
					this.groupTags[index] = value.GetValueAsString();
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