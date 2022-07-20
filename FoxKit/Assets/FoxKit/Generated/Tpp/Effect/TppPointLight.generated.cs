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
    [UnityEditor.InitializeOnLoad]
    public partial class TppPointLight : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public UnityEngine.Color color { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Vector3 reachPoint { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected Fox.Core.DynamicArray<uint> BynaryData { get; set; } = new Fox.Core.DynamicArray<uint>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink lightArea { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink irradiationPoint { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float outerRange { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float innerRange { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float temperature { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float colorDeflection { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float lumen { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float lightSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float dimmer { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float shadowBias { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float LodFarSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float LodNearSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float LodShadowDrawRate { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected uint lightFlags { get; set; }
        
        [field: UnityEngine.SerializeField]
        public int lodRadiusLevel { get; set; }
        
        [field: UnityEngine.SerializeField]
        public byte lodFadeType { get; set; }
        
        public bool enable { get => Get_enable(); set { Set_enable(value); } }
        protected partial bool Get_enable();
        protected partial void Set_enable(bool value);
        
        public TppPointLight_PackingGeneration packingGeneration { get => Get_packingGeneration(); set { Set_packingGeneration(value); } }
        protected partial TppPointLight_PackingGeneration Get_packingGeneration();
        protected partial void Set_packingGeneration(TppPointLight_PackingGeneration value);
        
        public bool castShadow { get => Get_castShadow(); set { Set_castShadow(value); } }
        protected partial bool Get_castShadow();
        protected partial void Set_castShadow(bool value);
        
        public bool isBounced { get => Get_isBounced(); set { Set_isBounced(value); } }
        protected partial bool Get_isBounced();
        protected partial void Set_isBounced(bool value);
        
        public bool showObject { get => Get_showObject(); set { Set_showObject(value); } }
        protected partial bool Get_showObject();
        protected partial void Set_showObject(bool value);
        
        public bool showRange { get => Get_showRange(); set { Set_showRange(value); } }
        protected partial bool Get_showRange();
        protected partial void Set_showRange(bool value);
        
        public bool isDebugLightVolumeBounding { get => Get_isDebugLightVolumeBounding(); set { Set_isDebugLightVolumeBounding(value); } }
        protected partial bool Get_isDebugLightVolumeBounding();
        protected partial void Set_isDebugLightVolumeBounding(bool value);
        
        public bool hasSpecular { get => Get_hasSpecular(); set { Set_hasSpecular(value); } }
        protected partial bool Get_hasSpecular();
        protected partial void Set_hasSpecular(bool value);
        
        public Fox.Core.Path importFilePath { get => Get_importFilePath(); set { Set_importFilePath(value); } }
        protected partial Fox.Core.Path Get_importFilePath();
        protected partial void Set_importFilePath(Fox.Core.Path value);
        
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
        static TppPointLight()
        {
            classInfo = new Fox.EntityInfo("TppPointLight", typeof(TppPointLight), new Fox.Core.TransformData().GetClassEntityInfo(), 432, "Light", 1);
			classInfo.StaticProperties.Insert("color", new Fox.Core.PropertyInfo("color", Fox.Core.PropertyInfo.PropertyType.Color, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("reachPoint", new Fox.Core.PropertyInfo("reachPoint", Fox.Core.PropertyInfo.PropertyType.Vector3, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("BynaryData", new Fox.Core.PropertyInfo("BynaryData", Fox.Core.PropertyInfo.PropertyType.UInt32, 336, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lightArea", new Fox.Core.PropertyInfo("lightArea", Fox.Core.PropertyInfo.PropertyType.EntityLink, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("irradiationPoint", new Fox.Core.PropertyInfo("irradiationPoint", Fox.Core.PropertyInfo.PropertyType.EntityLink, 392, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("outerRange", new Fox.Core.PropertyInfo("outerRange", Fox.Core.PropertyInfo.PropertyType.Float, 432, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("innerRange", new Fox.Core.PropertyInfo("innerRange", Fox.Core.PropertyInfo.PropertyType.Float, 436, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("temperature", new Fox.Core.PropertyInfo("temperature", Fox.Core.PropertyInfo.PropertyType.Float, 440, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("colorDeflection", new Fox.Core.PropertyInfo("colorDeflection", Fox.Core.PropertyInfo.PropertyType.Float, 444, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lumen", new Fox.Core.PropertyInfo("lumen", Fox.Core.PropertyInfo.PropertyType.Float, 448, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lightSize", new Fox.Core.PropertyInfo("lightSize", Fox.Core.PropertyInfo.PropertyType.Float, 452, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("dimmer", new Fox.Core.PropertyInfo("dimmer", Fox.Core.PropertyInfo.PropertyType.Float, 456, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("shadowBias", new Fox.Core.PropertyInfo("shadowBias", Fox.Core.PropertyInfo.PropertyType.Float, 460, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("LodFarSize", new Fox.Core.PropertyInfo("LodFarSize", Fox.Core.PropertyInfo.PropertyType.Float, 464, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("LodNearSize", new Fox.Core.PropertyInfo("LodNearSize", Fox.Core.PropertyInfo.PropertyType.Float, 468, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("LodShadowDrawRate", new Fox.Core.PropertyInfo("LodShadowDrawRate", Fox.Core.PropertyInfo.PropertyType.Float, 472, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lightFlags", new Fox.Core.PropertyInfo("lightFlags", Fox.Core.PropertyInfo.PropertyType.UInt32, 476, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lodRadiusLevel", new Fox.Core.PropertyInfo("lodRadiusLevel", Fox.Core.PropertyInfo.PropertyType.Int32, 480, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lodFadeType", new Fox.Core.PropertyInfo("lodFadeType", Fox.Core.PropertyInfo.PropertyType.UInt8, 484, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("enable", new Fox.Core.PropertyInfo("enable", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("packingGeneration", new Fox.Core.PropertyInfo("packingGeneration", Fox.Core.PropertyInfo.PropertyType.Int32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppPointLight_PackingGeneration), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("castShadow", new Fox.Core.PropertyInfo("castShadow", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isBounced", new Fox.Core.PropertyInfo("isBounced", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("showObject", new Fox.Core.PropertyInfo("showObject", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("showRange", new Fox.Core.PropertyInfo("showRange", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isDebugLightVolumeBounding", new Fox.Core.PropertyInfo("isDebugLightVolumeBounding", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hasSpecular", new Fox.Core.PropertyInfo("hasSpecular", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("importFilePath", new Fox.Core.PropertyInfo("importFilePath", Fox.Core.PropertyInfo.PropertyType.Path, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppPointLight(ulong id) : base(id) { }
		public TppPointLight() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
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
                    this.lodRadiusLevel = value.GetValueAsInt32();
                    return;
                case "lodFadeType":
                    this.lodFadeType = value.GetValueAsUInt8();
                    return;
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "packingGeneration":
                    this.packingGeneration = (TppPointLight_PackingGeneration)value.GetValueAsInt32();
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
                case "isDebugLightVolumeBounding":
                    this.isDebugLightVolumeBounding = value.GetValueAsBool();
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
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
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