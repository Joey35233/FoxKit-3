//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Tpp.GameKit
{
    public partial class TppPermanentGimmickSearchLightParameter : Fox.Core.DataElement 
    {
        // Properties
        public float rotationLimitLeftRight { get; set; }
        
        public float rotationLimitUp { get; set; }
        
        public float rotationLimitDown { get; set; }
        
        public float rangeDiscovery { get; set; }
        
        public float rangeLeftRightDiscovery { get; set; }
        
        public float rangeUpDownDiscovery { get; set; }
        
        public float rangeDim { get; set; }
        
        public float rangeLeftRightDim { get; set; }
        
        public float rangeUpDownDim { get; set; }
        
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
        static TppPermanentGimmickSearchLightParameter()
        {
            classInfo = new EntityInfo(new String("TppPermanentGimmickSearchLightParameter"), base.GetClassEntityInfo(), 64, null, 0);
			
			classInfo.StaticProperties.Insert(new String("rotationLimitLeftRight"), new PropertyInfo(PropertyInfo.PropertyType.Float, 56, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rotationLimitUp"), new PropertyInfo(PropertyInfo.PropertyType.Float, 60, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rotationLimitDown"), new PropertyInfo(PropertyInfo.PropertyType.Float, 64, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rangeDiscovery"), new PropertyInfo(PropertyInfo.PropertyType.Float, 68, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rangeLeftRightDiscovery"), new PropertyInfo(PropertyInfo.PropertyType.Float, 72, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rangeUpDownDiscovery"), new PropertyInfo(PropertyInfo.PropertyType.Float, 76, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rangeDim"), new PropertyInfo(PropertyInfo.PropertyType.Float, 80, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rangeLeftRightDim"), new PropertyInfo(PropertyInfo.PropertyType.Float, 84, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rangeUpDownDim"), new PropertyInfo(PropertyInfo.PropertyType.Float, 88, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppPermanentGimmickSearchLightParameter(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "rotationLimitLeftRight":
                    this.rotationLimitLeftRight = value.GetValueAsFloat();
                    return;
                case "rotationLimitUp":
                    this.rotationLimitUp = value.GetValueAsFloat();
                    return;
                case "rotationLimitDown":
                    this.rotationLimitDown = value.GetValueAsFloat();
                    return;
                case "rangeDiscovery":
                    this.rangeDiscovery = value.GetValueAsFloat();
                    return;
                case "rangeLeftRightDiscovery":
                    this.rangeLeftRightDiscovery = value.GetValueAsFloat();
                    return;
                case "rangeUpDownDiscovery":
                    this.rangeUpDownDiscovery = value.GetValueAsFloat();
                    return;
                case "rangeDim":
                    this.rangeDim = value.GetValueAsFloat();
                    return;
                case "rangeLeftRightDim":
                    this.rangeLeftRightDim = value.GetValueAsFloat();
                    return;
                case "rangeUpDownDim":
                    this.rangeUpDownDim = value.GetValueAsFloat();
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