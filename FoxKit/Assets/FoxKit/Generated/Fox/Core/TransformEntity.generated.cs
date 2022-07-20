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
    public partial class TransformEntity : Fox.Core.DataElement 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected UnityEngine.Vector3 transform_scale { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected UnityEngine.Quaternion transform_rotation_quat { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected UnityEngine.Vector3 transform_translation { get; set; }
        
        public UnityEngine.Vector3 scale { get => Get_scale(); set { Set_scale(value); } }
        protected partial UnityEngine.Vector3 Get_scale();
        protected partial void Set_scale(UnityEngine.Vector3 value);
        
        public UnityEngine.Quaternion rotQuat { get => Get_rotQuat(); set { Set_rotQuat(value); } }
        protected partial UnityEngine.Quaternion Get_rotQuat();
        protected partial void Set_rotQuat(UnityEngine.Quaternion value);
        
        public UnityEngine.Vector3 translation { get => Get_translation(); set { Set_translation(value); } }
        protected partial UnityEngine.Vector3 Get_translation();
        protected partial void Set_translation(UnityEngine.Vector3 value);
        
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
        static TransformEntity()
        {
            classInfo = new Fox.EntityInfo("TransformEntity", typeof(TransformEntity), new Fox.Core.DataElement().GetClassEntityInfo(), 80, null, 0);
			classInfo.StaticProperties.Insert("transform_scale", new Fox.Core.PropertyInfo("transform_scale", Fox.Core.PropertyInfo.PropertyType.Vector3, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("transform_rotation_quat", new Fox.Core.PropertyInfo("transform_rotation_quat", Fox.Core.PropertyInfo.PropertyType.Quat, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("transform_translation", new Fox.Core.PropertyInfo("transform_translation", Fox.Core.PropertyInfo.PropertyType.Vector3, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("scale", new Fox.Core.PropertyInfo("scale", Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rotQuat", new Fox.Core.PropertyInfo("rotQuat", Fox.Core.PropertyInfo.PropertyType.Quat, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("translation", new Fox.Core.PropertyInfo("translation", Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TransformEntity(ulong id) : base(id) { }
		public TransformEntity() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "transform_scale":
                    this.transform_scale = value.GetValueAsVector3();
                    return;
                case "transform_rotation_quat":
                    this.transform_rotation_quat = value.GetValueAsQuat();
                    return;
                case "transform_translation":
                    this.transform_translation = value.GetValueAsVector3();
                    return;
                case "scale":
                    this.scale = value.GetValueAsVector3();
                    return;
                case "rotQuat":
                    this.rotQuat = value.GetValueAsQuat();
                    return;
                case "translation":
                    this.translation = value.GetValueAsVector3();
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