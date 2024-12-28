//using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.Kernel
{
    [System.Serializable]
    public class String : System.IEquatable<string>
    {
        [SerializeField]
        private string _cString;
        public string CString => _cString;

        [SerializeField]
        private int _length;
        public int Length => _length;

        [SerializeField]
        private StrCode _hash;
        public StrCode Hash => _hash;

        public StrCode32 Hash32 => (StrCode32)Hash;

        /// <summary>
        /// The empty string.
        /// </summary>
        public static String Empty => new("");

        // Unfortunately, this must exist because Unity's serialization system tracks this down and screws up certain data structures like StringMap.
        private String()
        {
            _cString = Empty.CString;
            _length = Empty.Length;
            _hash = Empty.Hash;
        }

        public String(System.ReadOnlySpan<char> value) : this(new string(value)) { }

        public String(string name)
        {
            if (name is null)
            {
                _cString = null;
                _length = -1;
                _hash = HashingBitConverter.ToStrCode(0);
            }
            else
            {
                _cString = name;
                _length = name.Length;
                _hash = new StrCode(name);
            }
        }

        public String(StrCode hash)
        {
            _cString = null;
            _length = -1;
            _hash = hash;
        }

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