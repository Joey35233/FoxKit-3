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
    public partial class TppTrapExecChangeGlobalWindCallbackDataElement : Fox.Geo.GeoTrapModuleCallbackDataElement 
    {
        // Properties
        public float speed;
        
        public UnityEngine.Quaternion rotation;
        
        public float speedTurbulentRate;
        
        public float speedTurbulentCycle;
        
        public float rotTurbulentRate;
        
        public float rotTurbulentCycle;
        
        public float interpTime;
        
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
        static TppTrapExecChangeGlobalWindCallbackDataElement()
        {
            classInfo = new Fox.EntityInfo("TppTrapExecChangeGlobalWindCallbackDataElement", new Fox.Geo.GeoTrapModuleCallbackDataElement().GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert("speed", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rotation", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Quat, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("speedTurbulentRate", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 84, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("speedTurbulentCycle", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 88, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rotTurbulentRate", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 92, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rotTurbulentCycle", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("interpTime", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 100, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppTrapExecChangeGlobalWindCallbackDataElement(ulong address, ulong id) : base(address, id) { }
		public TppTrapExecChangeGlobalWindCallbackDataElement() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "speed":
                    this.speed = value.GetValueAsFloat();
                    return;
                case "rotation":
                    this.rotation = value.GetValueAsQuat();
                    return;
                case "speedTurbulentRate":
                    this.speedTurbulentRate = value.GetValueAsFloat();
                    return;
                case "speedTurbulentCycle":
                    this.speedTurbulentCycle = value.GetValueAsFloat();
                    return;
                case "rotTurbulentRate":
                    this.rotTurbulentRate = value.GetValueAsFloat();
                    return;
                case "rotTurbulentCycle":
                    this.rotTurbulentCycle = value.GetValueAsFloat();
                    return;
                case "interpTime":
                    this.interpTime = value.GetValueAsFloat();
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