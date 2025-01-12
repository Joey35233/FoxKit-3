using System;
using System.Collections.Generic;
using Fox.Core;
using UnityEditor;

namespace Fox.EdCore
{
    public class CustomEntityField : Attribute
    {
        
    }

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
    public static class CustomEntityFieldManager
    {
        private static Dictionary<EntityInfo, CustomEntityFieldDesc> Map = new Dictionary<EntityInfo, CustomEntityFieldDesc>();

        static CustomEntityFieldManager()
        {
            var customEntityFieldTypes = TypeCache.GetTypesWithAttribute<CustomEntityField>();
            foreach (var fieldType in customEntityFieldTypes)
            {
                if (fieldType.TypeInitializer.IsStatic)
                    fieldType.TypeInitializer.Invoke(null, null);
            }
        }
        
        public static void Register(EntityInfo entityInfo, CustomEntityFieldDesc desc)
        {
            if (!Map.TryAdd(entityInfo, desc))
                return;
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