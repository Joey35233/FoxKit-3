namespace Fox
{
    using BaseClass = Data;
    using Value = System.Int16;

    class DataSet : BaseClass
    {
        private static EntityInfo entityInfo;

        static DataSet()
        {
            entityInfo = new EntityInfo(new String("DataSet"), BaseClass.GetClassEntityInfo(), 232, null, 0);

            entityInfo.StaticProperties.Insert(new String("dataList"), new PropertyInfo(PropertyInfo.PropertyType.EntityPtr, 120, 1, PropertyInfo.ContainerType.StringMap, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, typeof(FoxCore.Data), null, PropertyInfo.PropertyStorage.Instance));
        }

        public static new EntityInfo GetClassEntityInfo()
        {
            return entityInfo;
        }

        public StringMap<EntityPtr<Data>> dataList { get; } = new StringMap<EntityPtr<Data>>();

        public DataSet()
        {

        }

        public override void SetProperty(String propertyName, Value value)
        {
            switch (propertyName.Hash)
            {
                default:

                    base.SetProperty(propertyName, value);
                    return;
            }
        }

        public override void SetPropertyElement(Fox.FoxKernel.String propertyName, ushort index, Value value)
        {
            switch (propertyName.CString)
            {
                default:

                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }

        public override void SetPropertyElement(String propertyName, String key, Value value)
        {
            switch (propertyName.CString)
            {
                case Hashing.StrCode32("dataList"):
                    this.dataList.Add(key, EntityPtr<FoxCore.Data>.Get(value.GetValueAsEntityPtr().Entity as FoxCore.Data));
                    return;
                default:

                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}