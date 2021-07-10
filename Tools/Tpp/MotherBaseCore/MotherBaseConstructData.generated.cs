//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Tpp.MotherBaseCore
{
    public partial class MotherBaseConstructData : Fox.Core.TransformData 
    {
        // Properties
        public MbConstructDataType type { get; set; }
        
        public ushort index { get; set; }
        
        public byte[] divisionType { get; } = new byte[4];
        
        public ushort[] divisionRotate { get; } = new ushort[4];
        
        public bool[] anotherConnector { get; } = new bool[8];
        
        public byte cluster { get; set; }
        
        public byte plant { get; set; }
        
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
        static MotherBaseConstructData()
        {
            classInfo = new EntityInfo(new String("MotherBaseConstructData"), base.GetClassEntityInfo(), 288, "TppMotherBase", 6);
			
			classInfo.StaticProperties.Insert(new String("type"), new PropertyInfo(PropertyInfo.PropertyType.Int32, 368, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, typeof(MbConstructDataType), PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("index"), new PropertyInfo(PropertyInfo.PropertyType.UInt16, 372, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("divisionType"), new PropertyInfo(PropertyInfo.PropertyType.UInt8, 374, 4, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("divisionRotate"), new PropertyInfo(PropertyInfo.PropertyType.UInt16, 378, 4, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("anotherConnector"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 386, 8, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("cluster"), new PropertyInfo(PropertyInfo.PropertyType.UInt8, 394, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("plant"), new PropertyInfo(PropertyInfo.PropertyType.UInt8, 395, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public MotherBaseConstructData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "type":
                    this.type = (MbConstructDataType)value.GetValueAsInt32();
                    return;
                case "index":
                    this.index = value.GetValueAsUInt16();
                    return;
                case "cluster":
                    this.cluster = value.GetValueAsUInt8();
                    return;
                case "plant":
                    this.plant = value.GetValueAsUInt8();
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
                case "divisionType":
                    
                    this.divisionType[index] = value.GetValueAsUInt8();
                    return;
                case "divisionRotate":
                    
                    this.divisionRotate[index] = value.GetValueAsUInt16();
                    return;
                case "anotherConnector":
                    
                    this.anotherConnector[index] = value.GetValueAsBool();
                    return;
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