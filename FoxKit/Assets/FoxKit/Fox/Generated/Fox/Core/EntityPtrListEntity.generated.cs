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
    public partial class EntityPtrListEntity : Fox.Core.Entity 
    {
        // Properties
        public Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Core.Entity>> list = new Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Core.Entity>>();
        
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
        static EntityPtrListEntity()
        {
            classInfo = new Fox.EntityInfo("EntityPtrListEntity", new Fox.Core.Entity().GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert("list", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 48, 1, Fox.Core.PropertyInfo.ContainerType.List, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.Entity), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public EntityPtrListEntity(ulong address, ulong id) : base(address, id) { }
		public EntityPtrListEntity() : base() { }
        
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
                case "list":
                    while(this.list.Count <= index) { this.list.Add(default(Fox.Core.EntityPtr<Fox.Core.Entity>)); }
                    this.list[index] = value.GetValueAsEntityPtr<Fox.Core.Entity>();
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