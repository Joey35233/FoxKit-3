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
    public partial class TppPermanentGimmickMortarParameter : Fox.Core.DataElement 
    {
        // Properties
        public float rotationLimitLeftRight { get; set; }
        
        public float rotationLimitUp { get; set; }
        
        public float rotationLimitDown { get; set; }
        
        public FilePtr<File> defaultShellPartsFile { get; set; }
        
        public FilePtr<File> flareShellPartsFile { get; set; }
        
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
        static TppPermanentGimmickMortarParameter()
        {
            classInfo = new EntityInfo(new String("TppPermanentGimmickMortarParameter"), base.GetClassEntityInfo(), 88, null, 1);
			
			classInfo.StaticProperties.Insert(new String("rotationLimitLeftRight"), new PropertyInfo(PropertyInfo.PropertyType.Float, 56, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rotationLimitUp"), new PropertyInfo(PropertyInfo.PropertyType.Float, 60, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rotationLimitDown"), new PropertyInfo(PropertyInfo.PropertyType.Float, 64, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("defaultShellPartsFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 72, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("flareShellPartsFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 96, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppPermanentGimmickMortarParameter(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "rotationLimitLeftRight":
                    this.rotationLimitLeftRight = value.GetValueAsFloat();
                    return;
                case "rotationLimitUp":
                    this.rotationLimitUp = value.GetValueAsFloat();
                    return;
                case "rotationLimitDown":
                    this.rotationLimitDown = value.GetValueAsFloat();
                    return;
                case "defaultShellPartsFile":
                    this.defaultShellPartsFile = value.GetValueAsFilePtr();
                    return;
                case "flareShellPartsFile":
                    this.flareShellPartsFile = value.GetValueAsFilePtr();
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