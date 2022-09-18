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
    public partial class DirectionalLight : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public UnityEngine.Color color { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Vector3 direction { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float shadowRange { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float shadowRangeExtra { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float hiResShadowRange { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float shadowProjectionRange { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float shadowFadeRange { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float selfShadowBias { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float temperature { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float colorDeflection { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float lux { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float lightSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float shadowMaskSpecular { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float shadowOffsetStartAngle { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float shadowOffsetEndAngle { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float diatanceFade_StartDistance { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float distanceFade_FadeoutRange { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected uint lightFlags { get; set; }
        
        public bool enable { get => Get_enable(); set { Set_enable(value); } }
        protected partial bool Get_enable();
        protected partial void Set_enable(bool value);
        
        public bool isCascadeBlend { get => Get_isCascadeBlend(); set { Set_isCascadeBlend(value); } }
        protected partial bool Get_isCascadeBlend();
        protected partial void Set_isCascadeBlend(bool value);
        
        public bool castShadow { get => Get_castShadow(); set { Set_castShadow(value); } }
        protected partial bool Get_castShadow();
        protected partial void Set_castShadow(bool value);
        
        public bool isBounced { get => Get_isBounced(); set { Set_isBounced(value); } }
        protected partial bool Get_isBounced();
        protected partial void Set_isBounced(bool value);
        
        public bool showObject { get => Get_showObject(); set { Set_showObject(value); } }
        protected partial bool Get_showObject();
        protected partial void Set_showObject(bool value);
        
        public bool enableDistanceFade { get => Get_enableDistanceFade(); set { Set_enableDistanceFade(value); } }
        protected partial bool Get_enableDistanceFade();
        protected partial void Set_enableDistanceFade(bool value);
        
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
        static DirectionalLight()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("DirectionalLight"), typeof(DirectionalLight), new Fox.Core.TransformData().GetClassEntityInfo(), 352, "Light", 8);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("color"), Fox.Core.PropertyInfo.PropertyType.Color, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("direction"), Fox.Core.PropertyInfo.PropertyType.Vector3, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shadowRange"), Fox.Core.PropertyInfo.PropertyType.Float, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shadowRangeExtra"), Fox.Core.PropertyInfo.PropertyType.Float, 340, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("hiResShadowRange"), Fox.Core.PropertyInfo.PropertyType.Float, 344, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shadowProjectionRange"), Fox.Core.PropertyInfo.PropertyType.Float, 348, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shadowFadeRange"), Fox.Core.PropertyInfo.PropertyType.Float, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("selfShadowBias"), Fox.Core.PropertyInfo.PropertyType.Float, 356, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("temperature"), Fox.Core.PropertyInfo.PropertyType.Float, 360, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("colorDeflection"), Fox.Core.PropertyInfo.PropertyType.Float, 364, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lux"), Fox.Core.PropertyInfo.PropertyType.Float, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lightSize"), Fox.Core.PropertyInfo.PropertyType.Float, 372, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shadowMaskSpecular"), Fox.Core.PropertyInfo.PropertyType.Float, 376, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shadowOffsetStartAngle"), Fox.Core.PropertyInfo.PropertyType.Float, 380, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shadowOffsetEndAngle"), Fox.Core.PropertyInfo.PropertyType.Float, 384, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("diatanceFade_StartDistance"), Fox.Core.PropertyInfo.PropertyType.Float, 388, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("distanceFade_FadeoutRange"), Fox.Core.PropertyInfo.PropertyType.Float, 392, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lightFlags"), Fox.Core.PropertyInfo.PropertyType.UInt32, 396, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("enable"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isCascadeBlend"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("castShadow"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isBounced"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("showObject"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("enableDistanceFade"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
        }

        // Constructors
		public DirectionalLight(ulong id) : base(id) { }
		public DirectionalLight() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "color":
                    this.color = value.GetValueAsColor();
                    return;
                case "direction":
                    this.direction = value.GetValueAsVector3();
                    return;
                case "shadowRange":
                    this.shadowRange = value.GetValueAsFloat();
                    return;
                case "shadowRangeExtra":
                    this.shadowRangeExtra = value.GetValueAsFloat();
                    return;
                case "hiResShadowRange":
                    this.hiResShadowRange = value.GetValueAsFloat();
                    return;
                case "shadowProjectionRange":
                    this.shadowProjectionRange = value.GetValueAsFloat();
                    return;
                case "shadowFadeRange":
                    this.shadowFadeRange = value.GetValueAsFloat();
                    return;
                case "selfShadowBias":
                    this.selfShadowBias = value.GetValueAsFloat();
                    return;
                case "temperature":
                    this.temperature = value.GetValueAsFloat();
                    return;
                case "colorDeflection":
                    this.colorDeflection = value.GetValueAsFloat();
                    return;
                case "lux":
                    this.lux = value.GetValueAsFloat();
                    return;
                case "lightSize":
                    this.lightSize = value.GetValueAsFloat();
                    return;
                case "shadowMaskSpecular":
                    this.shadowMaskSpecular = value.GetValueAsFloat();
                    return;
                case "shadowOffsetStartAngle":
                    this.shadowOffsetStartAngle = value.GetValueAsFloat();
                    return;
                case "shadowOffsetEndAngle":
                    this.shadowOffsetEndAngle = value.GetValueAsFloat();
                    return;
                case "diatanceFade_StartDistance":
                    this.diatanceFade_StartDistance = value.GetValueAsFloat();
                    return;
                case "distanceFade_FadeoutRange":
                    this.distanceFade_FadeoutRange = value.GetValueAsFloat();
                    return;
                case "lightFlags":
                    this.lightFlags = value.GetValueAsUInt32();
                    return;
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "isCascadeBlend":
                    this.isCascadeBlend = value.GetValueAsBool();
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
                case "enableDistanceFade":
                    this.enableDistanceFade = value.GetValueAsBool();
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