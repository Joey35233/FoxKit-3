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
    public partial class Project : Fox.Core.Entity 
    {
        // Properties
        public Fox.Core.StringMap<Fox.Core.Path> dataSetPaths = new Fox.Core.StringMap<Fox.Core.Path>();
        
        public Fox.Core.Path currentDataSetPath;
        
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
        static Project()
        {
            classInfo = new Fox.EntityInfo("Project", new Fox.Core.Entity().GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert("dataSetPaths", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 48, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("currentDataSetPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public Project(ulong address, ulong id) : base(address, id) { }
		public Project() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "currentDataSetPath":
                    this.currentDataSetPath = value.GetValueAsPath();
                    return;
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
					
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Value value)
        {
            switch(propertyName)
            {
                case "dataSetPaths":
                    this.dataSetPaths.Insert(key, value.GetValueAsPath());
                    return;
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}