using System;
using UnityEngine;

namespace Fox.Core
{
    [System.Serializable]
    public class EntityHandle
    {
        [SerializeReference]
        private Entity _entity;
        public Entity Entity { get => _entity; }

        private EntityHandle(Entity entity)
        {
            this._entity = entity;
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
            _entity = entity;
        }
    }
}
