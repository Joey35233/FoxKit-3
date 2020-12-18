using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox
{
    [Serializable, StructLayout(LayoutKind.Explicit, Size = 16, CharSet = CharSet.Ansi)]
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public class Path
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
    {
        [SerializeField, FieldOffset(0)]
        private string _cString;
        public string CString
        {
            get => _cString;
        }

        [SerializeField, FieldOffset(8)]
        private int _length;
        public int Length
        {
            get => _length;
        }

        [SerializeField, FieldOffset(12)]
        private PathFileNameCode _hash;
        public PathFileNameCode Hash
        {
            get => _hash;
        }

        /// <summary>
        /// The empty path.
        /// </summary>
        public static Fox.Path Empty { get; }

        static Path()
        {
            Empty = new Path
            {
                _cString = string.Empty,
                _length = 0,
                _hash = new PathFileNameCode(string.Empty)
            };
        }

        private Path()
        {

        }

        public Path(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                this._cString = name;
                this._length = name.Length;
                this._hash = new PathFileNameCode(name);
            }
            else
            {
                this._cString = Empty.CString;
                this._length = Empty.Length;
                this._hash = Empty.Hash;
            }
        }

        public static bool operator ==(Path a, Path b)
        {
            return a.Hash == b.Hash;
        }

        public static bool operator !=(Path a, Path b)
        {
            return !(a == b);
        }
    }
}