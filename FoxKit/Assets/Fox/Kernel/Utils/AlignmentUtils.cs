using System;
using UnityEngine;

namespace Fox
{
    public static class AlignmentUtils
    {
        public static ulong Align(uint value, uint alignment)
        {
            Debug.Assert(value > 0);

            return (value + alignment - 1u) & ~(alignment - 1);
        }
        
        public static long Align(long value, uint alignment)
        {
            Debug.Assert(value > 0);
            
            return (value + alignment - 1u) & ~((long)alignment - 1);
        }
        
        public static ulong Align(ulong value, uint alignment)
        {
            Debug.Assert(value > 0);

            return (value + alignment - 1u) & ~((ulong)alignment - 1);
        }
    }
}
