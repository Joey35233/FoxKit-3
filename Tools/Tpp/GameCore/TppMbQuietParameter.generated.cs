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
    public partial class TppMbQuietParameter : Fox.Core.DataElement 
    {
        // Properties
        public FilePtr<File> partsFile { get; set; }
        
        public FilePtr<File> motionGraphFile { get; set; }
        
        public FilePtr<File> mtarFile { get; set; }
        
        public FilePtr<File> extensionMtarFile { get; set; }
        
        public StringMap<FilePtr<File>> vfxFiles { get; } = new StringMap<FilePtr<File>>();
        
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
        static TppMbQuietParameter()
        {
            classInfo = new EntityInfo(new String("TppMbQuietParameter"), base.GetClassEntityInfo(), 176, null, 0);
			
			classInfo.StaticProperties.Insert(new String("partsFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 56, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("motionGraphFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 80, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("mtarFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 104, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("extensionMtarFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 128, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("vfxFiles"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 152, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppMbQuietParameter(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "partsFile":
                    this.partsFile = value.GetValueAsFilePtr();
                    return;
                case "motionGraphFile":
                    this.motionGraphFile = value.GetValueAsFilePtr();
                    return;
                case "mtarFile":
                    this.mtarFile = value.GetValueAsFilePtr();
                    return;
                case "extensionMtarFile":
                    this.extensionMtarFile = value.GetValueAsFilePtr();
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
                case "vfxFiles":
                    this.vfxFiles.Add(key, value.GetValueAsFilePtr());
                    return;
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}