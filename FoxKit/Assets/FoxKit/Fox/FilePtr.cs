namespace Fox.Core
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Stores a typed reference to a file.
    /// </summary>
    /// <typeparam name="T">The type of the referenced file.</typeparam>
    [Serializable]
    public class FilePtr<T> where T : File
    {
        /// <summary>
        /// The referenced file.
        /// </summary>
        [SerializeField]
        private UnityEngine.Object file;

        public FilePtr(UnityEngine.Object file) => this.file = file;

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