//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Gr
{
    public partial class TerrainMaterialConfigration : Fox.Core.Data 
    {
        // Properties
        public System.Collections.Generic.IList<uint> slot0 { get; } = new System.Collections.Generic.List<uint>();
        
        public System.Collections.Generic.IList<uint> slot1 { get; } = new System.Collections.Generic.List<uint>();
        
        public System.Collections.Generic.IList<uint> slot2 { get; } = new System.Collections.Generic.List<uint>();
        
        public System.Collections.Generic.IList<uint> slot3 { get; } = new System.Collections.Generic.List<uint>();
        
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
        static TerrainMaterialConfigration()
        {
            classInfo = new EntityInfo(new String("TerrainMaterialConfigration"), base.GetClassEntityInfo(), 128, null, 0);
			
			classInfo.StaticProperties.Insert(new String("slot0"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 120, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("slot1"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 136, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("slot2"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 152, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("slot3"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 168, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TerrainMaterialConfigration(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(String propertyName, ushort index, Value value)
        {
            switch(propertyName.CString())
            {
                case "slot0":
                    while(this.slot0.Count <= index) { this.slot0.Add(default(uint)); }
                    this.slot0[index] = value.GetValueAsUInt32();
                    return;
                case "slot1":
                    while(this.slot1.Count <= index) { this.slot1.Add(default(uint)); }
                    this.slot1[index] = value.GetValueAsUInt32();
                    return;
                case "slot2":
                    while(this.slot2.Count <= index) { this.slot2.Add(default(uint)); }
                    this.slot2[index] = value.GetValueAsUInt32();
                    return;
                case "slot3":
                    while(this.slot3.Count <= index) { this.slot3.Add(default(uint)); }
                    this.slot3[index] = value.GetValueAsUInt32();
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