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

namespace Fox.Animx
{
    public partial class PluginAngleLimit 
    {
        // Properties
        public float hriLimL;
        
        public float hriLimR;
        
        public float verLimU;
        
        public float verLimD;
        
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
        static PluginAngleLimit()
        {
            classInfo = new Fox.EntityInfo("PluginAngleLimit", null, 0, null, 0);
			
			classInfo.StaticProperties.Insert("hriLimL", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hriLimR", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 4, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("verLimU", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 8, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("verLimD", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 12, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		
        
        public virtual void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "hriLimL":
                    this.hriLimL = value.GetValueAsFloat();
                    return;
                case "hriLimR":
                    this.hriLimR = value.GetValueAsFloat();
                    return;
                case "verLimU":
                    this.verLimU = value.GetValueAsFloat();
                    return;
                case "verLimD":
                    this.verLimD = value.GetValueAsFloat();
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