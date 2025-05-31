using System;
using System.Collections.Generic;
using System.Reflection;
using Fox.Core;
using UnityEditor;
using UnityEngine;

namespace Fox.EdCore
{
    public enum BuildBodyOverrideBehavior
    {
        SpecificClassOverride,
        ChildrenOverride,
    }
    
    public struct CustomEntityFieldDesc
    {
        public Func<IEntityField> Constructor;
        public BuildBodyOverrideBehavior BodyOverrideBehavior;
        public Action<EntityFieldBuildContext> BuildHeader;
        public Action<EntityFieldBuildContext> BuildBody;
        public Action<EntityFieldBuildContext> BuildFooter;
    }
    
    [InitializeOnLoad]
    public static class EntityEditorManager
    {
        private static Dictionary<EntityInfo, CustomEntityFieldDesc> Map = new Dictionary<EntityInfo, CustomEntityFieldDesc>();

        static EntityEditorManager()
        {
            var customEntityFieldTypes = TypeCache.GetTypesWithAttribute<CustomEntityInspector>();
            foreach (Type fieldType in customEntityFieldTypes)
            {
                if (fieldType.TypeInitializer.IsStatic)
                    fieldType.TypeInitializer.Invoke(null, null);
                else
                    Debug.Log($"Custom field for Entity {fieldType.Name} does not have a static constructor.");
            }
        }
        
        public static void Register(EntityInfo entityInfo, CustomEntityFieldDesc desc)
        {
            if (!Map.TryAdd(entityInfo, desc))
            {
            }
        }
        
        public static CustomEntityFieldDesc? Get(EntityInfo entityInfo)
        {
            if (Map.TryGetValue(entityInfo, out CustomEntityFieldDesc desc))
                return desc;
            else
                return null;
        }
    }
}