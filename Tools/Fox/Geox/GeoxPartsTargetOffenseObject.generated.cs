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
    public partial class GeoxPartsTargetOffenseObject : Fox.Geox.GeoxPartsTargetObject 
    {
        // Properties
        public bool isAnyOffenseCallback { get; set; }
        
        public bool isNoDefenseCallback { get; set; }
        
        public bool isHandleCheck { get; set; }
        
        public bool isNameCheck { get; set; }
        
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
        static GeoxPartsTargetOffenseObject()
        {
            classInfo = new EntityInfo(new String("GeoxPartsTargetOffenseObject"), base.GetClassEntityInfo(), 0, "Target", 1);
			
			classInfo.StaticProperties.Insert(new String("isAnyOffenseCallback"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 400, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isNoDefenseCallback"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 401, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isHandleCheck"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 402, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isNameCheck"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 403, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public GeoxPartsTargetOffenseObject(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "isAnyOffenseCallback":
                    this.isAnyOffenseCallback = value.GetValueAsBool();
                    return;
                case "isNoDefenseCallback":
                    this.isNoDefenseCallback = value.GetValueAsBool();
                    return;
                case "isHandleCheck":
                    this.isHandleCheck = value.GetValueAsBool();
                    return;
                case "isNameCheck":
                    this.isNameCheck = value.GetValueAsBool();
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