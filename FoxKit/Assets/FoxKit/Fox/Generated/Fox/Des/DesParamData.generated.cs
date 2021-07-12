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

namespace Fox.Des
{
    public partial class DesParamData : Fox.Core.Data 
    {
        // Properties
        public float density;
        
        public float friction;
        
        public float restitution;
        
        public Fox.String materialName;
        
        public ParamDataDesCondition desCondition;
        
        public float desImpactPowerThreshold;
        
        public float physicalCoefficient;
        
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
        static DesParamData()
        {
            classInfo = new Fox.EntityInfo("DesParamData", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 92, "Des", 2);
			
			classInfo.StaticProperties.Insert("density", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("friction", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("restitution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("materialName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("desCondition", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, typeof(ParamDataDesCondition), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("desImpactPowerThreshold", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 148, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("physicalCoefficient", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public DesParamData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "density":
                    this.density = value.GetValueAsFloat();
                    return;
                case "friction":
                    this.friction = value.GetValueAsFloat();
                    return;
                case "restitution":
                    this.restitution = value.GetValueAsFloat();
                    return;
                case "materialName":
                    this.materialName = value.GetValueAsString();
                    return;
                case "desCondition":
                    this.desCondition = (ParamDataDesCondition)value.GetValueAsInt32();
                    return;
                case "desImpactPowerThreshold":
                    this.desImpactPowerThreshold = value.GetValueAsFloat();
                    return;
                case "physicalCoefficient":
                    this.physicalCoefficient = value.GetValueAsFloat();
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