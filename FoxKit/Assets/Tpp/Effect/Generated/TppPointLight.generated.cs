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
        protected Fox.Kernel.DynamicArray<uint> BynaryData { get; set; } = new Fox.Kernel.DynamicArray<uint>();
        
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
        
        public Fox.Kernel.Path importFilePath { get => Get_importFilePath(); set { Set_importFilePath(value); } }
        protected partial Fox.Kernel.Path Get_importFilePath();
        protected partial void Set_importFilePath(Fox.Kernel.Path value);
        
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
        static TppPointLight()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppPointLight"), typeof(TppPointLight), new Fox.Core.TransformData().GetClassEntityInfo(), 432, "Light", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("color"), Fox.Core.PropertyInfo.PropertyType.Color, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("reachPoint"), Fox.Core.PropertyInfo.PropertyType.Vector3, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("BynaryData"), Fox.Core.PropertyInfo.PropertyType.UInt32, 336, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lightArea"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("irradiationPoint"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 392, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("outerRange"), Fox.Core.PropertyInfo.PropertyType.Float, 432, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("innerRange"), Fox.Core.PropertyInfo.PropertyType.Float, 436, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("temperature"), Fox.Core.PropertyInfo.PropertyType.Float, 440, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("colorDeflection"), Fox.Core.PropertyInfo.PropertyType.Float, 444, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lumen"), Fox.Core.PropertyInfo.PropertyType.Float, 448, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lightSize"), Fox.Core.PropertyInfo.PropertyType.Float, 452, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("dimmer"), Fox.Core.PropertyInfo.PropertyType.Float, 456, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shadowBias"), Fox.Core.PropertyInfo.PropertyType.Float, 460, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("LodFarSize"), Fox.Core.PropertyInfo.PropertyType.Float, 464, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("LodNearSize"), Fox.Core.PropertyInfo.PropertyType.Float, 468, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("LodShadowDrawRate"), Fox.Core.PropertyInfo.PropertyType.Float, 472, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lightFlags"), Fox.Core.PropertyInfo.PropertyType.UInt32, 476, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lodRadiusLevel"), Fox.Core.PropertyInfo.PropertyType.Int32, 480, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lodFadeType"), Fox.Core.PropertyInfo.PropertyType.UInt8, 484, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("enable"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("packingGeneration"), Fox.Core.PropertyInfo.PropertyType.Int32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppPointLight_PackingGeneration), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("castShadow"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isBounced"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("showObject"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("showRange"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isDebugLightVolumeBounding"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("hasSpecular"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("importFilePath"), Fox.Core.PropertyInfo.PropertyType.Path, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
        }

        // Constructors
		public TppPointLight(ulong id) : base(id) { }
		public TppPointLight() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
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
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName.CString)
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