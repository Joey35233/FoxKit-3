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
    [UnityEditor.InitializeOnLoad]
    public partial class UiLayoutData : Fox.Core.TransformData 
    {
        // Properties
        public Fox.Core.Path layoutPath;
        
        public UnityEngine.Color color;
        
        public bool visible;
        
        public int drawPriority;
        
        public Fox.Core.EntityHandle connection_connectModelDataHandle;
        
        public Fox.String connection_connectModelNodeName;
        
        public bool useParentCamera;
        
        public int fontTableIndex;
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static UiLayoutData()
        {
            classInfo = new Fox.EntityInfo("UiLayoutData", typeof(UiLayoutData), new Fox.Core.TransformData().GetClassEntityInfo(), 0, "Ui", 6);
			classInfo.StaticProperties.Insert("layoutPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("color", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Color, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("visible", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("drawPriority", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 340, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("connection_connectModelDataHandle", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityHandle, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("connection_connectModelNodeName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 360, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("useParentCamera", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("fontTableIndex", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 372, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public UiLayoutData(ulong address, ulong id) : base(address, id) { }
		public UiLayoutData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "layoutPath":
                    this.layoutPath = value.GetValueAsPath();
                    return;
                case "color":
                    this.color = value.GetValueAsColor();
                    return;
                case "visible":
                    this.visible = value.GetValueAsBool();
                    return;
                case "drawPriority":
                    this.drawPriority = value.GetValueAsInt32();
                    return;
                case "connection_connectModelDataHandle":
                    this.connection_connectModelDataHandle = value.GetValueAsEntityHandle();
                    return;
                case "connection_connectModelNodeName":
                    this.connection_connectModelNodeName = value.GetValueAsString();
                    return;
                case "useParentCamera":
                    this.useParentCamera = value.GetValueAsBool();
                    return;
                case "fontTableIndex":
                    this.fontTableIndex = value.GetValueAsInt32();
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