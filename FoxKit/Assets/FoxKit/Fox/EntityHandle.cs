namespace Fox
{
    using System;

    /// <summary>
    /// Stores a shared reference to an Entity.
    /// </summary>
    [Serializable]
    public readonly struct EntityHandle : System.IEquatable<EntityHandle>
    {
        /// <summary>
        /// The referenced Entity.
        /// </summary>
        public Entity Entity { get; }

        private EntityHandle(Entity entity) => this.Entity = entity;

        /// <summary>
        /// Creates an EntityHandle to a null Entity.
        /// </summary>
        /// <returns>An EntityHandle to a null Entity.</returns>
        public static EntityHandle Empty() => Get(null);

        /// <summary>
        /// Creates an EntityHandle.
        /// </summary>
        /// <param name="entity">The Entity to reference.</param>
        /// <returns>A new EntityHandle.</returns>
        public static EntityHandle Get(Entity entity) => new EntityHandle(entity);

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (!(obj is EntityHandle))
            {
                return false;
            }

            return this.Equals((EntityHandle)obj);
        }

        public bool Equals(EntityHandle other) => this.Entity == other.Entity;

        public override int GetHashCode() => Entity?.GetHashCode() ?? 0;

        public static bool operator ==(EntityHandle lhs, EntityHandle rhs) => lhs.Equals(rhs);

        public static bool operator !=(EntityHandle lhs, EntityHandle rhs) => !lhs.Equals(rhs);

        public override string ToString()
        {
            if (this.Entity == null)
            {
                return "null";
            }

            return this.Entity.ToString();
        }
    }
}