namespace Fox.Core
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Stores a reference to an Entity.
    /// </summary>
    [Serializable]
    public struct EntityLink : System.IEquatable<EntityLink>
    {
        /// <summary>
        /// The referenced Entity.
        /// </summary>
        private EntityHandle handle;

        /// <summary>
        /// Path to the referenced Entity's containing package.
        /// </summary>
        [SerializeField]
        private Path packagePath;

        /// <summary>
        /// Path to the referenced Entity's containing DataSetFile2.
        /// </summary>
        [SerializeField]
        private Path archivePath;

        /// <summary>
        /// The referenced Entity's name.
        /// </summary>
        [SerializeField]
        private Fox.Core.String nameInArchive;

        public EntityLink(Path packagePath, Path archivePath, Fox.Core.String nameInArchive)
        {
            this.handle = EntityHandle.Empty();
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

        internal static EntityLink Empty()
        {
            return new EntityLink(null, null, null);
        }
    }
}