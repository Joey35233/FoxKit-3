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
    public partial class TppLensFlareAsymmetricField : Tpp.Effect.TppLensFlareField 
    {
        // Properties
        public float verticalInnerScale { get; set; }
        
        public float verticalCenterScale { get; set; }
        
        public float verticalOuterScale { get; set; }
        
        public float verticalInnerValue { get; set; }
        
        public float verticalCenterValue { get; set; }
        
        public float verticalOuterValue { get; set; }
        
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
        static TppLensFlareAsymmetricField()
        {
            classInfo = new EntityInfo(new String("TppLensFlareAsymmetricField"), base.GetClassEntityInfo(), 176, null, 0);
			
			classInfo.StaticProperties.Insert(new String("verticalInnerScale"), new PropertyInfo(PropertyInfo.PropertyType.Float, 208, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("verticalCenterScale"), new PropertyInfo(PropertyInfo.PropertyType.Float, 216, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("verticalOuterScale"), new PropertyInfo(PropertyInfo.PropertyType.Float, 224, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("verticalInnerValue"), new PropertyInfo(PropertyInfo.PropertyType.Float, 212, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("verticalCenterValue"), new PropertyInfo(PropertyInfo.PropertyType.Float, 220, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("verticalOuterValue"), new PropertyInfo(PropertyInfo.PropertyType.Float, 228, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppLensFlareAsymmetricField(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "verticalInnerScale":
                    this.verticalInnerScale = value.GetValueAsFloat();
                    return;
                case "verticalCenterScale":
                    this.verticalCenterScale = value.GetValueAsFloat();
                    return;
                case "verticalOuterScale":
                    this.verticalOuterScale = value.GetValueAsFloat();
                    return;
                case "verticalInnerValue":
                    this.verticalInnerValue = value.GetValueAsFloat();
                    return;
                case "verticalCenterValue":
                    this.verticalCenterValue = value.GetValueAsFloat();
                    return;
                case "verticalOuterValue":
                    this.verticalOuterValue = value.GetValueAsFloat();
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