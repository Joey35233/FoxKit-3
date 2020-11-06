namespace Fox
{
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
        public virtual void SetProperty<T>(String propertyName, Value<T> value)
        {
            switch (propertyName.CString())
            {
                default:
                    if (this.DynamicProperties.TryGetValue(propertyName, out DynamicProperty property))
                    {
                        property.SetValue(value);
                        return;
                    }
                    throw new System.MissingMemberException("Unrecognized property", propertyName.CString());
                    return;
            }
        }

        public virtual void SetPropertyElement<T>(String propertyName, ushort index, Value<T> value)
        {
            switch (propertyName.CString())
            {
                default:
                    if (this.DynamicProperties.TryGetValue(propertyName, out DynamicProperty property))
                    {
                        property.SetElement(index, value);
                        return;
                    }
                    throw new System.MissingMemberException("Unrecognized property", propertyName.CString());
                    return;
            }
        }

        public virtual void SetPropertyElement<T>(String propertyName, String key, Value<T> value)
        {
            switch (propertyName.CString())
            {
                default:
                    if (this.DynamicProperties.TryGetValue(propertyName, out DynamicProperty property))
                    {
                        property.SetElement(key, value);
                        return;
                    }
                    throw new System.MissingMemberException("Unrecognized property", propertyName.CString());
                    return;
            }
        }
    }
}