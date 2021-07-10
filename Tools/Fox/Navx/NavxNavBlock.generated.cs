//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Navx
{
    public partial class NavxNavBlock : Fox.Core.Data 
    {
        // Properties
        public String sceneName { get; set; }
        
        public String worldName { get; set; }
        
        public uint tileId { get; set; }
        
        public Path filePath { get; set; }
        
        public FilePtr<File> filePtr { get; set; }
        
        public FilePtr<File> remainingFilePtr { get; set; }
        
        public bool isSplit { get; set; }
        
        public uint maxFileSizeInKb { get; set; }
        
        public bool useBlockParameter { get; set; }
        
        public float verticalThreshold { get; set; }
        
        public float simplificationThreshold { get; set; }
        
        public bool doesHoleSimplification { get; set; }
        
        public float holeSimplificationConvexThreshold { get; set; }
        
        public float holeSimplificationObbExpandThreshold { get; set; }
        
        public float holeSimplificationObbToAabbThreshold { get; set; }
        
        public float holeSimplificationSmoothingThreshold { get; set; }
        
        public bool isHoleSimplificationDoesNotClosePassage { get; set; }
        
        public uint holeSimplificationReduceCount { get; set; }
        
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
        static NavxNavBlock()
        {
            classInfo = new EntityInfo(new String("NavxNavBlock"), base.GetClassEntityInfo(), 248, "Navx", 9);
			
			classInfo.StaticProperties.Insert(new String("sceneName"), new PropertyInfo(PropertyInfo.PropertyType.String, 120, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("worldName"), new PropertyInfo(PropertyInfo.PropertyType.String, 128, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("tileId"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 136, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("filePath"), new PropertyInfo(PropertyInfo.PropertyType.Path, 144, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("filePtr"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 152, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("remainingFilePtr"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 176, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isSplit"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 208, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("maxFileSizeInKb"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 212, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("useBlockParameter"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 216, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("verticalThreshold"), new PropertyInfo(PropertyInfo.PropertyType.Float, 220, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("simplificationThreshold"), new PropertyInfo(PropertyInfo.PropertyType.Float, 224, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("doesHoleSimplification"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 228, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("holeSimplificationConvexThreshold"), new PropertyInfo(PropertyInfo.PropertyType.Float, 232, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("holeSimplificationObbExpandThreshold"), new PropertyInfo(PropertyInfo.PropertyType.Float, 236, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("holeSimplificationObbToAabbThreshold"), new PropertyInfo(PropertyInfo.PropertyType.Float, 240, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("holeSimplificationSmoothingThreshold"), new PropertyInfo(PropertyInfo.PropertyType.Float, 244, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isHoleSimplificationDoesNotClosePassage"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 248, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("holeSimplificationReduceCount"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 252, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public NavxNavBlock(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "sceneName":
                    this.sceneName = value.GetValueAsString();
                    return;
                case "worldName":
                    this.worldName = value.GetValueAsString();
                    return;
                case "tileId":
                    this.tileId = value.GetValueAsUInt32();
                    return;
                case "filePath":
                    this.filePath = value.GetValueAsPath();
                    return;
                case "filePtr":
                    this.filePtr = value.GetValueAsFilePtr();
                    return;
                case "remainingFilePtr":
                    this.remainingFilePtr = value.GetValueAsFilePtr();
                    return;
                case "isSplit":
                    this.isSplit = value.GetValueAsBool();
                    return;
                case "maxFileSizeInKb":
                    this.maxFileSizeInKb = value.GetValueAsUInt32();
                    return;
                case "useBlockParameter":
                    this.useBlockParameter = value.GetValueAsBool();
                    return;
                case "verticalThreshold":
                    this.verticalThreshold = value.GetValueAsFloat();
                    return;
                case "simplificationThreshold":
                    this.simplificationThreshold = value.GetValueAsFloat();
                    return;
                case "doesHoleSimplification":
                    this.doesHoleSimplification = value.GetValueAsBool();
                    return;
                case "holeSimplificationConvexThreshold":
                    this.holeSimplificationConvexThreshold = value.GetValueAsFloat();
                    return;
                case "holeSimplificationObbExpandThreshold":
                    this.holeSimplificationObbExpandThreshold = value.GetValueAsFloat();
                    return;
                case "holeSimplificationObbToAabbThreshold":
                    this.holeSimplificationObbToAabbThreshold = value.GetValueAsFloat();
                    return;
                case "holeSimplificationSmoothingThreshold":
                    this.holeSimplificationSmoothingThreshold = value.GetValueAsFloat();
                    return;
                case "isHoleSimplificationDoesNotClosePassage":
                    this.isHoleSimplificationDoesNotClosePassage = value.GetValueAsBool();
                    return;
                case "holeSimplificationReduceCount":
                    this.holeSimplificationReduceCount = value.GetValueAsUInt32();
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