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
    public partial class TppGimmickBrokenCandleBank : Fox.Core.Data 
    {
        // Properties
        public System.Collections.Generic.IList<Path> referencePartsPathList { get; } = new System.Collections.Generic.List<Path>();
        
        public FilePtr<File> modelFile { get; set; }
        
        public FilePtr<File> connectPointFile { get; set; }
        
        public FilePtr<File> soundFile { get; set; }
        
        public byte instanceCount { get; set; }
        
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
        static TppGimmickBrokenCandleBank()
        {
            classInfo = new EntityInfo(new String("TppGimmickBrokenCandleBank"), base.GetClassEntityInfo(), 160, "Gimmick", 0);
			
			classInfo.StaticProperties.Insert(new String("referencePartsPathList"), new PropertyInfo(PropertyInfo.PropertyType.Path, 120, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("modelFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 136, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("connectPointFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 160, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("soundFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 184, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("instanceCount"), new PropertyInfo(PropertyInfo.PropertyType.UInt8, 208, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppGimmickBrokenCandleBank(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "modelFile":
                    this.modelFile = value.GetValueAsFilePtr();
                    return;
                case "connectPointFile":
                    this.connectPointFile = value.GetValueAsFilePtr();
                    return;
                case "soundFile":
                    this.soundFile = value.GetValueAsFilePtr();
                    return;
                case "instanceCount":
                    this.instanceCount = value.GetValueAsUInt8();
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
                case "referencePartsPathList":
                    while(this.referencePartsPathList.Count <= index) { this.referencePartsPathList.Add(default(Path)); }
                    this.referencePartsPathList[index] = value.GetValueAsPath();
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