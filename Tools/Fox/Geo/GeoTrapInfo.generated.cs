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
    public partial class GeoTrapInfo : Fox.Core.Entity 
    {
        // Properties
        public StringMap<byte> moverTags { get; } = new StringMap<byte>();
        
        public EntityHandle moverHandle { get; set; }
        
        public System.Numerics.Vector3 moverPosition { get; set; }
        
        public System.Numerics.Vector3 moverRotation { get; set; }
        
        public String trapName { get; set; }
        
        public System.Numerics.Vector3 trapPosition { get; set; }
        
        public EntityHandle trapBodyHandle { get; set; }
        
        public EntityHandle conditionHandle { get; set; }
        
        public EntityHandle conditionBodyHandle { get; set; }
        
        public String trapFlagString { get; set; }
        
        public uint trapFlag { get; set; }
        
        public ushort moverGameObjectId { get; set; }
        
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
        static GeoTrapInfo()
        {
            classInfo = new EntityInfo(new String("GeoTrapInfo"), base.GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert(new String("moverTags"), new PropertyInfo(PropertyInfo.PropertyType.UInt8, 48, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("moverHandle"), new PropertyInfo(PropertyInfo.PropertyType.EntityHandle, 96, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("moverPosition"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 112, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("moverRotation"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 128, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("trapName"), new PropertyInfo(PropertyInfo.PropertyType.String, 144, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("trapPosition"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 160, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("trapBodyHandle"), new PropertyInfo(PropertyInfo.PropertyType.EntityHandle, 176, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("conditionHandle"), new PropertyInfo(PropertyInfo.PropertyType.EntityHandle, 184, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("conditionBodyHandle"), new PropertyInfo(PropertyInfo.PropertyType.EntityHandle, 192, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("trapFlagString"), new PropertyInfo(PropertyInfo.PropertyType.String, 200, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("trapFlag"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 208, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("moverGameObjectId"), new PropertyInfo(PropertyInfo.PropertyType.UInt16, 104, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public GeoTrapInfo(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "moverHandle":
                    this.moverHandle = value.GetValueAsEntityHandle();
                    return;
                case "moverPosition":
                    this.moverPosition = value.GetValueAsVector3();
                    return;
                case "moverRotation":
                    this.moverRotation = value.GetValueAsVector3();
                    return;
                case "trapName":
                    this.trapName = value.GetValueAsString();
                    return;
                case "trapPosition":
                    this.trapPosition = value.GetValueAsVector3();
                    return;
                case "trapBodyHandle":
                    this.trapBodyHandle = value.GetValueAsEntityHandle();
                    return;
                case "conditionHandle":
                    this.conditionHandle = value.GetValueAsEntityHandle();
                    return;
                case "conditionBodyHandle":
                    this.conditionBodyHandle = value.GetValueAsEntityHandle();
                    return;
                case "trapFlagString":
                    this.trapFlagString = value.GetValueAsString();
                    return;
                case "trapFlag":
                    this.trapFlag = value.GetValueAsUInt32();
                    return;
                case "moverGameObjectId":
                    this.moverGameObjectId = value.GetValueAsUInt16();
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
                case "moverTags":
                    this.moverTags.Add(key, value.GetValueAsUInt8());
                    return;
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}