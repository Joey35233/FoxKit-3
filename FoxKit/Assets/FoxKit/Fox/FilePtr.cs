using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.Core
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Stores a typed reference to a file.
    /// </summary>
    /// <typeparam name="T">The type of the referenced file.</typeparam>
    [Serializable]
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public class FilePtr<T> where T : File
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

        public static FilePtr<T> Empty()
        {
            return new FilePtr<T>();
        }

        public static bool operator ==(FilePtr<T> a, FilePtr<T> b)
        {
            return a.path == b.path;
        }

        public static bool operator !=(FilePtr<T> a, FilePtr<T> b)
        {
            return !(a == b);
        }
    }
}