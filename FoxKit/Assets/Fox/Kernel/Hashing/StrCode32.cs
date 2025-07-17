using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fox
{
    [Serializable, StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct StrCode32 : IEquatable<uint>
    {
        [SerializeField, FieldOffset(0)]
        uint hash;

        public StrCode32(ReadOnlySpan<char> str)
        {
            hash = Hashing.StringId32(str);
        }

        internal StrCode32(uint hash)
        {
            this.hash = hash;
        }
        
        public bool IsValid() => hash != 0;

        internal uint Backing => hash;

        // Fox.StrCode32
        public static bool operator ==(StrCode32 a, StrCode32 b) => a.hash == b.hash;

        public static bool operator !=(StrCode32 a, StrCode32 b) => !(a == b);

        // System.UInt32 comparisons
        public static bool operator ==(StrCode32 a, uint b) => a.hash == b;

        public static bool operator !=(StrCode32 a, uint b) => !(a == b);

        // Generic overrides
        public override bool Equals(object obj) => obj is StrCode32 rhs && this == rhs;

        public override int GetHashCode() => unchecked((int)hash);

        public bool Equals(uint other) => hash.Equals(other);

        // Bitwise operators
        public static uint operator &(StrCode32 a, uint b) => a.hash & b;

        public override string ToString() => $"0x{hash:x8}";
    }
}