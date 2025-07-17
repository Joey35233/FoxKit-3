using System.Numerics;
using UnityEngine;

namespace Fox.EdCore
{
    internal static class NumericPropertyFields
    {
        public static readonly string FloatExpressionCharacterWhitelist = "inftynaeINFTYNAE0123456789.,-*/+%^()cosqrludxvRL=pP#";
        public static readonly string IntegerExpressionCharacterWhitelist = "0123456789-*/+%^()cosintaqrtelfundxvRL,=pPI#";
        public static readonly string DoubleFieldFormatString = "R";
        public static readonly string FloatFieldFormatString = "g7";
        public static readonly string IntegerFieldFormatString = "#######0";

        public static sbyte ClampToInt8(int value) => (sbyte)(value > System.SByte.MaxValue ? System.SByte.MaxValue : (value < System.SByte.MinValue ? System.SByte.MinValue : value));
        public static byte ClampToUInt8(int value) => (byte)(value > System.Byte.MaxValue ? System.Byte.MaxValue : (value < System.Byte.MinValue ? System.Byte.MinValue : value));
        public static byte ClampToUInt8(uint value) => (byte)(value > System.Byte.MaxValue ? System.Byte.MaxValue : (value));
        public static short ClampToInt16(int value) => (short)(value > System.Int16.MaxValue ? System.Int16.MaxValue : (value < System.Int16.MinValue ? System.Int16.MinValue : value));
        public static ushort ClampToUInt16(int value) => (ushort)(value > System.UInt16.MaxValue ? System.UInt16.MaxValue : (value < System.UInt16.MinValue ? System.UInt16.MinValue : value));
        public static ushort ClampToUInt16(uint value) => (ushort)(value > System.UInt16.MaxValue ? System.UInt16.MaxValue : (value));
        public static int ClampToInt32(long value) => (int)(value > System.Int32.MaxValue ? System.Int32.MaxValue : (value < System.Int32.MinValue ? System.Int32.MinValue : value));
        public static uint ClampToUInt32(long value) => (uint)(value > System.UInt32.MaxValue ? System.UInt32.MaxValue : (value < System.UInt32.MinValue ? System.UInt32.MinValue : value));

        public static float ClampToFloat(double value)
        {
            return System.Double.IsPositiveInfinity(value)
                ? System.Single.PositiveInfinity
                : System.Double.IsNegativeInfinity(value)
                ? System.Single.NegativeInfinity
                : (float)System.Math.Clamp(value, System.Single.MinValue, System.Single.MaxValue);
        }

        public static bool TryConvertStringToDouble(string str, out double value)
        {
            var lowered = str.ToLower();
            switch (lowered)
            {
                case "inf" or "infinity":
                    value = double.PositiveInfinity;
                    break;
                case "-inf" or "-infinity":
                    value = double.NegativeInfinity;
                    break;
                case "nan":
                    value = double.NaN;
                    break;
                default:
                    return ExpressionEvaluator.Evaluate(str, out value);
            }
            return true;
        }

        public static bool TryConvertStringToFloat(string str, out float value)
        {
            var success = TryConvertStringToDouble(str, out var v);
            value = ClampToFloat(v);
            return success;
        }

        public static bool TryConvertStringToLong(string str, out long value)
        {
            var success = ExpressionEvaluator.Evaluate(str, out value);
            
            return success;
        }

        public static bool TryConvertStringToULong(string str, out ulong value)
        {
            var success = ExpressionEvaluator.Evaluate(str, out value);
            
            return success;
        }

        public static bool TryConvertStringToInt(string str, out int value)
        {
            var success = TryConvertStringToLong(str, out var v);
            value = ClampToInt32(v);
            return success;
        }

        public static bool TryConvertStringToUInt(string str, out uint value)
        {
            var success = TryConvertStringToLong(str, out var v);
            value = ClampToUInt32(v);
            return success;
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
