//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Tpp.System
{
    public partial class TppLocationData : Fox.Core.Data 
    {
        // Properties
        public ushort locationId { get; set; }
        
        public Path scriptPath { get; set; }
        
        public FilePtr<File> weatherParametersFile { get; set; }
        
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
        static TppLocationData()
        {
            classInfo = new EntityInfo(new String("TppLocationData"), base.GetClassEntityInfo(), 104, null, 3);
			
			classInfo.StaticProperties.Insert(new String("locationId"), new PropertyInfo(PropertyInfo.PropertyType.UInt16, 120, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("scriptPath"), new PropertyInfo(PropertyInfo.PropertyType.Path, 128, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("weatherParametersFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 136, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppLocationData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "locationId":
                    this.locationId = value.GetValueAsUInt16();
                    return;
                case "scriptPath":
                    this.scriptPath = value.GetValueAsPath();
                    return;
                case "weatherParametersFile":
                    this.weatherParametersFile = value.GetValueAsFilePtr();
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