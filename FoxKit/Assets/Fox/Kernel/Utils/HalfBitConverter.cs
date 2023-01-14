using System;
using System.Diagnostics;
using System.Globalization;

namespace Fox.Kernel
{
    // Thanks to https://sourceforge.net/projects/csharp-half/!
    internal static class HalfConversions
    {
        public static float HalfToSingle(Half value)
        {
            uint tempA = (uint)value.value << 0x10;
            uint tempB;
            if ((tempA & 0x7fffffff) == 0)
                tempB = 0;
            else
                tempB = tempA & 0xb8000000 | 0x38000000;

            tempA = ((tempA & 0x7fffffff) >> 3) + tempB;

            return BitConverter.Int32BitsToSingle((int)tempA);
        }

        public static Half SingleToHalf(float value)
        {
            uint uValue = (uint)BitConverter.SingleToInt32Bits(value);

            uint tempA = uValue & 0x7fffffffu;
            uint tempB;
            if (0x47ffffffu < tempA)
                tempA = 0x47ffffffu;

            if (tempA < 0x38000000u)
                tempB = 0;
            else
                tempB = (ushort)(tempA * 8 + 0x40000000u >> 0x10);

            return new Half { value = (ushort)(tempB | (ushort)(uValue >> 0x10) & 0x8000u) };
        }

        public static Half Negate(Half half)
        {
            return Half.ToHalf((ushort)(half.value ^ 0x8000));
        }

        public static Half Abs(Half half)
        {
            return Half.ToHalf((ushort)(half.value & 0x7fff));
        }
    }

    /// <summary>
    /// Represents a half-precision floating point number. 
    /// </summary>
    [Serializable]
    public struct Half : IComparable, IFormattable, IConvertible, IComparable<Half>, IEquatable<Half>
    {
        /// <summary>
        /// Internal representation of the half-precision floating-point number.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal ushort value;

        #region Constants
        /// <summary>
        /// Represents the smallest positive Fox.Kernel.Half value greater than zero. This field is constant.
        /// </summary>
        public static readonly Half Epsilon = Half.ToHalf(0x0001);
        /// <summary>
        /// Represents the largest possible value of Fox.Kernel.Half. This field is constant.
        /// </summary>
        public static readonly Half MaxValue = Half.ToHalf(0x7bff);
        /// <summary>
        /// Represents the smallest possible value of Fox.Kernel.Half. This field is constant.
        /// </summary>
        public static readonly Half MinValue = Half.ToHalf(0xfbff);
        /// <summary>
        /// Represents not a number (NaN). This field is constant.
        /// </summary>
        public static readonly Half NaN = Half.ToHalf(0xfe00);
        /// <summary>
        /// Represents negative infinity. This field is constant.
        /// </summary>
        public static readonly Half NegativeInfinity = Half.ToHalf(0xfc00);
        /// <summary>
        /// Represents positive infinity. This field is constant.
        /// </summary>
        public static readonly Half PositiveInfinity = Half.ToHalf(0x7c00);
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of Fox.Kernel.Half to the value of the specified single-precision floating-point number.
        /// </summary>
        /// <param name="value">The value to represent as a Fox.Kernel.Half.</param>
        public Half(float value) { this = HalfConversions.SingleToHalf(value); }
        /// <summary>
        /// Initializes a new instance of Fox.Kernel.Half to the value of the specified 32-bit signed integer.
        /// </summary>
        /// <param name="value">The value to represent as a Fox.Kernel.Half.</param>
        public Half(int value) : this((float)value) { }
        /// <summary>
        /// Initializes a new instance of Fox.Kernel.Half to the value of the specified 64-bit signed integer.
        /// </summary>
        /// <param name="value">The value to represent as a Fox.Kernel.Half.</param>
        public Half(long value) : this((float)value) { }
        /// <summary>
        /// Initializes a new instance of Fox.Kernel.Half to the value of the specified double-precision floating-point number.
        /// </summary>
        /// <param name="value">The value to represent as a Fox.Kernel.Half.</param>
        public Half(double value) : this((float)value) { }
        /// <summary>
        /// Initializes a new instance of Fox.Kernel.Half to the value of the specified decimal number.
        /// </summary>
        /// <param name="value">The value to represent as a Fox.Kernel.Half.</param>
        public Half(decimal value) : this((float)value) { }
        /// <summary>
        /// Initializes a new instance of Fox.Kernel.Half to the value of the specified 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">The value to represent as a Fox.Kernel.Half.</param>
        public Half(uint value) : this((float)value) { }
        /// <summary>
        /// Initializes a new instance of Fox.Kernel.Half to the value of the specified 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">The value to represent as a Fox.Kernel.Half.</param>
        public Half(ulong value) : this((float)value) { }
        #endregion

