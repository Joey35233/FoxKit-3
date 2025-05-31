using System;
using System.Collections.Generic;
using System.Reflection;
using Fox.Core;
using UnityEditor;
using UnityEngine;

namespace Fox.EdCore
{
    public struct CustomEntityInspectorDesc
    {
        public Func<Entity, EntityInspector2<Entity>> Constructor;
        
        public bool OverridesHeader;
        public bool OverridesBody;
        public BuildBodyOverrideBehavior BodyOverrideBehavior;
        public bool OverridesFooter;
    }
    
    [InitializeOnLoad]
    public static class EntityInspectorManager2
    {
        private static Dictionary<EntityInfo, CustomEntityInspectorDesc> Map = new Dictionary<EntityInfo, CustomEntityInspectorDesc>();

        static EntityInspectorManager2()
        {
            var customEntityFieldTypes = TypeCache.GetTypesWithAttribute<CustomEntityInspector2>();
            foreach (Type fieldType in customEntityFieldTypes)
            {
                CustomEntityInspector2 attribute = fieldType.GetCustomAttribute<CustomEntityInspector2>();
                
                // Func<Entity, EntityInspector2<Entity>> constructor = (Entity x) => Activator.CreateInstance<Entity>(fieldType, new object[] { attribute });
                
                CustomEntityInspectorDesc desc = new CustomEntityInspectorDesc
                {
                    OverridesHeader = attribute.OverridesHeader,
                    OverridesBody = attribute.OverridesBody,
                    BodyOverrideBehavior = attribute.BuildBodyOverrideBehavior,
                    OverridesFooter = attribute.OverridesFooter,
                };

                if (fieldType.TypeInitializer.IsStatic)
                    fieldType.TypeInitializer.Invoke(null, null);
                else
                    Debug.Log($"Custom field for Entity {fieldType.Name} does not have a static constructor.");
            }
        }
        
        public static CustomEntityInspectorDesc? Get(EntityInfo entityInfo)
        {
            if (Map.TryGetValue(entityInfo, out CustomEntityInspectorDesc desc))
                return desc;
            else
                return null;
        }
    }
}