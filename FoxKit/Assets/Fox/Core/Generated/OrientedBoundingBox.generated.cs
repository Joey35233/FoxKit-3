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
    public partial class OrientedBoundingBox 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public UnityEngine.Vector3 center { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Vector3 size { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Quaternion rotation { get; set; }
        
        // ClassInfos
        public static  bool ClassInfoInitialized = false;
        private static Fox.Core.EntityInfo classInfo;
        public static  Fox.Core.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public virtual Fox.Core.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static OrientedBoundingBox()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("OrientedBoundingBox"), typeof(OrientedBoundingBox), null, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("center"), Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("size"), Fox.Core.PropertyInfo.PropertyType.Vector3, 16, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rotation"), Fox.Core.PropertyInfo.PropertyType.Quat, 32, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

            ClassInfoInitialized = true;
        }

        // Constructors
		
		public OrientedBoundingBox()
        {
            
        }
        
        public virtual void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "center":
                    this.center = value.GetValueAsVector3();
                    return;
                case "size":
                    this.size = value.GetValueAsVector3();
                    return;
                case "rotation":
                    this.rotation = value.GetValueAsQuat();
                    return;
                default:
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
            }
        }
        
        public virtual void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
            }
        }
        
        public virtual void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
            }
        }
    }
}