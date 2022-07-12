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
    public partial class TppSkyClouds3Param : Fox.Core.DataElement 
    {
        // Properties
        public bool enable;
        
        public bool followCamera;
        
        public UnityEngine.Color color;
        
        public float luminanceScale;
        
        public float bottom;
        
        public float radius;
        
        public float height;
        
        public float domeLength;
        
        public float domeStreach;
        
        public float domeWindInfluence;
        
        public float midCylinderPos;
        
        public float midCylinderWidth;
        
        public float midCylinderStreach;
        
        public float midCylinderScrSpeed;
        
        public float lowCylinderIntrusion;
        
        public float lowCylinderStreach;
        
        public float lowCylinderScrSpeed;
        
        public uint cylinderTexRepeat;
        
        public Fox.Core.Path domeTexture;
        
        public Fox.Core.Path midCylinderTexture;
        
        public Fox.Core.Path lowCylinderTexture;
        
        public TppSkyClouds3Param_ColorSpace colorSpace;
        
        public TppSkyClouds3Param_TexColor textureColorHandling;
        
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
        static TppSkyClouds3Param()
        {
            classInfo = new Fox.EntityInfo("TppSkyClouds3Param", typeof(TppSkyClouds3Param), new Fox.Core.DataElement().GetClassEntityInfo(), 0, "TppEffect", 3);
			classInfo.StaticProperties.Insert("enable", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("followCamera", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 173, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("color", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Color, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("luminanceScale", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("bottom", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 108, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("radius", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("height", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 116, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("domeLength", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("domeStreach", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("domeWindInfluence", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("midCylinderPos", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("midCylinderWidth", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 148, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("midCylinderStreach", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("midCylinderScrSpeed", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lowCylinderIntrusion", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lowCylinderStreach", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lowCylinderScrSpeed", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 140, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cylinderTexRepeat", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("domeTexture", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("midCylinderTexture", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lowCylinderTexture", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 88, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("colorSpace", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppSkyClouds3Param_ColorSpace), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("textureColorHandling", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppSkyClouds3Param_TexColor), Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppSkyClouds3Param(ulong id) : base(id) { }
		public TppSkyClouds3Param() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "followCamera":
                    this.followCamera = value.GetValueAsBool();
                    return;
                case "color":
                    this.color = value.GetValueAsColor();
                    return;
                case "luminanceScale":
                    this.luminanceScale = value.GetValueAsFloat();
                    return;
                case "bottom":
                    this.bottom = value.GetValueAsFloat();
                    return;
                case "radius":
                    this.radius = value.GetValueAsFloat();
                    return;
                case "height":
                    this.height = value.GetValueAsFloat();
                    return;
                case "domeLength":
                    this.domeLength = value.GetValueAsFloat();
                    return;
                case "domeStreach":
                    this.domeStreach = value.GetValueAsFloat();
                    return;
                case "domeWindInfluence":
                    this.domeWindInfluence = value.GetValueAsFloat();
                    return;
                case "midCylinderPos":
                    this.midCylinderPos = value.GetValueAsFloat();
                    return;
                case "midCylinderWidth":
                    this.midCylinderWidth = value.GetValueAsFloat();
                    return;
                case "midCylinderStreach":
                    this.midCylinderStreach = value.GetValueAsFloat();
                    return;
                case "midCylinderScrSpeed":
                    this.midCylinderScrSpeed = value.GetValueAsFloat();
                    return;
                case "lowCylinderIntrusion":
                    this.lowCylinderIntrusion = value.GetValueAsFloat();
                    return;
                case "lowCylinderStreach":
                    this.lowCylinderStreach = value.GetValueAsFloat();
                    return;
                case "lowCylinderScrSpeed":
                    this.lowCylinderScrSpeed = value.GetValueAsFloat();
                    return;
                case "cylinderTexRepeat":
                    this.cylinderTexRepeat = value.GetValueAsUInt32();
                    return;
                case "domeTexture":
                    this.domeTexture = value.GetValueAsPath();
                    return;
                case "midCylinderTexture":
                    this.midCylinderTexture = value.GetValueAsPath();
                    return;
                case "lowCylinderTexture":
                    this.lowCylinderTexture = value.GetValueAsPath();
                    return;
                case "colorSpace":
                    this.colorSpace = (TppSkyClouds3Param_ColorSpace)value.GetValueAsInt32();
                    return;
                case "textureColorHandling":
                    this.textureColorHandling = (TppSkyClouds3Param_TexColor)value.GetValueAsInt32();
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