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
    public partial class TppSpotLight : Fox.Core.TransformData 
    {
        // Properties
        public UnityEngine.Color color;
        
        public UnityEngine.Vector3 reachPoint;
        
        public Fox.Core.DynamicArray<uint> BynaryData = new Fox.Core.DynamicArray<uint>();
        
        public Fox.Core.EntityLink lightArea;
        
        public Fox.Core.EntityLink irradiationPoint;
        
        public Fox.Core.EntityLink lookAtPoint;
        
        public float outerRange;
        
        public float innerRange;
        
        public float temperature;
        
        public float colorDeflection;
        
        public float lumen;
        
        public float lightSize;
        
        public float umbraAngle;
        
        public float penumbraAngle;
        
        public float attenuationExponent;
        
        public float shadowUmbraAngle;
        
        public float shadowPenumbraAngle;
        
        public float shadowAttenuationExponent;
        
        public float dimmer;
        
        public float shadowBias;
        
        public float viewBias;
        
        public float powerScale;
        
        public float LodFarSize;
        
        public float LodNearSize;
        
        public float LodShadowDrawRate;
        
        public uint lightFlags;
        
        public int lodRadiusLevel;
        
        public byte lodFadeType;
        
        public bool enable;
        
        public TppSpotLight_PackingGeneration packingGeneration;
        
        public bool castShadow;
        
        public bool isBounced;
        
        public bool showObject;
        
        public bool showRange;
        
        public bool isDebugLightVolumeBound;
        
        public bool useAutoDimmer;
        
        public bool hasSpecular;
        
        public Fox.Core.Path importFilePath;
        
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
        static TppSpotLight()
        {
            classInfo = new Fox.EntityInfo("TppSpotLight", new Fox.Core.TransformData(0, 0, 0).GetClassEntityInfo(), 496, "Light", 1);
			
			classInfo.StaticProperties.Insert("color", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Color, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("reachPoint", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("BynaryData", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 336, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lightArea", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("irradiationPoint", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 392, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lookAtPoint", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 432, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("outerRange", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 472, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("innerRange", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 476, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("temperature", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 480, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("colorDeflection", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 484, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lumen", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 488, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lightSize", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 492, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("umbraAngle", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 496, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("penumbraAngle", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 500, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("attenuationExponent", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 504, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("shadowUmbraAngle", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 508, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("shadowPenumbraAngle", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 512, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("shadowAttenuationExponent", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 516, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("dimmer", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 520, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("shadowBias", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 524, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("viewBias", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 528, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("powerScale", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 532, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("LodFarSize", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 536, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("LodNearSize", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 540, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("LodShadowDrawRate", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 544, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lightFlags", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 548, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lodRadiusLevel", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 552, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lodFadeType", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 556, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("enable", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("packingGeneration", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppSpotLight_PackingGeneration), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("castShadow", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isBounced", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("showObject", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("showRange", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isDebugLightVolumeBound", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("useAutoDimmer", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hasSpecular", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("importFilePath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppSpotLight(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "color":
                    this.color = value.GetValueAsColor();
                    return;
                case "reachPoint":
                    this.reachPoint = value.GetValueAsVector3();
                    return;
                case "lightArea":
                    this.lightArea = value.GetValueAsEntityLink();
                    return;
                case "irradiationPoint":
                    this.irradiationPoint = value.GetValueAsEntityLink();
                    return;
                case "lookAtPoint":
                    this.lookAtPoint = value.GetValueAsEntityLink();
                    return;
                case "outerRange":
                    this.outerRange = value.GetValueAsFloat();
                    return;
                case "innerRange":
                    this.innerRange = value.GetValueAsFloat();
                    return;
                case "temperature":
                    this.temperature = value.GetValueAsFloat();
                    return;
                case "colorDeflection":
                    this.colorDeflection = value.GetValueAsFloat();
                    return;
                case "lumen":
                    this.lumen = value.GetValueAsFloat();
                    return;
                case "lightSize":
                    this.lightSize = value.GetValueAsFloat();
                    return;
                case "umbraAngle":
                    this.umbraAngle = value.GetValueAsFloat();
                    return;
                case "penumbraAngle":
                    this.penumbraAngle = value.GetValueAsFloat();
                    return;
                case "attenuationExponent":
                    this.attenuationExponent = value.GetValueAsFloat();
                    return;
                case "shadowUmbraAngle":
                    this.shadowUmbraAngle = value.GetValueAsFloat();
                    return;
                case "shadowPenumbraAngle":
                    this.shadowPenumbraAngle = value.GetValueAsFloat();
                    return;
                case "shadowAttenuationExponent":
                    this.shadowAttenuationExponent = value.GetValueAsFloat();
                    return;
                case "dimmer":
                    this.dimmer = value.GetValueAsFloat();
                    return;
                case "shadowBias":
                    this.shadowBias = value.GetValueAsFloat();
                    return;
                case "viewBias":
                    this.viewBias = value.GetValueAsFloat();
                    return;
                case "powerScale":
                    this.powerScale = value.GetValueAsFloat();
                    return;
                case "LodFarSize":
                    this.LodFarSize = value.GetValueAsFloat();
                    return;
                case "LodNearSize":
                    this.LodNearSize = value.GetValueAsFloat();
                    return;
                case "LodShadowDrawRate":
                    this.LodShadowDrawRate = value.GetValueAsFloat();
                    return;
                case "lightFlags":
                    this.lightFlags = value.GetValueAsUInt32();
                    return;
                case "lodRadiusLevel":
                    this.lodRadiusLevel = value.GetValueAsInt32();
                    return;
                case "lodFadeType":
                    this.lodFadeType = value.GetValueAsUInt8();
                    return;
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "packingGeneration":
                    this.packingGeneration = (TppSpotLight_PackingGeneration)value.GetValueAsInt32();
                    return;
                case "castShadow":
                    this.castShadow = value.GetValueAsBool();
                    return;
                case "isBounced":
                    this.isBounced = value.GetValueAsBool();
                    return;
                case "showObject":
                    this.showObject = value.GetValueAsBool();
                    return;
                case "showRange":
                    this.showRange = value.GetValueAsBool();
                    return;
                case "isDebugLightVolumeBound":
                    this.isDebugLightVolumeBound = value.GetValueAsBool();
                    return;
                case "useAutoDimmer":
                    this.useAutoDimmer = value.GetValueAsBool();
                    return;
                case "hasSpecular":
                    this.hasSpecular = value.GetValueAsBool();
                    return;
                case "importFilePath":
                    this.importFilePath = value.GetValueAsPath();
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
                case "BynaryData":
                    while(this.BynaryData.Count <= index) { this.BynaryData.Add(default(uint)); }
                    this.BynaryData[index] = value.GetValueAsUInt32();
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