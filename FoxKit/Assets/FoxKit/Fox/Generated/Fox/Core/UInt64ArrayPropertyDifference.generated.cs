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
    public partial class UInt64ArrayPropertyDifference : Fox.Core.PropertyDifference 
    {
        // Properties
        public Fox.Core.DynamicArray<ulong> originalValues = new Fox.Core.DynamicArray<ulong>();
        
        public Fox.Core.DynamicArray<ulong> values = new Fox.Core.DynamicArray<ulong>();
        
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
        static UInt64ArrayPropertyDifference()
        {
            classInfo = new Fox.EntityInfo("UInt64ArrayPropertyDifference", typeof(UInt64ArrayPropertyDifference), new Fox.Core.PropertyDifference().GetClassEntityInfo(), 0, null, 0);
			classInfo.StaticProperties.Insert("originalValues", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt64, 72, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("values", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt64, 88, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public UInt64ArrayPropertyDifference(ulong id) : base(id) { }
		public UInt64ArrayPropertyDifference() : base() { }
        
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
                case "originalValues":
                    while(this.originalValues.Count <= index) { this.originalValues.Add(default(ulong)); }
                    this.originalValues[index] = value.GetValueAsUInt64();
                    return;
                case "values":
                    while(this.values.Count <= index) { this.values.Add(default(ulong)); }
                    this.values[index] = value.GetValueAsUInt64();
                    return;
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}