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
    public partial class EntityLinkStringMapPropertyDifference : Fox.Core.PropertyDifference 
    {
        // Properties
        public StringMap<EntityLink> originalValues { get; } = new StringMap<EntityLink>();
        
        public StringMap<EntityLink> values { get; } = new StringMap<EntityLink>();
        
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
        static EntityLinkStringMapPropertyDifference()
        {
            classInfo = new EntityInfo(new String("EntityLinkStringMapPropertyDifference"), base.GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert(new String("originalValues"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 72, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("values"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 120, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public EntityLinkStringMapPropertyDifference(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
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
                default:
					
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(String propertyName, String key, Value value)
        {
            switch(propertyName.CString())
            {
                case "originalValues":
                    this.originalValues.Add(key, value.GetValueAsEntityLink());
                    return;
                case "values":
                    this.values.Add(key, value.GetValueAsEntityLink());
                    return;
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}