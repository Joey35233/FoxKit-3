using System;

using UnityEngine;

namespace Fox.Kernel
{
    [Serializable]
    public struct PathFileNameAndExtCode : IEquatable<ulong>
    {
        [SerializeField]
        private ulong _hash;

        public PathFileNameAndExtCode(string str)
        {
            _hash = Hashing.PathFileNameAndExtCode(str);
        }

        internal PathFileNameAndExtCode(ulong hash)
        {
            _hash = hash;
        }

        // Kernel.StrCode
        public static bool operator ==(PathFileNameAndExtCode a, PathFileNameAndExtCode b)
        {
            return a._hash == b._hash;
        }

        public static bool operator !=(PathFileNameAndExtCode a, PathFileNameAndExtCode b)
        {
            return !(a == b);
        }

        // System.UInt64 comparisons
        public static bool operator ==(PathFileNameAndExtCode a, ulong b)
        {
            return a._hash == b;
        }

        public static bool operator !=(PathFileNameAndExtCode a, ulong b)
        {
            return !(a == b);
        }

        // Generic overrides
        public override bool Equals(object obj)
        {
            return obj is PathFileNameAndExtCode rhs && this == rhs;
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
        public static ulong operator &(PathFileNameAndExtCode a, ulong b)
        {
            return a._hash & b;
        }
        public static uint operator &(PathFileNameAndExtCode a, uint b)
        {
            return (uint)(a._hash & (ulong)b);
        }

        public override string ToString()
        {
            return $"0x{_hash.ToString("x16")}";
        }

        // Step-down conversion
        // public static explicit operator StrCode32(StrCode value) => new StrCode32((uint)(value._hash & 0xFFFFFFFF));
    }
}