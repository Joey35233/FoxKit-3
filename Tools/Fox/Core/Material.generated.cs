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
    public partial class Material : Fox.Core.Data 
    {
        // Properties
        public Fox.String materialName;
        
        public Fox.Core.Path shader;
        
        public Fox.Core.Path diffuseTexture;
        
        public Fox.Core.Path srmTexture;
        
        public Fox.Core.Path normalTexture;
        
        public Fox.Core.Path materialMapTexture;
        
        public byte materialIndex;
        
        public UnityEngine.Color diffuseColor;
        
        public UnityEngine.Color specularColor;
        
        public Fox.Core.Path fmtrPath;
        
        public bool residentFlag;
        
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
        static Material()
        {
            classInfo = new Fox.EntityInfo("Material", typeof(Material), new Fox.Core.Data().GetClassEntityInfo(), 176, "Material", 6);
			classInfo.StaticProperties.Insert("materialName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("shader", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("diffuseTexture", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("srmTexture", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("normalTexture", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("materialMapTexture", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("materialIndex", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("diffuseColor", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Color, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("specularColor", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Color, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("fmtrPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("residentFlag", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public Material(ulong id) : base(id) { }
		public Material() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "materialName":
                    this.materialName = value.GetValueAsString();
                    return;
                case "shader":
                    this.shader = value.GetValueAsPath();
                    return;
                case "diffuseTexture":
                    this.diffuseTexture = value.GetValueAsPath();
                    return;
                case "srmTexture":
                    this.srmTexture = value.GetValueAsPath();
                    return;
                case "normalTexture":
                    this.normalTexture = value.GetValueAsPath();
                    return;
                case "materialMapTexture":
                    this.materialMapTexture = value.GetValueAsPath();
                    return;
                case "materialIndex":
                    this.materialIndex = value.GetValueAsUInt8();
                    return;
                case "diffuseColor":
                    this.diffuseColor = value.GetValueAsColor();
                    return;
                case "specularColor":
                    this.specularColor = value.GetValueAsColor();
                    return;
                case "fmtrPath":
                    this.fmtrPath = value.GetValueAsPath();
                    return;
                case "residentFlag":
                    this.residentFlag = value.GetValueAsBool();
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