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
    public partial class TppGrenadeShock : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public float redConeSaturationDuration { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float greenConeSaturationDuration { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float blueConeSaturationDuration { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float distortionVelocity { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float distortionIntensity { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float distortionProjectionScale { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float rotationSpeed { get; set; }
        
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
        static TppGrenadeShock()
        {
            classInfo = new Fox.EntityInfo("TppGrenadeShock", typeof(TppGrenadeShock), new Fox.Core.Data().GetClassEntityInfo(), 92, null, 1);
			classInfo.StaticProperties.Insert("redConeSaturationDuration", new Fox.Core.PropertyInfo("redConeSaturationDuration", Fox.Core.PropertyInfo.PropertyType.Float, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("greenConeSaturationDuration", new Fox.Core.PropertyInfo("greenConeSaturationDuration", Fox.Core.PropertyInfo.PropertyType.Float, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blueConeSaturationDuration", new Fox.Core.PropertyInfo("blueConeSaturationDuration", Fox.Core.PropertyInfo.PropertyType.Float, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("distortionVelocity", new Fox.Core.PropertyInfo("distortionVelocity", Fox.Core.PropertyInfo.PropertyType.Float, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("distortionIntensity", new Fox.Core.PropertyInfo("distortionIntensity", Fox.Core.PropertyInfo.PropertyType.Float, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("distortionProjectionScale", new Fox.Core.PropertyInfo("distortionProjectionScale", Fox.Core.PropertyInfo.PropertyType.Float, 140, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rotationSpeed", new Fox.Core.PropertyInfo("rotationSpeed", Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppGrenadeShock(ulong id) : base(id) { }
		public TppGrenadeShock() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "redConeSaturationDuration":
                    this.redConeSaturationDuration = value.GetValueAsFloat();
                    return;
                case "greenConeSaturationDuration":
                    this.greenConeSaturationDuration = value.GetValueAsFloat();
                    return;
                case "blueConeSaturationDuration":
                    this.blueConeSaturationDuration = value.GetValueAsFloat();
                    return;
                case "distortionVelocity":
                    this.distortionVelocity = value.GetValueAsFloat();
                    return;
                case "distortionIntensity":
                    this.distortionIntensity = value.GetValueAsFloat();
                    return;
                case "distortionProjectionScale":
                    this.distortionProjectionScale = value.GetValueAsFloat();
                    return;
                case "rotationSpeed":
                    this.rotationSpeed = value.GetValueAsFloat();
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