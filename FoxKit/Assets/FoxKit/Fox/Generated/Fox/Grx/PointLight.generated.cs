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

namespace Fox.Grx
{
    public partial class PointLight : Fox.Core.TransformData 
    {
        // Properties
        public UnityEngine.Color color;
        
        public UnityEngine.Vector3 reachPoint;
        
        public Fox.Core.EntityLink lightArea;
        
        public Fox.Core.EntityLink irradiationPoint;
        
        public float outerRange;
        
        public float innerRange;
        
        public float temperature;
        
        public float colorDeflection;
        
        public float lumen;
        
        public float lightSize;
        
        public float dimmer;
        
        public float shadowBias;
        
        public float LodFarSize;
        
        public float LodNearSize;
        
        public float LodShadowDrawRate;
        
        public uint lightFlags;
        
        public PointLight_LodRadiusLevel lodRadiusLevel;
        
        public byte lodFadeType;
        
        public bool enable;
        
        public PointLight_PackingGeneration packingGeneration;
        
        public bool castShadow;
        
        public bool isBounced;
        
        public bool showObject;
        
        public bool showRange;
        
        public bool isDebugLightVolumeBound;
        
        public bool hasSpecular;
        
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
        static PointLight()
        {
            classInfo = new Fox.EntityInfo("PointLight", new Fox.Core.TransformData(0, 0, 0).GetClassEntityInfo(), 416, "Light", 14);
			
			classInfo.StaticProperties.Insert("color", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Color, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("reachPoint", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lightArea", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("irradiationPoint", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 376, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("outerRange", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 416, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("innerRange", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 420, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("temperature", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 424, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("colorDeflection", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 428, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lumen", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 432, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lightSize", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 436, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("dimmer", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 440, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("shadowBias", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 444, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("LodFarSize", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 448, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("LodNearSize", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 452, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("LodShadowDrawRate", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 456, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lightFlags", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 460, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lodRadiusLevel", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 464, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(PointLight_LodRadiusLevel), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lodFadeType", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 468, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("enable", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("packingGeneration", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(PointLight_PackingGeneration), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("castShadow", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isBounced", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("showObject", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("showRange", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isDebugLightVolumeBound", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hasSpecular", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public PointLight(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
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
                case "dimmer":
                    this.dimmer = value.GetValueAsFloat();
                    return;
                case "shadowBias":
                    this.shadowBias = value.GetValueAsFloat();
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
                    this.lodRadiusLevel = (PointLight_LodRadiusLevel)value.GetValueAsInt32();
                    return;
                case "lodFadeType":
                    this.lodFadeType = value.GetValueAsUInt8();
                    return;
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "packingGeneration":
                    this.packingGeneration = (PointLight_PackingGeneration)value.GetValueAsInt32();
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
                case "hasSpecular":
                    this.hasSpecular = value.GetValueAsBool();
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