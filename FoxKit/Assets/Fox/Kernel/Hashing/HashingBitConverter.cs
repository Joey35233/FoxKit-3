using System;
using System.IO;
using UnityEngine;

namespace Fox.Kernel
{
    public static class HashingBitConverter
    {
        public static StrCode ToStrCode(ulong value)
        {
            return new StrCode(value);
        }
        public static StrCode ToStrCode(byte[] value, int startIndex)
        {
            return new StrCode(BitConverter.ToUInt64(value, startIndex));
        }
        public static StrCode ToStrCode(ReadOnlySpan<byte> value)
        {
            return new StrCode(BitConverter.ToUInt64(value));
        }
        public static ulong StrCodeToUInt64(StrCode hash)
        {
            return hash.Backing;
        }

        public static StrCode32 ToStrCode32(uint value)
        {
            return new StrCode32(value);
        }
        public static StrCode32 ToStrCode32(byte[] value, int startIndex)
        {
            return new StrCode32(BitConverter.ToUInt32(value, startIndex));
        }
        public static StrCode32 ToStrCode32(ReadOnlySpan<byte> value)
        {
            return new StrCode32(BitConverter.ToUInt32(value));
        }
        public static uint StrCode32ToUInt32(StrCode32 hash)
        {
            return hash.Backing;
        }
    }
}