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
    public partial class GrPluginSettings : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public uint motionBlurConvolutionLevel { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float exposureCompensation { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float minExposure { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float maxExposure { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float keyValue { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float bloomSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float bloomBrightnessExtraction { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float bloomWeight { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float tonemapSpeed { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float maxLuminanceValue { get; set; }
        
        [field: UnityEngine.SerializeField]
        public byte captureBounceCount { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint minDecalArea { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected uint flags { get; set; }
        
        public bool isTonemap { get => Get_isTonemap(); set { Set_isTonemap(value); } }
        protected partial bool Get_isTonemap();
        protected partial void Set_isTonemap(bool value);
        
        public bool isBloom { get => Get_isBloom(); set { Set_isBloom(value); } }
        protected partial bool Get_isBloom();
        protected partial void Set_isBloom(bool value);
        
        public bool isMotionBlur { get => Get_isMotionBlur(); set { Set_isMotionBlur(value); } }
        protected partial bool Get_isMotionBlur();
        protected partial void Set_isMotionBlur(bool value);
        
        public bool isDepthOfField { get => Get_isDepthOfField(); set { Set_isDepthOfField(value); } }
        protected partial bool Get_isDepthOfField();
        protected partial void Set_isDepthOfField(bool value);
        
        public bool isDOFVisualizeFocus { get => Get_isDOFVisualizeFocus(); set { Set_isDOFVisualizeFocus(value); } }
        protected partial bool Get_isDOFVisualizeFocus();
        protected partial void Set_isDOFVisualizeFocus(bool value);
        
        public bool isLocalReflections { get => Get_isLocalReflections(); set { Set_isLocalReflections(value); } }
        protected partial bool Get_isLocalReflections();
        protected partial void Set_isLocalReflections(bool value);
        
        public bool isTemporalAA { get => Get_isTemporalAA(); set { Set_isTemporalAA(value); } }
        protected partial bool Get_isTemporalAA();
        protected partial void Set_isTemporalAA(bool value);
        
        public bool isFixedShutterRatio { get => Get_isFixedShutterRatio(); set { Set_isFixedShutterRatio(value); } }
        protected partial bool Get_isFixedShutterRatio();
        protected partial void Set_isFixedShutterRatio(bool value);
        
        public bool isPatchVelocity { get => Get_isPatchVelocity(); set { Set_isPatchVelocity(value); } }
        protected partial bool Get_isPatchVelocity();
        protected partial void Set_isPatchVelocity(bool value);
        
        public bool isLightAdaptationFromLACC { get => Get_isLightAdaptationFromLACC(); set { Set_isLightAdaptationFromLACC(value); } }
        protected partial bool Get_isLightAdaptationFromLACC();
        protected partial void Set_isLightAdaptationFromLACC(bool value);
        
        public bool isShowDecals { get => Get_isShowDecals(); set { Set_isShowDecals(value); } }
        protected partial bool Get_isShowDecals();
        protected partial void Set_isShowDecals(bool value);
        
        public bool isShrinkSHBuffer { get => Get_isShrinkSHBuffer(); set { Set_isShrinkSHBuffer(value); } }
        protected partial bool Get_isShrinkSHBuffer();
        protected partial void Set_isShrinkSHBuffer(bool value);
        
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
        static GrPluginSettings()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("GrPluginSettings"), typeof(GrPluginSettings), new Fox.Core.Data().GetClassEntityInfo(), 120, "Config", 25);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("motionBlurConvolutionLevel"), Fox.Core.PropertyInfo.PropertyType.UInt32, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("exposureCompensation"), Fox.Core.PropertyInfo.PropertyType.Float, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("minExposure"), Fox.Core.PropertyInfo.PropertyType.Float, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("maxExposure"), Fox.Core.PropertyInfo.PropertyType.Float, 140, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("keyValue"), Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("bloomSize"), Fox.Core.PropertyInfo.PropertyType.Float, 148, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("bloomBrightnessExtraction"), Fox.Core.PropertyInfo.PropertyType.Float, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("bloomWeight"), Fox.Core.PropertyInfo.PropertyType.Float, 156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("tonemapSpeed"), Fox.Core.PropertyInfo.PropertyType.Float, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("maxLuminanceValue"), Fox.Core.PropertyInfo.PropertyType.Float, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("captureBounceCount"), Fox.Core.PropertyInfo.PropertyType.UInt8, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("minDecalArea"), Fox.Core.PropertyInfo.PropertyType.UInt32, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("flags"), Fox.Core.PropertyInfo.PropertyType.UInt32, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isTonemap"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isBloom"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isMotionBlur"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isDepthOfField"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isDOFVisualizeFocus"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isLocalReflections"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isTemporalAA"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isFixedShutterRatio"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isPatchVelocity"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isLightAdaptationFromLACC"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isShowDecals"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isShrinkSHBuffer"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
        }

        // Constructors
		public GrPluginSettings(ulong id) : base(id) { }
		public GrPluginSettings() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "motionBlurConvolutionLevel":
                    this.motionBlurConvolutionLevel = value.GetValueAsUInt32();
                    return;
                case "exposureCompensation":
                    this.exposureCompensation = value.GetValueAsFloat();
                    return;
                case "minExposure":
                    this.minExposure = value.GetValueAsFloat();
                    return;
                case "maxExposure":
                    this.maxExposure = value.GetValueAsFloat();
                    return;
                case "keyValue":
                    this.keyValue = value.GetValueAsFloat();
                    return;
                case "bloomSize":
                    this.bloomSize = value.GetValueAsFloat();
                    return;
                case "bloomBrightnessExtraction":
                    this.bloomBrightnessExtraction = value.GetValueAsFloat();
                    return;
                case "bloomWeight":
                    this.bloomWeight = value.GetValueAsFloat();
                    return;
                case "tonemapSpeed":
                    this.tonemapSpeed = value.GetValueAsFloat();
                    return;
                case "maxLuminanceValue":
                    this.maxLuminanceValue = value.GetValueAsFloat();
                    return;
                case "captureBounceCount":
                    this.captureBounceCount = value.GetValueAsUInt8();
                    return;
                case "minDecalArea":
                    this.minDecalArea = value.GetValueAsUInt32();
                    return;
                case "flags":
                    this.flags = value.GetValueAsUInt32();
                    return;
                case "isTonemap":
                    this.isTonemap = value.GetValueAsBool();
                    return;
                case "isBloom":
                    this.isBloom = value.GetValueAsBool();
                    return;
                case "isMotionBlur":
                    this.isMotionBlur = value.GetValueAsBool();
                    return;
                case "isDepthOfField":
                    this.isDepthOfField = value.GetValueAsBool();
                    return;
                case "isDOFVisualizeFocus":
                    this.isDOFVisualizeFocus = value.GetValueAsBool();
                    return;
                case "isLocalReflections":
                    this.isLocalReflections = value.GetValueAsBool();
                    return;
                case "isTemporalAA":
                    this.isTemporalAA = value.GetValueAsBool();
                    return;
                case "isFixedShutterRatio":
                    this.isFixedShutterRatio = value.GetValueAsBool();
                    return;
                case "isPatchVelocity":
                    this.isPatchVelocity = value.GetValueAsBool();
                    return;
                case "isLightAdaptationFromLACC":
                    this.isLightAdaptationFromLACC = value.GetValueAsBool();
                    return;
                case "isShowDecals":
                    this.isShowDecals = value.GetValueAsBool();
                    return;
                case "isShrinkSHBuffer":
                    this.isShrinkSHBuffer = value.GetValueAsBool();
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