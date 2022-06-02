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

namespace Fox.Sim
{
    public partial class SimEngineOnPhysicsDefaultInfo : Fox.Core.DataElement 
    {
        // Properties
        public float defaultRadius;
        
        public float defaultLimit;
        
        public float defaultSpring;
        
        public bool defaultStopTwistFlag;
        
        public float defaultMass;
        
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
        static SimEngineOnPhysicsDefaultInfo()
        {
            classInfo = new Fox.EntityInfo("SimEngineOnPhysicsDefaultInfo", new Fox.Core.DataElement().GetClassEntityInfo(), 0, "Sim", 1);
			
			classInfo.StaticProperties.Insert("defaultRadius", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("defaultLimit", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 60, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("defaultSpring", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("defaultStopTwistFlag", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 68, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("defaultMass", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public SimEngineOnPhysicsDefaultInfo(ulong address, ulong id) : base(address, id) { }
		public SimEngineOnPhysicsDefaultInfo() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "defaultRadius":
                    this.defaultRadius = value.GetValueAsFloat();
                    return;
                case "defaultLimit":
                    this.defaultLimit = value.GetValueAsFloat();
                    return;
                case "defaultSpring":
                    this.defaultSpring = value.GetValueAsFloat();
                    return;
                case "defaultStopTwistFlag":
                    this.defaultStopTwistFlag = value.GetValueAsBool();
                    return;
                case "defaultMass":
                    this.defaultMass = value.GetValueAsFloat();
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