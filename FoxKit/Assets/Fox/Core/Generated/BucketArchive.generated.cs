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
	public partial class BucketArchive : Fox.Core.Entity
	{
		// Properties
		[field: UnityEngine.SerializeField]
		private new Fox.Kernel.String name { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.StringMap<Fox.Core.FilePtr> dataSetFiles { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.StringMap<Fox.Core.DataBodySet> dataBodySets { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.DataBodySet>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Core.DataBodySet editableDataBodySet { get; set; }
		
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
		static BucketArchive()
		{
			if (Fox.Core.Entity.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("BucketArchive"), typeof(BucketArchive), Fox.Core.Entity.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("name"), Fox.Core.PropertyInfo.PropertyType.String, 48, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("dataSetFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 56, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("dataBodySets"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 104, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.DataBodySet), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("editableDataBodySet"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.DataBodySet), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public BucketArchive(ulong id) : base(id) { }
		public BucketArchive() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "name":
					return new Fox.Core.Value(name);
				case "dataSetFiles":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)dataSetFiles);
				case "dataBodySets":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)dataBodySets);
				case "editableDataBodySet":
					return new Fox.Core.Value(editableDataBodySet);
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
				case "dataSetFiles":
					return new Fox.Core.Value(this.dataSetFiles[key]);
				case "dataBodySets":
					return new Fox.Core.Value(this.dataBodySets[key]);
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "name":
					this.name = value.GetValueAsString();
					return;
				case "editableDataBodySet":
					this.editableDataBodySet = value.GetValueAsEntityPtr<Fox.Core.DataBodySet>();
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
				case "dataSetFiles":
					this.dataSetFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "dataBodySets":
					this.dataBodySets.Insert(key, value.GetValueAsEntityPtr<Fox.Core.DataBodySet>());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}