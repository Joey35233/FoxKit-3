using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox
{
    [Serializable]
    public class Path : IEquatable<string>
    {
        [SerializeField]
        private string _cString;
        public string CString => _cString;

        [SerializeField]
        private PathFileNameAndExtCode _hash;
        public PathFileNameAndExtCode Hash => _hash;

        public String Extension => Hash.Extension;

        /// <summary>
        /// The empty string.
        /// </summary>
        public static Path Empty => new Path("");

        private Path()
        {
            _cString = Empty.CString;
            _hash = Empty.Hash;
        }

        public Path(ReadOnlySpan<char> value) : this(new string(value)) { }

        public Path(string name)
        {
            if (name is null)
            {
                _cString = null;
                _hash = HashingBitConverter.ToPathFileNameAndExtCode(0);
            }
            else
            {
                _cString = name;
                _hash = new PathFileNameAndExtCode(name);
            }
        }

        public Path(PathFileNameAndExtCode hash)
        {
            _cString = null;
            _hash = hash;
        }
        
        public bool IsHashed() => (string.IsNullOrEmpty(CString)) && (Hash != Empty.Hash);

        public override string ToString() => IsHashed() ? Hash.ToString() : CString;

        // Fox.Path
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