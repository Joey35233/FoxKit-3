using Fox.Core.Utils;
using Fox;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Fox.Core
{
    [Serializable, DisallowMultipleComponent]
    public partial class Entity : UnityEngine.MonoBehaviour
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        private ulong Id
        {
            get;
        }

        public DynamicProperty AddDynamicProperty(PropertyInfo.PropertyType type, string propertyName, ushort arraySize, PropertyInfo.ContainerType container)
        {
            if (HasPropertyWithName(this, propertyName))
                return null;

            return DynamicPropertyCollector.GetSpecificTypeForDescription(this.gameObject, type, propertyName, container, arraySize);
        }

        /// <summary>
        /// True if this entity should be serialized in a fox2 file on export.
        /// </summary>
        /// <returns></returns>
        public virtual bool ShouldWriteToFox2() => true;

        /// <summary>
        /// Checks if the given Entity has a static or dynamic property with a given name.
        /// </summary>
        /// <param name="entity">The Entity.</param>
        /// <param name="name">The name of the property to find.</param>
        /// <returns>True if a static or dynamic property was found, else false.</returns>
        public static bool HasPropertyWithName(Entity entity, string name)
        {
            bool hasStaticProperty = EntityInfo.HasPropertyWithName(entity.GetClassEntityInfo(), name);
            if (hasStaticProperty)
                return true;
            
            foreach (var dynamicProperty in entity.gameObject.GetComponents<DynamicProperty>())
                if (dynamicProperty.Name == name)
                    return true;

            return false;
        }

        /// <summary>
        /// Called after importing a DataSet. Use to initialize scene data.
        /// </summary>
        public virtual void OnDeserializeEntity(TaskLogger logger)
        {

        }
        
        /// <summary>
        /// Called after OnDeserializeEntity. Use to perform operations that require all DataSet Entities to be fully initialized and enabled.
        /// </summary>
        public virtual void OnPostDeserializeEntity(TaskLogger logger)
        {

        }

        /// <summary>
        /// If a property needs to be converted on export (for instance, Unity to Fox coordinates), add it to the export context.
        /// If a property is not overridden here, its original value will be exported instead.
        /// </summary>
        public virtual void OnSerializeEntity(EntityExportContext context)
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
                foreach (KeyValuePair<string, PropertyInfo> staticProperty in @class.StaticProperties)
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
                        CollectReferencedEntity(GetProperty(property.Name).GetValueAsEntityPtr<Entity>(), alreadyCollectedEntities);
                        break;
                    case PropertyInfo.PropertyType.EntityHandle:
                        CollectReferencedEntity(GetProperty(property.Name).GetValueAsEntityHandle(), alreadyCollectedEntities);
                        break;
                    case PropertyInfo.PropertyType.EntityLink:
                        CollectReferencedEntity(GetProperty(property.Name).GetValueAsEntityLink().handle, alreadyCollectedEntities);
                        break;
                }

                return;
            }
            else if (property.Container == PropertyInfo.ContainerType.StringMap)
            {
                IStringMap list = GetProperty(property.Name).GetValueAsIStringMap();
                foreach (KeyValuePair<string, object> item in list.ToList())
                {
                    switch (property.Type)
                    {
                        case PropertyInfo.PropertyType.EntityPtr:
                            CollectReferencedEntity((Entity)item.Value, alreadyCollectedEntities);
                            break;
                        case PropertyInfo.PropertyType.EntityHandle:
                            CollectReferencedEntity((Entity)item.Value, alreadyCollectedEntities);
                            break;
                        case PropertyInfo.PropertyType.EntityLink:
                            CollectReferencedEntity(((EntityLink)item.Value).handle, alreadyCollectedEntities);
                            break;
                    }
                }
            }
            else
            {
                var list = GetProperty(property.Name).GetValueAsIList();
                foreach (object item in list)
                {
                    switch (property.Type)
                    {
                        case PropertyInfo.PropertyType.EntityPtr:
                            CollectReferencedEntity((Entity)item, alreadyCollectedEntities);
                            break;
                        case PropertyInfo.PropertyType.EntityHandle:
                            CollectReferencedEntity((Entity)item, alreadyCollectedEntities);
                            break;
                        case PropertyInfo.PropertyType.EntityLink:
                            CollectReferencedEntity(((EntityLink)item).handle, alreadyCollectedEntities);
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

        public virtual string GenerateUniqueName(Type type, HashSet<string> invalidNames)
        {
            var index = 0;
            while (true)
            {
                var workingName = type.Name + index.ToString("D4");
                if (!invalidNames.Contains(workingName))
                {
                    return workingName;
                }

                index++;
            }
        }

        public override string ToString() => $"{GetType().Name}";

        public virtual void Reset() { }
    }
}