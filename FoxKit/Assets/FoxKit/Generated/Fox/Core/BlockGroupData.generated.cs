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

namespace Fox.Core
{
    [UnityEditor.InitializeOnLoad]
    public partial class BlockGroupData : Fox.Core.Data 
    {
        // Properties
        public float blockMemorySize { get => Get_blockMemorySize(); set { Set_blockMemorySize(value); } }
        protected partial float Get_blockMemorySize();
        protected partial void Set_blockMemorySize(float value);
        
        [field: UnityEngine.SerializeField]
        public BlockGroupData_ByteOrder sizeOrder { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint blockSizeInBytes { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint blockCount { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<Fox.Core.Path> block { get; set; } = new Fox.Core.DynamicArray<Fox.Core.Path>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<Fox.Core.EntityLink> relatedBlockGroups { get; set; } = new Fox.Core.DynamicArray<Fox.Core.EntityLink>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<Fox.Core.EntityLink> prerequisiteBlockGroups { get; set; } = new Fox.Core.DynamicArray<Fox.Core.EntityLink>();
        
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
        static BlockGroupData()
        {
            classInfo = new Fox.EntityInfo("BlockGroupData", typeof(BlockGroupData), new Fox.Core.Data().GetClassEntityInfo(), 0, null, 1);
			classInfo.StaticProperties.Insert("blockMemorySize", new Fox.Core.PropertyInfo("blockMemorySize", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("sizeOrder", new Fox.Core.PropertyInfo("sizeOrder", Fox.Core.PropertyInfo.PropertyType.Int32, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(BlockGroupData_ByteOrder), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blockSizeInBytes", new Fox.Core.PropertyInfo("blockSizeInBytes", Fox.Core.PropertyInfo.PropertyType.UInt32, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blockCount", new Fox.Core.PropertyInfo("blockCount", Fox.Core.PropertyInfo.PropertyType.UInt32, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("block", new Fox.Core.PropertyInfo("block", Fox.Core.PropertyInfo.PropertyType.Path, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("relatedBlockGroups", new Fox.Core.PropertyInfo("relatedBlockGroups", Fox.Core.PropertyInfo.PropertyType.EntityLink, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("prerequisiteBlockGroups", new Fox.Core.PropertyInfo("prerequisiteBlockGroups", Fox.Core.PropertyInfo.PropertyType.EntityLink, 168, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public BlockGroupData(ulong id) : base(id) { }
		public BlockGroupData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "blockMemorySize":
                    this.blockMemorySize = value.GetValueAsFloat();
                    return;
                case "sizeOrder":
                    this.sizeOrder = (BlockGroupData_ByteOrder)value.GetValueAsInt32();
                    return;
                case "blockSizeInBytes":
                    this.blockSizeInBytes = value.GetValueAsUInt32();
                    return;
                case "blockCount":
                    this.blockCount = value.GetValueAsUInt32();
                    return;
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "block":
                    while(this.block.Count <= index) { this.block.Add(default(Fox.Core.Path)); }
                    this.block[index] = value.GetValueAsPath();
                    return;
                case "relatedBlockGroups":
                    while(this.relatedBlockGroups.Count <= index) { this.relatedBlockGroups.Add(default(Fox.Core.EntityLink)); }
                    this.relatedBlockGroups[index] = value.GetValueAsEntityLink();
                    return;
                case "prerequisiteBlockGroups":
                    while(this.prerequisiteBlockGroups.Count <= index) { this.prerequisiteBlockGroups.Add(default(Fox.Core.EntityLink)); }
                    this.prerequisiteBlockGroups[index] = value.GetValueAsEntityLink();
                    return;
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
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