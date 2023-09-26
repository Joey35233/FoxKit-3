using Fox.Kernel;
using System;
using UnityEngine;
using String = Fox.Kernel.String;

namespace Fox.Core
{

    /// <summary>
    /// Stores a reference to an Entity.
    /// </summary>
    [Serializable]
    public struct EntityLink : System.IEquatable<EntityLink>
    {
        /// <summary>
        /// The referenced Entity.
        /// </summary>
        [SerializeField]
        public Entity handle;

        /// <summary>
        /// Path to the referenced Entity's containing package.
        /// </summary>
        [SerializeField]
        public Path packagePath;

        /// <summary>
        /// Path to the referenced Entity's containing DataSetFile2.
        /// </summary>
        [SerializeField]
        public Path archivePath;

        /// <summary>
        /// The referenced Entity's name.
        /// </summary>
        [SerializeField]
        public String nameInArchive;

        public EntityLink(Entity handle, Path packagePath, Path archivePath, String nameInArchive)
        {
            this.handle = handle;
            this.packagePath = packagePath;
            this.archivePath = archivePath;
            this.nameInArchive = nameInArchive;
        }

        public override bool Equals(object obj) => obj is not null && Equals((EntityLink)obj);

        public bool Equals(EntityLink other) => handle == other.handle;

        public override int GetHashCode() => handle.GetHashCode();

        public static bool operator ==(EntityLink lhs, EntityLink rhs) => lhs.Equals(rhs);

        public static bool operator !=(EntityLink lhs, EntityLink rhs) => !lhs.Equals(rhs);

        public override string ToString() => handle.ToString();

        internal static EntityLink Empty() => new(null, null, null, null);
    }
}