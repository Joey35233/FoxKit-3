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
    public partial class TppObjectBrushSkeletonModelReserveResource : Fox.Core.Data 
    {
        // Properties
        public String pluginName { get; set; }
        
        public uint reserveLodLevel0 { get; set; }
        
        public uint reserveLodLevel1 { get; set; }
        
        public uint reserveLodLevel2 { get; set; }
        
        public uint reserveLodLevel3 { get; set; }
        
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
        static TppObjectBrushSkeletonModelReserveResource()
        {
            classInfo = new EntityInfo(new String("TppObjectBrushSkeletonModelReserveResource"), base.GetClassEntityInfo(), 84, null, 0);
			
			classInfo.StaticProperties.Insert(new String("pluginName"), new PropertyInfo(PropertyInfo.PropertyType.String, 120, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("reserveLodLevel0"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 128, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("reserveLodLevel1"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 132, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("reserveLodLevel2"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 136, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("reserveLodLevel3"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 140, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppObjectBrushSkeletonModelReserveResource(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "pluginName":
                    this.pluginName = value.GetValueAsString();
                    return;
                case "reserveLodLevel0":
                    this.reserveLodLevel0 = value.GetValueAsUInt32();
                    return;
                case "reserveLodLevel1":
                    this.reserveLodLevel1 = value.GetValueAsUInt32();
                    return;
                case "reserveLodLevel2":
                    this.reserveLodLevel2 = value.GetValueAsUInt32();
                    return;
                case "reserveLodLevel3":
                    this.reserveLodLevel3 = value.GetValueAsUInt32();
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