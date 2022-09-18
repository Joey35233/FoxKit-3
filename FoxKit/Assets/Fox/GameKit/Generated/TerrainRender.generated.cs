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
    public partial class TerrainRender : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.Path filePath { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.Path loadFilePath { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.Path dummyFilePath { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr filePtr { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float meterPerOneRepeat { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float meterPerPixel { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isWireFrame { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool lodFlag { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isDebugMaterial { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StaticArray<Fox.Core.EntityLink> materials { get; set; } = new Fox.Kernel.StaticArray<Fox.Core.EntityLink>(16);
        
        [field: UnityEngine.SerializeField]
        public float lodParam { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.EntityLink> materialConfigs { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityLink>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.Path packedAlbedoTexturePath { get; protected set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.Path packedNormalTexturePath { get; protected set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.Path packedSrmTexturePath { get; protected set; }
        
        [field: UnityEngine.SerializeField]
        public ulong packedMaterialIdentify { get; protected set; }
        
        [field: UnityEngine.SerializeField]
        public bool isFourceUsePackedMaterialTexture { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.Path baseColorTexture { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float materialLodScale { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float materialLodNearOffset { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float materialLodFarOffset { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float materialLodHeightOffset { get; set; }
        
        [field: UnityEngine.SerializeField]
        public WolrdTerrainTextureMode worldTextureMode { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint worldTextureDividedNumX { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint worldTextureDividedNumZ { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Kernel.Path> worldTextureTilePathes { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.Path>();
        
        // PropertyInfo
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
        static TerrainRender()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TerrainRender"), typeof(TerrainRender), new Fox.Core.TransformData().GetClassEntityInfo(), 960, null, 9);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("filePath"), Fox.Core.PropertyInfo.PropertyType.Path, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("loadFilePath"), Fox.Core.PropertyInfo.PropertyType.Path, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("dummyFilePath"), Fox.Core.PropertyInfo.PropertyType.Path, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("filePtr"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 968, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("meterPerOneRepeat"), Fox.Core.PropertyInfo.PropertyType.Float, 996, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("meterPerPixel"), Fox.Core.PropertyInfo.PropertyType.Float, 1000, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isWireFrame"), Fox.Core.PropertyInfo.PropertyType.Bool, 992, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lodFlag"), Fox.Core.PropertyInfo.PropertyType.Bool, 993, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isDebugMaterial"), Fox.Core.PropertyInfo.PropertyType.Bool, 1004, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("materials"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 328, 16, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lodParam"), Fox.Core.PropertyInfo.PropertyType.Float, 1008, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("materialConfigs"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 1080, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("packedAlbedoTexturePath"), Fox.Core.PropertyInfo.PropertyType.Path, 1104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("packedNormalTexturePath"), Fox.Core.PropertyInfo.PropertyType.Path, 1112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("packedSrmTexturePath"), Fox.Core.PropertyInfo.PropertyType.Path, 1120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("packedMaterialIdentify"), Fox.Core.PropertyInfo.PropertyType.UInt64, 1096, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isFourceUsePackedMaterialTexture"), Fox.Core.PropertyInfo.PropertyType.Bool, 1072, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("baseColorTexture"), Fox.Core.PropertyInfo.PropertyType.Path, 1016, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("materialLodScale"), Fox.Core.PropertyInfo.PropertyType.Float, 1024, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("materialLodNearOffset"), Fox.Core.PropertyInfo.PropertyType.Float, 1032, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("materialLodFarOffset"), Fox.Core.PropertyInfo.PropertyType.Float, 1028, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("materialLodHeightOffset"), Fox.Core.PropertyInfo.PropertyType.Float, 1036, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("worldTextureMode"), Fox.Core.PropertyInfo.PropertyType.Int32, 1044, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(WolrdTerrainTextureMode), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("worldTextureDividedNumX"), Fox.Core.PropertyInfo.PropertyType.UInt32, 1048, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("worldTextureDividedNumZ"), Fox.Core.PropertyInfo.PropertyType.UInt32, 1052, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("worldTextureTilePathes"), Fox.Core.PropertyInfo.PropertyType.Path, 1056, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TerrainRender(ulong id) : base(id) { }
		public TerrainRender() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
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
                case "filePtr":
                    this.filePtr = value.GetValueAsFilePtr();
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
                case "isDebugMaterial":
                    this.isDebugMaterial = value.GetValueAsBool();
                    return;
                case "lodParam":
                    this.lodParam = value.GetValueAsFloat();
                    return;
                case "packedAlbedoTexturePath":
                    this.packedAlbedoTexturePath = value.GetValueAsPath();
                    return;
                case "packedNormalTexturePath":
                    this.packedNormalTexturePath = value.GetValueAsPath();
                    return;
                case "packedSrmTexturePath":
                    this.packedSrmTexturePath = value.GetValueAsPath();
                    return;
                case "packedMaterialIdentify":
                    this.packedMaterialIdentify = value.GetValueAsUInt64();
                    return;
                case "isFourceUsePackedMaterialTexture":
                    this.isFourceUsePackedMaterialTexture = value.GetValueAsBool();
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
                case "worldTextureMode":
                    this.worldTextureMode = (WolrdTerrainTextureMode)value.GetValueAsInt32();
                    return;
                case "worldTextureDividedNumX":
                    this.worldTextureDividedNumX = value.GetValueAsUInt32();
                    return;
                case "worldTextureDividedNumZ":
                    this.worldTextureDividedNumZ = value.GetValueAsUInt32();
                    return;
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "materials":
                    
                    this.materials[index] = value.GetValueAsEntityLink();
                    return;
                case "materialConfigs":
                    while(this.materialConfigs.Count <= index) { this.materialConfigs.Add(default(Fox.Core.EntityLink)); }
                    this.materialConfigs[index] = value.GetValueAsEntityLink();
                    return;
                case "worldTextureTilePathes":
                    while(this.worldTextureTilePathes.Count <= index) { this.worldTextureTilePathes.Add(default(Fox.Kernel.Path)); }
                    this.worldTextureTilePathes[index] = value.GetValueAsPath();
                    return;
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}