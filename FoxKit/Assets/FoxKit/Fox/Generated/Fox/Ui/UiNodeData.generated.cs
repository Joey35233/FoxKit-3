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
    public partial class UiNodeData : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.DynamicArray<Fox.Core.EntityLink> inputEdges = new Fox.Core.DynamicArray<Fox.Core.EntityLink>();
        
        public Fox.Core.DynamicArray<Fox.Core.EntityLink> outputEdges = new Fox.Core.DynamicArray<Fox.Core.EntityLink>();
        
        public uint inputPortCount;
        
        public Fox.Core.DynamicArray<UiNodeType> inputPortTypes = new Fox.Core.DynamicArray<UiNodeType>();
        
        public Fox.Core.DynamicArray<Fox.String> inputPropertyNames = new Fox.Core.DynamicArray<Fox.String>();
        
        public Fox.Core.DynamicArray<UiNodePropType> inputPropertyTypes = new Fox.Core.DynamicArray<UiNodePropType>();
        
        public uint outputPortCount;
        
        public Fox.Core.DynamicArray<UiNodeType> outputPortTypes = new Fox.Core.DynamicArray<UiNodeType>();
        
        public Fox.Core.DynamicArray<Fox.String> outputPropertyNames = new Fox.Core.DynamicArray<Fox.String>();
        
        public Fox.Core.DynamicArray<UiNodePropType> outputPropertyTypes = new Fox.Core.DynamicArray<UiNodePropType>();
        
        public float xPosition;
        
        public float yPosition;
        
        public int category;
        
        public UiNodeType type;
        
        public Fox.String nodeName;
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public  override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static UiNodeData()
        {
            classInfo = new Fox.EntityInfo("UiNodeData", new Fox.Core.Data().GetClassEntityInfo(), 0, "UiG", 2);
			
			classInfo.StaticProperties.Insert("inputEdges", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("outputEdges", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("inputPortCount", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("inputPortTypes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 160, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, typeof(UiNodeType), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("inputPropertyNames", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 176, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("inputPropertyTypes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 192, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, typeof(UiNodePropType), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("outputPortCount", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("outputPortTypes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 216, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, typeof(UiNodeType), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("outputPropertyNames", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 232, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("outputPropertyTypes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 248, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, typeof(UiNodePropType), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("xPosition", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 264, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("yPosition", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 268, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("category", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 272, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("type", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 276, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, typeof(UiNodeType), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("nodeName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 288, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public UiNodeData(ulong address, ulong id) : base(address, id) { }
		public UiNodeData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
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
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
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
                    while(this.inputPropertyNames.Count <= index) { this.inputPropertyNames.Add(default(Fox.String)); }
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
                    while(this.outputPropertyNames.Count <= index) { this.outputPropertyNames.Add(default(Fox.String)); }
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
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}