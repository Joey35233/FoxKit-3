using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fox.Kernel
{
    [Serializable, StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct PathFileNameCode32 : IEquatable<uint>
    {
        [FormerlySerializedAs("hash")]
        [SerializeField]
        [FieldOffset(0)] private uint _hash;

        public PathFileNameCode32(string str)
        {
            _hash = Hashing.PathFileNameCode32(str);
        }

        internal PathFileNameCode32(uint hash)
        {
            _hash = hash;
        }

        public bool IsValid() => _hash != 0;

        internal uint Backing => _hash;

        // Kernel.PathFileNameCode32
        public static bool operator ==(PathFileNameCode32 a, PathFileNameCode32 b) => a._hash == b._hash;

        public static bool operator !=(PathFileNameCode32 a, PathFileNameCode32 b) => !(a == b);

        // System.UInt32 comparisons
        public static bool operator ==(PathFileNameCode32 a, uint b) => a._hash == b;

        public static bool operator !=(PathFileNameCode32 a, uint b) => !(a == b);

        // Generic overrides
        public override bool Equals(object obj) => obj is PathFileNameCode32 rhs && this == rhs;

        public override int GetHashCode() => unchecked((int)_hash);

        public bool Equals(uint other) => _hash.Equals(other);

        // Bitwise operators
        public static uint operator &(PathFileNameCode32 a, uint b) => (uint)(a._hash & b);

        public override string ToString() => $"0x{_hash:x8}";
    }
}