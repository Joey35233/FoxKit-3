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
    [UnityEditor.InitializeOnLoad]
    public partial class SpotLight : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink lightArea { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink irradiationPoint { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink lookAtPoint { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Vector3 reachPoint { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float innerRange { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float outerRange { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Color color { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float temperature { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float colorDeflection { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float lumen { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float lightSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float umbraAngle { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float penumbraAngle { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float attenuationExponent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float shadowUmbraAngle { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float shadowPenumbraAngle { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float shadowAttenuationExponent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float dimmer { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float shadowBias { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float viewBias { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float powerScale { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float LodFarSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float LodNearSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float LodShadowDrawRate { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected uint lightFlags { get; set; }
        
        [field: UnityEngine.SerializeField]
        public SpotLight_LodRadiusLevel lodRadiusLevel { get; set; }
        
        [field: UnityEngine.SerializeField]
        public byte lodFadeType { get; set; }
        
        public bool enable { get => Get_enable(); set { Set_enable(value); } }
        protected partial bool Get_enable();
        protected partial void Set_enable(bool value);
        
        public SpotLight_PackingGeneration packingGeneration { get => Get_packingGeneration(); set { Set_packingGeneration(value); } }
        protected partial SpotLight_PackingGeneration Get_packingGeneration();
        protected partial void Set_packingGeneration(SpotLight_PackingGeneration value);
        
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
        
        public bool isDebugLightVolumeBound { get => Get_isDebugLightVolumeBound(); set { Set_isDebugLightVolumeBound(value); } }
        protected partial bool Get_isDebugLightVolumeBound();
        protected partial void Set_isDebugLightVolumeBound(bool value);
        
        public bool useAutoDimmer { get => Get_useAutoDimmer(); set { Set_useAutoDimmer(value); } }
        protected partial bool Get_useAutoDimmer();
        protected partial void Set_useAutoDimmer(bool value);
        
        public bool hasSpecular { get => Get_hasSpecular(); set { Set_hasSpecular(value); } }
        protected partial bool Get_hasSpecular();
        protected partial void Set_hasSpecular(bool value);
        
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
        static SpotLight()
        {
            classInfo = new Fox.EntityInfo("SpotLight", typeof(SpotLight), new Fox.Core.TransformData().GetClassEntityInfo(), 480, "Light", 18);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lightArea", Fox.Core.PropertyInfo.PropertyType.EntityLink, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("irradiationPoint", Fox.Core.PropertyInfo.PropertyType.EntityLink, 376, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lookAtPoint", Fox.Core.PropertyInfo.PropertyType.EntityLink, 416, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("reachPoint", Fox.Core.PropertyInfo.PropertyType.Vector3, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("innerRange", Fox.Core.PropertyInfo.PropertyType.Float, 460, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("outerRange", Fox.Core.PropertyInfo.PropertyType.Float, 456, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("color", Fox.Core.PropertyInfo.PropertyType.Color, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("temperature", Fox.Core.PropertyInfo.PropertyType.Float, 464, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("colorDeflection", Fox.Core.PropertyInfo.PropertyType.Float, 468, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lumen", Fox.Core.PropertyInfo.PropertyType.Float, 472, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lightSize", Fox.Core.PropertyInfo.PropertyType.Float, 476, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("umbraAngle", Fox.Core.PropertyInfo.PropertyType.Float, 480, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("penumbraAngle", Fox.Core.PropertyInfo.PropertyType.Float, 484, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("attenuationExponent", Fox.Core.PropertyInfo.PropertyType.Float, 488, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("shadowUmbraAngle", Fox.Core.PropertyInfo.PropertyType.Float, 492, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("shadowPenumbraAngle", Fox.Core.PropertyInfo.PropertyType.Float, 496, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("shadowAttenuationExponent", Fox.Core.PropertyInfo.PropertyType.Float, 500, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dimmer", Fox.Core.PropertyInfo.PropertyType.Float, 504, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("shadowBias", Fox.Core.PropertyInfo.PropertyType.Float, 508, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("viewBias", Fox.Core.PropertyInfo.PropertyType.Float, 512, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("powerScale", Fox.Core.PropertyInfo.PropertyType.Float, 516, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("LodFarSize", Fox.Core.PropertyInfo.PropertyType.Float, 520, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("LodNearSize", Fox.Core.PropertyInfo.PropertyType.Float, 524, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("LodShadowDrawRate", Fox.Core.PropertyInfo.PropertyType.Float, 528, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lightFlags", Fox.Core.PropertyInfo.PropertyType.UInt32, 532, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lodRadiusLevel", Fox.Core.PropertyInfo.PropertyType.Int32, 536, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(SpotLight_LodRadiusLevel), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lodFadeType", Fox.Core.PropertyInfo.PropertyType.UInt8, 540, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("enable", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("packingGeneration", Fox.Core.PropertyInfo.PropertyType.Int32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(SpotLight_PackingGeneration), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("castShadow", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isBounced", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("showObject", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("showRange", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isDebugLightVolumeBound", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("useAutoDimmer", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("hasSpecular", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
        }

        // Constructors
		public SpotLight(ulong id) : base(id) { }
		public SpotLight() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "lightArea":
                    this.lightArea = value.GetValueAsEntityLink();
                    return;
                case "irradiationPoint":
                    this.irradiationPoint = value.GetValueAsEntityLink();
                    return;
                case "lookAtPoint":
                    this.lookAtPoint = value.GetValueAsEntityLink();
                    return;
                case "reachPoint":
                    this.reachPoint = value.GetValueAsVector3();
                    return;
                case "innerRange":
                    this.innerRange = value.GetValueAsFloat();
                    return;
                case "outerRange":
                    this.outerRange = value.GetValueAsFloat();
                    return;
                case "color":
                    this.color = value.GetValueAsColor();
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
                    this.lodRadiusLevel = (SpotLight_LodRadiusLevel)value.GetValueAsInt32();
                    return;
                case "lodFadeType":
                    this.lodFadeType = value.GetValueAsUInt8();
                    return;
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "packingGeneration":
                    this.packingGeneration = (SpotLight_PackingGeneration)value.GetValueAsInt32();
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