        #region Numeric operators
        /// <summary>
        /// Returns the result of multiplying the specified Fox.Kernel.Half value by negative one.
        /// </summary>
        /// <param name="half">A Fox.Kernel.Half.</param>
        /// <returns>A Fox.Kernel.Half with the value of half, but the opposite sign. -or- Zero, if half is zero.</returns>
        public static Half Negate(Half half) { return -half; }
        /// <summary>
        /// Adds two specified Fox.Kernel.Half values.
        /// </summary>
        /// <param name="half1">A Fox.Kernel.Half.</param>
        /// <param name="half2">A Fox.Kernel.Half.</param>
        /// <returns>A Fox.Kernel.Half value that is the sum of half1 and half2.</returns>
        public static Half Add(Half half1, Half half2) { return half1 + half2; }
        /// <summary>
        /// Subtracts one specified Fox.Kernel.Half value from another.
        /// </summary>
        /// <param name="half1">A Fox.Kernel.Half (the minuend).</param>
        /// <param name="half2">A Fox.Kernel.Half (the subtrahend).</param>
        /// <returns>The Fox.Kernel.Half result of subtracting half2 from half1.</returns>
        public static Half Subtract(Half half1, Half half2) { return half1 - half2; }
        /// <summary>
        /// Multiplies two specified Fox.Kernel.Half values.
        /// </summary>
        /// <param name="half1">A Fox.Kernel.Half (the multiplicand).</param>
        /// <param name="half2">A Fox.Kernel.Half (the multiplier).</param>
        /// <returns>A Fox.Kernel.Half that is the result of multiplying half1 and half2.</returns>
        public static Half Multiply(Half half1, Half half2) { return half1 * half2; }
        /// <summary>
        /// Divides two specified Fox.Kernel.Half values.
        /// </summary>
        /// <param name="half1">A Fox.Kernel.Half (the dividend).</param>
        /// <param name="half2">A Fox.Kernel.Half (the divisor).</param>
        /// <returns>The Fox.Kernel.Half that is the result of dividing half1 by half2.</returns>
        /// <exception cref="System.DivideByZeroException">half2 is zero.</exception>
        public static Half Divide(Half half1, Half half2) { return half1 / half2; }

