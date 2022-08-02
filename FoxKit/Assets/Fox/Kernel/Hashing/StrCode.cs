using System;
using System.IO;
using UnityEngine;

namespace Fox.Kernel
{
    [Serializable]
    public struct StrCode : IEquatable<ulong>
    {
        [SerializeField]
        private ulong _hash;

        public StrCode(string str)
        {
            _hash = Hashing.StrCode(str);
        }

        internal StrCode(ulong hash)
        {
            _hash = hash;
        }

        // Kernel.StrCode
        public static bool operator ==(StrCode a, StrCode b)
        {
            return a._hash == b._hash;
        }

        public static bool operator !=(StrCode a, StrCode b)
        {
            return !(a == b);
        }

        // System.UInt64 comparisons
        public static bool operator ==(StrCode a, ulong b)
        {
            return a._hash == b;
        }

        public static bool operator !=(StrCode a, ulong b)
        {
            return !(a == b);
        }

        // Generic overrides
        public override bool Equals(object obj)
        {
            return obj is StrCode rhs && this == rhs;
        }

        public override int GetHashCode()
        {
            return unchecked((int)_hash);
        }

        public bool Equals(ulong other)
        {
            return _hash.Equals(other);
        }

        // Bitwise operators
        public static ulong operator &(StrCode a, ulong b)
        {
            return a._hash & b;
        }
        public static uint operator &(StrCode a, uint b)
        {
            return (uint)(a._hash & (ulong)b);
        }

        public override string ToString()
        {
            return $"0x{_hash.ToString("x16")}";
        }

        // Step-down conversion
        public static explicit operator StrCode32(StrCode value) => new StrCode32((uint)(value._hash & 0xFFFFFFFF));
    }
}