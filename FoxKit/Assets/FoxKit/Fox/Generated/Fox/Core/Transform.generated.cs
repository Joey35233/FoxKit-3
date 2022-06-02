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
    public partial class Transform 
    {
        // Properties
        public UnityEngine.Vector3 scale;
        
        public UnityEngine.Quaternion rotation_quat;
        
        public UnityEngine.Vector3 translation;
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
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
        static Transform()
        {
            classInfo = new Fox.EntityInfo("Transform", null, 0, null, 0);
			
			classInfo.StaticProperties.Insert("scale", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rotation_quat", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Quat, 16, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("translation", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 32, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		
		
        
        public virtual void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "scale":
                    this.scale = value.GetValueAsVector3();
                    return;
                case "rotation_quat":
                    this.rotation_quat = value.GetValueAsQuat();
                    return;
                case "translation":
                    this.translation = value.GetValueAsVector3();
                    return;
                default:
				    
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
                    return;
            }
        }
        
        public virtual void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
					
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
                    return;
            }
        }
        
        public virtual void SetPropertyElement(string propertyName, string key, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
					
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
                    return;
            }
        }
    }
}