using System;

namespace Fox.Kernel
{
    public enum Endianness
    {
        LittleEndian,
        BigEndian,
    }

    public static class EndiannessBitConverter
    {
        public static short FlipEndianness(short value) => unchecked((short)FlipEndianness(unchecked((ushort)value)));
        public static ushort FlipEndianness(ushort value)
        {
            byte a = (byte)((value >> 0) & 0xFF);
            byte b = (byte)((value >> 8) & 0xFF);

            return (ushort)(((ushort)b << 8) | ((ushort)a << 0));
        }

        public static int FlipEndianness(int value) => unchecked((int)FlipEndianness(unchecked((uint)value)));
        public static uint FlipEndianness(uint value)
        {
            byte a = (byte)((value >> 0) & 0xFF);
            byte b = (byte)((value >> 8) & 0xFF);
            byte c = (byte)((value >> 16) & 0xFF);
            byte d = (byte)((value >> 24) & 0xFF);

            return ((uint)a << 24) | ((uint)b << 16) | ((uint)c << 8) | ((uint)d << 0);
        }

        public static long FlipEndianness(long value) => unchecked((long)FlipEndianness(unchecked((ulong)value)));
        public static ulong FlipEndianness(ulong value)
        {
            byte a = (byte)((value >> 0) & 0xFF);
            byte b = (byte)((value >> 8) & 0xFF);
            byte c = (byte)((value >> 16) & 0xFF);
            byte d = (byte)((value >> 24) & 0xFF);
            byte e = (byte)((value >> 32) & 0xFF);
            byte f = (byte)((value >> 40) & 0xFF);
            byte g = (byte)((value >> 48) & 0xFF);
            byte h = (byte)((value >> 56) & 0xFF);

            return ((ulong)a << 56) | ((ulong)b << 48) | ((ulong)c << 40) | ((ulong)d << 32) | ((ulong)e << 24) | ((ulong)f << 16) | ((ulong)g << 8) | ((ulong)h << 0);
        }

        //public static Half FlipEndianness(Half value)
        //{
        //    return Half.ToHalf(FlipEndianness((ushort)(value.GetHashCode() & 0xFFFF)));
        //}

        public static float FlipEndianness(float value)
        {
            return BitConverter.Int32BitsToSingle(FlipEndianness(BitConverter.SingleToInt32Bits(value)));
        }

        public static double FlipEndianness(double value)
        {
            return BitConverter.Int64BitsToDouble(FlipEndianness(BitConverter.DoubleToInt64Bits(value)));
        }
    }
}
