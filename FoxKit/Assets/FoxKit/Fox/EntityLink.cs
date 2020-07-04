namespace Fox
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Stores a reference to an Entity.
    /// </summary>
    [Serializable]
    public readonly struct EntityLink : System.IEquatable<EntityLink>
    {
        /// <summary>
        /// The referenced Entity.
        /// </summary>
        [SerializeField]
        private readonly EntityHandle handle;

        /// <summary>
        /// Path to the referenced Entity's containing package.
        /// </summary>
        [SerializeField]
        private readonly Fox.Path packagePath;

        /// <summary>
        /// Path to the referenced Entity's containing DataSetFile2.
        /// </summary>
        [SerializeField]
        private readonly Fox.Path archivePath;

        /// <summary>
        /// The referenced Entity.
        /// </summary>
        [SerializeField]
        private readonly Fox.String nameInArchive;

        public EntityLink(Entity entity, Fox.Path packagePath, Fox.Path archivePath, Fox.String nameInArchive)
        {
            this.handle = EntityHandle.Get(entity);
            this.packagePath = packagePath;
            this.archivePath = archivePath;
            this.nameInArchive = nameInArchive;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return this.Equals((EntityLink)obj);
        }

        public bool Equals(EntityLink other) => this.handle == other.handle;

        public override int GetHashCode() => handle.GetHashCode();

        public static bool operator ==(EntityLink lhs, EntityLink rhs) => lhs.Equals(rhs);

        public static bool operator !=(EntityLink lhs, EntityLink rhs) => !lhs.Equals(rhs);

        public override string ToString()
        {
            return this.handle.ToString();
        }
    }
}