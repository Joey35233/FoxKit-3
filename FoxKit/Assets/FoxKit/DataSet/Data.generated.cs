namespace Fox
{
    using BaseClass = Entity;

    class Data : BaseClass
    {
        private static EntityInfo entityInfo;

        static Data()
        {
            entityInfo = new EntityInfo(new String("Data"), BaseClass.GetClassEntityInfo(), -1, null, 2);

            entityInfo.StaticProperties.Insert(new String("name"), new PropertyInfo(PropertyInfo.PropertyType.String, 72, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
            entityInfo.StaticProperties.Insert(new String("dataSet"), new PropertyInfo(PropertyInfo.PropertyType.EntityHandle, 80, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
            entityInfo.StaticProperties.Insert(new String("referencePath"), new PropertyInfo(PropertyInfo.PropertyType.String, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        public static new EntityInfo GetClassEntityInfo()
        {
            return entityInfo;
        }

        [Category("Data")]
        public String name { get; set; }

        [Category("Data")]
        public EntityHandle dataSet { get; set; }

        [Category("Data")]
        public String referencePath { get; set; }

        public Data()
        {

        }
    }
}