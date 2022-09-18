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
    public partial class EntityHandleArrayPropertyDifference : Fox.Core.PropertyDifference 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.EntityHandle> originalValues { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityHandle>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.EntityHandle> values { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityHandle>();
        
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
        static EntityHandleArrayPropertyDifference()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("EntityHandleArrayPropertyDifference"), typeof(EntityHandleArrayPropertyDifference), new Fox.Core.PropertyDifference().GetClassEntityInfo(), 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("originalValues"), Fox.Core.PropertyInfo.PropertyType.EntityHandle, 72, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("values"), Fox.Core.PropertyInfo.PropertyType.EntityHandle, 88, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public EntityHandleArrayPropertyDifference(ulong id) : base(id) { }
		public EntityHandleArrayPropertyDifference() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "originalValues":
                    while(this.originalValues.Count <= index) { this.originalValues.Add(default(Fox.Core.EntityHandle)); }
                    this.originalValues[index] = value.GetValueAsEntityHandle();
                    return;
                case "values":
                    while(this.values.Count <= index) { this.values.Add(default(Fox.Core.EntityHandle)); }
                    this.values[index] = value.GetValueAsEntityHandle();
                    return;
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}