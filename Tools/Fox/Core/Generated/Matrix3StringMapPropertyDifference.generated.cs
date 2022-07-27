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
    public partial class Matrix3StringMapPropertyDifference : Fox.Core.PropertyDifference 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<object> originalValues { get; set; } = new Fox.Kernel.StringMap<object>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<object> values { get; set; } = new Fox.Kernel.StringMap<object>();
        
        // PropertyInfo
        private static Fox.Core.EntityInfo classInfo;
        public static new Fox.Core.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override Fox.Core.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static Matrix3StringMapPropertyDifference()
        {
            classInfo = new Fox.Core.EntityInfo("Matrix3StringMapPropertyDifference", typeof(Matrix3StringMapPropertyDifference), new Fox.Core.PropertyDifference().GetClassEntityInfo(), 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("originalValues", Fox.Core.PropertyInfo.PropertyType.Matrix3, 72, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("values", Fox.Core.PropertyInfo.PropertyType.Matrix3, 120, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public Matrix3StringMapPropertyDifference(ulong id) : base(id) { }
		public Matrix3StringMapPropertyDifference() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "originalValues":
                    this.originalValues.Insert(key, value.GetValueAsMatrix3());
                    return;
                case "values":
                    this.values.Insert(key, value.GetValueAsMatrix3());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}