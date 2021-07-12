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

namespace Fox.UiScene
{
    public partial class UiModelData : Fox.Core.TransformData 
    {
        // Properties
        public Fox.Core.FilePtr<Fox.Core.File> data;
        
        public Fox.String sceneName;
        
        public int priority;
        
        public Fox.Core.DynamicArray<Fox.Core.EntityLink> animations = new Fox.Core.DynamicArray<Fox.Core.EntityLink>();
        
        public bool useLayoutCamera;
        
        public UiModelDataFlag flag;
        
        public float billboardMin;
        
        public float billboardMax;
        
        public Fox.Core.EntityHandle connection_connectModelDataHandle;
        
        public Fox.String connection_connectModelNodeName;
        
        public UnityEngine.Color color;
        
        public UiInheritanceSetting inheritanceSetting;
        
        public Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.UiScene.UiModelNodeElement>> modelNodes = new Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.UiScene.UiModelNodeElement>>();
        
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
        static UiModelData()
        {
            classInfo = new Fox.EntityInfo("UiModelData", new Fox.Core.TransformData(0, 0, 0).GetClassEntityInfo(), 0, "Ui", 6);
			
			classInfo.StaticProperties.Insert("data", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("sceneName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("priority", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("animations", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 344, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("useLayoutCamera", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 360, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("flag", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 364, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(UiModelDataFlag), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("billboardMin", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("billboardMax", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 372, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("connection_connectModelDataHandle", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityHandle, 384, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("connection_connectModelNodeName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 392, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("color", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Color, 400, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("inheritanceSetting", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 416, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(UiInheritanceSetting), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("modelNodes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 424, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.UiScene.UiModelNodeElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public UiModelData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "data":
                    this.data = value.GetValueAsFilePtr();
                    return;
                case "sceneName":
                    this.sceneName = value.GetValueAsString();
                    return;
                case "priority":
                    this.priority = value.GetValueAsInt32();
                    return;
                case "useLayoutCamera":
                    this.useLayoutCamera = value.GetValueAsBool();
                    return;
                case "flag":
                    this.flag = (UiModelDataFlag)value.GetValueAsUInt32();
                    return;
                case "billboardMin":
                    this.billboardMin = value.GetValueAsFloat();
                    return;
                case "billboardMax":
                    this.billboardMax = value.GetValueAsFloat();
                    return;
                case "connection_connectModelDataHandle":
                    this.connection_connectModelDataHandle = value.GetValueAsEntityHandle();
                    return;
                case "connection_connectModelNodeName":
                    this.connection_connectModelNodeName = value.GetValueAsString();
                    return;
                case "color":
                    this.color = value.GetValueAsColor();
                    return;
                case "inheritanceSetting":
                    this.inheritanceSetting = (UiInheritanceSetting)value.GetValueAsUInt32();
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
                case "animations":
                    while(this.animations.Count <= index) { this.animations.Add(default(Fox.Core.EntityLink)); }
                    this.animations[index] = value.GetValueAsEntityLink();
                    return;
                case "modelNodes":
                    while(this.modelNodes.Count <= index) { this.modelNodes.Add(default(Fox.Core.EntityPtr<Fox.UiScene.UiModelNodeElement>)); }
                    this.modelNodes[index] = value.GetValueAsEntityPtr<Fox.UiScene.UiModelNodeElement>();
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