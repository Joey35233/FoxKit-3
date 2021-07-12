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

namespace Tpp.GameCore
{
    public partial class TppPlayer2InstanceSettings 
    {
        // Properties
        public Fox.String instancePackagePath;
        
        public uint instanceBlockSize;
        
        public Fox.String commonMotionTypeName;
        
        public Fox.Core.DynamicArray<Fox.String> partsTypeNames = new Fox.Core.DynamicArray<Fox.String>();
        
        public Fox.Core.DynamicArray<Fox.String> partsTypeInitial = new Fox.Core.DynamicArray<Fox.String>();
        
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
        static TppPlayer2InstanceSettings()
        {
            classInfo = new Fox.EntityInfo("TppPlayer2InstanceSettings", null, 0, null, 0);
			
			classInfo.StaticProperties.Insert("instancePackagePath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("instanceBlockSize", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 8, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("commonMotionTypeName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 16, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("partsTypeNames", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 24, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("partsTypeInitial", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 40, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		
        
        public virtual void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "instancePackagePath":
                    this.instancePackagePath = value.GetValueAsString();
                    return;
                case "instanceBlockSize":
                    this.instanceBlockSize = value.GetValueAsUInt32();
                    return;
                case "commonMotionTypeName":
                    this.commonMotionTypeName = value.GetValueAsString();
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
                case "partsTypeNames":
                    while(this.partsTypeNames.Count <= index) { this.partsTypeNames.Add(default(Fox.String)); }
                    this.partsTypeNames[index] = value.GetValueAsString();
                    return;
                case "partsTypeInitial":
                    while(this.partsTypeInitial.Count <= index) { this.partsTypeInitial.Add(default(Fox.String)); }
                    this.partsTypeInitial[index] = value.GetValueAsString();
                    return;
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