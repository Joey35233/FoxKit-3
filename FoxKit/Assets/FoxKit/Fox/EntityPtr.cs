namespace Fox
{
    using System;

    /// <summary>
    /// Stores a typed reference to an Entity.
    /// </summary>
    /// <typeparam name="T">The type of the referenced Entity.</typeparam>
    [Serializable]
    public struct EntityPtr<T> : System.IEquatable<EntityPtr<T>> where T : Entity
    {
        /// <summary>
        /// The referenced Entity.
        /// </summary>
        public T Entity;

        private EntityPtr(T entity) => this.Entity = entity;

        /// <summary>
        /// Creates an EntityHandle to a null Entity.
        /// </summary>
        /// <returns>An EntityHandle to a null Entity.</returns>
        public static EntityPtr<T> Empty() => Get(null);

        /// <summary>
        /// Creates an EntityHandle.
        /// </summary>
        /// <param name="entity">The Entity to reference.</param>
        /// <returns>A new EntityHandle.</returns>
        public static EntityPtr<T> Get(T entity) => new EntityPtr<T>(entity);

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return this.Equals((EntityPtr<T>)obj);
        }

        public bool Equals(EntityPtr<T> other) => this.Entity == other.Entity;

        public override int GetHashCode() => Entity?.GetHashCode() ?? 0;

        public static bool operator ==(EntityPtr<T> lhs, EntityPtr<T> rhs) => lhs.Equals(rhs);

        public static bool operator !=(EntityPtr<T> lhs, EntityPtr<T> rhs) => !lhs.Equals(rhs);

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