using System;
using UnityEngine;

namespace Fox.Core
{
    [System.Serializable]
    public class EntityHandle
    {
        [SerializeField]
        private FoxEntity entity;

        private EntityHandle(FoxEntity entity)
        {
            this.entity = entity;
        }

        public static EntityHandle Empty()
        {
            return new EntityHandle(null);
        }

        public static EntityHandle Get(FoxEntity entity)
        {
            return new EntityHandle(entity);
        }

        public void Reset(FoxEntity entityGameObject)
        {
            this.entity = entityGameObject;
        }

        public Entity Entity()
        {
            if (entity == null)
                return null;

            return this.entity.Entity;
        }
    }
}
