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
    public partial class TppBuddyPuppyParameter : Fox.Core.DataElement 
    {
        // Properties
        public FilePtr<File> partsFile { get; set; }
        
        public FilePtr<File> motionGraphFile { get; set; }
        
        public FilePtr<File> mtarFile { get; set; }
        
        public StringMap<FilePtr<File>> vfxFiles { get; } = new StringMap<FilePtr<File>>();
        
        public System.Collections.Generic.IList<FilePtr<File>> fovaFiles { get; } = new System.Collections.Generic.List<FilePtr<File>>();
        
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
        static TppBuddyPuppyParameter()
        {
            classInfo = new EntityInfo(new String("TppBuddyPuppyParameter"), base.GetClassEntityInfo(), 168, null, 1);
			
			classInfo.StaticProperties.Insert(new String("partsFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 56, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("motionGraphFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 80, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("mtarFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 104, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("vfxFiles"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 128, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("fovaFiles"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 176, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppBuddyPuppyParameter(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
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
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(String propertyName, ushort index, Value value)
        {
            switch(propertyName.CString())
            {
                case "fovaFiles":
                    while(this.fovaFiles.Count <= index) { this.fovaFiles.Add(default(FilePtr<File>)); }
                    this.fovaFiles[index] = value.GetValueAsFilePtr();
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