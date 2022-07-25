using Fox.FoxKernel;

namespace Fox.Core
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Stores a reference to a file.
    /// </summary>
    [Serializable]
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public class FilePtr
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
    {
        [SerializeField]
        public Path path;

        private FilePtr()
        {
            path = Path.Empty;
        }

        public FilePtr(Path path)
        {
            this.path = path;
        }

        public FilePtr(string path)
        {
            this.path = new Path(path);
        }

        public static FilePtr Empty()
        {
            return new FilePtr();
        }

        public static bool operator ==(FilePtr a, FilePtr b)
        {
            return a.path == b.path;
        }

        public static bool operator !=(FilePtr a, FilePtr b)
        {
            return !(a == b);
        }
    }
}