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
    public partial class GeoTrapScriptConditionBody : Fox.Geo.GeoTrapConditionBody 
    {
        // Properties
        public EntityPtr<FoxCore.SafeScript> script { get; set; }
        
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
        static GeoTrapScriptConditionBody()
        {
            classInfo = new EntityInfo(new String("GeoTrapScriptConditionBody"), base.GetClassEntityInfo(), 0, "Trap", 0);
			
			classInfo.StaticProperties.Insert(new String("script"), new PropertyInfo(PropertyInfo.PropertyType.EntityPtr, 160, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, typeof(FoxCore.SafeScript), null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public GeoTrapScriptConditionBody(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "script":
                    this.script = EntityPtr<FoxCore.SafeScript>.Get(value.GetValueAsEntityPtr().Entity as FoxCore.SafeScript);
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