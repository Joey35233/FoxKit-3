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
    public partial class UInt64StringMapPropertyDifference : Fox.Core.PropertyDifference 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<ulong> originalValues { get; set; } = new Fox.Kernel.StringMap<ulong>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<ulong> values { get; set; } = new Fox.Kernel.StringMap<ulong>();
        
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
        static UInt64StringMapPropertyDifference()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("UInt64StringMapPropertyDifference"), typeof(UInt64StringMapPropertyDifference), new Fox.Core.PropertyDifference().GetClassEntityInfo(), 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("originalValues"), Fox.Core.PropertyInfo.PropertyType.UInt64, 72, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("values"), Fox.Core.PropertyInfo.PropertyType.UInt64, 120, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public UInt64StringMapPropertyDifference(ulong id) : base(id) { }
		public UInt64StringMapPropertyDifference() : base() { }
        
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
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "originalValues":
                    this.originalValues.Insert(key, value.GetValueAsUInt64());
                    return;
                case "values":
                    this.values.Insert(key, value.GetValueAsUInt64());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}