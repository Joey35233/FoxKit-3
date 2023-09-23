using System;

namespace Fox.Kernel
{
    public static class HashingBitConverter
    {
        public static StrCode ToStrCode(ulong value) => new(value);
        public static StrCode ToStrCode(byte[] value, int startIndex) => new(BitConverter.ToUInt64(value, startIndex));
        public static StrCode ToStrCode(ReadOnlySpan<byte> value) => new(BitConverter.ToUInt64(value));
        public static ulong StrCodeToUInt64(StrCode hash) => hash.Backing;

        public static StrCode32 ToStrCode32(uint value) => new(value);
        public static StrCode32 ToStrCode32(byte[] value, int startIndex) => new(BitConverter.ToUInt32(value, startIndex));
        public static StrCode32 ToStrCode32(ReadOnlySpan<byte> value) => new(BitConverter.ToUInt32(value));
        public static uint StrCode32ToUInt32(StrCode32 hash) => hash.Backing;

        public static PathFileNameAndExtCode ToPathFileNameAndExtCode(ulong value) => new(value);
        public static ulong PathFileNameAndExtCodeToUInt64(PathFileNameAndExtCode hash) => hash.Backing;
    }
}