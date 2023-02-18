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

        internal uint Backing => _hash;

        // Kernel.StrCode32
        public static bool operator ==(StrCode32 a, StrCode32 b) => a._hash == b._hash;

        public static bool operator !=(StrCode32 a, StrCode32 b) => !(a == b);

        // System.UInt32 comparisons
        public static bool operator ==(StrCode32 a, uint b) => a._hash == b;

        public static bool operator !=(StrCode32 a, uint b) => !(a == b);

        // Generic overrides
        public override bool Equals(object obj) => obj is StrCode32 rhs && this == rhs;

        public override int GetHashCode() => unchecked((int)_hash);

        public bool Equals(uint other) => _hash.Equals(other);

        // Bitwise operators
        public static uint operator &(StrCode32 a, uint b) => a._hash & b;

        public override string ToString() => $"0x{_hash:x8}";
    }
}