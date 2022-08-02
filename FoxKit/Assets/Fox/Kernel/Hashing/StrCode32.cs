using System;

using UnityEngine;

namespace Fox.Kernel
{
    [Serializable]
    public struct StrCode32 : IEquatable<uint>
    {
        [SerializeField]
        private uint _hash;

        public StrCode32(string str)
        {
            _hash = Hashing.StrCode32(str);
        }

        internal StrCode32(uint hash)
        {
            _hash = hash;
        }

        // Kernel.StrCode32
        public static bool operator ==(StrCode32 a, StrCode32 b)
        {
            return a._hash == b._hash;
        }

        public static bool operator !=(StrCode32 a, StrCode32 b)
        {
            return !(a == b);
        }

        // System.UInt32 comparisons
        public static bool operator ==(StrCode32 a, uint b)
        {
            return a._hash == b;
        }

        public static bool operator !=(StrCode32 a, uint b)
        {
            return !(a == b);
        }

        // Generic overrides
        public override bool Equals(object obj)
        {
            return obj is StrCode32 rhs && this == rhs;
        }

        public override int GetHashCode()
        {
            return unchecked((int)_hash);
        }

        public bool Equals(uint other)
        {
            return _hash.Equals(other);
        }

        // Bitwise operators
        public static uint operator &(StrCode32 a, uint b)
        {
            return a._hash & b;
        }

        public override string ToString()
        {
            return $"0x{_hash.ToString("x8")}";
        }
    }
}