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
    public partial class TppLensFlareShape : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink material { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float width { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float height { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Color baseColor { get; set; }
        
        [field: UnityEngine.SerializeField]
        public TppLensFlareShapeOffsetType offsetType { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float offsetScale { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float baseOffsetX { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float baseOffsetY { get; set; }
        
        [field: UnityEngine.SerializeField]
        public TppLensFlareShapeRotateType rotateType { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float baseRotate { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float screenSpaceRotSpeedX { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float screenSpaceRotSpeedY { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink screenSpaceRotField { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink scaleFieldX { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink scaleFieldY { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool scaleFieldPickSunPositionFlag { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink alphaField { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool alphaFieldPickSunPositionFlag { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float shieldFadeOutTime { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float shieldFadeInTime { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink angleScaleGraphX { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink angleScaleGraphY { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink angleAlphaGraph { get; set; }
        
        [field: UnityEngine.SerializeField]
        public TppLensFlareShapeDistanceScalingMode distanceScaling { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float limitDistance { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool notDrawMultiple { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String seName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float seCallThreshold { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool scaleOnZoom { get; set; }
        
        // ClassInfos
        public static new bool ClassInfoInitialized = false;
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
        static TppLensFlareShape()
        {
            if (Fox.Core.TransformData.ClassInfoInitialized)
                classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppLensFlareShape"), typeof(TppLensFlareShape), Fox.Core.TransformData.ClassInfo, 672, null, 11);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("material"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("width"), Fox.Core.PropertyInfo.PropertyType.Float, 344, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("height"), Fox.Core.PropertyInfo.PropertyType.Float, 348, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("baseColor"), Fox.Core.PropertyInfo.PropertyType.Color, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("offsetType"), Fox.Core.PropertyInfo.PropertyType.Int32, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppLensFlareShapeOffsetType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("offsetScale"), Fox.Core.PropertyInfo.PropertyType.Float, 372, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("baseOffsetX"), Fox.Core.PropertyInfo.PropertyType.Float, 376, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("baseOffsetY"), Fox.Core.PropertyInfo.PropertyType.Float, 380, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rotateType"), Fox.Core.PropertyInfo.PropertyType.Int32, 384, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppLensFlareShapeRotateType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("baseRotate"), Fox.Core.PropertyInfo.PropertyType.Float, 388, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("screenSpaceRotSpeedX"), Fox.Core.PropertyInfo.PropertyType.Float, 392, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("screenSpaceRotSpeedY"), Fox.Core.PropertyInfo.PropertyType.Float, 396, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("screenSpaceRotField"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 400, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("scaleFieldX"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 440, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("scaleFieldY"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 480, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("scaleFieldPickSunPositionFlag"), Fox.Core.PropertyInfo.PropertyType.Bool, 520, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("alphaField"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 528, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("alphaFieldPickSunPositionFlag"), Fox.Core.PropertyInfo.PropertyType.Bool, 568, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shieldFadeOutTime"), Fox.Core.PropertyInfo.PropertyType.Float, 572, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shieldFadeInTime"), Fox.Core.PropertyInfo.PropertyType.Float, 576, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("angleScaleGraphX"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 584, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("angleScaleGraphY"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 624, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("angleAlphaGraph"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 664, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("distanceScaling"), Fox.Core.PropertyInfo.PropertyType.Int32, 704, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppLensFlareShapeDistanceScalingMode), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("limitDistance"), Fox.Core.PropertyInfo.PropertyType.Float, 708, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("notDrawMultiple"), Fox.Core.PropertyInfo.PropertyType.Bool, 712, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("seName"), Fox.Core.PropertyInfo.PropertyType.String, 720, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("seCallThreshold"), Fox.Core.PropertyInfo.PropertyType.Float, 728, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("scaleOnZoom"), Fox.Core.PropertyInfo.PropertyType.Bool, 732, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

            ClassInfoInitialized = true;
        }

        // Constructors
		public TppLensFlareShape(ulong id) : base(id) { }
		public TppLensFlareShape() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "material":
                    this.material = value.GetValueAsEntityLink();
                    return;
                case "width":
                    this.width = value.GetValueAsFloat();
                    return;
                case "height":
                    this.height = value.GetValueAsFloat();
                    return;
                case "baseColor":
                    this.baseColor = value.GetValueAsColor();
                    return;
                case "offsetType":
                    this.offsetType = (TppLensFlareShapeOffsetType)value.GetValueAsInt32();
                    return;
                case "offsetScale":
                    this.offsetScale = value.GetValueAsFloat();
                    return;
                case "baseOffsetX":
                    this.baseOffsetX = value.GetValueAsFloat();
                    return;
                case "baseOffsetY":
                    this.baseOffsetY = value.GetValueAsFloat();
                    return;
                case "rotateType":
                    this.rotateType = (TppLensFlareShapeRotateType)value.GetValueAsInt32();
                    return;
                case "baseRotate":
                    this.baseRotate = value.GetValueAsFloat();
                    return;
                case "screenSpaceRotSpeedX":
                    this.screenSpaceRotSpeedX = value.GetValueAsFloat();
                    return;
                case "screenSpaceRotSpeedY":
                    this.screenSpaceRotSpeedY = value.GetValueAsFloat();
                    return;
                case "screenSpaceRotField":
                    this.screenSpaceRotField = value.GetValueAsEntityLink();
                    return;
                case "scaleFieldX":
                    this.scaleFieldX = value.GetValueAsEntityLink();
                    return;
                case "scaleFieldY":
                    this.scaleFieldY = value.GetValueAsEntityLink();
                    return;
                case "scaleFieldPickSunPositionFlag":
                    this.scaleFieldPickSunPositionFlag = value.GetValueAsBool();
                    return;
                case "alphaField":
                    this.alphaField = value.GetValueAsEntityLink();
                    return;
                case "alphaFieldPickSunPositionFlag":
                    this.alphaFieldPickSunPositionFlag = value.GetValueAsBool();
                    return;
                case "shieldFadeOutTime":
                    this.shieldFadeOutTime = value.GetValueAsFloat();
                    return;
                case "shieldFadeInTime":
                    this.shieldFadeInTime = value.GetValueAsFloat();
                    return;
                case "angleScaleGraphX":
                    this.angleScaleGraphX = value.GetValueAsEntityLink();
                    return;
                case "angleScaleGraphY":
                    this.angleScaleGraphY = value.GetValueAsEntityLink();
                    return;
                case "angleAlphaGraph":
                    this.angleAlphaGraph = value.GetValueAsEntityLink();
                    return;
                case "distanceScaling":
                    this.distanceScaling = (TppLensFlareShapeDistanceScalingMode)value.GetValueAsInt32();
                    return;
                case "limitDistance":
                    this.limitDistance = value.GetValueAsFloat();
                    return;
                case "notDrawMultiple":
                    this.notDrawMultiple = value.GetValueAsBool();
                    return;
                case "seName":
                    this.seName = value.GetValueAsString();
                    return;
                case "seCallThreshold":
                    this.seCallThreshold = value.GetValueAsFloat();
                    return;
                case "scaleOnZoom":
                    this.scaleOnZoom = value.GetValueAsBool();
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