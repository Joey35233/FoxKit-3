using System.Numerics;

namespace Fox.EdCore
{
    internal static class NumericPropertyFields
    {
        public static readonly string FloatExpressionCharacterWhitelist = "inftynaeINFTYNAE0123456789.,-*/+%^()cosqrludxvRL=pP#";

        public static readonly string IntegerExpressionCharacterWhitelist = "0123456789-*/+%^()cosintaqrtelfundxvRL,=pPI#";

        //public static readonly string PropertyPathExpressionCharacterWhitelist = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz[]._";

        public static sbyte ClampToInt8(int value) => (sbyte)(value > System.SByte.MaxValue ? System.SByte.MaxValue : (value < System.SByte.MinValue ? System.SByte.MinValue : value));
        public static byte ClampToUInt8(int value) => (byte)(value > System.Byte.MaxValue ? System.Byte.MaxValue : (value < System.Byte.MinValue ? System.Byte.MinValue : value));
        public static short ClampToInt16(int value) => (short)(value > System.Int16.MaxValue ? System.Int16.MaxValue : (value < System.Int16.MinValue ? System.Int16.MinValue : value));
        public static ushort ClampToUInt16(int value) => (ushort)(value > System.UInt16.MaxValue ? System.UInt16.MaxValue : (value < System.UInt16.MinValue ? System.UInt16.MinValue : value));
        public static int ClampToInt32(long value) => (int)(value > System.Int32.MaxValue ? System.Int32.MaxValue : (value < System.Int32.MinValue ? System.Int32.MinValue : value));
        public static uint ClampToUInt32(BigInteger value) => (uint)(value > System.UInt32.MaxValue ? System.UInt32.MaxValue : (value < System.UInt32.MinValue ? System.UInt32.MinValue : value));
        public static long ClampToInt64(BigInteger value) => (long)(value > System.Int64.MaxValue ? System.Int64.MaxValue : (value < System.Int64.MinValue ? System.Int64.MinValue : value));
        public static ulong ClampToUInt64(BigInteger value) => (ulong)(value > System.UInt64.MaxValue ? System.UInt64.MaxValue : (value < System.UInt64.MinValue ? System.UInt64.MinValue : value));

        public static float ClampToFloat(double value)
        {
            return System.Double.IsPositiveInfinity(value)
                ? System.Single.PositiveInfinity
                : System.Double.IsNegativeInfinity(value)
                ? System.Single.NegativeInfinity
                : (float)System.Math.Clamp(value, System.Single.MinValue, System.Single.MaxValue);
        }

        public static bool StringToDouble(string str, out double value)
        {
            string lowered = str.ToLower();
            if (lowered is "inf" or "infinity")
                value = System.Double.PositiveInfinity;
            else if (lowered is "-inf" or "-infinity")
                value = System.Double.NegativeInfinity;
            else if (lowered == "nan")
                value = System.Double.NaN;
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
