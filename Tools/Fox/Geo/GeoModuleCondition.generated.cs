//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Geo
{
    public partial class GeoModuleCondition : Fox.Geo.GeoTrapCondition 
    {
        // Properties
        public bool isAndCheck { get; set; }
        
        public System.Collections.Generic.IList<String> checkFuncNames { get; } = new System.Collections.Generic.List<String>();
        
        public System.Collections.Generic.IList<String> execFuncNames { get; } = new System.Collections.Generic.List<String>();
        
        public System.Collections.Generic.IList<EntityPtr<Geo.GeoTrapModuleCallbackDataElement>> checkCallbackDataElements { get; } = new System.Collections.Generic.List<EntityPtr<Geo.GeoTrapModuleCallbackDataElement>>();
        
        public System.Collections.Generic.IList<EntityPtr<Geo.GeoTrapModuleCallbackDataElement>> execCallbackDataElements { get; } = new System.Collections.Generic.List<EntityPtr<Geo.GeoTrapModuleCallbackDataElement>>();
        
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
        static GeoModuleCondition()
        {
            classInfo = new EntityInfo(new String("GeoModuleCondition"), base.GetClassEntityInfo(), 352, "Trap", 0);
			
			classInfo.StaticProperties.Insert(new String("isAndCheck"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 320, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("checkFuncNames"), new PropertyInfo(PropertyInfo.PropertyType.String, 328, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("execFuncNames"), new PropertyInfo(PropertyInfo.PropertyType.String, 344, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("checkCallbackDataElements"), new PropertyInfo(PropertyInfo.PropertyType.EntityPtr, 360, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, typeof(Geo.GeoTrapModuleCallbackDataElement), null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("execCallbackDataElements"), new PropertyInfo(PropertyInfo.PropertyType.EntityPtr, 376, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, typeof(Geo.GeoTrapModuleCallbackDataElement), null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public GeoModuleCondition(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "isAndCheck":
                    this.isAndCheck = value.GetValueAsBool();
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
                case "checkFuncNames":
                    while(this.checkFuncNames.Count <= index) { this.checkFuncNames.Add(default(String)); }
                    this.checkFuncNames[index] = value.GetValueAsString();
                    return;
                case "execFuncNames":
                    while(this.execFuncNames.Count <= index) { this.execFuncNames.Add(default(String)); }
                    this.execFuncNames[index] = value.GetValueAsString();
                    return;
                case "checkCallbackDataElements":
                    while(this.checkCallbackDataElements.Count <= index) { this.checkCallbackDataElements.Add(default(EntityPtr<Geo.GeoTrapModuleCallbackDataElement>)); }
                    this.checkCallbackDataElements[index] = EntityPtr<Geo.GeoTrapModuleCallbackDataElement>.Get(value.GetValueAsEntityPtr().Entity as Geo.GeoTrapModuleCallbackDataElement);
                    return;
                case "execCallbackDataElements":
                    while(this.execCallbackDataElements.Count <= index) { this.execCallbackDataElements.Add(default(EntityPtr<Geo.GeoTrapModuleCallbackDataElement>)); }
                    this.execCallbackDataElements[index] = EntityPtr<Geo.GeoTrapModuleCallbackDataElement>.Get(value.GetValueAsEntityPtr().Entity as Geo.GeoTrapModuleCallbackDataElement);
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