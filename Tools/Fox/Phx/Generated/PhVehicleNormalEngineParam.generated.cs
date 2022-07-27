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
    public partial class PhVehicleNormalEngineParam : Fox.Core.Entity 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<float> specPointAngularVelocity { get; set; } = new Fox.Kernel.DynamicArray<float>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<float> specPointTorque { get; set; } = new Fox.Kernel.DynamicArray<float>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<float> specPointBreakTorque { get; set; } = new Fox.Kernel.DynamicArray<float>();
        
        // PropertyInfo
        private static Fox.Core.EntityInfo classInfo;
        public static new Fox.Core.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override Fox.Core.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static PhVehicleNormalEngineParam()
        {
            classInfo = new Fox.Core.EntityInfo("PhVehicleNormalEngineParam", typeof(PhVehicleNormalEngineParam), new Fox.Core.Entity().GetClassEntityInfo(), 72, "Phx", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("specPointAngularVelocity", Fox.Core.PropertyInfo.PropertyType.Float, 48, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("specPointTorque", Fox.Core.PropertyInfo.PropertyType.Float, 64, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("specPointBreakTorque", Fox.Core.PropertyInfo.PropertyType.Float, 80, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public PhVehicleNormalEngineParam(ulong id) : base(id) { }
		public PhVehicleNormalEngineParam() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "specPointAngularVelocity":
                    while(this.specPointAngularVelocity.Count <= index) { this.specPointAngularVelocity.Add(default(float)); }
                    this.specPointAngularVelocity[index] = value.GetValueAsFloat();
                    return;
                case "specPointTorque":
                    while(this.specPointTorque.Count <= index) { this.specPointTorque.Add(default(float)); }
                    this.specPointTorque[index] = value.GetValueAsFloat();
                    return;
                case "specPointBreakTorque":
                    while(this.specPointBreakTorque.Count <= index) { this.specPointBreakTorque.Add(default(float)); }
                    this.specPointBreakTorque[index] = value.GetValueAsFloat();
                    return;
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