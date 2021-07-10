//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Demox
{
    public partial class DemoStreamAnimation : Fox.Core.Data 
    {
        // Properties
        public Path streamPath { get; set; }
        
        public uint demoLength { get; set; }
        
        public StringMap<DemoStreamAnimation_LocatorType> locatorTypes { get; } = new StringMap<DemoStreamAnimation_LocatorType>();
        
        public StringMap<DemoStreamAnimation_CameraType> cameraTypes { get; } = new StringMap<DemoStreamAnimation_CameraType>();
        
        public StringMap<FilePtr<File>> modelFiles { get; } = new StringMap<FilePtr<File>>();
        
        public StringMap<FilePtr<File>> helpBoneFiles { get; } = new StringMap<FilePtr<File>>();
        
        public StringMap<FilePtr<File>> partsFiles { get; } = new StringMap<FilePtr<File>>();
        
        public StringMap<FilePtr<File>> coverModelFiles { get; } = new StringMap<FilePtr<File>>();
        
        public StringMap<String> modelPartsDictionary { get; } = new StringMap<String>();
        
        public StringMap<String> coverModelDictionary { get; } = new StringMap<String>();
        
        public uint updateJobCount { get; set; }
        
        public StringMap<Path> modelProxyPaths { get; } = new StringMap<Path>();
        
        public StringMap<Path> partsProxyPaths { get; } = new StringMap<Path>();
        
        public StringMap<EntityPtr<Demox.DemoDynamicFileChangeModel>> dynamicModel { get; } = new StringMap<EntityPtr<Demox.DemoDynamicFileChangeModel>>();
        
        public StringMap<EntityPtr<Demox.DemoDynamicFileChangeModel>> dynamicParts { get; } = new StringMap<EntityPtr<Demox.DemoDynamicFileChangeModel>>();
        
        public StringMap<EntityPtr<Demox.DemoFv2ResourceMemory>> dynamicFv2 { get; } = new StringMap<EntityPtr<Demox.DemoFv2ResourceMemory>>();
        
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
        static DemoStreamAnimation()
        {
            classInfo = new EntityInfo(new String("DemoStreamAnimation"), base.GetClassEntityInfo(), 712, null, 3);
			
			classInfo.StaticProperties.Insert(new String("streamPath"), new PropertyInfo(PropertyInfo.PropertyType.Path, 120, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("demoLength"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 128, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("locatorTypes"), new PropertyInfo(PropertyInfo.PropertyType.Int32, 136, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, typeof(DemoStreamAnimation_LocatorType), PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("cameraTypes"), new PropertyInfo(PropertyInfo.PropertyType.Int32, 184, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, typeof(DemoStreamAnimation_CameraType), PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("modelFiles"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 232, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("helpBoneFiles"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 280, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("partsFiles"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 328, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("coverModelFiles"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 376, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("modelPartsDictionary"), new PropertyInfo(PropertyInfo.PropertyType.String, 424, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("coverModelDictionary"), new PropertyInfo(PropertyInfo.PropertyType.String, 472, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("updateJobCount"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 768, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("modelProxyPaths"), new PropertyInfo(PropertyInfo.PropertyType.Path, 520, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("partsProxyPaths"), new PropertyInfo(PropertyInfo.PropertyType.Path, 568, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("dynamicModel"), new PropertyInfo(PropertyInfo.PropertyType.EntityPtr, 616, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, typeof(Demox.DemoDynamicFileChangeModel), null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("dynamicParts"), new PropertyInfo(PropertyInfo.PropertyType.EntityPtr, 664, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, typeof(Demox.DemoDynamicFileChangeModel), null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("dynamicFv2"), new PropertyInfo(PropertyInfo.PropertyType.EntityPtr, 712, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, typeof(Demox.DemoFv2ResourceMemory), null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public DemoStreamAnimation(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "streamPath":
                    this.streamPath = value.GetValueAsPath();
                    return;
                case "demoLength":
                    this.demoLength = value.GetValueAsUInt32();
                    return;
                case "updateJobCount":
                    this.updateJobCount = value.GetValueAsUInt32();
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
                case "locatorTypes":
                    this.locatorTypes.Add(key, (DemoStreamAnimation_LocatorType)value.GetValueAsInt32());
                    return;
                case "cameraTypes":
                    this.cameraTypes.Add(key, (DemoStreamAnimation_CameraType)value.GetValueAsInt32());
                    return;
                case "modelFiles":
                    this.modelFiles.Add(key, value.GetValueAsFilePtr());
                    return;
                case "helpBoneFiles":
                    this.helpBoneFiles.Add(key, value.GetValueAsFilePtr());
                    return;
                case "partsFiles":
                    this.partsFiles.Add(key, value.GetValueAsFilePtr());
                    return;
                case "coverModelFiles":
                    this.coverModelFiles.Add(key, value.GetValueAsFilePtr());
                    return;
                case "modelPartsDictionary":
                    this.modelPartsDictionary.Add(key, value.GetValueAsString());
                    return;
                case "coverModelDictionary":
                    this.coverModelDictionary.Add(key, value.GetValueAsString());
                    return;
                case "modelProxyPaths":
                    this.modelProxyPaths.Add(key, value.GetValueAsPath());
                    return;
                case "partsProxyPaths":
                    this.partsProxyPaths.Add(key, value.GetValueAsPath());
                    return;
                case "dynamicModel":
                    this.dynamicModel.Add(key, EntityPtr<Demox.DemoDynamicFileChangeModel>.Get(value.GetValueAsEntityPtr().Entity as Demox.DemoDynamicFileChangeModel));
                    return;
                case "dynamicParts":
                    this.dynamicParts.Add(key, EntityPtr<Demox.DemoDynamicFileChangeModel>.Get(value.GetValueAsEntityPtr().Entity as Demox.DemoDynamicFileChangeModel));
                    return;
                case "dynamicFv2":
                    this.dynamicFv2.Add(key, EntityPtr<Demox.DemoFv2ResourceMemory>.Get(value.GetValueAsEntityPtr().Entity as Demox.DemoFv2ResourceMemory));
                    return;
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}