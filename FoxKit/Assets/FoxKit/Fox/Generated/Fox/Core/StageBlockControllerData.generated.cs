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
    public partial class StageBlockControllerData : Fox.Core.Data 
    {
        // Properties
        public bool enable;
        
        public Fox.String stageName;
        
        public bool useBaseDirectoryPathAndName;
        
        public Fox.String baseDirectoryPath;
        
        public Fox.String baseName;
        
        public Fox.String smallBlock1BaseDirectoryPath;
        
        public Fox.String smallBlock1BaseName;
        
        public uint blockSizeX;
        
        public uint blockSizeZ;
        
        public uint countX;
        
        public uint countZ;
        
        public uint centerIndexX;
        
        public uint centerIndexZ;
        
        public uint blockSizeInBytes;
        
        public uint smallBlock1CountX;
        
        public uint smallBlock1CountZ;
        
        public uint smallBlock1BlockSizeInBytes;
        
        public uint blockMarginX;
        
        public uint blockMarginZ;
        
        public uint loadingDistanceX;
        
        public uint loadingDistanceZ;
        
        public uint commonBlockSizeInBytes;
        
        public uint largeBlockCount0;
        
        public uint largeBlockSizeInBytes0;
        
        public uint largeBlockCount1;
        
        public uint largeBlockSizeInBytes1;
        
        public uint largeBlockCount2;
        
        public uint largeBlockSizeInBytes2;
        
        public uint largeBlockCount3;
        
        public uint largeBlockSizeInBytes3;
        
        public uint largeBlockLoadingMarginX;
        
        public uint largeBlockLoadingMarginZ;
        
        public Fox.Core.FilePtr<Fox.Core.File> stageBlockFile;
        
        public Fox.String lod0BaseDirectoryPath;
        
        public Fox.String lod0BaseName;
        
        public uint lod0blockSizeInBytes;
        
        public byte lod0blockSizeX;
        
        public byte lod0blockSizeZ;
        
        public byte lod0BlockCountX;
        
        public byte lod0BlockCountZ;
        
        public uint lod0LargeBlock0SizeInBytes;
        
        public byte lod0LargeBlock0Count;
        
        public uint lod0LargeBlock1SizeInBytes;
        
        public byte lod0LargeBlock1Count;
        
        public uint lod0LargeBlock2SizeInBytes;
        
        public byte lod0LargeBlock2Count;
        
        public uint lod0LargeBlock3SizeInBytes;
        
        public byte lod0LargeBlock3Count;
        
        public Fox.String lod1BaseDirectoryPath;
        
        public Fox.String lod1BaseName;
        
        public uint lod1blockSizeInBytes;
        
        public byte lod1blockSizeX;
        
        public byte lod1blockSizeZ;
        
        public byte lod1BlockCountX;
        
        public byte lod1BlockCountZ;
        
        public uint lod1LargeBlock0SizeInBytes;
        
        public byte lod1LargeBlock0Count;
        
        public uint lod1LargeBlock1SizeInBytes;
        
        public byte lod1LargeBlock1Count;
        
        public uint lod1LargeBlock2SizeInBytes;
        
        public byte lod1LargeBlock2Count;
        
        public uint lod1LargeBlock3SizeInBytes;
        
        public byte lod1LargeBlock3Count;
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public  override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static StageBlockControllerData()
        {
            classInfo = new Fox.EntityInfo("StageBlockControllerData", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 288, null, 8);
			
			classInfo.StaticProperties.Insert("enable", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("stageName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("useBaseDirectoryPathAndName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("baseDirectoryPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("baseName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("smallBlock1BaseDirectoryPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("smallBlock1BaseName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blockSizeX", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blockSizeZ", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("countX", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 180, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("countZ", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("centerIndexX", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 188, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("centerIndexZ", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blockSizeInBytes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 196, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("smallBlock1CountX", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("smallBlock1CountZ", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 204, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("smallBlock1BlockSizeInBytes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blockMarginX", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 212, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blockMarginZ", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("loadingDistanceX", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 220, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("loadingDistanceZ", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("commonBlockSizeInBytes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 228, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("largeBlockCount0", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("largeBlockSizeInBytes0", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 236, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("largeBlockCount1", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 240, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("largeBlockSizeInBytes1", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 244, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("largeBlockCount2", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("largeBlockSizeInBytes2", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 252, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("largeBlockCount3", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 256, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("largeBlockSizeInBytes3", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 260, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("largeBlockLoadingMarginX", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 264, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("largeBlockLoadingMarginZ", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 268, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("stageBlockFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 360, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod0BaseDirectoryPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 272, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod0BaseName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 280, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod0blockSizeInBytes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod0blockSizeX", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod0blockSizeZ", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 309, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod0BlockCountX", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 310, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod0BlockCountZ", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 311, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod0LargeBlock0SizeInBytes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod0LargeBlock0Count", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod0LargeBlock1SizeInBytes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 316, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod0LargeBlock1Count", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 329, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod0LargeBlock2SizeInBytes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod0LargeBlock2Count", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 330, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod0LargeBlock3SizeInBytes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 324, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod0LargeBlock3Count", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 331, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod1BaseDirectoryPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 288, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod1BaseName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 296, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod1blockSizeInBytes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 332, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod1blockSizeX", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod1blockSizeZ", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 337, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod1BlockCountX", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 338, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod1BlockCountZ", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 339, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod1LargeBlock0SizeInBytes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 340, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod1LargeBlock0Count", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 356, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod1LargeBlock1SizeInBytes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 344, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod1LargeBlock1Count", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 357, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod1LargeBlock2SizeInBytes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 348, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod1LargeBlock2Count", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 358, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod1LargeBlock3SizeInBytes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lod1LargeBlock3Count", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 359, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public StageBlockControllerData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "stageName":
                    this.stageName = value.GetValueAsString();
                    return;
                case "useBaseDirectoryPathAndName":
                    this.useBaseDirectoryPathAndName = value.GetValueAsBool();
                    return;
                case "baseDirectoryPath":
                    this.baseDirectoryPath = value.GetValueAsString();
                    return;
                case "baseName":
                    this.baseName = value.GetValueAsString();
                    return;
                case "smallBlock1BaseDirectoryPath":
                    this.smallBlock1BaseDirectoryPath = value.GetValueAsString();
                    return;
                case "smallBlock1BaseName":
                    this.smallBlock1BaseName = value.GetValueAsString();
                    return;
                case "blockSizeX":
                    this.blockSizeX = value.GetValueAsUInt32();
                    return;
                case "blockSizeZ":
                    this.blockSizeZ = value.GetValueAsUInt32();
                    return;
                case "countX":
                    this.countX = value.GetValueAsUInt32();
                    return;
                case "countZ":
                    this.countZ = value.GetValueAsUInt32();
                    return;
                case "centerIndexX":
                    this.centerIndexX = value.GetValueAsUInt32();
                    return;
                case "centerIndexZ":
                    this.centerIndexZ = value.GetValueAsUInt32();
                    return;
                case "blockSizeInBytes":
                    this.blockSizeInBytes = value.GetValueAsUInt32();
                    return;
                case "smallBlock1CountX":
                    this.smallBlock1CountX = value.GetValueAsUInt32();
                    return;
                case "smallBlock1CountZ":
                    this.smallBlock1CountZ = value.GetValueAsUInt32();
                    return;
                case "smallBlock1BlockSizeInBytes":
                    this.smallBlock1BlockSizeInBytes = value.GetValueAsUInt32();
                    return;
                case "blockMarginX":
                    this.blockMarginX = value.GetValueAsUInt32();
                    return;
                case "blockMarginZ":
                    this.blockMarginZ = value.GetValueAsUInt32();
                    return;
                case "loadingDistanceX":
                    this.loadingDistanceX = value.GetValueAsUInt32();
                    return;
                case "loadingDistanceZ":
                    this.loadingDistanceZ = value.GetValueAsUInt32();
                    return;
                case "commonBlockSizeInBytes":
                    this.commonBlockSizeInBytes = value.GetValueAsUInt32();
                    return;
                case "largeBlockCount0":
                    this.largeBlockCount0 = value.GetValueAsUInt32();
                    return;
                case "largeBlockSizeInBytes0":
                    this.largeBlockSizeInBytes0 = value.GetValueAsUInt32();
                    return;
                case "largeBlockCount1":
                    this.largeBlockCount1 = value.GetValueAsUInt32();
                    return;
                case "largeBlockSizeInBytes1":
                    this.largeBlockSizeInBytes1 = value.GetValueAsUInt32();
                    return;
                case "largeBlockCount2":
                    this.largeBlockCount2 = value.GetValueAsUInt32();
                    return;
                case "largeBlockSizeInBytes2":
                    this.largeBlockSizeInBytes2 = value.GetValueAsUInt32();
                    return;
                case "largeBlockCount3":
                    this.largeBlockCount3 = value.GetValueAsUInt32();
                    return;
                case "largeBlockSizeInBytes3":
                    this.largeBlockSizeInBytes3 = value.GetValueAsUInt32();
                    return;
                case "largeBlockLoadingMarginX":
                    this.largeBlockLoadingMarginX = value.GetValueAsUInt32();
                    return;
                case "largeBlockLoadingMarginZ":
                    this.largeBlockLoadingMarginZ = value.GetValueAsUInt32();
                    return;
                case "stageBlockFile":
                    this.stageBlockFile = value.GetValueAsFilePtr();
                    return;
                case "lod0BaseDirectoryPath":
                    this.lod0BaseDirectoryPath = value.GetValueAsString();
                    return;
                case "lod0BaseName":
                    this.lod0BaseName = value.GetValueAsString();
                    return;
                case "lod0blockSizeInBytes":
                    this.lod0blockSizeInBytes = value.GetValueAsUInt32();
                    return;
                case "lod0blockSizeX":
                    this.lod0blockSizeX = value.GetValueAsUInt8();
                    return;
                case "lod0blockSizeZ":
                    this.lod0blockSizeZ = value.GetValueAsUInt8();
                    return;
                case "lod0BlockCountX":
                    this.lod0BlockCountX = value.GetValueAsUInt8();
                    return;
                case "lod0BlockCountZ":
                    this.lod0BlockCountZ = value.GetValueAsUInt8();
                    return;
                case "lod0LargeBlock0SizeInBytes":
                    this.lod0LargeBlock0SizeInBytes = value.GetValueAsUInt32();
                    return;
                case "lod0LargeBlock0Count":
                    this.lod0LargeBlock0Count = value.GetValueAsUInt8();
                    return;
                case "lod0LargeBlock1SizeInBytes":
                    this.lod0LargeBlock1SizeInBytes = value.GetValueAsUInt32();
                    return;
                case "lod0LargeBlock1Count":
                    this.lod0LargeBlock1Count = value.GetValueAsUInt8();
                    return;
                case "lod0LargeBlock2SizeInBytes":
                    this.lod0LargeBlock2SizeInBytes = value.GetValueAsUInt32();
                    return;
                case "lod0LargeBlock2Count":
                    this.lod0LargeBlock2Count = value.GetValueAsUInt8();
                    return;
                case "lod0LargeBlock3SizeInBytes":
                    this.lod0LargeBlock3SizeInBytes = value.GetValueAsUInt32();
                    return;
                case "lod0LargeBlock3Count":
                    this.lod0LargeBlock3Count = value.GetValueAsUInt8();
                    return;
                case "lod1BaseDirectoryPath":
                    this.lod1BaseDirectoryPath = value.GetValueAsString();
                    return;
                case "lod1BaseName":
                    this.lod1BaseName = value.GetValueAsString();
                    return;
                case "lod1blockSizeInBytes":
                    this.lod1blockSizeInBytes = value.GetValueAsUInt32();
                    return;
                case "lod1blockSizeX":
                    this.lod1blockSizeX = value.GetValueAsUInt8();
                    return;
                case "lod1blockSizeZ":
                    this.lod1blockSizeZ = value.GetValueAsUInt8();
                    return;
                case "lod1BlockCountX":
                    this.lod1BlockCountX = value.GetValueAsUInt8();
                    return;
                case "lod1BlockCountZ":
                    this.lod1BlockCountZ = value.GetValueAsUInt8();
                    return;
                case "lod1LargeBlock0SizeInBytes":
                    this.lod1LargeBlock0SizeInBytes = value.GetValueAsUInt32();
                    return;
                case "lod1LargeBlock0Count":
                    this.lod1LargeBlock0Count = value.GetValueAsUInt8();
                    return;
                case "lod1LargeBlock1SizeInBytes":
                    this.lod1LargeBlock1SizeInBytes = value.GetValueAsUInt32();
                    return;
                case "lod1LargeBlock1Count":
                    this.lod1LargeBlock1Count = value.GetValueAsUInt8();
                    return;
                case "lod1LargeBlock2SizeInBytes":
                    this.lod1LargeBlock2SizeInBytes = value.GetValueAsUInt32();
                    return;
                case "lod1LargeBlock2Count":
                    this.lod1LargeBlock2Count = value.GetValueAsUInt8();
                    return;
                case "lod1LargeBlock3SizeInBytes":
                    this.lod1LargeBlock3SizeInBytes = value.GetValueAsUInt32();
                    return;
                case "lod1LargeBlock3Count":
                    this.lod1LargeBlock3Count = value.GetValueAsUInt8();
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