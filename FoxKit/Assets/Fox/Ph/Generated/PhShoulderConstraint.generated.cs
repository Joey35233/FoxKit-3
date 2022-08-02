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
    public partial class PhShoulderConstraint : Fox.Ph.PhConstraint 
    {
        // Properties
        public bool limitedFlag { get => Get_limitedFlag(); set { Set_limitedFlag(value); } }
        protected partial bool Get_limitedFlag();
        protected partial void Set_limitedFlag(bool value);
        
        public UnityEngine.Vector3 refA { get => Get_refA(); set { Set_refA(value); } }
        protected partial UnityEngine.Vector3 Get_refA();
        protected partial void Set_refA(UnityEngine.Vector3 value);
        
        public UnityEngine.Vector3 refB { get => Get_refB(); set { Set_refB(value); } }
        protected partial UnityEngine.Vector3 Get_refB();
        protected partial void Set_refB(UnityEngine.Vector3 value);
        
        public float limit { get => Get_limit(); set { Set_limit(value); } }
        protected partial float Get_limit();
        protected partial void Set_limit(float value);
        
        public bool limitedFlag1 { get => Get_limitedFlag1(); set { Set_limitedFlag1(value); } }
        protected partial bool Get_limitedFlag1();
        protected partial void Set_limitedFlag1(bool value);
        
        public UnityEngine.Vector3 refA1 { get => Get_refA1(); set { Set_refA1(value); } }
        protected partial UnityEngine.Vector3 Get_refA1();
        protected partial void Set_refA1(UnityEngine.Vector3 value);
        
        public UnityEngine.Vector3 refB1 { get => Get_refB1(); set { Set_refB1(value); } }
        protected partial UnityEngine.Vector3 Get_refB1();
        protected partial void Set_refB1(UnityEngine.Vector3 value);
        
        public float limit1 { get => Get_limit1(); set { Set_limit1(value); } }
        protected partial float Get_limit1();
        protected partial void Set_limit1(float value);
        
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
        static PhShoulderConstraint()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("PhShoulderConstraint"), typeof(PhShoulderConstraint), new Fox.Ph.PhConstraint().GetClassEntityInfo(), 0, "Ph", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("limitedFlag"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("refA"), Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("refB"), Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("limit"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("limitedFlag1"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("refA1"), Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("refB1"), Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("limit1"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
        }

        // Constructors
		public PhShoulderConstraint(ulong id) : base(id) { }
		public PhShoulderConstraint() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "limitedFlag":
                    this.limitedFlag = value.GetValueAsBool();
                    return;
                case "refA":
                    this.refA = value.GetValueAsVector3();
                    return;
                case "refB":
                    this.refB = value.GetValueAsVector3();
                    return;
                case "limit":
                    this.limit = value.GetValueAsFloat();
                    return;
                case "limitedFlag1":
                    this.limitedFlag1 = value.GetValueAsBool();
                    return;
                case "refA1":
                    this.refA1 = value.GetValueAsVector3();
                    return;
                case "refB1":
                    this.refB1 = value.GetValueAsVector3();
                    return;
                case "limit1":
                    this.limit1 = value.GetValueAsFloat();
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