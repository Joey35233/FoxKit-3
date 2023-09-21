using Fox.Kernel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using String = Fox.Kernel.String;

namespace Fox.Core
{
    [Serializable]
    public partial class Entity : UnityEngine.MonoBehaviour
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
            // TODO Sorry this is ugly but there are two "name" properties due to inheriting from MonoBehaviour
            if (property.Name == "name")
            {
                if (!(this is Data))
                {
                    return (T)(object)new String($"NO NAME FOXKIT ERROR {UnityEngine.Random.Range(Int32.MinValue, Int32.MaxValue)}");
                }
                return (T)(object)(this as Data).name;
            }
            // Same here
            else if (property.Name == "transform")
            {
                return (T)(object)(this as TransformData).transform;
            }

            System.Reflection.PropertyInfo propInfo = this.GetType().GetProperty(property.Name.CString, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return (T)propInfo.GetValue(this, null);
        }

        /// <summary>
        /// If a property needs to be converted on export (for instance, Unity to Fox coordinates), add it to the export context.
        /// If a property is not overridden here, its original value will be exported instead.
        /// </summary>
        public virtual void OverridePropertiesForExport(EntityExportContext context)
        {
        }

        public void CollectReferencedEntities(HashSet<Entity> alreadyCollectedEntities)
        {
            EntityInfo current = this.GetClassEntityInfo();
            var superClasses = new List<EntityInfo>();
            superClasses.Add(this.GetClassEntityInfo());
            while (true)
            {
                if (current.Super == null)
                {
                    break;
                }

                superClasses.Add(current.Super);
                current = current.Super;
            }

            foreach (EntityInfo @class in superClasses)
            {
                foreach (KeyValuePair<String, PropertyInfo> staticProperty in @class.StaticProperties)
                {
                    if (staticProperty.Value.Offset == 0)
                    {
                        continue;
                    }

                    if (staticProperty.Value.Type == PropertyInfo.PropertyType.EntityPtr
                        || staticProperty.Value.Type == PropertyInfo.PropertyType.EntityHandle
                        || staticProperty.Value.Type == PropertyInfo.PropertyType.EntityLink)
                    {
                        CollectReferencedEntities(staticProperty.Value, alreadyCollectedEntities);
                    }
                }
            }
        }

        private void CollectReferencedEntities(PropertyInfo property, HashSet<Entity> alreadyCollectedEntities)
        {
            if (property.Container == PropertyInfo.ContainerType.StaticArray && property.ArraySize == 1)
            {
                switch (property.Type)
                {
                    case PropertyInfo.PropertyType.EntityPtr:
                        CollectReferencedEntity(GetProperty<IEntityPtr>(property).Get(), alreadyCollectedEntities);
                        break;
                    case PropertyInfo.PropertyType.EntityHandle:
                        CollectReferencedEntity(GetProperty<EntityHandle>(property).Entity, alreadyCollectedEntities);
                        break;
                    case PropertyInfo.PropertyType.EntityLink:
                        CollectReferencedEntity(GetProperty<EntityLink>(property).handle.Entity, alreadyCollectedEntities);
                        break;
                }

                return;
            }
            else if (property.Container == PropertyInfo.ContainerType.StringMap)
            {
                var list = GetProperty<IStringMap>(property).ToList();
                foreach (KeyValuePair<Kernel.String, object> item in list)
                {
                    switch (property.Type)
                    {
                        case PropertyInfo.PropertyType.EntityPtr:
                            CollectReferencedEntity(((IEntityPtr)item.Value).Get(), alreadyCollectedEntities);
                            break;
                        case PropertyInfo.PropertyType.EntityHandle:
                            CollectReferencedEntity(((EntityHandle)item.Value).Entity, alreadyCollectedEntities);
                            break;
                        case PropertyInfo.PropertyType.EntityLink:
                            CollectReferencedEntity(((EntityLink)item.Value).handle.Entity, alreadyCollectedEntities);
                            break;
                    }
                }
            }
            else
            {
                IList list = GetProperty<IList>(property);
                foreach (object item in list)
                {
                    switch (property.Type)
                    {
                        case PropertyInfo.PropertyType.EntityPtr:
                            CollectReferencedEntity(((IEntityPtr)item).Get(), alreadyCollectedEntities);
                            break;
                        case PropertyInfo.PropertyType.EntityHandle:
                            CollectReferencedEntity(((EntityHandle)item).Entity, alreadyCollectedEntities);
                            break;
                        case PropertyInfo.PropertyType.EntityLink:
                            CollectReferencedEntity(((EntityLink)item).handle.Entity, alreadyCollectedEntities);
                            break;
                    }
                }
            }
        }

        private void CollectReferencedEntity(Entity entity, HashSet<Entity> alreadyCollectedEntities)
        {
            if (entity == null)
            {
                return;
            }

            if (alreadyCollectedEntities.Contains(entity))
            {
                return;
            }

            _ = alreadyCollectedEntities.Add(entity);
            entity.CollectReferencedEntities(alreadyCollectedEntities);
        }

        public override string ToString() => $"{GetType().Name}";
    }
}