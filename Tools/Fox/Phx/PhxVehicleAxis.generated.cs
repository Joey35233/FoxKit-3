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

namespace Fox.Phx
{
    [UnityEditor.InitializeOnLoad]
    public partial class PhxVehicleAxis : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.EntityPtr<Fox.Phx.PhVehicleAxisParam> vehicleAxisParam = new Fox.Core.EntityPtr<Fox.Phx.PhVehicleAxisParam>();
        
        public Fox.Core.EntityPtr<Fox.Phx.PhxWheelConstraintParam> wheelConstraintParam = new Fox.Core.EntityPtr<Fox.Phx.PhxWheelConstraintParam>();
        
        public Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Phx.PhxWheelAssociationUnitParam>> wheelAssociationUnitParams = new Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Phx.PhxWheelAssociationUnitParam>>();
        
        public Fox.Core.DynamicArray<float> torqueDistributions = new Fox.Core.DynamicArray<float>();
        
        public Fox.Core.DynamicArray<float> gearRatios = new Fox.Core.DynamicArray<float>();
        
        public UnityEngine.Vector3 wheelFront;
        
        public UnityEngine.Vector3 wheelUp;
        
        public UnityEngine.Vector3 wheelPositionOffset;
        
        public float wheelRadius;
        
        public float wheelFriction;
        
        public float wheelRestitution;
        
        public float wheelInertia;
        
        public float suspentionLength;
        
        public float maxSuspentionForceCoeff;
        
        public float dampingCoeffElong;
        
        public float dampingCoeffCompress;
        
        public float maxBreakTorqueCoeff;
        
        public bool useDifferential;
        
        public Fox.Core.DynamicArray<Fox.String> AssignedBoneNames = new Fox.Core.DynamicArray<Fox.String>();
        
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
        static PhxVehicleAxis()
        {
            classInfo = new Fox.EntityInfo("PhxVehicleAxis", typeof(PhxVehicleAxis), new Fox.Core.Data().GetClassEntityInfo(), 128, "Phx", 1);
			classInfo.StaticProperties.Insert("vehicleAxisParam", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Phx.PhVehicleAxisParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("wheelConstraintParam", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Phx.PhxWheelConstraintParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("wheelAssociationUnitParams", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Phx.PhxWheelAssociationUnitParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("torqueDistributions", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("gearRatios", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 168, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("wheelFront", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("wheelUp", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("wheelPositionOffset", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("wheelRadius", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("wheelFriction", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("wheelRestitution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("wheelInertia", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("suspentionLength", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("maxSuspentionForceCoeff", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("dampingCoeffElong", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("dampingCoeffCompress", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("maxBreakTorqueCoeff", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("useDifferential", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("AssignedBoneNames", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 0, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public PhxVehicleAxis(ulong id) : base(id) { }
		public PhxVehicleAxis() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "vehicleAxisParam":
                    this.vehicleAxisParam = value.GetValueAsEntityPtr<Fox.Phx.PhVehicleAxisParam>();
                    return;
                case "wheelConstraintParam":
                    this.wheelConstraintParam = value.GetValueAsEntityPtr<Fox.Phx.PhxWheelConstraintParam>();
                    return;
                case "wheelFront":
                    this.wheelFront = value.GetValueAsVector3();
                    return;
                case "wheelUp":
                    this.wheelUp = value.GetValueAsVector3();
                    return;
                case "wheelPositionOffset":
                    this.wheelPositionOffset = value.GetValueAsVector3();
                    return;
                case "wheelRadius":
                    this.wheelRadius = value.GetValueAsFloat();
                    return;
                case "wheelFriction":
                    this.wheelFriction = value.GetValueAsFloat();
                    return;
                case "wheelRestitution":
                    this.wheelRestitution = value.GetValueAsFloat();
                    return;
                case "wheelInertia":
                    this.wheelInertia = value.GetValueAsFloat();
                    return;
                case "suspentionLength":
                    this.suspentionLength = value.GetValueAsFloat();
                    return;
                case "maxSuspentionForceCoeff":
                    this.maxSuspentionForceCoeff = value.GetValueAsFloat();
                    return;
                case "dampingCoeffElong":
                    this.dampingCoeffElong = value.GetValueAsFloat();
                    return;
                case "dampingCoeffCompress":
                    this.dampingCoeffCompress = value.GetValueAsFloat();
                    return;
                case "maxBreakTorqueCoeff":
                    this.maxBreakTorqueCoeff = value.GetValueAsFloat();
                    return;
                case "useDifferential":
                    this.useDifferential = value.GetValueAsBool();
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
                case "wheelAssociationUnitParams":
                    while(this.wheelAssociationUnitParams.Count <= index) { this.wheelAssociationUnitParams.Add(default(Fox.Core.EntityPtr<Fox.Phx.PhxWheelAssociationUnitParam>)); }
                    this.wheelAssociationUnitParams[index] = value.GetValueAsEntityPtr<Fox.Phx.PhxWheelAssociationUnitParam>();
                    return;
                case "torqueDistributions":
                    while(this.torqueDistributions.Count <= index) { this.torqueDistributions.Add(default(float)); }
                    this.torqueDistributions[index] = value.GetValueAsFloat();
                    return;
                case "gearRatios":
                    while(this.gearRatios.Count <= index) { this.gearRatios.Add(default(float)); }
                    this.gearRatios[index] = value.GetValueAsFloat();
                    return;
                case "AssignedBoneNames":
                    while(this.AssignedBoneNames.Count <= index) { this.AssignedBoneNames.Add(default(Fox.String)); }
                    this.AssignedBoneNames[index] = value.GetValueAsString();
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