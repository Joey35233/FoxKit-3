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
    public partial class OrientedBoundingBox 
    {
        // Properties
        public UnityEngine.Vector3 center;
        
        public UnityEngine.Vector3 size;
        
        public UnityEngine.Quaternion rotation;
        
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
        static OrientedBoundingBox()
        {
            classInfo = new Fox.EntityInfo("OrientedBoundingBox", null, 0, null, 0);
			
			classInfo.StaticProperties.Insert("center", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("size", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 16, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rotation", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Quat, 32, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		
        
        public virtual void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
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