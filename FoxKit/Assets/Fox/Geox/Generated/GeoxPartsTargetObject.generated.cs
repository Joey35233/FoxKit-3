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
	[UnityEditor.InitializeOnLoad]
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
		public Fox.Kernel.String categoryTag { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Kernel.String> groupTags { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
		
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
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("GeoxPartsTargetObject"), typeof(GeoxPartsTargetObject), Fox.Core.TransformData.ClassInfo, 0, "Target", 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("primType"), Fox.Core.PropertyInfo.PropertyType.Int32, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(PrimType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("axisSortFlag"), Fox.Core.PropertyInfo.PropertyType.Int32, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(AxisSort), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("systemAttribute"), Fox.Core.PropertyInfo.PropertyType.UInt64, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("through"), Fox.Core.PropertyInfo.PropertyType.UInt32, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isValid"), Fox.Core.PropertyInfo.PropertyType.Bool, 324, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("categoryTag"), Fox.Core.PropertyInfo.PropertyType.String, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("groupTags"), Fox.Core.PropertyInfo.PropertyType.String, 336, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("applicationDataLink"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public GeoxPartsTargetObject(ulong id) : base(id) { }
		public GeoxPartsTargetObject() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
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

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "groupTags":
					return new Fox.Core.Value(this.groupTags[index]);
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

		public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "groupTags":
					while(this.groupTags.Count <= index) { this.groupTags.Add(default(Fox.Kernel.String)); }
					this.groupTags[index] = value.GetValueAsString();
					return;
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