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
    public partial class PivotTransform 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public UnityEngine.Vector3 pivot { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Vector3 pivotTranslation { get; set; }
        
        // PropertyInfo
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
        static PivotTransform()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("PivotTransform"), typeof(PivotTransform), null, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("pivot"), Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("pivotTranslation"), Fox.Core.PropertyInfo.PropertyType.Vector3, 16, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		
		public PivotTransform()
        {
            
        }
        
        public virtual void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "pivot":
                    this.pivot = value.GetValueAsVector3();
                    return;
                case "pivotTranslation":
                    this.pivotTranslation = value.GetValueAsVector3();
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