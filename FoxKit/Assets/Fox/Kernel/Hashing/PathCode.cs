using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fox
{
    [Serializable, StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct PathCode : IEquatable<ulong>
    {
        [SerializeField, FieldOffset(0)] private ulong hash;
        
        public PathCode(ReadOnlySpan<char> str)
        {
            hash = Hashing.PathCode(str);
        }

        internal PathCode(ulong hash)
        {
            this.hash = hash;
        }

        public bool IsValid() => hash != 0;

        internal ulong Backing => hash;
        
        public string Extension => throw new NotImplementedException();

        // Fox.PathFileNameAndExtCode
        public static bool operator ==(PathCode a, PathCode b) => a.hash == b.hash;

        public static bool operator !=(PathCode a, PathCode b) => !(a == b);

        // System.UInt64 comparisons
        public static bool operator ==(PathCode a, ulong b) => a.hash == b;

        public static bool operator !=(PathCode a, ulong b) => !(a == b);

        // Generic overrides
        public override bool Equals(object obj) => obj is PathCode rhs && this == rhs;

        public override int GetHashCode() => unchecked((int)hash);

        public bool Equals(ulong other) => hash.Equals(other);

        // Bitwise operators
        public static ulong operator &(PathCode a, ulong b) => a.hash & b;
        public static uint operator &(PathCode a, uint b) => (uint)(a.hash & b);

        public override string ToString() => $"0x{hash:x16}";
        
        // Step-down conversion
        public static explicit operator StrCode32(PathCode value) => new((uint)(value.hash & 0xFFFFFFFF));
    }
}