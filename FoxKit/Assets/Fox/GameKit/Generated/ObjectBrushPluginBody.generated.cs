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
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("FoxGameKit/ObjectBrushPluginBody")]
	public partial class ObjectBrushPluginBody : Fox.Core.DataBody
	{
		// Properties
		[field: UnityEngine.SerializeField]
		private new string name { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string pluginName { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string modelName { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string thumbnailPath { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint numObjects { get; set; }
		
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
		static ObjectBrushPluginBody()
		{
			if (Fox.Core.DataBody.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("ObjectBrushPluginBody", typeof(ObjectBrushPluginBody), Fox.Core.DataBody.ClassInfo, 0, "ObjectBrush", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("name", Fox.Core.PropertyInfo.PropertyType.String, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("pluginName", Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("modelName", Fox.Core.PropertyInfo.PropertyType.String, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("thumbnailPath", Fox.Core.PropertyInfo.PropertyType.String, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("numObjects", Fox.Core.PropertyInfo.PropertyType.UInt32, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "name":
					return new Fox.Core.Value(name);
				case "pluginName":
					return new Fox.Core.Value(pluginName);
				case "modelName":
					return new Fox.Core.Value(modelName);
				case "thumbnailPath":
					return new Fox.Core.Value(thumbnailPath);
				case "numObjects":
					return new Fox.Core.Value(numObjects);
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
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(string propertyName, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "name":
					this.name = value.GetValueAsString();
					return;
				case "pluginName":
					this.pluginName = value.GetValueAsString();
					return;
				case "modelName":
					this.modelName = value.GetValueAsString();
					return;
				case "thumbnailPath":
					this.thumbnailPath = value.GetValueAsString();
					return;
				case "numObjects":
					this.numObjects = value.GetValueAsUInt32();
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