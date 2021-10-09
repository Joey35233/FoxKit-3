using System;
using UnityEngine;

namespace Fox.Core
{
    [System.Serializable]
    public class EntityHandle
    {
        [SerializeReference]
        private GameObject entity;

        private EntityHandle(Entity entity)
        {
            this.entity = new GameObject();
            this.entity.AddComponent<FoxEntity>().Entity = entity;
        }

        public static EntityHandle Empty()
        {
            return new EntityHandle(null);
        }

        public static EntityHandle Get(Entity entity)
        {
            return new EntityHandle(entity);
        }

        public void Reset(Entity entity)
        {
            this.entity.GetComponent<FoxEntity>().Entity = entity;
        }

        public Entity Entity()
        {
            if (entity is null)
                return null;

            return entity.GetComponent<FoxEntity>().Entity;
        }
    }
}
