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

namespace Fox.Navx
{
    public partial class NavxWorldGenerateParameter : Fox.Core.TransformData 
    {
        // Properties
        public float resolution;
        
        public float verticalThreshold;
        
        public bool doesDivideIslandWithSector;
        
        public bool doesHoleSimplification;
        
        public float holeSimplificationConvexThreshold;
        
        public float holeSimplificationObbExpandThreshold;
        
        public float holeSimplificationObbToAabbThreshold;
        
        public float holeSimplificationSmoothingThreshold;
        
        public bool isHoleSimplificationDoesNotClosePassage;
        
        public uint holeSimplificationReduceCount;
        
        public bool doesAdjustSearchSpaceToNavmesh;
        
        public bool doesGenerateFillNavVolumeInRadius;
        
        public Fox.Core.Path roughGraphFilePath;
        
        public Fox.Core.FilePtr<Fox.Core.File> roughGraphFilePtr;
        
        public string worldName;
        
        public uint maxFileSizeInKb;
        
        public CsSystem.Collections.Generic.List<Fox.Core.EntityPtr<Fox.Navx.NavxNavigableParameter>> parameters = new CsSystem.Collections.Generic.List<Fox.Core.EntityPtr<Fox.Navx.NavxNavigableParameter>>();
        
        public uint sectorSizeHorizontal;
        
        public uint tileSizeHorizontal;
        
        public uint searchSpaceBucketSizeHorizontal;
        
        public CsSystem.Collections.Generic.List<string> collisionAttributes = new CsSystem.Collections.Generic.List<string>();
        
        public Fox.Core.Path loadFox2FileListScriptPath;
        
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
        static NavxWorldGenerateParameter()
        {
            classInfo = new Fox.EntityInfo("NavxWorldGenerateParameter", new Fox.Core.TransformData(0, 0, 0).GetClassEntityInfo(), 400, "Navx", 27);
			
			classInfo.StaticProperties.Insert("resolution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("verticalThreshold", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("doesDivideIslandWithSector", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("doesHoleSimplification", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 313, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("holeSimplificationConvexThreshold", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 316, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("holeSimplificationObbExpandThreshold", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("holeSimplificationObbToAabbThreshold", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 324, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("holeSimplificationSmoothingThreshold", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isHoleSimplificationDoesNotClosePassage", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 332, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("holeSimplificationReduceCount", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("doesAdjustSearchSpaceToNavmesh", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 340, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("doesGenerateFillNavVolumeInRadius", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 341, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("roughGraphFilePath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 344, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("roughGraphFilePtr", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("worldName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 376, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("maxFileSizeInKb", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 384, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("parameters", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 392, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Navx.NavxNavigableParameter), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("sectorSizeHorizontal", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 408, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("tileSizeHorizontal", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 412, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("searchSpaceBucketSizeHorizontal", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 416, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("collisionAttributes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 424, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("loadFox2FileListScriptPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 440, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public NavxWorldGenerateParameter(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "resolution":
                    this.resolution = value.GetValueAsFloat();
                    return;
                case "verticalThreshold":
                    this.verticalThreshold = value.GetValueAsFloat();
                    return;
                case "doesDivideIslandWithSector":
                    this.doesDivideIslandWithSector = value.GetValueAsBool();
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
                case "doesAdjustSearchSpaceToNavmesh":
                    this.doesAdjustSearchSpaceToNavmesh = value.GetValueAsBool();
                    return;
                case "doesGenerateFillNavVolumeInRadius":
                    this.doesGenerateFillNavVolumeInRadius = value.GetValueAsBool();
                    return;
                case "roughGraphFilePath":
                    this.roughGraphFilePath = value.GetValueAsPath();
                    return;
                case "roughGraphFilePtr":
                    this.roughGraphFilePtr = value.GetValueAsFilePtr();
                    return;
                case "worldName":
                    this.worldName = value.GetValueAsString();
                    return;
                case "maxFileSizeInKb":
                    this.maxFileSizeInKb = value.GetValueAsUInt32();
                    return;
                case "sectorSizeHorizontal":
                    this.sectorSizeHorizontal = value.GetValueAsUInt32();
                    return;
                case "tileSizeHorizontal":
                    this.tileSizeHorizontal = value.GetValueAsUInt32();
                    return;
                case "searchSpaceBucketSizeHorizontal":
                    this.searchSpaceBucketSizeHorizontal = value.GetValueAsUInt32();
                    return;
                case "loadFox2FileListScriptPath":
                    this.loadFox2FileListScriptPath = value.GetValueAsPath();
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
                case "parameters":
                    while(this.parameters.Count <= index) { this.parameters.Add(default(Fox.Core.EntityPtr<Fox.Navx.NavxNavigableParameter>)); }
                    this.parameters[index] = value.GetValueAsEntityPtr<Fox.Navx.NavxNavigableParameter>();
                    return;
                case "collisionAttributes":
                    while(this.collisionAttributes.Count <= index) { this.collisionAttributes.Add(default(string)); }
                    this.collisionAttributes[index] = value.GetValueAsString();
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