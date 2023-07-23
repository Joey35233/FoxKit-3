//using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.Kernel
{
    [System.Serializable, StructLayout(LayoutKind.Explicit, Size = 16, CharSet = CharSet.Ansi)]
    public class String : System.IEquatable<string>
    {
        [SerializeField, FieldOffset(0)]
        private string _cString;
        public string CString => _cString;

        [SerializeField, FieldOffset(8)]
        private int _length;
        public int Length => _length;

        [SerializeField, FieldOffset(12)]
        private StrCode _hash;
        public StrCode Hash => _hash;

        public StrCode32 Hash32 => (StrCode32)Hash;

        /// <summary>
        /// The empty string.
        /// </summary>
        public static String Empty => new String();

        private String()
        {
            _cString = System.String.Empty;
            _length = 0;
            _hash = new StrCode(System.String.Empty);
        }

        public String(System.ReadOnlySpan<char> value) : this(new string(value)) { }

        public String(string name)
        {
            if (!System.String.IsNullOrEmpty(name))
            {
                _cString = name;
                _length = name.Length;
                _hash = new StrCode(name);
            }
            else
            {
                _cString = Empty.CString;
                _length = Empty.Length;
                _hash = Empty.Hash;
            }
        }

        public String(StrCode hash)
        {
            _cString = null;
            _length = -1;
            _hash = hash;
        }

        public bool IsPseudoNull() => (Length == 0) && (Hash == 0);

        public bool IsHashed() => (Length == 0) && (Hash != Empty.Hash);

        public override string ToString() => IsHashed() ? Hash.ToString() : CString;

        // Kernel.String
        public static bool operator ==(String a, String b) => a?.Hash == b?.Hash;
        public static bool operator !=(String a, String b) => !(a == b);

        // System.String comparisons
        public static bool operator ==(String a, string b) => a?.Hash == new StrCode(b);
        public static bool operator !=(String a, string b) => !(a == b);

        // Generic overrides
        public override bool Equals(object obj) => obj is String rhs && this == rhs;

        public override int GetHashCode() => unchecked(Hash.GetHashCode());

        public bool Equals(string other) => Hash == new StrCode(other);
    }
}