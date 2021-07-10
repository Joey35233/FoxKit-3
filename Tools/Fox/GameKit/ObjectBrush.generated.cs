//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.GameKit
{
    public partial class ObjectBrush : Fox.Core.TransformData 
    {
        // Properties
        public System.Collections.Generic.IList<EntityHandle> pluginHandle { get; } = new System.Collections.Generic.List<EntityHandle>();
        
        public System.Collections.Generic.IList<String> blockDataName { get; } = new System.Collections.Generic.List<String>();
        
        public Path filePath { get; set; }
        
        public Path loadFilePath { get; set; }
        
        public FilePtr<File> obrFile { get; set; }
        
        public uint numBlocks { get; set; }
        
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
        static ObjectBrush()
        {
            classInfo = new EntityInfo(new String("ObjectBrush"), base.GetClassEntityInfo(), 352, null, 4);
			
			classInfo.StaticProperties.Insert(new String("pluginHandle"), new PropertyInfo(PropertyInfo.PropertyType.EntityHandle, 304, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("blockDataName"), new PropertyInfo(PropertyInfo.PropertyType.String, 320, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("filePath"), new PropertyInfo(PropertyInfo.PropertyType.Path, 336, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("loadFilePath"), new PropertyInfo(PropertyInfo.PropertyType.Path, 344, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("obrFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 352, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("numBlocks"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 376, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public ObjectBrush(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "filePath":
                    this.filePath = value.GetValueAsPath();
                    return;
                case "loadFilePath":
                    this.loadFilePath = value.GetValueAsPath();
                    return;
                case "obrFile":
                    this.obrFile = value.GetValueAsFilePtr();
                    return;
                case "numBlocks":
                    this.numBlocks = value.GetValueAsUInt32();
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
                case "pluginHandle":
                    while(this.pluginHandle.Count <= index) { this.pluginHandle.Add(default(EntityHandle)); }
                    this.pluginHandle[index] = value.GetValueAsEntityHandle();
                    return;
                case "blockDataName":
                    while(this.blockDataName.Count <= index) { this.blockDataName.Add(default(String)); }
                    this.blockDataName[index] = value.GetValueAsString();
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