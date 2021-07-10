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
    public partial class TppOutOfMissionRangeEffect : Fox.Core.Data 
    {
        // Properties
        public bool enable { get; set; }
        
        public Path lutTexture { get; set; }
        
        public float startSlope { get; set; }
        
        public float endSlope { get; set; }
        
        public float blendRatio { get; set; }
        
        public Color colorScale { get; set; }
        
        public float noiseScale { get; set; }
        
        public float noiseOffset { get; set; }
        
        public float noiseCutScale { get; set; }
        
        public float noiseCutOffset { get; set; }
        
        public Color noiseColor { get; set; }
        
        public float cinemaScopeSlope { get; set; }
        
        public float cinemaScopeShift { get; set; }
        
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
        static TppOutOfMissionRangeEffect()
        {
            classInfo = new EntityInfo(new String("TppOutOfMissionRangeEffect"), base.GetClassEntityInfo(), 144, "TppEffect", 2);
			
			classInfo.StaticProperties.Insert(new String("enable"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 204, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("lutTexture"), new PropertyInfo(PropertyInfo.PropertyType.Path, 160, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("startSlope"), new PropertyInfo(PropertyInfo.PropertyType.Float, 168, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("endSlope"), new PropertyInfo(PropertyInfo.PropertyType.Float, 172, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("blendRatio"), new PropertyInfo(PropertyInfo.PropertyType.Float, 176, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("colorScale"), new PropertyInfo(PropertyInfo.PropertyType.Color, 128, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("noiseScale"), new PropertyInfo(PropertyInfo.PropertyType.Float, 180, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("noiseOffset"), new PropertyInfo(PropertyInfo.PropertyType.Float, 184, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("noiseCutScale"), new PropertyInfo(PropertyInfo.PropertyType.Float, 188, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("noiseCutOffset"), new PropertyInfo(PropertyInfo.PropertyType.Float, 192, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("noiseColor"), new PropertyInfo(PropertyInfo.PropertyType.Color, 144, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("cinemaScopeSlope"), new PropertyInfo(PropertyInfo.PropertyType.Float, 196, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("cinemaScopeShift"), new PropertyInfo(PropertyInfo.PropertyType.Float, 200, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppOutOfMissionRangeEffect(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "lutTexture":
                    this.lutTexture = value.GetValueAsPath();
                    return;
                case "startSlope":
                    this.startSlope = value.GetValueAsFloat();
                    return;
                case "endSlope":
                    this.endSlope = value.GetValueAsFloat();
                    return;
                case "blendRatio":
                    this.blendRatio = value.GetValueAsFloat();
                    return;
                case "colorScale":
                    this.colorScale = value.GetValueAsColor();
                    return;
                case "noiseScale":
                    this.noiseScale = value.GetValueAsFloat();
                    return;
                case "noiseOffset":
                    this.noiseOffset = value.GetValueAsFloat();
                    return;
                case "noiseCutScale":
                    this.noiseCutScale = value.GetValueAsFloat();
                    return;
                case "noiseCutOffset":
                    this.noiseCutOffset = value.GetValueAsFloat();
                    return;
                case "noiseColor":
                    this.noiseColor = value.GetValueAsColor();
                    return;
                case "cinemaScopeSlope":
                    this.cinemaScopeSlope = value.GetValueAsFloat();
                    return;
                case "cinemaScopeShift":
                    this.cinemaScopeShift = value.GetValueAsFloat();
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