//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Fx
{
    public partial class FxLocatorData : Fox.Core.TransformData 
    {
        // Properties
        public String variationName { get; set; }
        
        public String effectInstanceName { get; set; }
        
        public bool enableUserRandomSeed { get; set; }
        
        public uint userRandomSeed { get; set; }
        
        public bool shapeKeep { get; set; }
        
        public bool createOnInitialize { get; set; }
        
        public bool blockMemoryAllocation { get; set; }
        
        public FilePtr<File> vfxFile { get; set; }
        
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
        static FxLocatorData()
        {
            classInfo = new EntityInfo(new String("FxLocatorData"), base.GetClassEntityInfo(), 304, "Fx", 4);
			
			classInfo.StaticProperties.Insert(new String("variationName"), new PropertyInfo(PropertyInfo.PropertyType.String, 336, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("effectInstanceName"), new PropertyInfo(PropertyInfo.PropertyType.String, 328, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("enableUserRandomSeed"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 348, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("userRandomSeed"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 344, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("shapeKeep"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 349, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("createOnInitialize"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 350, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("blockMemoryAllocation"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 351, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("vfxFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 304, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public FxLocatorData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "variationName":
                    this.variationName = value.GetValueAsString();
                    return;
                case "effectInstanceName":
                    this.effectInstanceName = value.GetValueAsString();
                    return;
                case "enableUserRandomSeed":
                    this.enableUserRandomSeed = value.GetValueAsBool();
                    return;
                case "userRandomSeed":
                    this.userRandomSeed = value.GetValueAsUInt32();
                    return;
                case "shapeKeep":
                    this.shapeKeep = value.GetValueAsBool();
                    return;
                case "createOnInitialize":
                    this.createOnInitialize = value.GetValueAsBool();
                    return;
                case "blockMemoryAllocation":
                    this.blockMemoryAllocation = value.GetValueAsBool();
                    return;
                case "vfxFile":
                    this.vfxFile = value.GetValueAsFilePtr();
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