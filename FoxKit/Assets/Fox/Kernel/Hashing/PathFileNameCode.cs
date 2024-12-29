using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fox
{
    [Serializable, StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct PathFileNameCode : IEquatable<ulong>
    {
        [FormerlySerializedAs("hash")]
        [SerializeField]
        [FieldOffset(0)] private ulong _hash;
        public PathFileNameCode(string str)
        {
            _hash = Hashing.PathFileNameCode(str);
        }

        internal PathFileNameCode(ulong hash)
        {
            _hash = hash;
        }

        public bool IsValid() => _hash != 0;

        internal ulong Backing => _hash;

        // Fox.PathFileNameCode
        public static bool operator ==(PathFileNameCode a, PathFileNameCode b) => a._hash == b._hash;

        public static bool operator !=(PathFileNameCode a, PathFileNameCode b) => !(a == b);

        // System.UInt64 comparisons
        public static bool operator ==(PathFileNameCode a, ulong b) => a._hash == b;

        public static bool operator !=(PathFileNameCode a, ulong b) => !(a == b);

        // Generic overrides
        public override bool Equals(object obj) => obj is PathFileNameCode rhs && this == rhs;

        public override int GetHashCode() => unchecked((int)_hash);

        public bool Equals(ulong other) => _hash.Equals(other);

        // Bitwise operators
        public static ulong operator &(PathFileNameCode a, ulong b) => a._hash & b;
        public static uint operator &(PathFileNameCode a, uint b) => (uint)(a._hash & b);

        public override string ToString() => $"0x{_hash:x16}";

        // Step-down conversion
        public static explicit operator PathFileNameCode32(PathFileNameCode value) => new((uint)(value._hash & 0xFFFFFFFF));
    }
}