        /// <summary>
        /// Returns the value of the Fox.Kernel.Half operand (the sign of the operand is unchanged).
        /// </summary>
        /// <param name="half">The Fox.Kernel.Half operand.</param>
        /// <returns>The value of the operand, half.</returns>
        public static Half operator +(Half half) { return half; }
        /// <summary>
        /// Negates the value of the specified Fox.Kernel.Half operand.
        /// </summary>
        /// <param name="half">The Fox.Kernel.Half operand.</param>
        /// <returns>The result of half multiplied by negative one (-1).</returns>
        public static Half operator -(Half half) { return HalfConversions.Negate(half); }
        /// <summary>
        /// Increments the Fox.Kernel.Half operand by 1.
        /// </summary>
        /// <param name="half">The Fox.Kernel.Half operand.</param>
        /// <returns>The value of half incremented by 1.</returns>
        public static Half operator ++(Half half) { return (Half)(half + 1f); }
        /// <summary>
        /// Decrements the Fox.Kernel.Half operand by one.
        /// </summary>
        /// <param name="half">The Fox.Kernel.Half operand.</param>
        /// <returns>The value of half decremented by 1.</returns>
        public static Half operator --(Half half) { return (Half)(half - 1f); }
        /// <summary>
        /// Adds two specified Fox.Kernel.Half values.
        /// </summary>
        /// <param name="half1">A Fox.Kernel.Half.</param>
        /// <param name="half2">A Fox.Kernel.Half.</param>
        /// <returns>The Fox.Kernel.Half result of adding half1 and half2.</returns>
        public static Half operator +(Half half1, Half half2) { return (Half)((float)half1 + (float)half2); }
        /// <summary>
        /// Subtracts two specified Fox.Kernel.Half values.
        /// </summary>
        /// <param name="half1">A Fox.Kernel.Half.</param>
        /// <param name="half2">A Fox.Kernel.Half.</param>
        /// <returns>The Fox.Kernel.Half result of subtracting half1 and half2.</returns>        
        public static Half operator -(Half half1, Half half2) { return (Half)((float)half1 - (float)half2); }
        /// <summary>
        /// Multiplies two specified Fox.Kernel.Half values.
        /// </summary>
        /// <param name="half1">A Fox.Kernel.Half.</param>
        /// <param name="half2">A Fox.Kernel.Half.</param>
        /// <returns>The Fox.Kernel.Half result of multiplying half1 by half2.</returns>
        public static Half operator *(Half half1, Half half2) { return (Half)((float)half1 * (float)half2); }
        /// <summary>
        /// Divides two specified Fox.Kernel.Half values.
        /// </summary>
        /// <param name="half1">A Fox.Kernel.Half (the dividend).</param>
        /// <param name="half2">A Fox.Kernel.Half (the divisor).</param>
        /// <returns>The Fox.Kernel.Half result of half1 by half2.</returns>
        public static Half operator /(Half half1, Half half2) { return (Half)((float)half1 / (float)half2); }
        /// <summary>
        /// Returns a value indicating whether two instances of Fox.Kernel.Half are equal.
        /// </summary>
        /// <param name="half1">A Fox.Kernel.Half.</param>
        /// <param name="half2">A Fox.Kernel.Half.</param>
        /// <returns>true if half1 and half2 are equal; otherwise, false.</returns>
        public static bool operator ==(Half half1, Half half2) { return (!IsNaN(half1) && (half1.value == half2.value)); }
        /// <summary>
        /// Returns a value indicating whether two instances of Fox.Kernel.Half are not equal.
        /// </summary>
        /// <param name="half1">A Fox.Kernel.Half.</param>
        /// <param name="half2">A Fox.Kernel.Half.</param>
        /// <returns>true if half1 and half2 are not equal; otherwise, false.</returns>
        public static bool operator !=(Half half1, Half half2) { return !(half1.value == half2.value); }
        /// <summary>
        /// Returns a value indicating whether a specified Fox.Kernel.Half is less than another specified Fox.Kernel.Half.
        /// </summary>
        /// <param name="half1">A Fox.Kernel.Half.</param>
        /// <param name="half2">A Fox.Kernel.Half.</param>
        /// <returns>true if half1 is less than half1; otherwise, false.</returns>
        public static bool operator <(Half half1, Half half2) { return (float)half1 < (float)half2; }
        /// <summary>
        /// Returns a value indicating whether a specified Fox.Kernel.Half is greater than another specified Fox.Kernel.Half.
        /// </summary>
        /// <param name="half1">A Fox.Kernel.Half.</param>
        /// <param name="half2">A Fox.Kernel.Half.</param>
        /// <returns>true if half1 is greater than half2; otherwise, false.</returns>
        public static bool operator >(Half half1, Half half2) { return (float)half1 > (float)half2; }
        /// <summary>
        /// Returns a value indicating whether a specified Fox.Kernel.Half is less than or equal to another specified Fox.Kernel.Half.
        /// </summary>
        /// <param name="half1">A Fox.Kernel.Half.</param>
        /// <param name="half2">A Fox.Kernel.Half.</param>
        /// <returns>true if half1 is less than or equal to half2; otherwise, false.</returns>
        public static bool operator <=(Half half1, Half half2) { return (half1 == half2) || (half1 < half2); }
        /// <summary>
        /// Returns a value indicating whether a specified Fox.Kernel.Half is greater than or equal to another specified Fox.Kernel.Half.
        /// </summary>
        /// <param name="half1">A Fox.Kernel.Half.</param>
        /// <param name="half2">A Fox.Kernel.Half.</param>
        /// <returns>true if half1 is greater than or equal to half2; otherwise, false.</returns>
        public static bool operator >=(Half half1, Half half2) { return (half1 == half2) || (half1 > half2); }
        #endregion

