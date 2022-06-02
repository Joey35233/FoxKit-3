using System;
using UnityEngine;

namespace Fox.Core
{
    [Serializable]
    public partial class Entity
    {
        /// <summary>
        /// The numeric identifier of the Entity, unique to its DataSet.
        /// </summary>
        public ulong Address { get; }

        /// <summary>
        /// Unknown.
        /// </summary>
        private ulong Id { get; }

        /// <summary>
        /// The Entity's dynamically-added properties.
        /// </summary>
        private StringMap<DynamicProperty> DynamicProperties { get; } = new StringMap<DynamicProperty>();

        public bool AddDynamicProperty(PropertyInfo.PropertyType type, string name, ushort arraySize, PropertyInfo.ContainerType container)
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
        private static bool HasPropertyWithName(Entity entity, string name)
        {
            var hasStaticProperty = EntityInfo.HasPropertyWithName(entity.GetClassEntityInfo(), name);
            if (hasStaticProperty)
            {
                return true;
            }

            var foxName = new String(name);
            return entity.DynamicProperties.ContainsKey(foxName);
        }

        /// <summary>
        /// Called after importing a DataSet. Use to initialize scene data.
        /// </summary>
        /// <param name="gameObject">The assigned GameObject.</param>
        public virtual void InitializeGameObject(GameObject gameObject)
        {

        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: 0x{this.Address:X16}";
        }
    }
}