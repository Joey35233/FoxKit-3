namespace Fox
{
    using Value = System.Int16;

    public partial class DataSet : Data
    {
        // Properties
        public StringMap<EntityPtr<Data>> dataList { get; } = new StringMap<EntityPtr<Data>>();

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
        static DataSet()
        {
            classInfo = new EntityInfo(new Fox.String("DataSet"), Data.ClassInfo, 232, null, 0);

            classInfo.StaticProperties.Insert(new Fox.String("dataList"), new PropertyInfo(PropertyInfo.PropertyType.EntityPtr, 120, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, typeof(Fox.Data), null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
        public DataSet()
        {

        }

        // Getters and setters
        public override void SetProperty(Fox.String propertyName, Value value)
        {
            switch (propertyName.Hash)
            {
                default:

                    base.SetProperty(propertyName, value);
                    return;
            }
        }

        public override void SetPropertyElement(Fox.String propertyName, ushort index, Value value)
        {
            switch (propertyName.CString)
            {
                default:

                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }

        public override void SetPropertyElement(Fox.String propertyName, Fox.String key, Value value)
        {
            switch (propertyName.Hash)
            {
                case Hashing.StrCode(""):
                    this.dataList.Insert(key, EntityPtr<Fox.Data>.Get(value.GetValueAsEntityPtr().Entity as FoxCore.Data));
                    return;
                default:

                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}