        #region Type casting operators
        /// <summary>
        /// Converts an 8-bit unsigned integer to a Fox.Kernel.Half.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>A Fox.Kernel.Half that represents the converted 8-bit unsigned integer.</returns>
        public static implicit operator Half(byte value) { return new Half((float)value); }
        /// <summary>
        /// Converts a 16-bit signed integer to a Fox.Kernel.Half.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>A Fox.Kernel.Half that represents the converted 16-bit signed integer.</returns>
        public static implicit operator Half(short value) { return new Half((float)value); }
        /// <summary>
        /// Converts a Unicode character to a Fox.Kernel.Half.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>A Fox.Kernel.Half that represents the converted Unicode character.</returns>
        public static implicit operator Half(char value) { return new Half((float)value); }
        /// <summary>
        /// Converts a 32-bit signed integer to a Fox.Kernel.Half.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>A Fox.Kernel.Half that represents the converted 32-bit signed integer.</returns>
        public static implicit operator Half(int value) { return new Half((float)value); }
        /// <summary>
        /// Converts a 64-bit signed integer to a Fox.Kernel.Half.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>A Fox.Kernel.Half that represents the converted 64-bit signed integer.</returns>
        public static implicit operator Half(long value) { return new Half((float)value); }
        /// <summary>
        /// Converts a single-precision floating-point number to a Fox.Kernel.Half.
        /// </summary>
        /// <param name="value">A single-precision floating-point number.</param>
        /// <returns>A Fox.Kernel.Half that represents the converted single-precision floating point number.</returns>
        public static explicit operator Half(float value) { return new Half((float)value); }
        /// <summary>
        /// Converts a double-precision floating-point number to a Fox.Kernel.Half.
        /// </summary>
        /// <param name="value">A double-precision floating-point number.</param>
        /// <returns>A Fox.Kernel.Half that represents the converted double-precision floating point number.</returns>
        public static explicit operator Half(double value) { return new Half((float)value); }
        /// <summary>
        /// Converts a decimal number to a Fox.Kernel.Half.
        /// </summary>
        /// <param name="value">decimal number</param>
        /// <returns>A Fox.Kernel.Half that represents the converted decimal number.</returns>
        public static explicit operator Half(decimal value) { return new Half((float)value); }
        /// <summary>
        /// Converts a Fox.Kernel.Half to an 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Fox.Kernel.Half to convert.</param>
        /// <returns>An 8-bit unsigned integer that represents the converted Fox.Kernel.Half.</returns>
        public static explicit operator byte(Half value) { return (byte)(float)value; }
        /// <summary>
        /// Converts a Fox.Kernel.Half to a Unicode character.
        /// </summary>
        /// <param name="value">A Fox.Kernel.Half to convert.</param>
        /// <returns>A Unicode character that represents the converted Fox.Kernel.Half.</returns>
        public static explicit operator char(Half value) { return (char)(float)value; }
        /// <summary>
        /// Converts a Fox.Kernel.Half to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">A Fox.Kernel.Half to convert.</param>
        /// <returns>A 16-bit signed integer that represents the converted Fox.Kernel.Half.</returns>
        public static explicit operator short(Half value) { return (short)(float)value; }
        /// <summary>
        /// Converts a Fox.Kernel.Half to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">A Fox.Kernel.Half to convert.</param>
        /// <returns>A 32-bit signed integer that represents the converted Fox.Kernel.Half.</returns>
        public static explicit operator int(Half value) { return (int)(float)value; }
        /// <summary>
        /// Converts a Fox.Kernel.Half to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">A Fox.Kernel.Half to convert.</param>
        /// <returns>A 64-bit signed integer that represents the converted Fox.Kernel.Half.</returns>
        public static explicit operator long(Half value) { return (long)(float)value; }
        /// <summary>
        /// Converts a Fox.Kernel.Half to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">A Fox.Kernel.Half to convert.</param>
        /// <returns>A single-precision floating-point number that represents the converted Fox.Kernel.Half.</returns>
        public static implicit operator float(Half value) { return (float)HalfConversions.HalfToSingle(value); }
        /// <summary>
        /// Converts a Fox.Kernel.Half to a double-precision floating-point number.
        /// </summary>
        /// <param name="value">A Fox.Kernel.Half to convert.</param>
        /// <returns>A double-precision floating-point number that represents the converted Fox.Kernel.Half.</returns>
        public static implicit operator double(Half value) { return (double)(float)value; }
        /// <summary>
        /// Converts a Fox.Kernel.Half to a decimal number.
        /// </summary>
        /// <param name="value">A Fox.Kernel.Half to convert.</param>
        /// <returns>A decimal number that represents the converted Fox.Kernel.Half.</returns>
        public static explicit operator decimal(Half value) { return (decimal)(float)value; }
        /// <summary>
        /// Converts an 8-bit signed integer to a Fox.Kernel.Half.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>A Fox.Kernel.Half that represents the converted 8-bit signed integer.</returns>
        public static implicit operator Half(sbyte value) { return new Half((float)value); }
        /// <summary>
        /// Converts a 16-bit unsigned integer to a Fox.Kernel.Half.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>A Fox.Kernel.Half that represents the converted 16-bit unsigned integer.</returns>
        public static implicit operator Half(ushort value) { return new Half((float)value); }
        /// <summary>
        /// Converts a 32-bit unsigned integer to a Fox.Kernel.Half.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>A Fox.Kernel.Half that represents the converted 32-bit unsigned integer.</returns>
        public static implicit operator Half(uint value) { return new Half((float)value); }
        /// <summary>
        /// Converts a 64-bit unsigned integer to a Fox.Kernel.Half.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>A Fox.Kernel.Half that represents the converted 64-bit unsigned integer.</returns>
        public static implicit operator Half(ulong value) { return new Half((float)value); }
        /// <summary>
        /// Converts a Fox.Kernel.Half to an 8-bit signed integer.
        /// </summary>
        /// <param name="value">A Fox.Kernel.Half to convert.</param>
        /// <returns>An 8-bit signed integer that represents the converted Fox.Kernel.Half.</returns>
        public static explicit operator sbyte(Half value) { return (sbyte)(float)value; }
        /// <summary>
        /// Converts a Fox.Kernel.Half to a 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Fox.Kernel.Half to convert.</param>
        /// <returns>A 16-bit unsigned integer that represents the converted Fox.Kernel.Half.</returns>
        public static explicit operator ushort(Half value) { return (ushort)(float)value; }
        /// <summary>
        /// Converts a Fox.Kernel.Half to a 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Fox.Kernel.Half to convert.</param>
        /// <returns>A 32-bit unsigned integer that represents the converted Fox.Kernel.Half.</returns>
        public static explicit operator uint(Half value) { return (uint)(float)value; }
        /// <summary>
        /// Converts a Fox.Kernel.Half to a 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Fox.Kernel.Half to convert.</param>
        /// <returns>A 64-bit unsigned integer that represents the converted Fox.Kernel.Half.</returns>
        public static explicit operator ulong(Half value) { return (ulong)(float)value; }
        #endregion

