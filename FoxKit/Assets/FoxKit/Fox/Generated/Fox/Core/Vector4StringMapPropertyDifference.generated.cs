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
    public partial class Vector4StringMapPropertyDifference : Fox.Core.PropertyDifference 
    {
        // Properties
        public Fox.Core.StringMap<UnityEngine.Vector4> originalValues = new Fox.Core.StringMap<UnityEngine.Vector4>();
        
        public Fox.Core.StringMap<UnityEngine.Vector4> values = new Fox.Core.StringMap<UnityEngine.Vector4>();
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public  override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static Vector4StringMapPropertyDifference()
        {
            classInfo = new Fox.EntityInfo("Vector4StringMapPropertyDifference", new Fox.Core.PropertyDifference().GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert("originalValues", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector4, 72, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("values", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector4, 120, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public Vector4StringMapPropertyDifference(ulong address, ulong id) : base(address, id) { }
		public Vector4StringMapPropertyDifference() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
					
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Value value)
        {
            switch(propertyName)
            {
                case "originalValues":
                    this.originalValues.Insert(key, value.GetValueAsVector4());
                    return;
                case "values":
                    this.values.Insert(key, value.GetValueAsVector4());
                    return;
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}