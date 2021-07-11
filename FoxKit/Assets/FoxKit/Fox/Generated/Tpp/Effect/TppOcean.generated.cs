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

namespace Tpp.Effect
{
    public partial class TppOcean : Fox.Core.TransformData 
    {
        // Properties
        public bool enable;
        
        public bool guantanamoOcean;
        
        public bool wireframe;
        
        public float baseHeight;
        
        public uint gridNumX;
        
        public uint gridNumY;
        
        public float screenMarginX;
        
        public float screenMarginY;
        
        public float waveLengthMin;
        
        public float waveLengthMax;
        
        public float waveDispersion;
        
        public float windSpeed;
        
        public Fox.Core.Path waveParamTexture;
        
        public Fox.Core.Path whitecapTexture;
        
        public float horizonDistance;
        
        public float lightCaptureDistance;
        
        public uint randomSeed;
        
        public CsSystem.Collections.Generic.List<Fox.Core.EntityLink> collisionDatas = new CsSystem.Collections.Generic.List<Fox.Core.EntityLink>();
        
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
        static TppOcean()
        {
            classInfo = new Fox.EntityInfo("TppOcean", new Fox.Core.TransformData(0, 0, 0).GetClassEntityInfo(), 352, null, 12);
			
			classInfo.StaticProperties.Insert("enable", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("guantanamoOcean", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 305, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("wireframe", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 306, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("baseHeight", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("gridNumX", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("gridNumY", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 316, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("screenMarginX", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("screenMarginY", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 324, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("waveLengthMin", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("waveLengthMax", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 332, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("waveDispersion", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("windSpeed", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 340, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("waveParamTexture", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 344, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("whitecapTexture", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("horizonDistance", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 360, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lightCaptureDistance", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 364, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("randomSeed", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("collisionDatas", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 376, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppOcean(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "guantanamoOcean":
                    this.guantanamoOcean = value.GetValueAsBool();
                    return;
                case "wireframe":
                    this.wireframe = value.GetValueAsBool();
                    return;
                case "baseHeight":
                    this.baseHeight = value.GetValueAsFloat();
                    return;
                case "gridNumX":
                    this.gridNumX = value.GetValueAsUInt32();
                    return;
                case "gridNumY":
                    this.gridNumY = value.GetValueAsUInt32();
                    return;
                case "screenMarginX":
                    this.screenMarginX = value.GetValueAsFloat();
                    return;
                case "screenMarginY":
                    this.screenMarginY = value.GetValueAsFloat();
                    return;
                case "waveLengthMin":
                    this.waveLengthMin = value.GetValueAsFloat();
                    return;
                case "waveLengthMax":
                    this.waveLengthMax = value.GetValueAsFloat();
                    return;
                case "waveDispersion":
                    this.waveDispersion = value.GetValueAsFloat();
                    return;
                case "windSpeed":
                    this.windSpeed = value.GetValueAsFloat();
                    return;
                case "waveParamTexture":
                    this.waveParamTexture = value.GetValueAsPath();
                    return;
                case "whitecapTexture":
                    this.whitecapTexture = value.GetValueAsPath();
                    return;
                case "horizonDistance":
                    this.horizonDistance = value.GetValueAsFloat();
                    return;
                case "lightCaptureDistance":
                    this.lightCaptureDistance = value.GetValueAsFloat();
                    return;
                case "randomSeed":
                    this.randomSeed = value.GetValueAsUInt32();
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
                case "collisionDatas":
                    while(this.collisionDatas.Count <= index) { this.collisionDatas.Add(default(Fox.Core.EntityLink)); }
                    this.collisionDatas[index] = value.GetValueAsEntityLink();
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