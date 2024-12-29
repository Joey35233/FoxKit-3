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
	public partial class Bucket : Fox.Core.Entity
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected Fox.Core.Entity collector { get; set; }
		
		[field: UnityEngine.SerializeField]
		private new string name { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string sceneName { get; protected set; }
		
		[field: UnityEngine.SerializeField]
		protected Fox.DynamicArray<Fox.Core.Actor> actors { get; private set; } = new Fox.DynamicArray<Fox.Core.Actor>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.StringMap<Fox.Core.FilePtr> dataSetFiles { get; private set; } = new Fox.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.StringMap<Fox.Core.DataBodySet> dataBodySets { get; private set; } = new Fox.StringMap<Fox.Core.DataBodySet>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Core.DataSet editableDataSet { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected Fox.Path editableDataSetPath { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected Fox.Core.DataBodySet editableDataBodySet { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected bool editableDataSetChanged { get; set; }
		
		public bool isEditableLocked { get => Get_isEditableLocked(); set { Set_isEditableLocked(value); } }
		private partial bool Get_isEditableLocked();
		private partial void Set_isEditableLocked(bool value);
		
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
		static Bucket()
		{
			if (Fox.Core.Entity.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("Bucket", typeof(Bucket), Fox.Core.Entity.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("collector", Fox.Core.PropertyInfo.PropertyType.EntityHandle, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("name", Fox.Core.PropertyInfo.PropertyType.String, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("sceneName", Fox.Core.PropertyInfo.PropertyType.String, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("actors", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 88, 1, Fox.Core.PropertyInfo.ContainerType.List, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.Actor), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dataSetFiles", Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dataBodySets", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 168, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.DataBodySet), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("editableDataSet", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.DataSet), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("editableDataSetPath", Fox.Core.PropertyInfo.PropertyType.Path, 232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("editableDataBodySet", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 240, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.DataBodySet), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("editableDataSetChanged", Fox.Core.PropertyInfo.PropertyType.Bool, 248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isEditableLocked", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "collector":
					return new Fox.Core.Value(collector);
				case "name":
					return new Fox.Core.Value(name);
				case "sceneName":
					return new Fox.Core.Value(sceneName);
				case "actors":
					return new Fox.Core.Value(actors);
				case "dataSetFiles":
					return new Fox.Core.Value((Fox.IStringMap)dataSetFiles);
				case "dataBodySets":
					return new Fox.Core.Value((Fox.IStringMap)dataBodySets);
				case "editableDataSet":
					return new Fox.Core.Value(editableDataSet);
				case "editableDataSetPath":
					return new Fox.Core.Value(editableDataSetPath);
				case "editableDataBodySet":
					return new Fox.Core.Value(editableDataBodySet);
				case "editableDataSetChanged":
					return new Fox.Core.Value(editableDataSetChanged);
				case "isEditableLocked":
					return new Fox.Core.Value(isEditableLocked);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "actors":
					return new Fox.Core.Value(this.actors[index]);
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, string key)
		{
			switch (propertyName)
			{
				case "dataSetFiles":
					return new Fox.Core.Value(this.dataSetFiles[key]);
				case "dataBodySets":
					return new Fox.Core.Value(this.dataBodySets[key]);
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(string propertyName, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "collector":
					this.collector = value.GetValueAsEntityHandle();
					return;
				case "name":
					this.name = value.GetValueAsString();
					return;
				case "sceneName":
					this.sceneName = value.GetValueAsString();
					return;
				case "editableDataSet":
					this.editableDataSet = value.GetValueAsEntityPtr<Fox.Core.DataSet>();
					return;
				case "editableDataSetPath":
					this.editableDataSetPath = value.GetValueAsPath();
					return;
				case "editableDataBodySet":
					this.editableDataBodySet = value.GetValueAsEntityPtr<Fox.Core.DataBodySet>();
					return;
				case "editableDataSetChanged":
					this.editableDataSetChanged = value.GetValueAsBool();
					return;
				case "isEditableLocked":
					this.isEditableLocked = value.GetValueAsBool();
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
				case "actors":
					while(this.actors.Count <= index) { this.actors.Add(default(Fox.Core.Actor)); }
					this.actors[index] = value.GetValueAsEntityPtr<Fox.Core.Actor>();
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
				case "dataSetFiles":
					if (this.dataSetFiles.ContainsKey(key))
						this.dataSetFiles[key] = value.GetValueAsFilePtr();
					else
						this.dataSetFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "dataBodySets":
					if (this.dataBodySets.ContainsKey(key))
						this.dataBodySets[key] = value.GetValueAsEntityPtr<Fox.Core.DataBodySet>();
					else
						this.dataBodySets.Insert(key, value.GetValueAsEntityPtr<Fox.Core.DataBodySet>());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}