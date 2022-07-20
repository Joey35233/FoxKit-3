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
        protected Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Core.Entity>> entityDifferences { get; set; } = new Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Core.Entity>>();
        
        [field: UnityEngine.SerializeField]
        protected Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Core.PropertyDifference>> propertyDifferences { get; set; } = new Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Core.PropertyDifference>>();
        
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
        static EntityDifference()
        {
            classInfo = new Fox.EntityInfo("EntityDifference", typeof(EntityDifference), new Fox.Core.Entity().GetClassEntityInfo(), 0, null, 0);
			classInfo.StaticProperties.Insert("entityDifferences", new Fox.Core.PropertyInfo("entityDifferences", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 48, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.Entity), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("propertyDifferences", new Fox.Core.PropertyInfo("propertyDifferences", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 96, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.PropertyDifference), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public EntityDifference(ulong id) : base(id) { }
		public EntityDifference() : base() { }
        
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