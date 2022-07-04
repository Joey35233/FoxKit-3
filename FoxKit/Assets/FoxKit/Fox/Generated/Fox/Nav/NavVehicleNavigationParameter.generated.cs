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

namespace Fox.Nav
{
    [UnityEditor.InitializeOnLoad]
    public partial class NavVehicleNavigationParameter : Fox.Nav.NavNavigationParameter 
    {
        // Properties
        public Fox.Core.DynamicArray<float> turningRadii = new Fox.Core.DynamicArray<float>();
        
        public Fox.Core.DynamicArray<float> turningSpeeds = new Fox.Core.DynamicArray<float>();
        
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
        static NavVehicleNavigationParameter()
        {
            classInfo = new Fox.EntityInfo("NavVehicleNavigationParameter", typeof(NavVehicleNavigationParameter), new Fox.Nav.NavNavigationParameter().GetClassEntityInfo(), 0, "Nav", 0);
			classInfo.StaticProperties.Insert("turningRadii", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 48, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("turningSpeeds", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 64, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public NavVehicleNavigationParameter(ulong address, ulong id) : base(address, id) { }
		public NavVehicleNavigationParameter() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                case "turningRadii":
                    while(this.turningRadii.Count <= index) { this.turningRadii.Add(default(float)); }
                    this.turningRadii[index] = value.GetValueAsFloat();
                    return;
                case "turningSpeeds":
                    while(this.turningSpeeds.Count <= index) { this.turningSpeeds.Add(default(float)); }
                    this.turningSpeeds[index] = value.GetValueAsFloat();
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