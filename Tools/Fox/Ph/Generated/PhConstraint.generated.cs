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
    public partial class PhConstraint : Fox.Ph.PhSubObject 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected Fox.Core.EntityPtr<Fox.Ph.PhConstraintParam> param { get; set; } = new Fox.Core.EntityPtr<Fox.Ph.PhConstraintParam>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink bodyA { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink bodyB { get; set; }
        
        public UnityEngine.Vector3 defaultPosition { get => Get_defaultPosition(); set { Set_defaultPosition(value); } }
        protected partial UnityEngine.Vector3 Get_defaultPosition();
        protected partial void Set_defaultPosition(UnityEngine.Vector3 value);
        
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
        static PhConstraint()
        {
            classInfo = new Fox.Core.EntityInfo("PhConstraint", typeof(PhConstraint), new Fox.Ph.PhSubObject().GetClassEntityInfo(), 0, "Ph", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("param", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Ph.PhConstraintParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("bodyA", Fox.Core.PropertyInfo.PropertyType.EntityLink, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("bodyB", Fox.Core.PropertyInfo.PropertyType.EntityLink, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("defaultPosition", Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
        }

        // Constructors
		public PhConstraint(ulong id) : base(id) { }
		public PhConstraint() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "param":
                    this.param = value.GetValueAsEntityPtr<Fox.Ph.PhConstraintParam>();
                    return;
                case "bodyA":
                    this.bodyA = value.GetValueAsEntityLink();
                    return;
                case "bodyB":
                    this.bodyB = value.GetValueAsEntityLink();
                    return;
                case "defaultPosition":
                    this.defaultPosition = value.GetValueAsVector3();
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