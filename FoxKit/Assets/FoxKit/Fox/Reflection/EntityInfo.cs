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

            //if (super == null)
            //    UnityEngine.Debug.Log($"{name}.Super == null");
            Super?.Children.Add(this);

            EntityInfo superIterator = Super;
            while (superIterator != null)
            {
                superIterator.AllChildren.Add(this);
                superIterator = superIterator.Super;
            }

            EntityInfos.Add(Type, this);
        }

        /// <summary>
        /// Name of the class.
        /// </summary>
        public string Name { get; }

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
        /// Metadata for all static properties.
        /// </summary>
        public Core.StringMap<Fox.Core.PropertyInfo> StaticProperties { get; } = new Core.StringMap<Fox.Core.PropertyInfo>();

        /// <summary>
        /// Checks if an EntityInfo instance or any of its superclasses contains a property with the given name.
        /// </summary>
        /// <param name="entityInfo">The EntityInfo.</param>
        /// <param name="name">The name of the property to find.</param>
        /// <returns>True if a property with the given name was found, else false.</returns>
        public static bool HasPropertyWithName(EntityInfo entityInfo, string name)
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

        public override string ToString()
        {
            return this.Name;
        }
    }
}