        /// <summary>
        /// Compares this instance to a specified Fox.Kernel.Half object.
        /// </summary>
        /// <param name="other">A Fox.Kernel.Half object.</param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and value.
        /// Return Value Meaning Less than zero This instance is less than value. Zero
        /// This instance is equal to value. Greater than zero This instance is greater than value.
        /// </returns>
        public int CompareTo(Half other)
        {
            int result = 0;
            if (this < other)
            {
                result = -1;
            }
            else if (this > other)
            {
                result = 1;
            }
            else if (this != other)
            {
                if (!IsNaN(this))
                {
                    result = 1;
                }
                else if (!IsNaN(other))
                {
                    result = -1;
                }
            }

            return result;
        }
        /// <summary>
        /// Compares this instance to a specified System.Object.
        /// </summary>
        /// <param name="obj">An System.Object or null.</param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and value.
        /// Return Value Meaning Less than zero This instance is less than value. Zero
        /// This instance is equal to value. Greater than zero This instance is greater
        /// than value. -or- value is null.
        /// </returns>
        /// <exception cref="System.ArgumentException">value is not a Fox.Kernel.Half</exception>
        public int CompareTo(object obj)
        {
            int result = 0;
            if (obj == null)
            {
                result = 1;
            }
            else
            {
                if (obj is Half)
                {
                    result = CompareTo((Half)obj);
                }
                else
                {
                    throw new ArgumentException("Object must be of type Half.");
                }
            }

            return result;
        }
        /// <summary>
        /// Returns a value indicating whether this instance and a specified Fox.Kernel.Half object represent the same value.
        /// </summary>
        /// <param name="other">A Fox.Kernel.Half object to compare to this instance.</param>
        /// <returns>true if value is equal to this instance; otherwise, false.</returns>
        public bool Equals(Half other)
        {
            return ((other == this) || (IsNaN(other) && IsNaN(this)));
        }
        /// <summary>
        /// Returns a value indicating whether this instance and a specified System.Object
        /// represent the same type and value.
        /// </summary>
        /// <param name="obj">An System.Object.</param>
        /// <returns>true if value is a Fox.Kernel.Half and equal to this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is Half)
            {
                Half half = (Half)obj;
                if ((half == this) || (IsNaN(half) && IsNaN(this)))
                {
                    result = true;
                }
            }

            return result;
        }
        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
        /// <summary>
        /// Returns the System.TypeCode for value type Fox.Kernel.Half.
        /// </summary>
        /// <returns>The enumerated constant (TypeCode)255.</returns>
        public TypeCode GetTypeCode()
        {
            return (TypeCode)255;
        }

        #region BitConverter & Math methods for Half
        /// <summary>
        /// Returns the specified half-precision floating point value as an array of bytes.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 2.</returns>
        public static byte[] GetBytes(Half value)
        {
            return BitConverter.GetBytes(value.value);
        }
        /// <summary>
        /// Converts the value of a specified instance of Fox.Kernel.Half to its equivalent binary representation.
        /// </summary>
        /// <param name="value">A Fox.Kernel.Half value.</param>
        /// <returns>A 16-bit unsigned integer that contain the binary representation of value.</returns>        
        public static ushort GetBits(Half value)
        {
            return value.value;
        }
        /// <summary>
        /// Returns a half-precision floating point number converted from two bytes
        /// at a specified position in a byte array.
        /// </summary>
        /// <param name="value">An array of bytes.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <returns>A half-precision floating point number formed by two bytes beginning at startIndex.</returns>
        /// <exception cref="System.ArgumentException">
        /// startIndex is greater than or equal to the length of value minus 1, and is
        /// less than or equal to the length of value minus 1.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">value is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">startIndex is less than zero or greater than the length of value minus 1.</exception>
        public static Half ToHalf(byte[] value, int startIndex)
        {
            return Half.ToHalf((ushort)BitConverter.ToInt16(value, startIndex));
        }
        /// <summary>
        /// Returns a half-precision floating point number converted from its binary representation.
        /// </summary>
        /// <param name="bits">Binary representation of Fox.Kernel.Half value</param>
        /// <returns>A half-precision floating point number formed by its binary representation.</returns>
        public static Half ToHalf(ushort bits)
        {
            return new Half { value = bits };
        }

