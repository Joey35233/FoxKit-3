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

namespace Fox.Core
{
    [UnityEditor.InitializeOnLoad]
    public partial class ShearTransformEntity : Fox.Core.DataElement 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected UnityEngine.Vector3 shearTransform_shear { get; set; }
        
        public UnityEngine.Vector3 shear { get => Get_shear(); set { Set_shear(value); } }
        protected partial UnityEngine.Vector3 Get_shear();
        protected partial void Set_shear(UnityEngine.Vector3 value);
        
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
        static ShearTransformEntity()
        {
            classInfo = new Fox.EntityInfo("ShearTransformEntity", typeof(ShearTransformEntity), new Fox.Core.DataElement().GetClassEntityInfo(), 48, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("shearTransform_shear", Fox.Core.PropertyInfo.PropertyType.Vector3, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("shear", Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
        }

        // Constructors
		public ShearTransformEntity(ulong id) : base(id) { }
		public ShearTransformEntity() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "shearTransform_shear":
                    this.shearTransform_shear = value.GetValueAsVector3();
                    return;
                case "shear":
                    this.shear = value.GetValueAsVector3();
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