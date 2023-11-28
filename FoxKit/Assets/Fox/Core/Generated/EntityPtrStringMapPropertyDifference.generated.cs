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
	public partial class EntityPtrStringMapPropertyDifference : Fox.Core.PropertyDifference
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Core.Entity> originalValues { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.Entity>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Core.Entity> values { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.Entity>();
		
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
		static EntityPtrStringMapPropertyDifference()
		{
			if (Fox.Core.PropertyDifference.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("EntityPtrStringMapPropertyDifference"), typeof(EntityPtrStringMapPropertyDifference), Fox.Core.PropertyDifference.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("originalValues"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 72, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, typeof(Fox.Core.Entity), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("values"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, typeof(Fox.Core.Entity), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public EntityPtrStringMapPropertyDifference(ulong id) : base(id) { }
		public EntityPtrStringMapPropertyDifference() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "originalValues":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)originalValues);
				case "values":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)values);
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
				case "originalValues":
					return new Fox.Core.Value(this.originalValues[key]);
				case "values":
					return new Fox.Core.Value(this.values[key]);
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
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "originalValues":
					if (this.originalValues.ContainsKey(key))
						this.originalValues[key] = value.GetValueAsEntityPtr<Fox.Core.Entity>();
					else
						this.originalValues.Insert(key, value.GetValueAsEntityPtr<Fox.Core.Entity>());
					return;
				case "values":
					if (this.values.ContainsKey(key))
						this.values[key] = value.GetValueAsEntityPtr<Fox.Core.Entity>();
					else
						this.values.Insert(key, value.GetValueAsEntityPtr<Fox.Core.Entity>());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}