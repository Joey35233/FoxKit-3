//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Core
{
    public partial class EntityPtrListEntity : Fox.Core.Entity 
    {
        // Properties
        public System.Collections.Generic.IList<EntityPtr<FoxCore.Entity>> list { get; } = new System.Collections.Generic.List<EntityPtr<FoxCore.Entity>>();
        
        // PropertyInfo
        private static EntityInfo classInfo;
        public static new EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static EntityPtrListEntity()
        {
            classInfo = new EntityInfo(new String("EntityPtrListEntity"), base.GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert(new String("list"), new PropertyInfo(PropertyInfo.PropertyType.EntityPtr, 48, 1, PropertyInfo.ContainerType.List, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, typeof(FoxCore.Entity), null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public EntityPtrListEntity(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(String propertyName, ushort index, Value value)
        {
            switch(propertyName.CString())
            {
                case "list":
                    while(this.list.Count <= index) { this.list.Add(default(EntityPtr<FoxCore.Entity>)); }
                    this.list[index] = EntityPtr<FoxCore.Entity>.Get(value.GetValueAsEntityPtr().Entity as FoxCore.Entity);
                    return;
                default:
					
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(String propertyName, String key, Value value)
        {
            switch(propertyName.CString())
            {
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}