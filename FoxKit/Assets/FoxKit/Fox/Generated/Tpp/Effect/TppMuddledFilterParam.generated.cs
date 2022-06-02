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
    public partial class TppMuddledFilterParam 
    {
        // Properties
        public float sphereRadiusMin;
        
        public float sphereRadiusMax;
        
        public float headRadiusMin;
        
        public float headRadiusMax;
        
        public float sinCurveAmplitude;
        
        public float sinCurveLength;
        
        public float moveSpeedMin;
        
        public float moveSpeedMax;
        
        public float power;
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public virtual Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static TppMuddledFilterParam()
        {
            classInfo = new Fox.EntityInfo("TppMuddledFilterParam", null, 0, null, 0);
			
			classInfo.StaticProperties.Insert("sphereRadiusMin", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("sphereRadiusMax", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 4, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("headRadiusMin", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 8, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("headRadiusMax", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 12, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("sinCurveAmplitude", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 16, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("sinCurveLength", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 20, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("moveSpeedMin", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 24, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("moveSpeedMax", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 28, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("power", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 32, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		
		
        
        public virtual void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "sphereRadiusMin":
                    this.sphereRadiusMin = value.GetValueAsFloat();
                    return;
                case "sphereRadiusMax":
                    this.sphereRadiusMax = value.GetValueAsFloat();
                    return;
                case "headRadiusMin":
                    this.headRadiusMin = value.GetValueAsFloat();
                    return;
                case "headRadiusMax":
                    this.headRadiusMax = value.GetValueAsFloat();
                    return;
                case "sinCurveAmplitude":
                    this.sinCurveAmplitude = value.GetValueAsFloat();
                    return;
                case "sinCurveLength":
                    this.sinCurveLength = value.GetValueAsFloat();
                    return;
                case "moveSpeedMin":
                    this.moveSpeedMin = value.GetValueAsFloat();
                    return;
                case "moveSpeedMax":
                    this.moveSpeedMax = value.GetValueAsFloat();
                    return;
                case "power":
                    this.power = value.GetValueAsFloat();
                    return;
                default:
				    
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
                    return;
            }
        }
        
        public virtual void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
					
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
                    return;
            }
        }
        
        public virtual void SetPropertyElement(string propertyName, string key, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
					
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
                    return;
            }
        }
    }
}