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
    public partial class EntityHandleListEntity : Fox.Core.Entity 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.DynamicArray<Fox.Core.EntityHandle> list { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityHandle>();
        
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
        static EntityHandleListEntity()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("EntityHandleListEntity"), typeof(EntityHandleListEntity), new Fox.Core.Entity().GetClassEntityInfo(), 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("list"), Fox.Core.PropertyInfo.PropertyType.EntityHandle, 48, 1, Fox.Core.PropertyInfo.ContainerType.List, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public EntityHandleListEntity(ulong id) : base(id) { }
		public EntityHandleListEntity() : base() { }
        
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
                case "list":
                    while(this.list.Count <= index) { this.list.Add(default(Fox.Core.EntityHandle)); }
                    this.list[index] = value.GetValueAsEntityHandle();
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