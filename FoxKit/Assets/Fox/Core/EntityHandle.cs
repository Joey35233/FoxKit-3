using UnityEngine;

namespace Fox.Core
{
    // [System.Serializable]
    // public struct EntityHandle : System.IEquatable<EntityHandle>
    // {
    //     [SerializeReference]
    //     private Entity _entity;
    //     public Entity Entity
    //     {
    //         get => _entity; set => _entity = value;
    //     }
    //
    //     private EntityHandle(Entity entity)
    //     {
    //         _entity = entity;
    //     }
    //
    //     public override bool Equals(object obj) => obj is not null && Equals((EntityHandle)obj);
    //
    //     public bool Equals(EntityHandle other) => Entity == other.Entity;
    //
    //     public override int GetHashCode() => Entity.GetHashCode();
    //
    //     public static bool operator ==(EntityHandle lhs, EntityHandle rhs) => lhs.Equals(rhs);
    //
    //     public static bool operator !=(EntityHandle lhs, EntityHandle rhs) => !lhs.Equals(rhs);
    //
    //     public static EntityHandle Empty => new(null);
    //
    //     public static Entity entity) => new(entity;
    //
    //     public void Reset(Entity entity) => _entity = entity;
    // }
}
