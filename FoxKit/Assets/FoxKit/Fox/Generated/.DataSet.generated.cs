namespace Fox
{
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
        public override void SetProperty<T>(String propertyName, Value<T> value)
        {
            switch (propertyName.CString())
            {
                default:

                    base.SetProperty(propertyName, value);
                    return;
            }
        }

        public override void SetPropertyElement<T>(String propertyName, ushort index, Value<T> value)
        {
            switch (propertyName.CString())
            {
                default:

                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }

        public override void SetPropertyElement<T>(String propertyName, String key, Value<T> value)
        {
            switch (propertyName.CString())
            {
                case "dataList":
                    this.dataList.Add(key, EntityPtr<FoxCore.Data>.Get(value.GetValueAsEntityPtr().Entity as FoxCore.Data));
                    return;
                default:

                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}