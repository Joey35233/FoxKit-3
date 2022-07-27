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

namespace Fox.Ph
{
    [UnityEditor.InitializeOnLoad]
    public partial class PhMultiHingeConstraint : Fox.Ph.PhConstraint 
    {
        // Properties
        public UnityEngine.Quaternion axis { get => Get_axis(); set { Set_axis(value); } }
        protected partial UnityEngine.Quaternion Get_axis();
        protected partial void Set_axis(UnityEngine.Quaternion value);
        
        public bool limitedFlag { get => Get_limitedFlag(); set { Set_limitedFlag(value); } }
        protected partial bool Get_limitedFlag();
        protected partial void Set_limitedFlag(bool value);
        
        public bool isPoweredFlag { get => Get_isPoweredFlag(); set { Set_isPoweredFlag(value); } }
        protected partial bool Get_isPoweredFlag();
        protected partial void Set_isPoweredFlag(bool value);
        
        public float limitHi { get => Get_limitHi(); set { Set_limitHi(value); } }
        protected partial float Get_limitHi();
        protected partial void Set_limitHi(float value);
        
        public float limitLo { get => Get_limitLo(); set { Set_limitLo(value); } }
        protected partial float Get_limitLo();
        protected partial void Set_limitLo(float value);
        
        public uint powerControlType { get => Get_powerControlType(); set { Set_powerControlType(value); } }
        protected partial uint Get_powerControlType();
        protected partial void Set_powerControlType(uint value);
        
        public float velocityMax { get => Get_velocityMax(); set { Set_velocityMax(value); } }
        protected partial float Get_velocityMax();
        protected partial void Set_velocityMax(float value);
        
        public float torqueMax { get => Get_torqueMax(); set { Set_torqueMax(value); } }
        protected partial float Get_torqueMax();
        protected partial void Set_torqueMax(float value);
        
        public float targetTheta { get => Get_targetTheta(); set { Set_targetTheta(value); } }
        protected partial float Get_targetTheta();
        protected partial void Set_targetTheta(float value);
        
        public float targetVelocity { get => Get_targetVelocity(); set { Set_targetVelocity(value); } }
        protected partial float Get_targetVelocity();
        protected partial void Set_targetVelocity(float value);
        
        public float velocityRate { get => Get_velocityRate(); set { Set_velocityRate(value); } }
        protected partial float Get_velocityRate();
        protected partial void Set_velocityRate(float value);
        
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
        static PhMultiHingeConstraint()
        {
            classInfo = new Fox.Core.EntityInfo("PhMultiHingeConstraint", typeof(PhMultiHingeConstraint), new Fox.Ph.PhConstraint().GetClassEntityInfo(), 0, "Ph", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("axis", Fox.Core.PropertyInfo.PropertyType.Quat, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("limitedFlag", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isPoweredFlag", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("limitHi", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("limitLo", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("powerControlType", Fox.Core.PropertyInfo.PropertyType.UInt32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("velocityMax", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("torqueMax", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("targetTheta", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("targetVelocity", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("velocityRate", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
        }

        // Constructors
		public PhMultiHingeConstraint(ulong id) : base(id) { }
		public PhMultiHingeConstraint() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "axis":
                    this.axis = value.GetValueAsQuat();
                    return;
                case "limitedFlag":
                    this.limitedFlag = value.GetValueAsBool();
                    return;
                case "isPoweredFlag":
                    this.isPoweredFlag = value.GetValueAsBool();
                    return;
                case "limitHi":
                    this.limitHi = value.GetValueAsFloat();
                    return;
                case "limitLo":
                    this.limitLo = value.GetValueAsFloat();
                    return;
                case "powerControlType":
                    this.powerControlType = value.GetValueAsUInt32();
                    return;
                case "velocityMax":
                    this.velocityMax = value.GetValueAsFloat();
                    return;
                case "torqueMax":
                    this.torqueMax = value.GetValueAsFloat();
                    return;
                case "targetTheta":
                    this.targetTheta = value.GetValueAsFloat();
                    return;
                case "targetVelocity":
                    this.targetVelocity = value.GetValueAsFloat();
                    return;
                case "velocityRate":
                    this.velocityRate = value.GetValueAsFloat();
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