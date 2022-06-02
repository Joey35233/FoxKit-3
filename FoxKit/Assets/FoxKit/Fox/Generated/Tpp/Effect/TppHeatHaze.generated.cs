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
    public partial class TppHeatHaze : Fox.Core.Data 
    {
        // Properties
        public float distortionIntensityFullResolution;
        
        public float distortionVelocityFullResolution;
        
        public float distortionTextureRepetitionFullResolution;
        
        public float hazeMirageIntensityFullResolution;
        
        public float hazeStartDistanceFullResolution;
        
        public float hazeEndDistanceFullResolution;
        
        public float hazeRangeAttenuationFullResolution;
        
        public float hazeSecondLayerIntensityDifference;
        
        public float hazeSecondLayerStartDistance;
        
        public float hazeSecondLayerBlurRadius;
        
        public float hazeDistortionIntensityAddedOnBinoculars;
        
        public float mirageColorSaturation;
        
        public float mirageSpreadingPower;
        
        public float mirageRayLength;
        
        public float mirageHitRange;
        
        public float mirageStartDistance;
        
        public float mirageRangeAttenuation;
        
        public float distortionIntensityHalfResolution;
        
        public float distortionVelocityHalfResolution;
        
        public float distortionTextureRepetitionHalfResolution;
        
        public float hazeIntensityHalfResolution;
        
        public float hazeStartDistanceHalfResolution;
        
        public float hazeEndDistanceHalfResolution;
        
        public float hazeRangeAttenuationHalfResolution;
        
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
        static TppHeatHaze()
        {
            classInfo = new Fox.EntityInfo("TppHeatHaze", new Fox.Core.Data().GetClassEntityInfo(), 160, null, 1);
			
			classInfo.StaticProperties.Insert("distortionIntensityFullResolution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("distortionVelocityFullResolution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("distortionTextureRepetitionFullResolution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hazeMirageIntensityFullResolution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hazeStartDistanceFullResolution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hazeEndDistanceFullResolution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 140, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hazeRangeAttenuationFullResolution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hazeSecondLayerIntensityDifference", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 148, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hazeSecondLayerStartDistance", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hazeSecondLayerBlurRadius", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hazeDistortionIntensityAddedOnBinoculars", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("mirageColorSaturation", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("mirageSpreadingPower", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("mirageRayLength", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("mirageHitRange", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("mirageStartDistance", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 180, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("mirageRangeAttenuation", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("distortionIntensityHalfResolution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 188, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("distortionVelocityHalfResolution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("distortionTextureRepetitionHalfResolution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 196, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hazeIntensityHalfResolution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hazeStartDistanceHalfResolution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 204, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hazeEndDistanceHalfResolution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hazeRangeAttenuationHalfResolution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 212, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppHeatHaze(ulong address, ulong id) : base(address, id) { }
		public TppHeatHaze() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "distortionIntensityFullResolution":
                    this.distortionIntensityFullResolution = value.GetValueAsFloat();
                    return;
                case "distortionVelocityFullResolution":
                    this.distortionVelocityFullResolution = value.GetValueAsFloat();
                    return;
                case "distortionTextureRepetitionFullResolution":
                    this.distortionTextureRepetitionFullResolution = value.GetValueAsFloat();
                    return;
                case "hazeMirageIntensityFullResolution":
                    this.hazeMirageIntensityFullResolution = value.GetValueAsFloat();
                    return;
                case "hazeStartDistanceFullResolution":
                    this.hazeStartDistanceFullResolution = value.GetValueAsFloat();
                    return;
                case "hazeEndDistanceFullResolution":
                    this.hazeEndDistanceFullResolution = value.GetValueAsFloat();
                    return;
                case "hazeRangeAttenuationFullResolution":
                    this.hazeRangeAttenuationFullResolution = value.GetValueAsFloat();
                    return;
                case "hazeSecondLayerIntensityDifference":
                    this.hazeSecondLayerIntensityDifference = value.GetValueAsFloat();
                    return;
                case "hazeSecondLayerStartDistance":
                    this.hazeSecondLayerStartDistance = value.GetValueAsFloat();
                    return;
                case "hazeSecondLayerBlurRadius":
                    this.hazeSecondLayerBlurRadius = value.GetValueAsFloat();
                    return;
                case "hazeDistortionIntensityAddedOnBinoculars":
                    this.hazeDistortionIntensityAddedOnBinoculars = value.GetValueAsFloat();
                    return;
                case "mirageColorSaturation":
                    this.mirageColorSaturation = value.GetValueAsFloat();
                    return;
                case "mirageSpreadingPower":
                    this.mirageSpreadingPower = value.GetValueAsFloat();
                    return;
                case "mirageRayLength":
                    this.mirageRayLength = value.GetValueAsFloat();
                    return;
                case "mirageHitRange":
                    this.mirageHitRange = value.GetValueAsFloat();
                    return;
                case "mirageStartDistance":
                    this.mirageStartDistance = value.GetValueAsFloat();
                    return;
                case "mirageRangeAttenuation":
                    this.mirageRangeAttenuation = value.GetValueAsFloat();
                    return;
                case "distortionIntensityHalfResolution":
                    this.distortionIntensityHalfResolution = value.GetValueAsFloat();
                    return;
                case "distortionVelocityHalfResolution":
                    this.distortionVelocityHalfResolution = value.GetValueAsFloat();
                    return;
                case "distortionTextureRepetitionHalfResolution":
                    this.distortionTextureRepetitionHalfResolution = value.GetValueAsFloat();
                    return;
                case "hazeIntensityHalfResolution":
                    this.hazeIntensityHalfResolution = value.GetValueAsFloat();
                    return;
                case "hazeStartDistanceHalfResolution":
                    this.hazeStartDistanceHalfResolution = value.GetValueAsFloat();
                    return;
                case "hazeEndDistanceHalfResolution":
                    this.hazeEndDistanceHalfResolution = value.GetValueAsFloat();
                    return;
                case "hazeRangeAttenuationHalfResolution":
                    this.hazeRangeAttenuationHalfResolution = value.GetValueAsFloat();
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