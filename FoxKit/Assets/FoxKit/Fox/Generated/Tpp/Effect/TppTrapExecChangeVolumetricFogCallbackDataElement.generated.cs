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
    public partial class TppTrapExecChangeVolumetricFogCallbackDataElement : Fox.Geo.GeoTrapModuleCallbackDataElement 
    {
        // Properties
        public bool ignoreYAxis;
        
        public bool ignoreZAxis;
        
        public float interpRange;
        
        public bool restoreFogParameters;
        
        public UnityEngine.Color color;
        
        public float luminance;
        
        public UnityEngine.Color albedo;
        
        public float density;
        
        public float nearDistance;
        
        public float falloff;
        
        public bool changeColor;
        
        public bool changeAlbedo;
        
        public bool changeLuminance;
        
        public bool changeDensity;
        
        public bool changeNearDistance;
        
        public bool changeFalloff;
        
        public Fox.Core.EntityLink areaVolumetricFog;
        
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
        static TppTrapExecChangeVolumetricFogCallbackDataElement()
        {
            classInfo = new Fox.EntityInfo("TppTrapExecChangeVolumetricFogCallbackDataElement", new Fox.Geo.GeoTrapModuleCallbackDataElement(0, 0, 0).GetClassEntityInfo(), 0, null, 4);
			
			classInfo.StaticProperties.Insert("ignoreYAxis", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("ignoreZAxis", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 165, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("interpRange", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("restoreFogParameters", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("color", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Color, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("luminance", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("albedo", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Color, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("density", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 148, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("nearDistance", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("falloff", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("changeColor", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 166, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("changeAlbedo", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 167, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("changeLuminance", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("changeDensity", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 169, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("changeNearDistance", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 170, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("changeFalloff", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 171, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("areaVolumetricFog", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppTrapExecChangeVolumetricFogCallbackDataElement(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "ignoreYAxis":
                    this.ignoreYAxis = value.GetValueAsBool();
                    return;
                case "ignoreZAxis":
                    this.ignoreZAxis = value.GetValueAsBool();
                    return;
                case "interpRange":
                    this.interpRange = value.GetValueAsFloat();
                    return;
                case "restoreFogParameters":
                    this.restoreFogParameters = value.GetValueAsBool();
                    return;
                case "color":
                    this.color = value.GetValueAsColor();
                    return;
                case "luminance":
                    this.luminance = value.GetValueAsFloat();
                    return;
                case "albedo":
                    this.albedo = value.GetValueAsColor();
                    return;
                case "density":
                    this.density = value.GetValueAsFloat();
                    return;
                case "nearDistance":
                    this.nearDistance = value.GetValueAsFloat();
                    return;
                case "falloff":
                    this.falloff = value.GetValueAsFloat();
                    return;
                case "changeColor":
                    this.changeColor = value.GetValueAsBool();
                    return;
                case "changeAlbedo":
                    this.changeAlbedo = value.GetValueAsBool();
                    return;
                case "changeLuminance":
                    this.changeLuminance = value.GetValueAsBool();
                    return;
                case "changeDensity":
                    this.changeDensity = value.GetValueAsBool();
                    return;
                case "changeNearDistance":
                    this.changeNearDistance = value.GetValueAsBool();
                    return;
                case "changeFalloff":
                    this.changeFalloff = value.GetValueAsBool();
                    return;
                case "areaVolumetricFog":
                    this.areaVolumetricFog = value.GetValueAsEntityLink();
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