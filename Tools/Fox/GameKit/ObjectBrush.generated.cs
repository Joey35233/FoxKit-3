//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using CsSystem = System;
using Fox;

namespace Fox.GameKit
{
    [UnityEditor.InitializeOnLoad]
    public partial class ObjectBrush : Fox.Core.TransformData 
    {
        // Properties
        public Fox.Core.DynamicArray<Fox.Core.EntityHandle> pluginHandle = new Fox.Core.DynamicArray<Fox.Core.EntityHandle>();
        
        public Fox.Core.DynamicArray<Fox.String> blockDataName = new Fox.Core.DynamicArray<Fox.String>();
        
        public Fox.Core.Path filePath;
        
        public Fox.Core.Path loadFilePath;
        
        public Fox.Core.FilePtr<Fox.Core.File> obrFile;
        
        public uint numBlocks;
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static ObjectBrush()
        {
            classInfo = new Fox.EntityInfo("ObjectBrush", typeof(ObjectBrush), new Fox.Core.TransformData().GetClassEntityInfo(), 352, null, 4);
			classInfo.StaticProperties.Insert("pluginHandle", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityHandle, 304, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blockDataName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 320, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("filePath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("loadFilePath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 344, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("obrFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("numBlocks", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 376, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public ObjectBrush(ulong id) : base(id) { }
		public ObjectBrush() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
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
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                case "pluginHandle":
                    while(this.pluginHandle.Count <= index) { this.pluginHandle.Add(default(Fox.Core.EntityHandle)); }
                    this.pluginHandle[index] = value.GetValueAsEntityHandle();
                    return;
                case "blockDataName":
                    while(this.blockDataName.Count <= index) { this.blockDataName.Add(default(Fox.String)); }
                    this.blockDataName[index] = value.GetValueAsString();
                    return;
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}