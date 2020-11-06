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
        public EntityInfo(String name, EntityInfo super, short id, string category, ushort version)
        {
            Name = name;
            Super = super;
            Id = id;
            Category = category;
            Version = version;
        }

        /// <summary>
        /// Name of the class.
        /// </summary>
        public String Name { get; }

        /// <summary>
        /// EntityInfo of the parent class, or null if there is no parent.
        /// </summary>
        public EntityInfo Super { get; }

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
        /// Metadata for all static properties.
        /// </summary>
        public StringMap<PropertyInfo> StaticProperties { get; } = new StringMap<PropertyInfo>();

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
                if (entityInfo.StaticProperties.ContainsKey(name))
                {
                    return true;
                }

                entityInfo = entityInfo.Super;
            }

            return false;
        }

        public override string ToString()
        {
            return this.Name.CString();
        }
    }
}
