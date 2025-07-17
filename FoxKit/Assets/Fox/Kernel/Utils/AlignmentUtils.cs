using System;
using UnityEngine;

namespace Fox
{
    public static class AlignmentUtils
    {
        public static long Align(long value, uint alignment)
        {
            Debug.Assert(value > 0);
            
            return (value + (alignment - 1)) & -alignment;
        }

        public static ulong Align(ulong value, uint alignment)
        {
            Debug.Assert(value > 0);

            return (value + (alignment - 1u)) & (ulong)-alignment;
        }
    }
}
