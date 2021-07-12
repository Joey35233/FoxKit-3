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

namespace Tpp.Effect
{
    public partial class TppWeatherSandStormData : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.FilePtr<Fox.Core.File> vfxFileSandStormStart;
        
        public Fox.Core.FilePtr<Fox.Core.File> vfxFileSandStormFar;
        
        public Fox.Core.FilePtr<Fox.Core.File> vfxFileSandStormNear;
        
        public Fox.Core.FilePtr<Fox.Core.File> vfxFileSandStormCamera;
        
        public float sandStormFarDistance;
        
        public float sandStormFarHeight;
        
        public float sandStormNearDistance;
        
        public float sandStormNearHeight;
        
        public float noiseScale;
        
        public float noiseOffset;
        
        public float noiseCutScale;
        
        public float noiseCutOffset;
        
        public UnityEngine.Color noiseColor;
        
        public bool noiseSunLightColorMul;
        
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
        static TppWeatherSandStormData()
        {
            classInfo = new Fox.EntityInfo("TppWeatherSandStormData", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 240, "TppEffect", 3);
			
			classInfo.StaticProperties.Insert("vfxFileSandStormStart", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("vfxFileSandStormFar", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("vfxFileSandStormNear", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("vfxFileSandStormCamera", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("sandStormFarDistance", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("sandStormFarHeight", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 220, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("sandStormNearDistance", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 228, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("sandStormNearHeight", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("noiseScale", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 240, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("noiseOffset", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 244, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("noiseCutScale", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("noiseCutOffset", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 252, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("noiseColor", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Color, 256, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("noiseSunLightColorMul", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 272, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppWeatherSandStormData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "vfxFileSandStormStart":
                    this.vfxFileSandStormStart = value.GetValueAsFilePtr();
                    return;
                case "vfxFileSandStormFar":
                    this.vfxFileSandStormFar = value.GetValueAsFilePtr();
                    return;
                case "vfxFileSandStormNear":
                    this.vfxFileSandStormNear = value.GetValueAsFilePtr();
                    return;
                case "vfxFileSandStormCamera":
                    this.vfxFileSandStormCamera = value.GetValueAsFilePtr();
                    return;
                case "sandStormFarDistance":
                    this.sandStormFarDistance = value.GetValueAsFloat();
                    return;
                case "sandStormFarHeight":
                    this.sandStormFarHeight = value.GetValueAsFloat();
                    return;
                case "sandStormNearDistance":
                    this.sandStormNearDistance = value.GetValueAsFloat();
                    return;
                case "sandStormNearHeight":
                    this.sandStormNearHeight = value.GetValueAsFloat();
                    return;
                case "noiseScale":
                    this.noiseScale = value.GetValueAsFloat();
                    return;
                case "noiseOffset":
                    this.noiseOffset = value.GetValueAsFloat();
                    return;
                case "noiseCutScale":
                    this.noiseCutScale = value.GetValueAsFloat();
                    return;
                case "noiseCutOffset":
                    this.noiseCutOffset = value.GetValueAsFloat();
                    return;
                case "noiseColor":
                    this.noiseColor = value.GetValueAsColor();
                    return;
                case "noiseSunLightColorMul":
                    this.noiseSunLightColorMul = value.GetValueAsBool();
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