//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Tpp.GameCore
{
    public partial class TppVehicle2AttachmentData : Fox.Core.Data 
    {
        // Properties
        public byte vehicleTypeCode { get; set; }
        
        public byte attachmentImplTypeIndex { get; set; }
        
        public FilePtr<File> attachmentFile { get; set; }
        
        public byte attachmentInstanceCount { get; set; }
        
        public String bodyCnpName { get; set; }
        
        public String attachmentBoneName { get; set; }
        
        public System.Collections.Generic.IList<EntityPtr<TppGameCore.TppVehicle2WeaponParameter>> weaponParams { get; } = new System.Collections.Generic.List<EntityPtr<TppGameCore.TppVehicle2WeaponParameter>>();
        
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
        static TppVehicle2AttachmentData()
        {
            classInfo = new EntityInfo(new String("TppVehicle2AttachmentData"), base.GetClassEntityInfo(), 120, null, 1);
			
			classInfo.StaticProperties.Insert(new String("vehicleTypeCode"), new PropertyInfo(PropertyInfo.PropertyType.UInt8, 177, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("attachmentImplTypeIndex"), new PropertyInfo(PropertyInfo.PropertyType.UInt8, 178, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("attachmentFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 136, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("attachmentInstanceCount"), new PropertyInfo(PropertyInfo.PropertyType.UInt8, 176, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("bodyCnpName"), new PropertyInfo(PropertyInfo.PropertyType.String, 160, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("attachmentBoneName"), new PropertyInfo(PropertyInfo.PropertyType.String, 168, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("weaponParams"), new PropertyInfo(PropertyInfo.PropertyType.EntityPtr, 120, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, typeof(TppGameCore.TppVehicle2WeaponParameter), null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppVehicle2AttachmentData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "vehicleTypeCode":
                    this.vehicleTypeCode = value.GetValueAsUInt8();
                    return;
                case "attachmentImplTypeIndex":
                    this.attachmentImplTypeIndex = value.GetValueAsUInt8();
                    return;
                case "attachmentFile":
                    this.attachmentFile = value.GetValueAsFilePtr();
                    return;
                case "attachmentInstanceCount":
                    this.attachmentInstanceCount = value.GetValueAsUInt8();
                    return;
                case "bodyCnpName":
                    this.bodyCnpName = value.GetValueAsString();
                    return;
                case "attachmentBoneName":
                    this.attachmentBoneName = value.GetValueAsString();
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
                case "weaponParams":
                    while(this.weaponParams.Count <= index) { this.weaponParams.Add(default(EntityPtr<TppGameCore.TppVehicle2WeaponParameter>)); }
                    this.weaponParams[index] = EntityPtr<TppGameCore.TppVehicle2WeaponParameter>.Get(value.GetValueAsEntityPtr().Entity as TppGameCore.TppVehicle2WeaponParameter);
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