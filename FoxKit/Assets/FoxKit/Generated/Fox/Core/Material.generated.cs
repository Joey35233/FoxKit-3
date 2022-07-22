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
        [field: UnityEngine.SerializeField]
        public Fox.Core.String materialName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.Path shader { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.Path diffuseTexture { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.Path srmTexture { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.Path normalTexture { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.Path materialMapTexture { get; set; }
        
        [field: UnityEngine.SerializeField]
        public byte materialIndex { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Color diffuseColor { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Color specularColor { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.Path fmtrPath { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool residentFlag { get; set; }
        
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
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("materialName", Fox.Core.PropertyInfo.PropertyType.String, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("shader", Fox.Core.PropertyInfo.PropertyType.Path, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("diffuseTexture", Fox.Core.PropertyInfo.PropertyType.Path, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("srmTexture", Fox.Core.PropertyInfo.PropertyType.Path, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("normalTexture", Fox.Core.PropertyInfo.PropertyType.Path, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("materialMapTexture", Fox.Core.PropertyInfo.PropertyType.Path, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("materialIndex", Fox.Core.PropertyInfo.PropertyType.UInt8, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("diffuseColor", Fox.Core.PropertyInfo.PropertyType.Color, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("specularColor", Fox.Core.PropertyInfo.PropertyType.Color, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("fmtrPath", Fox.Core.PropertyInfo.PropertyType.Path, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("residentFlag", Fox.Core.PropertyInfo.PropertyType.Bool, 216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public Material(ulong id) : base(id) { }
		public Material() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
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
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
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