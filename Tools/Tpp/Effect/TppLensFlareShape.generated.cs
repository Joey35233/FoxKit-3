//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Tpp.Effect
{
    public partial class TppLensFlareShape : Fox.Core.TransformData 
    {
        // Properties
        public EntityLink material { get; set; }
        
        public float width { get; set; }
        
        public float height { get; set; }
        
        public Color baseColor { get; set; }
        
        public TppLensFlareShapeOffsetType offsetType { get; set; }
        
        public float offsetScale { get; set; }
        
        public float baseOffsetX { get; set; }
        
        public float baseOffsetY { get; set; }
        
        public TppLensFlareShapeRotateType rotateType { get; set; }
        
        public float baseRotate { get; set; }
        
        public float screenSpaceRotSpeedX { get; set; }
        
        public float screenSpaceRotSpeedY { get; set; }
        
        public EntityLink screenSpaceRotField { get; set; }
        
        public EntityLink scaleFieldX { get; set; }
        
        public EntityLink scaleFieldY { get; set; }
        
        public bool scaleFieldPickSunPositionFlag { get; set; }
        
        public EntityLink alphaField { get; set; }
        
        public bool alphaFieldPickSunPositionFlag { get; set; }
        
        public float shieldFadeOutTime { get; set; }
        
        public float shieldFadeInTime { get; set; }
        
        public EntityLink angleScaleGraphX { get; set; }
        
        public EntityLink angleScaleGraphY { get; set; }
        
        public EntityLink angleAlphaGraph { get; set; }
        
        public TppLensFlareShapeDistanceScalingMode distanceScaling { get; set; }
        
        public float limitDistance { get; set; }
        
        public bool notDrawMultiple { get; set; }
        
        public String seName { get; set; }
        
        public float seCallThreshold { get; set; }
        
        public bool scaleOnZoom { get; set; }
        
        // PropertyInfo
        private static EntityInfo classInfo;
        public static new EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static TppLensFlareShape()
        {
            classInfo = new EntityInfo(new String("TppLensFlareShape"), base.GetClassEntityInfo(), 672, null, 11);
			
			classInfo.StaticProperties.Insert(new String("material"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 304, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("width"), new PropertyInfo(PropertyInfo.PropertyType.Float, 344, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("height"), new PropertyInfo(PropertyInfo.PropertyType.Float, 348, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("baseColor"), new PropertyInfo(PropertyInfo.PropertyType.Color, 352, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("offsetType"), new PropertyInfo(PropertyInfo.PropertyType.Int32, 368, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppLensFlareShapeOffsetType), PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("offsetScale"), new PropertyInfo(PropertyInfo.PropertyType.Float, 372, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("baseOffsetX"), new PropertyInfo(PropertyInfo.PropertyType.Float, 376, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("baseOffsetY"), new PropertyInfo(PropertyInfo.PropertyType.Float, 380, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rotateType"), new PropertyInfo(PropertyInfo.PropertyType.Int32, 384, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppLensFlareShapeRotateType), PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("baseRotate"), new PropertyInfo(PropertyInfo.PropertyType.Float, 388, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("screenSpaceRotSpeedX"), new PropertyInfo(PropertyInfo.PropertyType.Float, 392, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("screenSpaceRotSpeedY"), new PropertyInfo(PropertyInfo.PropertyType.Float, 396, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("screenSpaceRotField"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 400, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("scaleFieldX"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 440, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("scaleFieldY"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 480, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("scaleFieldPickSunPositionFlag"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 520, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("alphaField"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 528, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("alphaFieldPickSunPositionFlag"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 568, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("shieldFadeOutTime"), new PropertyInfo(PropertyInfo.PropertyType.Float, 572, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("shieldFadeInTime"), new PropertyInfo(PropertyInfo.PropertyType.Float, 576, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("angleScaleGraphX"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 584, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("angleScaleGraphY"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 624, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("angleAlphaGraph"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 664, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("distanceScaling"), new PropertyInfo(PropertyInfo.PropertyType.Int32, 704, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppLensFlareShapeDistanceScalingMode), PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("limitDistance"), new PropertyInfo(PropertyInfo.PropertyType.Float, 708, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("notDrawMultiple"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 712, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("seName"), new PropertyInfo(PropertyInfo.PropertyType.String, 720, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("seCallThreshold"), new PropertyInfo(PropertyInfo.PropertyType.Float, 728, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("scaleOnZoom"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 732, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppLensFlareShape(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
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
        
        public override void SetPropertyElement(String propertyName, ushort index, Value value)
        {
            switch(propertyName.CString())
            {
                default:
					
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(String propertyName, String key, Value value)
        {
            switch(propertyName.CString())
            {
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}