using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.Kernel
{
    [Serializable, StructLayout(LayoutKind.Explicit, Size = 16, CharSet = CharSet.Ansi)]
    public class Path : IEquatable<string>
    {
        [SerializeField, FieldOffset(0)]
        private string _cString;
        public string CString => _cString;

        [SerializeField, FieldOffset(8)]
        private int _length;
        public int Length => _length;

        [SerializeField, FieldOffset(12)]
        private PathFileNameAndExtCode _hash;
        public PathFileNameAndExtCode Hash => _hash;

        public String Extension => Hash.Extension;

        //public PathFileNameAndExtCode Hash32 => (StrCode32)Hash;

        /// <summary>
        /// The empty string.
        /// </summary>
        public static Path Empty => new Path();

        private Path()
        {
            _cString = System.String.Empty;
            _length = 0;
            _hash = new PathFileNameAndExtCode(System.String.Empty);
        }

        public Path(ReadOnlySpan<char> value) : this(new string(value)) { }

        public Path(string name)
        {
            if (!System.String.IsNullOrEmpty(name))
            {
                _cString = name;
                _length = name.Length;
                _hash = new PathFileNameAndExtCode(name);
            }
            else
            {
                _cString = Empty.CString;
                _length = Empty.Length;
                _hash = Empty.Hash;
            }
        }

        public Path(PathFileNameAndExtCode hash)
        {
            _cString = null;
            _length = -1;
            _hash = hash;
        }

        public bool IsPseudoNull() => (Length == 0) && (Hash == 0);

        public bool IsHashed() => (Length == 0) && (Hash != Empty.Hash);

        public override string ToString() => IsHashed() ? Hash.ToString() : CString;

        // Kernel.Path
        public static bool operator ==(Path a, Path b) => a?.Hash == b?.Hash;
        public static bool operator !=(Path a, Path b) => !(a == b);

        // System.String comparisons
        public static bool operator ==(Path a, string b) => a?.Hash == new PathFileNameAndExtCode(b);
        public static bool operator !=(Path a, string b) => !(a == b);

        // Generic overrides
        public override bool Equals(object obj) => obj is Path rhs && this == rhs;

        public override int GetHashCode() => unchecked(Hash.GetHashCode());

        public bool Equals(string other) => Hash == new PathFileNameAndExtCode(other);
    }
}