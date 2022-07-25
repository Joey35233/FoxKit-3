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
    [UnityEditor.InitializeOnLoad]
    public partial class Terrain : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.Path filePath { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.Path loadFilePath { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.Path dummyFilePath { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float meterPerOneRepeat { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float meterPerPixel { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isWireFrame { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool lodFlag { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isSave { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isDebugMaterial { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.StaticArray<Fox.Core.EntityLink> materials { get; set; } = new Fox.FoxKernel.StaticArray<Fox.Core.EntityLink>(16);
        
        [field: UnityEngine.SerializeField]
        public float lodParam { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.DynamicArray<Fox.Core.EntityLink> materialConfigs { get; set; } = new Fox.FoxKernel.DynamicArray<Fox.Core.EntityLink>();
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.Path baseColorTexture { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float materialLodScale { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float materialLodNearOffset { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float materialLodFarOffset { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float materialLodHeightOffset { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isUseWorldTexture { get; set; }
        
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
        static Terrain()
        {
            classInfo = new Fox.EntityInfo("Terrain", typeof(Terrain), new Fox.Core.TransformData().GetClassEntityInfo(), 0, null, 14);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("filePath", Fox.Core.PropertyInfo.PropertyType.Path, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("loadFilePath", Fox.Core.PropertyInfo.PropertyType.Path, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dummyFilePath", Fox.Core.PropertyInfo.PropertyType.Path, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("meterPerOneRepeat", Fox.Core.PropertyInfo.PropertyType.Float, 972, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("meterPerPixel", Fox.Core.PropertyInfo.PropertyType.Float, 976, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isWireFrame", Fox.Core.PropertyInfo.PropertyType.Bool, 968, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lodFlag", Fox.Core.PropertyInfo.PropertyType.Bool, 969, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isSave", Fox.Core.PropertyInfo.PropertyType.Bool, 980, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isDebugMaterial", Fox.Core.PropertyInfo.PropertyType.Bool, 981, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("materials", Fox.Core.PropertyInfo.PropertyType.EntityLink, 328, 16, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lodParam", Fox.Core.PropertyInfo.PropertyType.Float, 984, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("materialConfigs", Fox.Core.PropertyInfo.PropertyType.EntityLink, 1016, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("baseColorTexture", Fox.Core.PropertyInfo.PropertyType.Path, 992, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("materialLodScale", Fox.Core.PropertyInfo.PropertyType.Float, 1000, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("materialLodNearOffset", Fox.Core.PropertyInfo.PropertyType.Float, 1008, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("materialLodFarOffset", Fox.Core.PropertyInfo.PropertyType.Float, 1004, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("materialLodHeightOffset", Fox.Core.PropertyInfo.PropertyType.Float, 1012, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isUseWorldTexture", Fox.Core.PropertyInfo.PropertyType.Bool, 1032, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public Terrain(ulong id) : base(id) { }
		public Terrain() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "filePath":
                    this.filePath = value.GetValueAsPath();
                    return;
                case "loadFilePath":
                    this.loadFilePath = value.GetValueAsPath();
                    return;
                case "dummyFilePath":
                    this.dummyFilePath = value.GetValueAsPath();
                    return;
                case "meterPerOneRepeat":
                    this.meterPerOneRepeat = value.GetValueAsFloat();
                    return;
                case "meterPerPixel":
                    this.meterPerPixel = value.GetValueAsFloat();
                    return;
                case "isWireFrame":
                    this.isWireFrame = value.GetValueAsBool();
                    return;
                case "lodFlag":
                    this.lodFlag = value.GetValueAsBool();
                    return;
                case "isSave":
                    this.isSave = value.GetValueAsBool();
                    return;
                case "isDebugMaterial":
                    this.isDebugMaterial = value.GetValueAsBool();
                    return;
                case "lodParam":
                    this.lodParam = value.GetValueAsFloat();
                    return;
                case "baseColorTexture":
                    this.baseColorTexture = value.GetValueAsPath();
                    return;
                case "materialLodScale":
                    this.materialLodScale = value.GetValueAsFloat();
                    return;
                case "materialLodNearOffset":
                    this.materialLodNearOffset = value.GetValueAsFloat();
                    return;
                case "materialLodFarOffset":
                    this.materialLodFarOffset = value.GetValueAsFloat();
                    return;
                case "materialLodHeightOffset":
                    this.materialLodHeightOffset = value.GetValueAsFloat();
                    return;
                case "isUseWorldTexture":
                    this.isUseWorldTexture = value.GetValueAsBool();
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
                case "materials":
                    
                    this.materials[index] = value.GetValueAsEntityLink();
                    return;
                case "materialConfigs":
                    while(this.materialConfigs.Count <= index) { this.materialConfigs.Add(default(Fox.Core.EntityLink)); }
                    this.materialConfigs[index] = value.GetValueAsEntityLink();
                    return;
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