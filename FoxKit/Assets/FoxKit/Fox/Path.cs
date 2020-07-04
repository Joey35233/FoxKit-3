namespace Fox
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Stores the path to a file.
    /// </summary>
    [Serializable]
    public readonly struct Path : System.IEquatable<Path>
    {
        /// <summary>
        /// The file path.
        /// </summary>
        [SerializeField]
        private readonly string path;

        /// <summary>
        /// PathFileNameAndExtCode of the path.
        /// </summary>
        [SerializeField]
        private readonly ulong hash;

        /// <summary>
        /// The empty path.
        /// </summary>
        public static Path Empty { get; }

        /// <summary>
        /// The normal hashing algorithm doesn't working on the emptry string due to lacking a period, so Fox Engine uses the StrCode hash of the empty string.
        /// </summary>
        private const ulong EmptyPathHash = 203000540209048;

        static Path()
        {
            Empty = new Path(string.Empty, EmptyPathHash);
        }

        /// <summary>
        /// Creates a new Path.
        /// </summary>
        /// <param name="filePath">The file path to reference.</param>
        private Path(string filePath)
        {
            this.path = filePath;
            this.hash = Hashing.PathFileNameAndExtCode(filePath);
        }

        /// <summary>
        /// Creates a new Path.
        /// </summary>
        /// <param name="filePath">The file path to reference.</param>
        /// <param name="hash">The precomputed PathFileNameAndExtCode hash to use.</param>
        private Path(string filePath, ulong hash)
        {
            this.path = filePath;
            this.hash = hash;
        }

        public static Path FromFilePath(string filePath)
        {
            return new Path(filePath);
        }

        /// <summary>
        /// Gets the file extension.
        /// </summary>
        /// <remarks>
        /// If the FilePath is not a valid path, the empty string will be returned.
        /// In addition, if there are multiple extensions (e.g., Assets/foo.fox2.xml), everything after the first dot will be returned.
        /// </remarks>
        /// <returns>The extension of the referenced file, not including the leading dot.</returns>
        public string Extension()
        {
            var dotIndex = path.IndexOf('.');
            if (dotIndex == -1)
            {
                return string.Empty;
            }

            return path.Substring(dotIndex + 1);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return this.Equals((Path)obj);
        }

        public static bool operator ==(Path lhs, Path rhs) => lhs.Equals(rhs);

        public static bool operator !=(Path lhs, Path rhs) => !lhs.Equals(rhs);

        public bool Equals(Path other)
        {
            return this.hash == other.hash;
        }

        public override int GetHashCode()
        {
            return (int)this.hash;
        }

        public override string ToString()
        {
            return $"<{this.path}, {string.Format("0x{0:x8}", this.hash)}>";
        }
    }
}