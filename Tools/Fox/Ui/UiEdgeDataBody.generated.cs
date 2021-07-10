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
    public partial class UiEdgeDataBody : Fox.Core.DataBody 
    {
        // Properties
        public EntityHandle sourcePort { get; set; }
        
        public int sourcePortType { get; set; }
        
        public int sourcePortIndex { get; set; }
        
        public EntityHandle targetPort { get; set; }
        
        public int targetPortType { get; set; }
        
        public int targetPortIndex { get; set; }
        
        public bool isConnect { get; set; }
        
        public bool isVirtual { get; set; }
        
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
        static UiEdgeDataBody()
        {
            classInfo = new EntityInfo(new String("UiEdgeDataBody"), base.GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert(new String("sourcePort"), new PropertyInfo(PropertyInfo.PropertyType.EntityHandle, 88, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("sourcePortType"), new PropertyInfo(PropertyInfo.PropertyType.Int32, 96, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("sourcePortIndex"), new PropertyInfo(PropertyInfo.PropertyType.Int32, 100, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("targetPort"), new PropertyInfo(PropertyInfo.PropertyType.EntityHandle, 104, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("targetPortType"), new PropertyInfo(PropertyInfo.PropertyType.Int32, 112, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("targetPortIndex"), new PropertyInfo(PropertyInfo.PropertyType.Int32, 116, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isConnect"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 120, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isVirtual"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 121, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public UiEdgeDataBody(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "sourcePort":
                    this.sourcePort = value.GetValueAsEntityHandle();
                    return;
                case "sourcePortType":
                    this.sourcePortType = value.GetValueAsInt32();
                    return;
                case "sourcePortIndex":
                    this.sourcePortIndex = value.GetValueAsInt32();
                    return;
                case "targetPort":
                    this.targetPort = value.GetValueAsEntityHandle();
                    return;
                case "targetPortType":
                    this.targetPortType = value.GetValueAsInt32();
                    return;
                case "targetPortIndex":
                    this.targetPortIndex = value.GetValueAsInt32();
                    return;
                case "isConnect":
                    this.isConnect = value.GetValueAsBool();
                    return;
                case "isVirtual":
                    this.isVirtual = value.GetValueAsBool();
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