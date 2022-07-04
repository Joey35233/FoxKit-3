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
    public partial class Int8StringMapPropertyDifference : Fox.Core.PropertyDifference 
    {
        // Properties
        public Fox.Core.StringMap<sbyte> originalValues = new Fox.Core.StringMap<sbyte>();
        
        public Fox.Core.StringMap<sbyte> values = new Fox.Core.StringMap<sbyte>();
        
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
        static Int8StringMapPropertyDifference()
        {
            classInfo = new Fox.EntityInfo("Int8StringMapPropertyDifference", typeof(Int8StringMapPropertyDifference), new Fox.Core.PropertyDifference().GetClassEntityInfo(), 0, null, 0);
			classInfo.StaticProperties.Insert("originalValues", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int8, 72, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("values", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int8, 120, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public Int8StringMapPropertyDifference(ulong address, ulong id) : base(address, id) { }
		public Int8StringMapPropertyDifference() : base() { }
        
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
                    this.originalValues.Insert(key, value.GetValueAsInt8());
                    return;
                case "values":
                    this.values.Insert(key, value.GetValueAsInt8());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}