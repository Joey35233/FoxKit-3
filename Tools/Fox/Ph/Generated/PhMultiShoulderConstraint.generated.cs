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
    public partial class PhMultiShoulderConstraint : Fox.Ph.PhConstraint 
    {
        // Properties
        public UnityEngine.Quaternion refVec0 { get => Get_refVec0(); set { Set_refVec0(value); } }
        protected partial UnityEngine.Quaternion Get_refVec0();
        protected partial void Set_refVec0(UnityEngine.Quaternion value);
        
        public UnityEngine.Quaternion refVec1 { get => Get_refVec1(); set { Set_refVec1(value); } }
        protected partial UnityEngine.Quaternion Get_refVec1();
        protected partial void Set_refVec1(UnityEngine.Quaternion value);
        
        public float refLimit0 { get => Get_refLimit0(); set { Set_refLimit0(value); } }
        protected partial float Get_refLimit0();
        protected partial void Set_refLimit0(float value);
        
        public float refLimit1 { get => Get_refLimit1(); set { Set_refLimit1(value); } }
        protected partial float Get_refLimit1();
        protected partial void Set_refLimit1(float value);
        
        public float velocityMax { get => Get_velocityMax(); set { Set_velocityMax(value); } }
        protected partial float Get_velocityMax();
        protected partial void Set_velocityMax(float value);
        
        public float torqueMax { get => Get_torqueMax(); set { Set_torqueMax(value); } }
        protected partial float Get_torqueMax();
        protected partial void Set_torqueMax(float value);
        
        public float velocityRate { get => Get_velocityRate(); set { Set_velocityRate(value); } }
        protected partial float Get_velocityRate();
        protected partial void Set_velocityRate(float value);
        
        public bool isPoweredFlag { get => Get_isPoweredFlag(); set { Set_isPoweredFlag(value); } }
        protected partial bool Get_isPoweredFlag();
        protected partial void Set_isPoweredFlag(bool value);
        
        // ClassInfos
        public static new bool ClassInfoInitialized = false;
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
        static PhMultiShoulderConstraint()
        {
            if (Fox.Ph.PhConstraint.ClassInfoInitialized)
                classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("PhMultiShoulderConstraint"), typeof(PhMultiShoulderConstraint), Fox.Ph.PhConstraint.ClassInfo, 0, "Ph", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("refVec0"), Fox.Core.PropertyInfo.PropertyType.Quat, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("refVec1"), Fox.Core.PropertyInfo.PropertyType.Quat, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("refLimit0"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("refLimit1"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("velocityMax"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("torqueMax"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("velocityRate"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isPoweredFlag"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

            ClassInfoInitialized = true;
        }

        // Constructors
		public PhMultiShoulderConstraint(ulong id) : base(id) { }
		public PhMultiShoulderConstraint() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "refVec0":
                    this.refVec0 = value.GetValueAsQuat();
                    return;
                case "refVec1":
                    this.refVec1 = value.GetValueAsQuat();
                    return;
                case "refLimit0":
                    this.refLimit0 = value.GetValueAsFloat();
                    return;
                case "refLimit1":
                    this.refLimit1 = value.GetValueAsFloat();
                    return;
                case "velocityMax":
                    this.velocityMax = value.GetValueAsFloat();
                    return;
                case "torqueMax":
                    this.torqueMax = value.GetValueAsFloat();
                    return;
                case "velocityRate":
                    this.velocityRate = value.GetValueAsFloat();
                    return;
                case "isPoweredFlag":
                    this.isPoweredFlag = value.GetValueAsBool();
                    return;
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}