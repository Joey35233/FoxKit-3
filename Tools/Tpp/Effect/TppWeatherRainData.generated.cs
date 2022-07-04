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
    [UnityEditor.InitializeOnLoad]
    public partial class TppWeatherRainData : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.EntityLink rainFilter;
        
        public Fox.Core.EntityLink floorRainSplash;
        
        public Fox.Core.FilePtr<Fox.Core.File> vfxFileFallRain;
        
        public Fox.Core.FilePtr<Fox.Core.File> vfxFileFallRainSlow;
        
        public Fox.Core.FilePtr<Fox.Core.File> vfxFileCameraFog;
        
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
        static TppWeatherRainData()
        {
            classInfo = new Fox.EntityInfo("TppWeatherRainData", typeof(TppWeatherRainData), new Fox.Core.Data().GetClassEntityInfo(), 200, "TppEffect", 4);
			classInfo.StaticProperties.Insert("rainFilter", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("floorRainSplash", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("vfxFileFallRain", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("vfxFileFallRainSlow", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("vfxFileCameraFog", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppWeatherRainData(ulong address, ulong id) : base(address, id) { }
		public TppWeatherRainData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "rainFilter":
                    this.rainFilter = value.GetValueAsEntityLink();
                    return;
                case "floorRainSplash":
                    this.floorRainSplash = value.GetValueAsEntityLink();
                    return;
                case "vfxFileFallRain":
                    this.vfxFileFallRain = value.GetValueAsFilePtr();
                    return;
                case "vfxFileFallRainSlow":
                    this.vfxFileFallRainSlow = value.GetValueAsFilePtr();
                    return;
                case "vfxFileCameraFog":
                    this.vfxFileCameraFog = value.GetValueAsFilePtr();
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