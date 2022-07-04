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

namespace Fox.Grx
{
    [UnityEditor.InitializeOnLoad]
    public partial class GrxAreaSSAOParameters : Fox.Core.Entity 
    {
        // Properties
        public GrxAreaSSAOParameters_Resolution resolution;
        
        public float radius;
        
        public float angleBias;
        
        public uint numSteps;
        
        public uint numDirections;
        
        public float attenuation;
        
        public float contrast;
        
        public GrxAreaSSAOParameters_BlurMode blurMode;
        
        public float blurRadius;
        
        public float blurSharpness;
        
        public float blurSceneScale;
        
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
        static GrxAreaSSAOParameters()
        {
            classInfo = new Fox.EntityInfo("GrxAreaSSAOParameters", typeof(GrxAreaSSAOParameters), new Fox.Core.Entity().GetClassEntityInfo(), 68, null, 0);
			classInfo.StaticProperties.Insert("resolution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 48, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(GrxAreaSSAOParameters_Resolution), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("radius", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 52, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("angleBias", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("numSteps", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 60, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("numDirections", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("attenuation", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 68, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("contrast", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blurMode", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 76, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(GrxAreaSSAOParameters_BlurMode), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blurRadius", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blurSharpness", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 84, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blurSceneScale", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 88, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public GrxAreaSSAOParameters(ulong address, ulong id) : base(address, id) { }
		public GrxAreaSSAOParameters() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "resolution":
                    this.resolution = (GrxAreaSSAOParameters_Resolution)value.GetValueAsInt32();
                    return;
                case "radius":
                    this.radius = value.GetValueAsFloat();
                    return;
                case "angleBias":
                    this.angleBias = value.GetValueAsFloat();
                    return;
                case "numSteps":
                    this.numSteps = value.GetValueAsUInt32();
                    return;
                case "numDirections":
                    this.numDirections = value.GetValueAsUInt32();
                    return;
                case "attenuation":
                    this.attenuation = value.GetValueAsFloat();
                    return;
                case "contrast":
                    this.contrast = value.GetValueAsFloat();
                    return;
                case "blurMode":
                    this.blurMode = (GrxAreaSSAOParameters_BlurMode)value.GetValueAsInt32();
                    return;
                case "blurRadius":
                    this.blurRadius = value.GetValueAsFloat();
                    return;
                case "blurSharpness":
                    this.blurSharpness = value.GetValueAsFloat();
                    return;
                case "blurSceneScale":
                    this.blurSceneScale = value.GetValueAsFloat();
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