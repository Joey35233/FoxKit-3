using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.Kernel
{
    [Serializable, StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct StrCode : IEquatable<ulong>
    {
        [SerializeField]
        [FieldOffset(0)] private ulong _hash;

        public StrCode(string str)
        {
            _hash = Hashing.StrCode(str);
        }

        internal StrCode(ulong hash)
        {
            _hash = hash;
        }

        public bool IsValid() => _hash != 0;

        internal ulong Backing => _hash;

        // Kernel.StrCode
        public static bool operator ==(StrCode a, StrCode b) => a._hash == b._hash;

        public static bool operator !=(StrCode a, StrCode b) => !(a == b);

        // System.UInt64 comparisons
        public static bool operator ==(StrCode a, ulong b) => a._hash == b;

        public static bool operator !=(StrCode a, ulong b) => !(a == b);

        // Generic overrides
        public override bool Equals(object obj) => obj is StrCode rhs && this == rhs;

        public override int GetHashCode() => unchecked((int)_hash);

        public bool Equals(ulong other) => _hash.Equals(other);

        // Bitwise operators
        public static ulong operator &(StrCode a, ulong b) => a._hash & b;
        public static uint operator &(StrCode a, uint b) => (uint)(a._hash & b);

        public override string ToString() => $"0x{_hash:x16}";

        // Step-down conversion
        public static explicit operator StrCode32(StrCode value) => new((uint)(value._hash & 0xFFFFFFFF));
    }
}