//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Demo
{
    public partial class FxBaseLocator : Fox.Core.TransformData 
    {
        // Properties
        public String drawText { get; set; }
        
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
        static FxBaseLocator()
        {
            classInfo = new EntityInfo(new String("FxBaseLocator"), base.GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert(new String("drawText"), new PropertyInfo(PropertyInfo.PropertyType.String, 304, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public FxBaseLocator(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "drawText":
                    this.drawText = value.GetValueAsString();
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