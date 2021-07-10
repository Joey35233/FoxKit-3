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
    public partial class TppSharedGimmickData : Fox.Core.Data 
    {
        // Properties
        public FilePtr<File> modelFile { get; set; }
        
        public FilePtr<File> geomFile { get; set; }
        
        public FilePtr<File> breakedModelFile { get; set; }
        
        public FilePtr<File> breakedGeomFile { get; set; }
        
        public FilePtr<File> partsFile { get; set; }
        
        public uint numDynamicGimmick { get; set; }
        
        public FilePtr<File> locaterFile { get; set; }
        
        public uint flags1 { get; set; }
        
        public uint flags2 { get; set; }
        
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
        static TppSharedGimmickData()
        {
            classInfo = new EntityInfo(new String("TppSharedGimmickData"), base.GetClassEntityInfo(), 240, "Gimmick", 1);
			
			classInfo.StaticProperties.Insert(new String("modelFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 120, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("geomFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 144, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("breakedModelFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 168, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("breakedGeomFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 192, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("partsFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 216, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("numDynamicGimmick"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 240, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("locaterFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 256, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("flags1"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 244, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("flags2"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 248, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppSharedGimmickData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "modelFile":
                    this.modelFile = value.GetValueAsFilePtr();
                    return;
                case "geomFile":
                    this.geomFile = value.GetValueAsFilePtr();
                    return;
                case "breakedModelFile":
                    this.breakedModelFile = value.GetValueAsFilePtr();
                    return;
                case "breakedGeomFile":
                    this.breakedGeomFile = value.GetValueAsFilePtr();
                    return;
                case "partsFile":
                    this.partsFile = value.GetValueAsFilePtr();
                    return;
                case "numDynamicGimmick":
                    this.numDynamicGimmick = value.GetValueAsUInt32();
                    return;
                case "locaterFile":
                    this.locaterFile = value.GetValueAsFilePtr();
                    return;
                case "flags1":
                    this.flags1 = value.GetValueAsUInt32();
                    return;
                case "flags2":
                    this.flags2 = value.GetValueAsUInt32();
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