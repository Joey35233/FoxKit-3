using Fox.Kernel;
using System;
using System.Reflection;
using UnityEngine;
using String = Fox.Kernel.String;

namespace Fox.Core
{
    [Serializable]
    public partial class Entity
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        private ulong Id
        {
            get;
        }

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

            var propertyInfo = new PropertyInfo(name, type, 0, arraySize, container);
            DynamicProperties.Insert(name, new DynamicProperty(propertyInfo));
            return true;
        }

        /// <summary>
        /// True if this entity should be serialized in a fox2 file on export.
        /// </summary>
        /// <returns></returns>
        public virtual bool ShouldWriteToFox2() => true;

        /// <summary>
        /// Perform any property updates needed before exporting.
        /// </summary>
        public virtual void PrepareForExport()
        {
        }

        /// <summary>
        /// Checks if the given Entity has a static or dynamic property with a given name.
        /// </summary>
        /// <param name="entity">The Entity.</param>
        /// <param name="name">The name of the property to find.</param>
        /// <returns>True if a static or dynamic property was found, else false.</returns>
        private static bool HasPropertyWithName(Entity entity, String name)
        {
            bool hasStaticProperty = EntityInfo.HasPropertyWithName(entity.GetClassEntityInfo(), name);
            return hasStaticProperty || entity.DynamicProperties.ContainsKey(name);
        }

        /// <summary>
        /// Called after importing a DataSet. Use to initialize scene data.
        /// </summary>
        /// <param name="gameObject">The assigned GameObject.</param>
        public virtual void InitializeGameObject(GameObject gameObject)
        {

        }

        /// <summary>
        /// TODO: Do this through classgen
        /// </summary>
        public T GetProperty<T>(PropertyInfo property)
        {
            System.Reflection.PropertyInfo propInfo = this.GetType().GetProperty(property.Name.CString, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return (T)propInfo.GetValue(this, null);
        }

        public override string ToString() => $"{GetType().Name}";
    }
}