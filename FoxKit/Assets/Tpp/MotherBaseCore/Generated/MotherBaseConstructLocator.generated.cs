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

namespace Tpp.MotherBaseCore
{
	[UnityEditor.InitializeOnLoad]
	public partial class MotherBaseConstructLocator : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public int type { get; set; }
		
		[field: UnityEngine.SerializeField]
		public ushort index { get; set; }
		
		[field: UnityEngine.SerializeField]
		public byte clusterId { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool isLowModel { get; set; }
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.Core.EntityLink> staticModels { get; private set; } = new CsSystem.Collections.Generic.List<Fox.Core.EntityLink>();
		
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
		static MotherBaseConstructLocator()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("MotherBaseConstructLocator", typeof(MotherBaseConstructLocator), Fox.Core.TransformData.ClassInfo, 288, "TppMotherBase", 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("type", Fox.Core.PropertyInfo.PropertyType.Int32, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("index", Fox.Core.PropertyInfo.PropertyType.UInt16, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("clusterId", Fox.Core.PropertyInfo.PropertyType.UInt8, 310, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isLowModel", Fox.Core.PropertyInfo.PropertyType.Bool, 311, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("staticModels", Fox.Core.PropertyInfo.PropertyType.EntityLink, 312, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "type":
					return new Fox.Core.Value(type);
				case "index":
					return new Fox.Core.Value(index);
				case "clusterId":
					return new Fox.Core.Value(clusterId);
				case "isLowModel":
					return new Fox.Core.Value(isLowModel);
				case "staticModels":
					return new Fox.Core.Value(staticModels);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "staticModels":
					return new Fox.Core.Value(this.staticModels[index]);
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
				case "type":
					this.type = value.GetValueAsInt32();
					return;
				case "index":
					this.index = value.GetValueAsUInt16();
					return;
				case "clusterId":
					this.clusterId = value.GetValueAsUInt8();
					return;
				case "isLowModel":
					this.isLowModel = value.GetValueAsBool();
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
				case "staticModels":
					while(this.staticModels.Count <= index) { this.staticModels.Add(default(Fox.Core.EntityLink)); }
					this.staticModels[index] = value.GetValueAsEntityLink();
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