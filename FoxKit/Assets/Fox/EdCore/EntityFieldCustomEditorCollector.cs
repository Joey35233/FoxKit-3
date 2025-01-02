using System;
using System.Collections.Generic;
using Fox.Core;

namespace Fox.EdCore
{
    public static class EntityFieldCustomEditorCollector
    {
        private static Dictionary<EntityInfo, Func<IEntityField>> FieldMap = new Dictionary<EntityInfo, Func<IEntityField>>();
        
        public static void Register(EntityInfo entityInfo, Func<IEntityField> constructor)
        {
            FieldMap.Add(entityInfo, constructor);
        }
        
        public static Func<IEntityField> Get(EntityInfo entityInfo)
        {
            if (FieldMap.TryGetValue(entityInfo, out Func<IEntityField> constructor))
                return constructor;
            else
                return null;
        }
    }
}