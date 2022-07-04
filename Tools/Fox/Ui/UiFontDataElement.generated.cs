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
    public partial class UiFontDataElement : Fox.Core.DataElement 
    {
        // Properties
        public Fox.String language;
        
        public Fox.String fontName;
        
        public Fox.Core.FilePtr<Fox.Core.File> fontFile;
        
        public Fox.Core.Path texturePath;
        
        public float fontWidth;
        
        public float fontHeight;
        
        public float textSpace;
        
        public float lineSpace;
        
        public UnityEngine.Vector4 fontEdge;
        
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
        static UiFontDataElement()
        {
            classInfo = new Fox.EntityInfo("UiFontDataElement", typeof(UiFontDataElement), new Fox.Core.DataElement().GetClassEntityInfo(), 128, null, 2);
			classInfo.StaticProperties.Insert("language", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("fontName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("fontFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("texturePath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("fontWidth", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("fontHeight", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 108, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("textSpace", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lineSpace", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 116, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("fontEdge", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector4, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public UiFontDataElement(ulong address, ulong id) : base(address, id) { }
		public UiFontDataElement() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "language":
                    this.language = value.GetValueAsString();
                    return;
                case "fontName":
                    this.fontName = value.GetValueAsString();
                    return;
                case "fontFile":
                    this.fontFile = value.GetValueAsFilePtr();
                    return;
                case "texturePath":
                    this.texturePath = value.GetValueAsPath();
                    return;
                case "fontWidth":
                    this.fontWidth = value.GetValueAsFloat();
                    return;
                case "fontHeight":
                    this.fontHeight = value.GetValueAsFloat();
                    return;
                case "textSpace":
                    this.textSpace = value.GetValueAsFloat();
                    return;
                case "lineSpace":
                    this.lineSpace = value.GetValueAsFloat();
                    return;
                case "fontEdge":
                    this.fontEdge = value.GetValueAsVector4();
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