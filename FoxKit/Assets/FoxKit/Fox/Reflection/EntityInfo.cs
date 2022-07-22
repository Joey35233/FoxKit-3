using System;
using System.Collections.Generic;
using System.Reflection;

namespace Fox
{
    /// <summary>
    /// Provides metadata relating to a class. Each class should have a single static instance.
    /// </summary>
    public sealed class EntityInfo
    {
        private static readonly Dictionary<Type, EntityInfo> EntityInfos = new Dictionary<Type, EntityInfo>();

        public static EntityInfo GetEntityInfo<T>()
        {
            return GetEntityInfo(typeof(T));
        }
        public static EntityInfo GetEntityInfo(Type type)
        {
            return EntityInfos.TryGetValue(type, out var entityInfo) ? entityInfo : null;
        }

        public EntityInfo(string name, Type type, EntityInfo super, short id, string category, ushort version)
        {
            Name = name;
            Type = type;
            Super = super;
            Id = id;
            Category = category;
            Version = version;

            Children = new List<EntityInfo>();
            AllChildren = new List<EntityInfo>();

            Super?.Children.Add(this);

            EntityInfo superIterator = Super;
            while (superIterator != null)
            {
                superIterator.AllChildren.Add(this);
                superIterator = superIterator.Super;
            }

            EntityInfos.Add(Type, this);

            LongestNamedProperty = Super?.LongestNamedProperty;
        }

        /// <summary>
        /// Name of the class.
        /// </summary>
        public String Name { get; }

        /// <summary>
        /// Type of the class.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// EntityInfo of the parent class, or null if there is no parent.
        /// </summary>
        public EntityInfo Super { get; }

        /// <summary>
        /// EntityInfos of the immediate children.
        /// </summary>
        public List<EntityInfo> Children { get; private set; }

        /// <summary>
        /// EntityInfos of all descendants.
        /// </summary>
        public List<EntityInfo> AllChildren { get; private set; }

        /// <summary>
        /// ID of the class.
        /// </summary>
        public short Id { get; }

        /// <summary>
        /// Category the class belongs to, or null if there is no category.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Version of the class.
        /// </summary>
        public ushort Version { get; }

        /// <summary>
        /// Metadata for all static properties in their original order.
        /// </summary>
        public Core.DynamicArray<Fox.Core.PropertyInfo> OrderedStaticProperties { get; } = new Core.DynamicArray<Fox.Core.PropertyInfo>();

        /// <summary>
        /// Metadata for all static properties in a StringMap for fast lookup.
        /// </summary>
        public Core.StringMap<Fox.Core.PropertyInfo> StaticProperties { get; } = new Core.StringMap<Fox.Core.PropertyInfo>();

        /// <summary>
        /// PropertyInfo of the property with the longest name.
        /// </summary>
        public Fox.Core.PropertyInfo LongestNamedProperty { get; private set; }

        /// <summary>
        /// Checks if an EntityInfo instance or any of its superclasses contains a property with the given name.
        /// </summary>
        /// <param name="entityInfo">The EntityInfo.</param>
        /// <param name="name">The name of the property to find.</param>
        /// <returns>True if a property with the given name was found, else false.</returns>
        public static bool HasPropertyWithName(EntityInfo entityInfo, String name)
        {
            while (entityInfo != null)
            {
                var foxName = new String(name);
                if (entityInfo.StaticProperties.ContainsKey(foxName))
                {
                    return true;
                }

                entityInfo = entityInfo.Super;
            }

            return false;
        }

        /// <summary>
        /// Adds static property to entityInfo.
        /// </summary>
        /// <param name="propertyInfo">The property's PropertyInfo.</param>
        public void AddStaticProperty(Fox.Core.PropertyInfo propertyInfo)
        {
            OrderedStaticProperties.Add(propertyInfo);
            StaticProperties.Insert(propertyInfo.Name, propertyInfo);

            if (LongestNamedProperty == null)
                LongestNamedProperty = propertyInfo;
            else if (propertyInfo.Name.Length > LongestNamedProperty.Name.Length)
                LongestNamedProperty = propertyInfo;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
