using System.Numerics;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    internal static class NumericPropertyDrawers
    {
        public static readonly string FloatExpressionCharacterWhitelist = "inftynaeINFTYNAE0123456789.,-*/+%^()cosqrludxvRL=pP#";

        public static readonly string IntegerExpressionCharacterWhitelist = "0123456789-*/+%^()cosintaqrtelfundxvRL,=pPI#";

        public static sbyte ClampToInt8(int value) =>(sbyte)(value > sbyte.MaxValue ? sbyte.MaxValue : (value < sbyte.MinValue ? sbyte.MinValue : value));
        public static byte ClampToUInt8(int value) => (byte)(value > byte.MaxValue ? byte.MaxValue : (value < byte.MinValue ? byte.MinValue : value));
        public static short ClampToInt16(int value) => (short)(value > short.MaxValue ? short.MaxValue : (value < short.MinValue ? short.MinValue : value));
        public static ushort ClampToUInt16(int value) => (ushort)(value > ushort.MaxValue ? ushort.MaxValue : (value < ushort.MinValue ? ushort.MinValue : value));
        public static int ClampToInt32(long value) => (int)(value > int.MaxValue ? int.MaxValue : (value < int.MinValue ? int.MinValue : value));
        public static uint ClampToUInt32(BigInteger value)=> (uint)(value > uint.MaxValue ? uint.MaxValue : (value < uint.MinValue ? uint.MinValue : value));
        public static long ClampToInt64(BigInteger value) => (long)(value > long.MaxValue ? long.MaxValue : (value < long.MinValue ? long.MinValue : value));
        public static ulong ClampToUInt64(BigInteger value) => (ulong)(value > ulong.MaxValue ? ulong.MaxValue : (value < ulong.MinValue ? ulong.MinValue : value));

        public static float ClampToFloat(double value)
        {
            if (double.IsPositiveInfinity(value))
                return float.PositiveInfinity;

            if (double.IsNegativeInfinity(value))
                return float.NegativeInfinity;

            return (float)System.Math.Clamp(value, float.MinValue, float.MaxValue);
        }

        public static bool StringToDouble(string str, out double value)
        {
            string lowered = str.ToLower();
            if (lowered == "inf" || lowered == "infinity")
                value = double.PositiveInfinity;
            else if (lowered == "-inf" || lowered == "-infinity")
                value = double.NegativeInfinity;
            else if (lowered == "nan")
                value = double.NaN;
            else
                return ExpressionEvaluator.Evaluate(str, out value);

            return true;
        }


        public static double RoundBasedOnMinimumDifference(double valueToRound, double minDifference)
        {
            if (minDifference == 0)
            {
                int decimals = System.Math.Max(0, (int)(5 - System.Math.Log10(System.Math.Abs(valueToRound))));
                try
                {
                    return System.Math.Round(valueToRound, decimals);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    return 0;
                }
            }
            else
            {
                return System.Math.Round(valueToRound, (int)System.Math.Max(0.0, -System.Math.Floor(System.Math.Log10(System.Math.Abs(minDifference)))), System.MidpointRounding.AwayFromZero);
            }
        }
    }
}
