//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Geox
{
    public partial class GeoxPartsTargetFollowSkeleton : Fox.Core.Data 
    {
        // Properties
        public System.Collections.Generic.IList<String> skeletonNames { get; } = new System.Collections.Generic.List<String>();
        
        public System.Collections.Generic.IList<EntityLink> objectLinks { get; } = new System.Collections.Generic.List<EntityLink>();
        
        public EntityHandle partsTargetUnitHandle { get; set; }
        
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
        static GeoxPartsTargetFollowSkeleton()
        {
            classInfo = new EntityInfo(new String("GeoxPartsTargetFollowSkeleton"), base.GetClassEntityInfo(), 0, "Target", 2);
			
			classInfo.StaticProperties.Insert(new String("skeletonNames"), new PropertyInfo(PropertyInfo.PropertyType.String, 120, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("objectLinks"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 144, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("partsTargetUnitHandle"), new PropertyInfo(PropertyInfo.PropertyType.EntityHandle, 160, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public GeoxPartsTargetFollowSkeleton(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "partsTargetUnitHandle":
                    this.partsTargetUnitHandle = value.GetValueAsEntityHandle();
                    return;
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(String propertyName, ushort index, Value value)
        {
            switch(propertyName.CString())
            {
                case "skeletonNames":
                    while(this.skeletonNames.Count <= index) { this.skeletonNames.Add(default(String)); }
                    this.skeletonNames[index] = value.GetValueAsString();
                    return;
                case "objectLinks":
                    while(this.objectLinks.Count <= index) { this.objectLinks.Add(default(EntityLink)); }
                    this.objectLinks[index] = value.GetValueAsEntityLink();
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