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
	[UnityEditor.InitializeOnLoad]
	public partial class UInt32ArrayPropertyDifference : Fox.Core.PropertyDifference
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<uint> originalValues { get; private set; } = new Fox.Kernel.DynamicArray<uint>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<uint> values { get; private set; } = new Fox.Kernel.DynamicArray<uint>();
		
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
		static UInt32ArrayPropertyDifference()
		{
			if (Fox.Core.PropertyDifference.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("UInt32ArrayPropertyDifference"), typeof(UInt32ArrayPropertyDifference), Fox.Core.PropertyDifference.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("originalValues"), Fox.Core.PropertyInfo.PropertyType.UInt32, 72, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("values"), Fox.Core.PropertyInfo.PropertyType.UInt32, 88, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public UInt32ArrayPropertyDifference(ulong id) : base(id) { }
		public UInt32ArrayPropertyDifference() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "originalValues":
					return new Fox.Core.Value(originalValues);
				case "values":
					return new Fox.Core.Value(values);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "originalValues":
					return new Fox.Core.Value(this.originalValues[index]);
				case "values":
					return new Fox.Core.Value(this.values[index]);
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
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "originalValues":
					while(this.originalValues.Count <= index) { this.originalValues.Add(default(uint)); }
					this.originalValues[index] = value.GetValueAsUInt32();
					return;
				case "values":
					while(this.values.Count <= index) { this.values.Add(default(uint)); }
					this.values[index] = value.GetValueAsUInt32();
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