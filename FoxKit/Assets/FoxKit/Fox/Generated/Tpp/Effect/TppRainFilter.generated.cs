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
    public partial class TppRainFilter : Fox.Core.Data 
    {
        // Properties
        public bool enable;
        
        public float startFadeInDistance;
        
        public float endFadeInDistance;
        
        public float startFadeOutDistance;
        
        public float endFadeOutDistance;
        
        public float albedoExtinctionRatio;
        
        public float roughnessExtinctionCoefficient;
        
        public float roughnessEffectiveThreshold;
        
        public float LABDiffuseScale;
        
        public float LABDiffuseAdd;
        
        public float floorTexScale;
        
        public float wallTexScale0;
        
        public float wallTexScale1;
        
        public UnityEngine.Vector4 wallTexSpeed;
        
        public float maskTexScale0;
        
        public float maskTexScale1;
        
        public UnityEngine.Vector4 maskTexSpeed;
        
        public UnityEngine.Color rainColor;
        
        public float windScale;
        
        public float wallAlphaRate;
        
        public Fox.Core.Path normalWallTexPath;
        
        public Fox.Core.Path normalFloorTexPath;
        
        public Fox.Core.Path reflectionCubeMapTexPath;
        
        public Fox.Core.Path maskTexPath;
        
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
        static TppRainFilter()
        {
            classInfo = new Fox.EntityInfo("TppRainFilter", new Fox.Core.Data().GetClassEntityInfo(), 224, null, 2);
			
			classInfo.StaticProperties.Insert("enable", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 272, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("startFadeInDistance", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 236, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("endFadeInDistance", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 240, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("startFadeOutDistance", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 244, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("endFadeOutDistance", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("albedoExtinctionRatio", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 252, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("roughnessExtinctionCoefficient", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 260, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("roughnessEffectiveThreshold", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 256, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("LABDiffuseScale", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 264, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("LABDiffuseAdd", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 268, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("floorTexScale", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("wallTexScale0", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("wallTexScale1", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 228, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("wallTexSpeed", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector4, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("maskTexScale0", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("maskTexScale1", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 220, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("maskTexSpeed", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector4, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rainColor", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Color, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("windScale", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("wallAlphaRate", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 212, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("normalWallTexPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("normalFloorTexPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("reflectionCubeMapTexPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("maskTexPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppRainFilter(ulong address, ulong id) : base(address, id) { }
		public TppRainFilter() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "startFadeInDistance":
                    this.startFadeInDistance = value.GetValueAsFloat();
                    return;
                case "endFadeInDistance":
                    this.endFadeInDistance = value.GetValueAsFloat();
                    return;
                case "startFadeOutDistance":
                    this.startFadeOutDistance = value.GetValueAsFloat();
                    return;
                case "endFadeOutDistance":
                    this.endFadeOutDistance = value.GetValueAsFloat();
                    return;
                case "albedoExtinctionRatio":
                    this.albedoExtinctionRatio = value.GetValueAsFloat();
                    return;
                case "roughnessExtinctionCoefficient":
                    this.roughnessExtinctionCoefficient = value.GetValueAsFloat();
                    return;
                case "roughnessEffectiveThreshold":
                    this.roughnessEffectiveThreshold = value.GetValueAsFloat();
                    return;
                case "LABDiffuseScale":
                    this.LABDiffuseScale = value.GetValueAsFloat();
                    return;
                case "LABDiffuseAdd":
                    this.LABDiffuseAdd = value.GetValueAsFloat();
                    return;
                case "floorTexScale":
                    this.floorTexScale = value.GetValueAsFloat();
                    return;
                case "wallTexScale0":
                    this.wallTexScale0 = value.GetValueAsFloat();
                    return;
                case "wallTexScale1":
                    this.wallTexScale1 = value.GetValueAsFloat();
                    return;
                case "wallTexSpeed":
                    this.wallTexSpeed = value.GetValueAsVector4();
                    return;
                case "maskTexScale0":
                    this.maskTexScale0 = value.GetValueAsFloat();
                    return;
                case "maskTexScale1":
                    this.maskTexScale1 = value.GetValueAsFloat();
                    return;
                case "maskTexSpeed":
                    this.maskTexSpeed = value.GetValueAsVector4();
                    return;
                case "rainColor":
                    this.rainColor = value.GetValueAsColor();
                    return;
                case "windScale":
                    this.windScale = value.GetValueAsFloat();
                    return;
                case "wallAlphaRate":
                    this.wallAlphaRate = value.GetValueAsFloat();
                    return;
                case "normalWallTexPath":
                    this.normalWallTexPath = value.GetValueAsPath();
                    return;
                case "normalFloorTexPath":
                    this.normalFloorTexPath = value.GetValueAsPath();
                    return;
                case "reflectionCubeMapTexPath":
                    this.reflectionCubeMapTexPath = value.GetValueAsPath();
                    return;
                case "maskTexPath":
                    this.maskTexPath = value.GetValueAsPath();
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