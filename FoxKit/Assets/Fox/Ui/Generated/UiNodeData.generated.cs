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

namespace Fox.Ui
{
	[UnityEditor.InitializeOnLoad]
	public partial class UiNodeData : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<Fox.Core.EntityLink> inputEdges { get; private set; } = new Fox.DynamicArray<Fox.Core.EntityLink>();
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<Fox.Core.EntityLink> outputEdges { get; private set; } = new Fox.DynamicArray<Fox.Core.EntityLink>();
		
		[field: UnityEngine.SerializeField]
		public uint inputPortCount { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<UiNodeType> inputPortTypes { get; private set; } = new Fox.DynamicArray<UiNodeType>();
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<string> inputPropertyNames { get; private set; } = new Fox.DynamicArray<string>();
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<UiNodePropType> inputPropertyTypes { get; private set; } = new Fox.DynamicArray<UiNodePropType>();
		
		[field: UnityEngine.SerializeField]
		public uint outputPortCount { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<UiNodeType> outputPortTypes { get; private set; } = new Fox.DynamicArray<UiNodeType>();
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<string> outputPropertyNames { get; private set; } = new Fox.DynamicArray<string>();
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<UiNodePropType> outputPropertyTypes { get; private set; } = new Fox.DynamicArray<UiNodePropType>();
		
		[field: UnityEngine.SerializeField]
		public float xPosition { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float yPosition { get; set; }
		
		[field: UnityEngine.SerializeField]
		public int category { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UiNodeType type { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string nodeName { get; set; }
		
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
		static UiNodeData()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("UiNodeData", typeof(UiNodeData), Fox.Core.Data.ClassInfo, 0, "UiG", 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("inputEdges", Fox.Core.PropertyInfo.PropertyType.EntityLink, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("outputEdges", Fox.Core.PropertyInfo.PropertyType.EntityLink, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("inputPortCount", Fox.Core.PropertyInfo.PropertyType.UInt32, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("inputPortTypes", Fox.Core.PropertyInfo.PropertyType.Int32, 160, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, typeof(UiNodeType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("inputPropertyNames", Fox.Core.PropertyInfo.PropertyType.String, 176, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("inputPropertyTypes", Fox.Core.PropertyInfo.PropertyType.Int32, 192, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, typeof(UiNodePropType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("outputPortCount", Fox.Core.PropertyInfo.PropertyType.UInt32, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("outputPortTypes", Fox.Core.PropertyInfo.PropertyType.Int32, 216, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, typeof(UiNodeType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("outputPropertyNames", Fox.Core.PropertyInfo.PropertyType.String, 232, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("outputPropertyTypes", Fox.Core.PropertyInfo.PropertyType.Int32, 248, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, typeof(UiNodePropType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("xPosition", Fox.Core.PropertyInfo.PropertyType.Float, 264, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("yPosition", Fox.Core.PropertyInfo.PropertyType.Float, 268, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("category", Fox.Core.PropertyInfo.PropertyType.Int32, 272, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("type", Fox.Core.PropertyInfo.PropertyType.Int32, 276, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, typeof(UiNodeType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("nodeName", Fox.Core.PropertyInfo.PropertyType.String, 288, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "inputEdges":
					return new Fox.Core.Value(inputEdges);
				case "outputEdges":
					return new Fox.Core.Value(outputEdges);
				case "inputPortCount":
					return new Fox.Core.Value(inputPortCount);
				case "inputPortTypes":
					return new Fox.Core.Value(inputPortTypes);
				case "inputPropertyNames":
					return new Fox.Core.Value(inputPropertyNames);
				case "inputPropertyTypes":
					return new Fox.Core.Value(inputPropertyTypes);
				case "outputPortCount":
					return new Fox.Core.Value(outputPortCount);
				case "outputPortTypes":
					return new Fox.Core.Value(outputPortTypes);
				case "outputPropertyNames":
					return new Fox.Core.Value(outputPropertyNames);
				case "outputPropertyTypes":
					return new Fox.Core.Value(outputPropertyTypes);
				case "xPosition":
					return new Fox.Core.Value(xPosition);
				case "yPosition":
					return new Fox.Core.Value(yPosition);
				case "category":
					return new Fox.Core.Value(category);
				case "type":
					return new Fox.Core.Value(type);
				case "nodeName":
					return new Fox.Core.Value(nodeName);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "inputEdges":
					return new Fox.Core.Value(this.inputEdges[index]);
				case "outputEdges":
					return new Fox.Core.Value(this.outputEdges[index]);
				case "inputPortTypes":
					return new Fox.Core.Value(this.inputPortTypes[index]);
				case "inputPropertyNames":
					return new Fox.Core.Value(this.inputPropertyNames[index]);
				case "inputPropertyTypes":
					return new Fox.Core.Value(this.inputPropertyTypes[index]);
				case "outputPortTypes":
					return new Fox.Core.Value(this.outputPortTypes[index]);
				case "outputPropertyNames":
					return new Fox.Core.Value(this.outputPropertyNames[index]);
				case "outputPropertyTypes":
					return new Fox.Core.Value(this.outputPropertyTypes[index]);
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
				case "inputPortCount":
					this.inputPortCount = value.GetValueAsUInt32();
					return;
				case "outputPortCount":
					this.outputPortCount = value.GetValueAsUInt32();
					return;
				case "xPosition":
					this.xPosition = value.GetValueAsFloat();
					return;
				case "yPosition":
					this.yPosition = value.GetValueAsFloat();
					return;
				case "category":
					this.category = value.GetValueAsInt32();
					return;
				case "type":
					this.type = (UiNodeType)value.GetValueAsInt32();
					return;
				case "nodeName":
					this.nodeName = value.GetValueAsString();
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
				case "inputEdges":
					while(this.inputEdges.Count <= index) { this.inputEdges.Add(default(Fox.Core.EntityLink)); }
					this.inputEdges[index] = value.GetValueAsEntityLink();
					return;
				case "outputEdges":
					while(this.outputEdges.Count <= index) { this.outputEdges.Add(default(Fox.Core.EntityLink)); }
					this.outputEdges[index] = value.GetValueAsEntityLink();
					return;
				case "inputPortTypes":
					while(this.inputPortTypes.Count <= index) { this.inputPortTypes.Add(default(UiNodeType)); }
					this.inputPortTypes[index] = (UiNodeType)value.GetValueAsInt32();
					return;
				case "inputPropertyNames":
					while(this.inputPropertyNames.Count <= index) { this.inputPropertyNames.Add(default(string)); }
					this.inputPropertyNames[index] = value.GetValueAsString();
					return;
				case "inputPropertyTypes":
					while(this.inputPropertyTypes.Count <= index) { this.inputPropertyTypes.Add(default(UiNodePropType)); }
					this.inputPropertyTypes[index] = (UiNodePropType)value.GetValueAsInt32();
					return;
				case "outputPortTypes":
					while(this.outputPortTypes.Count <= index) { this.outputPortTypes.Add(default(UiNodeType)); }
					this.outputPortTypes[index] = (UiNodeType)value.GetValueAsInt32();
					return;
				case "outputPropertyNames":
					while(this.outputPropertyNames.Count <= index) { this.outputPropertyNames.Add(default(string)); }
					this.outputPropertyNames[index] = value.GetValueAsString();
					return;
				case "outputPropertyTypes":
					while(this.outputPropertyTypes.Count <= index) { this.outputPropertyTypes.Add(default(UiNodePropType)); }
					this.outputPropertyTypes[index] = (UiNodePropType)value.GetValueAsInt32();
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