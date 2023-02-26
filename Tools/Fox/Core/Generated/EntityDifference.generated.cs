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
    public partial class EntityDifference : Fox.Core.Entity 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Core.Entity>> entityDifferences { get; set; } = new Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Core.Entity>>();
        
        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Core.PropertyDifference>> propertyDifferences { get; set; } = new Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Core.PropertyDifference>>();
        
        // ClassInfos
        public static new bool ClassInfoInitialized = false;
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
        static EntityDifference()
        {
            if (Fox.Core.Entity.ClassInfoInitialized)
                classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("EntityDifference"), typeof(EntityDifference), Fox.Core.Entity.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("entityDifferences"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 48, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.Entity), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("propertyDifferences"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 96, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.PropertyDifference), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

            ClassInfoInitialized = true;
        }

        // Constructors
		public EntityDifference(ulong id) : base(id) { }
		public EntityDifference() : base() { }
        
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
                case "entityDifferences":
                    this.entityDifferences.Insert(key, value.GetValueAsEntityPtr<Fox.Core.Entity>());
                    return;
                case "propertyDifferences":
                    this.propertyDifferences.Insert(key, value.GetValueAsEntityPtr<Fox.Core.PropertyDifference>());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}