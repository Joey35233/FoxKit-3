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
    public partial class TppOutOfMissionRangeEffect : Fox.Core.Data 
    {
        // Properties
        public bool enable;
        
        public Fox.Core.Path lutTexture;
        
        public float startSlope;
        
        public float endSlope;
        
        public float blendRatio;
        
        public UnityEngine.Color colorScale;
        
        public float noiseScale;
        
        public float noiseOffset;
        
        public float noiseCutScale;
        
        public float noiseCutOffset;
        
        public UnityEngine.Color noiseColor;
        
        public float cinemaScopeSlope;
        
        public float cinemaScopeShift;
        
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
        static TppOutOfMissionRangeEffect()
        {
            classInfo = new Fox.EntityInfo("TppOutOfMissionRangeEffect", typeof(TppOutOfMissionRangeEffect), new Fox.Core.Data().GetClassEntityInfo(), 144, "TppEffect", 2);
			classInfo.StaticProperties.Insert("enable", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 204, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lutTexture", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("startSlope", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("endSlope", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blendRatio", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("colorScale", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Color, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("noiseScale", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 180, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("noiseOffset", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("noiseCutScale", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 188, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("noiseCutOffset", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("noiseColor", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Color, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cinemaScopeSlope", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 196, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cinemaScopeShift", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppOutOfMissionRangeEffect(ulong id) : base(id) { }
		public TppOutOfMissionRangeEffect() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "lutTexture":
                    this.lutTexture = value.GetValueAsPath();
                    return;
                case "startSlope":
                    this.startSlope = value.GetValueAsFloat();
                    return;
                case "endSlope":
                    this.endSlope = value.GetValueAsFloat();
                    return;
                case "blendRatio":
                    this.blendRatio = value.GetValueAsFloat();
                    return;
                case "colorScale":
                    this.colorScale = value.GetValueAsColor();
                    return;
                case "noiseScale":
                    this.noiseScale = value.GetValueAsFloat();
                    return;
                case "noiseOffset":
                    this.noiseOffset = value.GetValueAsFloat();
                    return;
                case "noiseCutScale":
                    this.noiseCutScale = value.GetValueAsFloat();
                    return;
                case "noiseCutOffset":
                    this.noiseCutOffset = value.GetValueAsFloat();
                    return;
                case "noiseColor":
                    this.noiseColor = value.GetValueAsColor();
                    return;
                case "cinemaScopeSlope":
                    this.cinemaScopeSlope = value.GetValueAsFloat();
                    return;
                case "cinemaScopeShift":
                    this.cinemaScopeShift = value.GetValueAsFloat();
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