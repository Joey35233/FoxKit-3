//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Tpp.GameKit
{
    public partial class TppGimmickElectricCableLinkSetData : Fox.Core.Data 
    {
        // Properties
        public EntityLink electricCableData { get; set; }
        
        public EntityLink poleData { get; set; }
        
        public System.Collections.Generic.IList<String> electricCable { get; } = new System.Collections.Generic.List<String>();
        
        public System.Collections.Generic.IList<String> pole { get; } = new System.Collections.Generic.List<String>();
        
        public System.Collections.Generic.IList<byte> cnpIndex { get; } = new System.Collections.Generic.List<byte>();
        
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
        static TppGimmickElectricCableLinkSetData()
        {
            classInfo = new EntityInfo(new String("TppGimmickElectricCableLinkSetData"), base.GetClassEntityInfo(), 176, "Gimmick", 0);
			
			classInfo.StaticProperties.Insert(new String("electricCableData"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 120, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("poleData"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 160, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("electricCable"), new PropertyInfo(PropertyInfo.PropertyType.String, 200, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("pole"), new PropertyInfo(PropertyInfo.PropertyType.String, 216, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("cnpIndex"), new PropertyInfo(PropertyInfo.PropertyType.UInt8, 232, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppGimmickElectricCableLinkSetData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "electricCableData":
                    this.electricCableData = value.GetValueAsEntityLink();
                    return;
                case "poleData":
                    this.poleData = value.GetValueAsEntityLink();
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
                case "electricCable":
                    while(this.electricCable.Count <= index) { this.electricCable.Add(default(String)); }
                    this.electricCable[index] = value.GetValueAsString();
                    return;
                case "pole":
                    while(this.pole.Count <= index) { this.pole.Add(default(String)); }
                    this.pole[index] = value.GetValueAsString();
                    return;
                case "cnpIndex":
                    while(this.cnpIndex.Count <= index) { this.cnpIndex.Add(default(byte)); }
                    this.cnpIndex[index] = value.GetValueAsUInt8();
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