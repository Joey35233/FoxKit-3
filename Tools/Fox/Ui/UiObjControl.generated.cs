//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Ui
{
    public partial class UiObjControl : Fox.Core.Entity 
    {
        // Properties
        public Path uigName { get; set; }
        
        public String uigFileName { get; set; }
        
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
        static UiObjControl()
        {
            classInfo = new EntityInfo(new String("UiObjControl"), base.GetClassEntityInfo(), 0, "Ui", 0);
			
			classInfo.StaticProperties.Insert(new String("uigName"), new PropertyInfo(PropertyInfo.PropertyType.Path, 96, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("uigFileName"), new PropertyInfo(PropertyInfo.PropertyType.String, 104, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public UiObjControl(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "uigName":
                    this.uigName = value.GetValueAsPath();
                    return;
                case "uigFileName":
                    this.uigFileName = value.GetValueAsString();
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
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}