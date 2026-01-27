using Fox;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Fox.Core
{
    /// <summary>
    /// Stores a reference to a file.
    /// </summary>
    [Serializable]
    public class FilePtr
    {
        protected bool Equals(FilePtr other)
        {
            return path == other.path;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FilePtr)obj);
        }

        public override int GetHashCode()
        {
            return path.GetHashCode();
        }

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

        public AsyncOperationHandle<T> LoadAsync<T>() where T : class
        {
            var handle = Addressables.LoadAssetAsync<T>(path.String);
            return handle;
        }

        public static FilePtr Empty => new();

        public static bool operator ==(FilePtr a, FilePtr b) => a.path == b.path;

        public static bool operator !=(FilePtr a, FilePtr b) => !(a == b);

        public override string ToString() => path.ToString();
    }
}