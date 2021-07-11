using System;
using UnityEngine;

namespace Fox.Core
{
    [System.Serializable]
    public class EntityHandle
    {
        [SerializeReference]
        private Entity entity;

        private EntityHandle(Entity entity)
        {
            this.entity = entity;
        }

        public static EntityHandle Empty()
        {
            return new EntityHandle(null);
        }

        public static EntityHandle Get(Entity entity)
        {
            return new EntityHandle(entity);
        }

        public Entity Entity()
        {
            return this.entity;
        }
    }
}