        /// <summary>
        /// Returns a value indicating the sign of a half-precision floating-point number.
        /// </summary>
        /// <param name="value">A signed number.</param>
        /// <returns>
        /// A number indicating the sign of value. Number Description -1 value is less
        /// than zero. 0 value is equal to zero. 1 value is greater than zero.
        /// </returns>
        /// <exception cref="System.ArithmeticException">value is equal to Fox.Kernel.Half.NaN.</exception>
        public static int Sign(Half value)
        {
            if (value < 0)
            {
                return -1;
            }
            else if (value > 0)
            {
                return 1;
            }
            else
            {
                if (value != 0)
                {
                    throw new ArithmeticException("Function does not accept floating point Not-a-Number values.");
                }
            }

            return 0;
        }
        /// <summary>
        /// Returns the absolute value of a half-precision floating-point number.
        /// </summary>
        /// <param name="value">A number in the range Fox.Kernel.Half.MinValue ≤ value ≤ Fox.Kernel.Half.MaxValue.</param>
        /// <returns>A half-precision floating-point number, x, such that 0 ≤ x ≤Fox.Kernel.Half.MaxValue.</returns>
        public static Half Abs(Half value)
        {
            return HalfConversions.Abs(value);
        }
        /// <summary>
        /// Returns the larger of two half-precision floating-point numbers.
        /// </summary>
        /// <param name="value1">The first of two half-precision floating-point numbers to compare.</param>
        /// <param name="value2">The second of two half-precision floating-point numbers to compare.</param>
        /// <returns>
        /// Parameter value1 or value2, whichever is larger. If value1, or value2, or both val1
        /// and value2 are equal to Fox.Kernel.Half.NaN, Fox.Kernel.Half.NaN is returned.
        /// </returns>
        public static Half Max(Half value1, Half value2)
        {
            return (value1 < value2) ? value2 : value1;
        }
        /// <summary>
        /// Returns the smaller of two half-precision floating-point numbers.
        /// </summary>
        /// <param name="value1">The first of two half-precision floating-point numbers to compare.</param>
        /// <param name="value2">The second of two half-precision floating-point numbers to compare.</param>
        /// <returns>
        /// Parameter value1 or value2, whichever is smaller. If value1, or value2, or both val1
        /// and value2 are equal to Fox.Kernel.Half.NaN, Fox.Kernel.Half.NaN is returned.
        /// </returns>
        public static Half Min(Half value1, Half value2)
        {
            return (value1 < value2) ? value1 : value2;
        }
        #endregion

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to not a number (Fox.Kernel.Half.NaN).
        /// </summary>
        /// <param name="half">A half-precision floating-point number.</param>
        /// <returns>true if value evaluates to not a number (Fox.Kernel.Half.NaN); otherwise, false.</returns>
        public static bool IsNaN(Half half)
        {
            return float.IsNaN(half);
        }

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to negative or positive infinity.
        /// </summary>
        /// <param name="half">A half-precision floating-point number.</param>
        /// <returns>true if half evaluates to Fox.Kernel.Half.PositiveInfinity or Fox.Kernel.Half.NegativeInfinity; otherwise, false.</returns>
        public static bool IsInfinity(Half half)
        {
            return float.IsInfinity(half);
        }

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to negative infinity.
        /// </summary>
        /// <param name="half">A half-precision floating-point number.</param>
        /// <returns>true if half evaluates to Fox.Kernel.Half.NegativeInfinity; otherwise, false.</returns>
        public static bool IsNegativeInfinity(Half half)
        {
            return float.IsNegativeInfinity(half);
        }

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to positive infinity.
        /// </summary>
        /// <param name="half">A half-precision floating-point number.</param>
        /// <returns>true if half evaluates to Fox.Kernel.Half.PositiveInfinity; otherwise, false.</returns>
        public static bool IsPositiveInfinity(Half half)
        {
            return float.IsPositiveInfinity(half);
        }

