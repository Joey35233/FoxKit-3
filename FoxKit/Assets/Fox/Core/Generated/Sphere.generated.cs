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
    public partial class Sphere 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public UnityEngine.Vector4 p { get; set; }
        
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
        static Sphere()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("Sphere"), typeof(Sphere), null, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("p"), Fox.Core.PropertyInfo.PropertyType.Vector4, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		
		public Sphere()
        {
            
        }
        
        public virtual void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "p":
                    this.p = value.GetValueAsVector4();
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