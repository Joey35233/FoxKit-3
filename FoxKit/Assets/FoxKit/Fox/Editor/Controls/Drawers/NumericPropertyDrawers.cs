using System.Numerics;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    internal static class NumericPropertyDrawers
    {
        internal static readonly string IntegerExpressionCharacterWhitelist = "0123456789-*/+%^()";

        internal static sbyte ClampToInt8(int value) =>(sbyte)(value > sbyte.MaxValue ? sbyte.MaxValue : (value < sbyte.MinValue ? sbyte.MinValue : value));
        internal static byte ClampToUInt8(int value) => (byte)(value > byte.MaxValue ? byte.MaxValue : (value < byte.MinValue ? byte.MinValue : value));
        internal static short ClampToInt16(int value) => (short)(value > short.MaxValue ? short.MaxValue : (value < short.MinValue ? short.MinValue : value));
        internal static ushort ClampToUInt16(int value) => (ushort)(value > ushort.MaxValue ? ushort.MaxValue : (value < ushort.MinValue ? ushort.MinValue : value));
        internal static int ClampToInt32(long value) => (int)(value > int.MaxValue ? int.MaxValue : (value < int.MinValue ? int.MinValue : value));
        internal static uint ClampToUInt32(BigInteger value)=> (uint)(value > uint.MaxValue ? uint.MaxValue : (value < uint.MinValue ? uint.MinValue : value));
        internal static long ClampToInt64(BigInteger value) => (long)(value > long.MaxValue ? long.MaxValue : (value < long.MinValue ? long.MinValue : value));
        internal static ulong ClampToUInt64(BigInteger value) => (ulong)(value > ulong.MaxValue ? ulong.MaxValue : (value < ulong.MinValue ? ulong.MinValue : value));
    }
}
