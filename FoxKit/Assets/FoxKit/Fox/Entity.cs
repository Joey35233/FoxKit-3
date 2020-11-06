namespace Fox
{
    public partial class Entity
    {
        /// <summary>
        /// The numeric identifier of the Entity, unique to its DataSet.
        /// </summary>
        public ulong Address { get; }

        /// <summary>
        /// Unknown.
        /// </summary>
        private ushort IdA { get; }

        /// <summary>
        /// Unknown.
        /// </summary>
        private ushort IdB { get; }

        /// <summary>
        /// The Entity's dynamically-added properties.
        /// </summary>
        private StringMap<DynamicProperty> DynamicProperties { get; } = new StringMap<DynamicProperty>();

        public bool AddDynamicProperty(PropertyInfo.PropertyType type, String name, ushort arraySize, PropertyInfo.ContainerType container)
        {
            if (HasPropertyWithName(this, name))
            {
                return false;
            }

            var propertyInfo = new PropertyInfo(type, 0, arraySize, container);
            this.DynamicProperties.Insert(name, new DynamicProperty(propertyInfo));
            return true;
        }

        /// <summary>
        /// Checks if the given Entity has a static or dynamic property with a given name.
        /// </summary>
        /// <param name="entity">The Entity.</param>
        /// <param name="name">The name of the property to find.</param>
        /// <returns>True if a static or dynamic property was found, else false.</returns>
        private static bool HasPropertyWithName(Entity entity, Fox.String name)
        {
            var hasStaticProperty = EntityInfo.HasPropertyWithName(entity.GetClassEntityInfo(), name);
            if (hasStaticProperty)
            {
                return true;
            }

            return entity.DynamicProperties.ContainsKey(name);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: 0x{this.Address:X16}";
        }
    }
}