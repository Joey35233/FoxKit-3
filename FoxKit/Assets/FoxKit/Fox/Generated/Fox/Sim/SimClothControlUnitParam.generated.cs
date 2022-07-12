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
    [UnityEditor.InitializeOnLoad]
    public partial class SimClothControlUnitParam : Fox.Core.Entity 
    {
        // Properties
        public float mass;
        
        public float thickness;
        
        public bool limitedFlag;
        
        public float limit;
        
        public float expansionRatio;
        
        public float contractionRatio;
        
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
        static SimClothControlUnitParam()
        {
            classInfo = new Fox.EntityInfo("SimClothControlUnitParam", typeof(SimClothControlUnitParam), new Fox.Core.Entity().GetClassEntityInfo(), 52, "Sim", 0);
			classInfo.StaticProperties.Insert("mass", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 52, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("thickness", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("limitedFlag", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("limit", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 60, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("expansionRatio", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("contractionRatio", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 68, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public SimClothControlUnitParam(ulong id) : base(id) { }
		public SimClothControlUnitParam() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "mass":
                    this.mass = value.GetValueAsFloat();
                    return;
                case "thickness":
                    this.thickness = value.GetValueAsFloat();
                    return;
                case "limitedFlag":
                    this.limitedFlag = value.GetValueAsBool();
                    return;
                case "limit":
                    this.limit = value.GetValueAsFloat();
                    return;
                case "expansionRatio":
                    this.expansionRatio = value.GetValueAsFloat();
                    return;
                case "contractionRatio":
                    this.contractionRatio = value.GetValueAsFloat();
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