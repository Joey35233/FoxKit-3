using System;
using UnityEngine;

namespace Fox.Core
{
    [System.Serializable]
    public struct EntityHandle : System.IEquatable<EntityHandle>
    {
        [SerializeReference]
        private Entity _entity;
        public Entity Entity { get => _entity; set { _entity = value; } }

        private EntityHandle(Entity entity)
        {
            this._entity = entity;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return this.Equals((EntityHandle)obj);
        }

        public bool Equals(EntityHandle other) => this.Entity == other.Entity;

        public override int GetHashCode() => Entity.GetHashCode();

        public static bool operator ==(EntityHandle lhs, EntityHandle rhs) => lhs.Equals(rhs);

        public static bool operator !=(EntityHandle lhs, EntityHandle rhs) => !lhs.Equals(rhs);

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
