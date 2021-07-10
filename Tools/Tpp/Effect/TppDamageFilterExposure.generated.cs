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
    public partial class TppDamageFilterExposure : Fox.Core.Data 
    {
        // Properties
        public float exposureCompensation { get; set; }
        
        public float minExposure { get; set; }
        
        public float maxExposure { get; set; }
        
        public float beatExposureCompensation { get; set; }
        
        public float minBeatInterval { get; set; }
        
        public float maxBeatInterval { get; set; }
        
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
        static TppDamageFilterExposure()
        {
            classInfo = new EntityInfo(new String("TppDamageFilterExposure"), base.GetClassEntityInfo(), 88, null, 1);
			
			classInfo.StaticProperties.Insert(new String("exposureCompensation"), new PropertyInfo(PropertyInfo.PropertyType.Float, 120, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("minExposure"), new PropertyInfo(PropertyInfo.PropertyType.Float, 124, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("maxExposure"), new PropertyInfo(PropertyInfo.PropertyType.Float, 128, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("beatExposureCompensation"), new PropertyInfo(PropertyInfo.PropertyType.Float, 132, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("minBeatInterval"), new PropertyInfo(PropertyInfo.PropertyType.Float, 136, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("maxBeatInterval"), new PropertyInfo(PropertyInfo.PropertyType.Float, 140, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppDamageFilterExposure(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "exposureCompensation":
                    this.exposureCompensation = value.GetValueAsFloat();
                    return;
                case "minExposure":
                    this.minExposure = value.GetValueAsFloat();
                    return;
                case "maxExposure":
                    this.maxExposure = value.GetValueAsFloat();
                    return;
                case "beatExposureCompensation":
                    this.beatExposureCompensation = value.GetValueAsFloat();
                    return;
                case "minBeatInterval":
                    this.minBeatInterval = value.GetValueAsFloat();
                    return;
                case "maxBeatInterval":
                    this.maxBeatInterval = value.GetValueAsFloat();
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