//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.FoxCore
{
    public partial class Project : FoxCore.Entity 
    {
        // Properties
        public StringMap<Path> dataSetPaths { get; } = new StringMap<Path>();
        
        public Path currentDataSetPath { get; set; }
        
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
        static Project()
        {
            classInfo = new EntityInfo(new String("Project"), base.GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert(new String("dataSetPaths"), new PropertyInfo(PropertyInfo.PropertyType.Path, 48, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("currentDataSetPath"), new PropertyInfo(PropertyInfo.PropertyType.Path, 96, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public Project(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "currentDataSetPath":
                    this.currentDataSetPath = value.GetValueAsPath();
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
                default:
					
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(String propertyName, String key, Value value)
        {
            switch(propertyName.CString())
            {
                case "dataSetPaths":
                    this.dataSetPaths.Add(key, value.GetValueAsPath());
                    return;
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}