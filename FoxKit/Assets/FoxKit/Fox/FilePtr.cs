namespace Fox
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Stores a typed reference to a file.
    /// </summary>
    /// <typeparam name="T">The type of the referenced file.</typeparam>
    [Serializable]
    public struct FilePtr<T> : System.IEquatable<FilePtr<T>> where T : File
    {
        /// <summary>
        /// The referenced file.
        /// </summary>
        [SerializeField]
        private T file;

        public FilePtr(T file) => this.file = file;

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return this.Equals((FilePtr<T>)obj);
        }

        public bool Equals(FilePtr<T> other) => this.file == other.file;

        public override int GetHashCode() => file.GetHashCode();

        public static bool operator ==(FilePtr<T> lhs, FilePtr<T> rhs) => lhs.Equals(rhs);

        public static bool operator !=(FilePtr<T> lhs, FilePtr<T> rhs) => !lhs.Equals(rhs);

        public override string ToString()
        {
            if (this.file == null)
            {
                return "NULL FILEPTR";
            }

            return this.file.ToString();
        }
    }
}