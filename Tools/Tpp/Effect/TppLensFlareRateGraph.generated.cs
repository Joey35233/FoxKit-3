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
    public partial class TppLensFlareRateGraph : Fox.Core.Data 
    {
        // Properties
        public float value0_0 { get; set; }
        
        public float value0_1 { get; set; }
        
        public float value0_2 { get; set; }
        
        public float value0_3 { get; set; }
        
        public float value0_4 { get; set; }
        
        public float value0_5 { get; set; }
        
        public float value0_6 { get; set; }
        
        public float value0_7 { get; set; }
        
        public float value0_8 { get; set; }
        
        public float value0_9 { get; set; }
        
        public float value1_0 { get; set; }
        
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
        static TppLensFlareRateGraph()
        {
            classInfo = new EntityInfo(new String("TppLensFlareRateGraph"), base.GetClassEntityInfo(), 108, null, 0);
			
			classInfo.StaticProperties.Insert(new String("value0_0"), new PropertyInfo(PropertyInfo.PropertyType.Float, 120, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("value0_1"), new PropertyInfo(PropertyInfo.PropertyType.Float, 124, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("value0_2"), new PropertyInfo(PropertyInfo.PropertyType.Float, 128, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("value0_3"), new PropertyInfo(PropertyInfo.PropertyType.Float, 132, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("value0_4"), new PropertyInfo(PropertyInfo.PropertyType.Float, 136, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("value0_5"), new PropertyInfo(PropertyInfo.PropertyType.Float, 140, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("value0_6"), new PropertyInfo(PropertyInfo.PropertyType.Float, 144, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("value0_7"), new PropertyInfo(PropertyInfo.PropertyType.Float, 148, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("value0_8"), new PropertyInfo(PropertyInfo.PropertyType.Float, 152, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("value0_9"), new PropertyInfo(PropertyInfo.PropertyType.Float, 156, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("value1_0"), new PropertyInfo(PropertyInfo.PropertyType.Float, 160, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppLensFlareRateGraph(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "value0_0":
                    this.value0_0 = value.GetValueAsFloat();
                    return;
                case "value0_1":
                    this.value0_1 = value.GetValueAsFloat();
                    return;
                case "value0_2":
                    this.value0_2 = value.GetValueAsFloat();
                    return;
                case "value0_3":
                    this.value0_3 = value.GetValueAsFloat();
                    return;
                case "value0_4":
                    this.value0_4 = value.GetValueAsFloat();
                    return;
                case "value0_5":
                    this.value0_5 = value.GetValueAsFloat();
                    return;
                case "value0_6":
                    this.value0_6 = value.GetValueAsFloat();
                    return;
                case "value0_7":
                    this.value0_7 = value.GetValueAsFloat();
                    return;
                case "value0_8":
                    this.value0_8 = value.GetValueAsFloat();
                    return;
                case "value0_9":
                    this.value0_9 = value.GetValueAsFloat();
                    return;
                case "value1_0":
                    this.value1_0 = value.GetValueAsFloat();
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