        #region String operations (Parse and ToString)
        /// <summary>
        /// Converts the string representation of a number to its Fox.Kernel.Half equivalent.
        /// </summary>
        /// <param name="value">The string representation of the number to convert.</param>
        /// <returns>The Fox.Kernel.Half number equivalent to the number contained in value.</returns>
        /// <exception cref="System.ArgumentNullException">value is null.</exception>
        /// <exception cref="System.FormatException">value is not in the correct format.</exception>
        /// <exception cref="System.OverflowException">value represents a number less than Fox.Kernel.Half.MinValue or greater than Fox.Kernel.Half.MaxValue.</exception>
        public static Half Parse(string value)
        {
            return (Half)float.Parse(value, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the string representation of a number to its Fox.Kernel.Half equivalent 
        /// using the specified culture-specific format information.
        /// </summary>
        /// <param name="value">The string representation of the number to convert.</param>
        /// <param name="provider">An System.IFormatProvider that supplies culture-specific parsing information about value.</param>
        /// <returns>The Fox.Kernel.Half number equivalent to the number contained in s as specified by provider.</returns>
        /// <exception cref="System.ArgumentNullException">value is null.</exception>
        /// <exception cref="System.FormatException">value is not in the correct format.</exception>
        /// <exception cref="System.OverflowException">value represents a number less than Fox.Kernel.Half.MinValue or greater than Fox.Kernel.Half.MaxValue.</exception>
        public static Half Parse(string value, IFormatProvider provider)
        {
            return (Half)float.Parse(value, provider);
        }

        /// <summary>
        /// Converts the string representation of a number in a specified style to its Fox.Kernel.Half equivalent.
        /// </summary>
        /// <param name="value">The string representation of the number to convert.</param>
        /// <param name="style">
        /// A bitwise combination of System.Globalization.NumberStyles values that indicates
        /// the style elements that can be present in value. A typical value to specify is
        /// System.Globalization.NumberStyles.Number.
        /// </param>
        /// <returns>The Fox.Kernel.Half number equivalent to the number contained in s as specified by style.</returns>
        /// <exception cref="System.ArgumentNullException">value is null.</exception>
        /// <exception cref="System.ArgumentException">
        /// style is not a System.Globalization.NumberStyles value. -or- style is the
        /// System.Globalization.NumberStyles.AllowHexSpecifier value.
        /// </exception>
        /// <exception cref="System.FormatException">value is not in the correct format.</exception>
        /// <exception cref="System.OverflowException">value represents a number less than Fox.Kernel.Half.MinValue or greater than Fox.Kernel.Half.MaxValue.</exception>
        public static Half Parse(string value, NumberStyles style)
        {
            return (Half)float.Parse(value, style, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the string representation of a number to its Fox.Kernel.Half equivalent 
        /// using the specified style and culture-specific format.
        /// </summary>
        /// <param name="value">The string representation of the number to convert.</param>
        /// <param name="style">
        /// A bitwise combination of System.Globalization.NumberStyles values that indicates
        /// the style elements that can be present in value. A typical value to specify is 
        /// System.Globalization.NumberStyles.Number.
        /// </param>
        /// <param name="provider">An System.IFormatProvider object that supplies culture-specific information about the format of value.</param>
        /// <returns>The Fox.Kernel.Half number equivalent to the number contained in s as specified by style and provider.</returns>
        /// <exception cref="System.ArgumentNullException">value is null.</exception>
        /// <exception cref="System.ArgumentException">
        /// style is not a System.Globalization.NumberStyles value. -or- style is the
        /// System.Globalization.NumberStyles.AllowHexSpecifier value.
        /// </exception>
        /// <exception cref="System.FormatException">value is not in the correct format.</exception>
        /// <exception cref="System.OverflowException">value represents a number less than Fox.Kernel.Half.MinValue or greater than Fox.Kernel.Half.MaxValue.</exception>
        public static Half Parse(string value, NumberStyles style, IFormatProvider provider)
        {
            return (Half)float.Parse(value, style, provider);
        }

        /// <summary>
        /// Converts the string representation of a number to its Fox.Kernel.Half equivalent.
        /// A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="value">The string representation of the number to convert.</param>
        /// <param name="result">
        /// When this method returns, contains the Fox.Kernel.Half number that is equivalent
        /// to the numeric value contained in value, if the conversion succeeded, or is zero
        /// if the conversion failed. The conversion fails if the s parameter is null,
        /// is not a number in a valid format, or represents a number less than Fox.Kernel.Half.MinValue
        /// or greater than Fox.Kernel.Half.MaxValue. This parameter is passed uninitialized.
        /// </param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryParse(string value, out Half result)
        {
            float f;
            if (float.TryParse(value, out f))
            {
                result = (Half)f;
                return true;
            }

            result = new Half();
            return false;
        }

        /// <summary>
        /// Converts the string representation of a number to its Fox.Kernel.Half equivalent
        /// using the specified style and culture-specific format. A return value indicates
        /// whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="value">The string representation of the number to convert.</param>
        /// <param name="style">
        /// A bitwise combination of System.Globalization.NumberStyles values that indicates
        /// the permitted format of value. A typical value to specify is System.Globalization.NumberStyles.Number.
        /// </param>
        /// <param name="provider">An System.IFormatProvider object that supplies culture-specific parsing information about value.</param>
        /// <param name="result">
        /// When this method returns, contains the Fox.Kernel.Half number that is equivalent
        /// to the numeric value contained in value, if the conversion succeeded, or is zero
        /// if the conversion failed. The conversion fails if the s parameter is null,
        /// is not in a format compliant with style, or represents a number less than
        /// Fox.Kernel.Half.MinValue or greater than Fox.Kernel.Half.MaxValue. This parameter is passed uninitialized.
        /// </param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        /// <exception cref="System.ArgumentException">
        /// style is not a System.Globalization.NumberStyles value. -or- style 
        /// is the System.Globalization.NumberStyles.AllowHexSpecifier value.
        /// </exception>
        public static bool TryParse(string value, NumberStyles style, IFormatProvider provider, out Half result)
        {
            bool parseResult = false;
            float f;
            if (float.TryParse(value, style, provider, out f))
            {
                result = (Half)f;
                parseResult = true;
            }
            else
            {
                result = new Half();
            }

            return parseResult;
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>A string that represents the value of this instance.</returns>
        public override string ToString()
        {
            return ((float)this).ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation
        /// using the specified culture-specific format information.
        /// </summary>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <returns>The string representation of the value of this instance as specified by provider.</returns>
        public string ToString(IFormatProvider formatProvider)
        {
            return ((float)this).ToString(formatProvider);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation, using the specified format.
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <returns>The string representation of the value of this instance as specified by format.</returns>
        public string ToString(string format)
        {
            return ((float)this).ToString(format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation 
        /// using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <returns>The string representation of the value of this instance as specified by format and provider.</returns>
        /// <exception cref="System.FormatException">format is invalid.</exception>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return ((float)this).ToString(format, formatProvider);
        }
        #endregion

        #region IConvertible Members
        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return (float)this;
        }
        TypeCode IConvertible.GetTypeCode()
        {
            return GetTypeCode();
        }
        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean((float)this);
        }
        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte((float)this);
        }
        char IConvertible.ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException(string.Format(CultureInfo.CurrentCulture, "Invalid cast from '{0}' to '{1}'.", "Half", "Char"));
        }
        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException(string.Format(CultureInfo.CurrentCulture, "Invalid cast from '{0}' to '{1}'.", "Half", "DateTime"));
        }
        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal((float)this);
        }
        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble((float)this);
        }
        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16((float)this);
        }
        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32((float)this);
        }
        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64((float)this);
        }
        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte((float)this);
        }
        string IConvertible.ToString(IFormatProvider provider)
        {
            return Convert.ToString((float)this, CultureInfo.InvariantCulture);
        }
        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return (((float)this) as IConvertible).ToType(conversionType, provider);
        }
        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16((float)this);
        }
        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32((float)this);
        }
        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64((float)this);
        }
        #endregion
    }

        //[Serializable]
        //public static class HalfBitConverter
        //{
        //    public static float ToFloat(Half value)
        //    {
        //        uint tempA = (uint)value.value << 0x10;
        //        uint tempB;
        //        if ((tempA & 0x7fffffff) == 0)
        //            tempB = 0;
        //        else
        //            tempB = tempA & 0xb8000000 | 0x38000000;

        //        tempA = ((tempA & 0x7fffffff) >> 3) + tempB;

        //        return BitConverter.Int32BitsToSingle((int)tempA);
        //    }

        //    public static Half ToHalf(float value)
        //    {
        //        uint uValue = (uint)BitConverter.SingleToInt32Bits(value);

        //        uint tempA = uValue & 0x7fffffffu;
        //        uint tempB;
        //        if (0x47ffffffu < tempA)
        //            tempA = 0x47ffffffu;

        //        if (tempA < 0x38000000u)
        //            tempB = 0;
        //        else
        //            tempB = (ushort)(tempA * 8 + 0x40000000u >> 0x10);

        //        return new Half { value = (ushort)(tempB | (ushort)(uValue >> 0x10) & 0x8000u) };
        //    }

        //    public static Half FromUInt16(ushort value)
        //    {
        //        return new Half { value = value };
        //    }

        //    public static ushort ToUInt16(Half value)
        //    {
        //        return value.value;
        //    }
        //}
    }