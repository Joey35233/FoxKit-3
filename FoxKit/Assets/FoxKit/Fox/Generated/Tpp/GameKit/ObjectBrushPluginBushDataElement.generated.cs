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

namespace Tpp.GameKit
{
    [UnityEditor.InitializeOnLoad]
    public partial class ObjectBrushPluginBushDataElement : Fox.Core.DataElement 
    {
        // Properties
        public Fox.Core.DynamicArray<Fox.String> lodMeshName = new Fox.Core.DynamicArray<Fox.String>();
        
        public Fox.Core.DynamicArray<float> lodDistance = new Fox.Core.DynamicArray<float>();
        
        public Fox.Core.DynamicArray<float> lodDistanceHighEnd = new Fox.Core.DynamicArray<float>();
        
        public float rotationRate;
        
        public float elasticRate;
        
        public float alphaMinimizeDist;
        
        public float alphaMaximizeDist;
        
        public float baseDensity;
        
        public float camoufDensity;
        
        public float camofRadius;
        
        public float camofHeight;
        
        public float modelRadius;
        
        public float stopEyeRadius;
        
        public float stopEyeHeight;
        
        public Fox.String noiseSeType;
        
        public uint bushFlags;
        
        public float baseCycleSpeedRate;
        
        public float windAmplitude;
        
        public bool windDirYAxisFixZero;
        
        public float windOffsetFactor;
        
        public Fox.Core.FilePtr<Fox.Core.File> bulletEffect;
        
        public Fox.Core.FilePtr<Fox.Core.File> fairEffect;
        
        public Fox.Core.FilePtr<Fox.Core.File> rainEffect;
        
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
        static ObjectBrushPluginBushDataElement()
        {
            classInfo = new Fox.EntityInfo("ObjectBrushPluginBushDataElement", typeof(ObjectBrushPluginBushDataElement), new Fox.Core.DataElement().GetClassEntityInfo(), 224, null, 20);
			classInfo.StaticProperties.Insert("lodMeshName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 56, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lodDistance", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 72, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lodDistanceHighEnd", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 88, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rotationRate", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("elasticRate", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 116, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("alphaMinimizeDist", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("alphaMaximizeDist", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("baseDensity", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("camoufDensity", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 108, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("camofRadius", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("camofHeight", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("modelRadius", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("stopEyeRadius", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 140, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("stopEyeHeight", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("noiseSeType", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("bushFlags", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("baseCycleSpeedRate", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("windAmplitude", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("windDirYAxisFixZero", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("windOffsetFactor", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("bulletEffect", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("fairEffect", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rainEffect", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public ObjectBrushPluginBushDataElement(ulong id) : base(id) { }
		public ObjectBrushPluginBushDataElement() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "rotationRate":
                    this.rotationRate = value.GetValueAsFloat();
                    return;
                case "elasticRate":
                    this.elasticRate = value.GetValueAsFloat();
                    return;
                case "alphaMinimizeDist":
                    this.alphaMinimizeDist = value.GetValueAsFloat();
                    return;
                case "alphaMaximizeDist":
                    this.alphaMaximizeDist = value.GetValueAsFloat();
                    return;
                case "baseDensity":
                    this.baseDensity = value.GetValueAsFloat();
                    return;
                case "camoufDensity":
                    this.camoufDensity = value.GetValueAsFloat();
                    return;
                case "camofRadius":
                    this.camofRadius = value.GetValueAsFloat();
                    return;
                case "camofHeight":
                    this.camofHeight = value.GetValueAsFloat();
                    return;
                case "modelRadius":
                    this.modelRadius = value.GetValueAsFloat();
                    return;
                case "stopEyeRadius":
                    this.stopEyeRadius = value.GetValueAsFloat();
                    return;
                case "stopEyeHeight":
                    this.stopEyeHeight = value.GetValueAsFloat();
                    return;
                case "noiseSeType":
                    this.noiseSeType = value.GetValueAsString();
                    return;
                case "bushFlags":
                    this.bushFlags = value.GetValueAsUInt32();
                    return;
                case "baseCycleSpeedRate":
                    this.baseCycleSpeedRate = value.GetValueAsFloat();
                    return;
                case "windAmplitude":
                    this.windAmplitude = value.GetValueAsFloat();
                    return;
                case "windDirYAxisFixZero":
                    this.windDirYAxisFixZero = value.GetValueAsBool();
                    return;
                case "windOffsetFactor":
                    this.windOffsetFactor = value.GetValueAsFloat();
                    return;
                case "bulletEffect":
                    this.bulletEffect = value.GetValueAsFilePtr();
                    return;
                case "fairEffect":
                    this.fairEffect = value.GetValueAsFilePtr();
                    return;
                case "rainEffect":
                    this.rainEffect = value.GetValueAsFilePtr();
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
                case "lodMeshName":
                    while(this.lodMeshName.Count <= index) { this.lodMeshName.Add(default(Fox.String)); }
                    this.lodMeshName[index] = value.GetValueAsString();
                    return;
                case "lodDistance":
                    while(this.lodDistance.Count <= index) { this.lodDistance.Add(default(float)); }
                    this.lodDistance[index] = value.GetValueAsFloat();
                    return;
                case "lodDistanceHighEnd":
                    while(this.lodDistanceHighEnd.Count <= index) { this.lodDistanceHighEnd.Add(default(float)); }
                    this.lodDistanceHighEnd[index] = value.GetValueAsFloat();
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