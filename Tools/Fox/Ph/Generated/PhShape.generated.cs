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
    public partial class PhShape : Fox.Ph.PhSubObject 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected Fox.Core.EntityPtr<Fox.Ph.PhShapeParam> param { get; set; } = new Fox.Core.EntityPtr<Fox.Ph.PhShapeParam>();
        
        public UnityEngine.Vector3 offset { get => Get_offset(); set { Set_offset(value); } }
        protected partial UnityEngine.Vector3 Get_offset();
        protected partial void Set_offset(UnityEngine.Vector3 value);
        
        public UnityEngine.Quaternion rotation { get => Get_rotation(); set { Set_rotation(value); } }
        protected partial UnityEngine.Quaternion Get_rotation();
        protected partial void Set_rotation(UnityEngine.Quaternion value);
        
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
        static PhShape()
        {
            classInfo = new Fox.Core.EntityInfo("PhShape", typeof(PhShape), new Fox.Ph.PhSubObject().GetClassEntityInfo(), 0, "Ph", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("param", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Ph.PhShapeParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("offset", Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rotation", Fox.Core.PropertyInfo.PropertyType.Quat, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
        }

        // Constructors
		public PhShape(ulong id) : base(id) { }
		public PhShape() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "param":
                    this.param = value.GetValueAsEntityPtr<Fox.Ph.PhShapeParam>();
                    return;
                case "offset":
                    this.offset = value.GetValueAsVector3();
                    return;
                case "rotation":
                    this.rotation = value.GetValueAsQuat();
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