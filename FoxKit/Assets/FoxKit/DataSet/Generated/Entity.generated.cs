namespace Fox
{
    using Value = System.Int16;

    public partial class Entity
    {
        // PropertyInfo
        private static EntityInfo classInfo;
        public static EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public virtual EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static Entity()
        {
            classInfo = new EntityInfo(new String("Entity"), null, -1, null, 2);
        }

        // Constructor
        public Entity()
        {

        }

        // Getters and setters
        public virtual void SetProperty(Fox.String propertyName, Value value)
        {
            switch (propertyName.Hash)
            {
                default:

                    base.SetProperty(propertyName, value);
                    return;
            }
        }

        public virtual void SetPropertyElement(Fox.String propertyName, ushort index, Value value)
        {
            switch (propertyName.CString)
            {
                default:

                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }

        public virtual void SetPropertyElement(Fox.String propertyName, Fox.String key, Value value)
        {
            switch (propertyName.CString)
            {
                case Hashing.StrCode32("dataList"):
                    this.dataList.Add(key, EntityPtr<Fox.Data>.Get(value.GetValueAsEntityPtr().Entity as FoxCore.Data));
                    return;
                default:

                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}