using System;

namespace Fox.Fs
{
    public static class EndianessBitConverter
    {
        private static byte[] FlipEndianess(byte[] b)
        {
            Array.Reverse(b);
            return b;
        }

        public static short FlipEndianess(short value) => unchecked((short)FlipEndianess(unchecked((ushort)value)));
        public static ushort FlipEndianess(ushort value)
        {
            byte a = (byte)((value >> 0) & 0xFF);
            byte b = (byte)((value >> 8) & 0xFF);

            return (ushort)(((ushort)b << 8) | ((ushort)a << 0));
        }

        public static int FlipEndianess(int value) => unchecked((int)FlipEndianess(unchecked((uint)value)));
        public static uint FlipEndianess(uint value)
        {
            byte a = (byte)((value >> 0) & 0xFF);
            byte b = (byte)((value >> 8) & 0xFF);
            byte c = (byte)((value >> 16) & 0xFF);
            byte d = (byte)((value >> 24) & 0xFF);

            return ((uint)a << 24) | ((uint)b << 16) | ((uint)c << 8) | ((uint)d << 0);
        }

        public static long FlipEndianess(long value) => unchecked((long)FlipEndianess(unchecked((ulong)value)));
        public static ulong FlipEndianess(ulong value)
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
    }
}
