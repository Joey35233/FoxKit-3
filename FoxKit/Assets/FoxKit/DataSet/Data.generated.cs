namespace Fox
{
    using Value = System.Int16;

    public partial class Data : Entity
    {
        // Properties
        public String name { get; set; }

        public EntityHandle dataSet { get; set; }

        public String referencePath { get; set; }

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
        static Data()
        {
            classInfo = new EntityInfo(new String("Data"), Entity.ClassInfo, -1, null, 2);

            classInfo.StaticProperties.Insert(new String("name"), new PropertyInfo(PropertyInfo.PropertyType.String, 72, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
            classInfo.StaticProperties.Insert(new String("dataSet"), new PropertyInfo(PropertyInfo.PropertyType.EntityHandle, 80, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
            classInfo.StaticProperties.Insert(new String("referencePath"), new PropertyInfo(PropertyInfo.PropertyType.String, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
        public Data()
        {

        }
    }
}