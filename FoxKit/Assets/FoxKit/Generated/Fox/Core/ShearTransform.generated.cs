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
    public partial class ShearTransform 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public UnityEngine.Vector3 shear { get; set; }
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static  Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public virtual Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static ShearTransform()
        {
            classInfo = new Fox.EntityInfo("ShearTransform", typeof(ShearTransform), null, 0, null, 0);
			classInfo.StaticProperties.Insert("shear", new Fox.Core.PropertyInfo("shear", Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		
		public ShearTransform()
        {
            
        }
        
        public virtual void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "shear":
                    this.shear = value.GetValueAsVector3();
                    return;
                default:
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
            }
        }
        
        public virtual void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
            }
        }
        
        public virtual void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
            }
        }
    }
}