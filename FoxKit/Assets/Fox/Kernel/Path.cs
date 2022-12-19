using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.Kernel
{
    [Serializable, StructLayout(LayoutKind.Explicit, Size = 16, CharSet = CharSet.Ansi)]
    public class Path : IEquatable<string>
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
        private PathFileNameAndExtCode _hash;
        public PathFileNameAndExtCode Hash
        {
            get => _hash;
        }

        public String Extension => Hash.Extension;

        //public PathFileNameAndExtCode Hash32 => (StrCode32)Hash;

        /// <summary>
        /// The empty string.
        /// </summary>
        public static Path Empty { get; }

        static Path()
        {
            Empty = new Path
            {
                _cString = string.Empty,
                _length = 0,
                _hash = new PathFileNameAndExtCode(string.Empty)
            };
        }

        private Path()
        {

        }

        public Path(ReadOnlySpan<char> value) : this(new string(value)) { }

        public Path(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                this._cString = name;
                this._length = name.Length;
                this._hash = new PathFileNameAndExtCode(name);
            }
            else
            {
                this._cString = Empty.CString;
                this._length = Empty.Length;
                this._hash = Empty.Hash;
            }
        }

        public Path(PathFileNameAndExtCode hash)
        {
            this._cString = null;
            this._length = -1;
            this._hash = hash;
        }

        public bool IsPseudoNull() => (Length == 0) && (Hash == 0);

        public bool IsHashed() => (Length == 0) && (Hash != Empty.Hash);

        public override string ToString()
        {
            return IsHashed() ? Hash.ToString() : CString;
        }

        // Kernel.Path
        public static bool operator ==(Path a, Path b)
        {
            return a?.Hash == b?.Hash;
        }
        public static bool operator !=(Path a, Path b)
        {
            return !(a == b);
        }

        // System.String comparisons
        public static bool operator ==(Path a, string b)
        {
            return a?.Hash == new PathFileNameAndExtCode(b);
        }
        public static bool operator !=(Path a, string b)
        {
            return !(a == b);
        }

        // Generic overrides
        public override bool Equals(object obj)
        {
            return obj is Path rhs && this == rhs;
        }

        public override int GetHashCode()
        {
            return unchecked((int)Hash.GetHashCode());
        }

        public bool Equals(string other)
        {
            return Hash == new PathFileNameAndExtCode(other);
        }
    }
}