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
    public partial class UiActionNode : Fox.Ui.UiNodeData 
    {
        // Properties
        public UiActionNodeKind kind { get; set; }
        
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
        static UiActionNode()
        {
            classInfo = new EntityInfo(new String("UiActionNode"), base.GetClassEntityInfo(), 0, "UiG", 1);
			
			classInfo.StaticProperties.Insert(new String("kind"), new PropertyInfo(PropertyInfo.PropertyType.Int32, 280, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, typeof(UiActionNodeKind), PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public UiActionNode(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "kind":
                    this.kind = (UiActionNodeKind)value.GetValueAsInt32();
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