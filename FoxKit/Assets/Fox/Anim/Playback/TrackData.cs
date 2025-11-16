using System;
using System.Runtime.InteropServices;
using UnityEngine;
using Math = Fox.Math;

namespace Fox.Anim
{
    internal enum TrackType : byte
    {
        Quat = 0,
        Float = 1,
        Vector2 = 2,
        Vector3 = 3,
        Vector4 = 4,
        QuatDiff = 5,
        VectorDiff = 6,
    }
    
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct TrackData
    {
        public const float PlaybackRate = 1.0f / (float)(60.0 * 1000.0 / 1001.0);

        public int DataOffset;

        public short Id;

        private byte Packed_Type_NextEntryOffset;
        public TrackType Type => (TrackType)(Packed_Type_NextEntryOffset & 0xF);
        public byte NextEntryOffset => (byte)(Packed_Type_NextEntryOffset >> 4 & 0x8);

        public byte ComponentBitSize;

        public static uint ReadUnalignedBits(ushort* buffer, ref ulong inoutBitstreamPos, int bitSize)
        {
            ulong baseIndex = inoutBitstreamPos >> 4; // Bit pos to ushort pos
            int startPosInBits = (int)(inoutBitstreamPos - (baseIndex << 4)); // [0, 16)

            ulong lowerIndex = baseIndex;
            int lowerShortBitOffset = startPosInBits;
            int lowerShortBitCount = bitSize > (16 - lowerShortBitOffset) ? 16 - lowerShortBitOffset : bitSize;
		
            ulong upperIndex = baseIndex + (lowerShortBitCount < bitSize ? 1u : 0u);
            int upperShortBitOffset = 0;
            int upperShortBitCount = bitSize - lowerShortBitCount;

            ushort mask;

            mask = unchecked((ushort)-1);
            mask >>= (16 - lowerShortBitCount);
            ushort lowerValue = (ushort)(buffer[lowerIndex] >> lowerShortBitOffset);
            lowerValue &= mask;

            mask = unchecked((ushort)-1);
            mask >>= (16 - upperShortBitCount);
            ushort upperValue = (ushort)(buffer[upperIndex] >> upperShortBitOffset);
            upperValue &= mask;

            uint value = lowerValue | ((uint)upperValue << lowerShortBitCount);

            inoutBitstreamPos += (uint)bitSize;

            return value;
        }

        public static Quaternion ReadUnalignedQuaternion(ushort* buffer, ref ulong inoutBitstreamPos, uint bitSize)
        {
            uint denominator = (1u << (int)bitSize) - 1;

            float halfTheta = (float)ReadUnalignedBits(buffer, ref inoutBitstreamPos, (int)bitSize) / denominator * Mathf.PI / 2; // Map to half-angle range for quaternion
		
            float X = (float)ReadUnalignedBits(buffer, ref inoutBitstreamPos, (int)bitSize) / denominator;
            float Y = (float)ReadUnalignedBits(buffer, ref inoutBitstreamPos, (int)bitSize) / denominator;
            float Z = 1.0f - X - Y;
		
            float len = Mathf.Sqrt(X*X + Y*Y + Z*Z);

            X /= len;
            Y /= len;
            Z /= len;

            if (ReadUnalignedBits(buffer, ref inoutBitstreamPos, 1) > 0)
                X = -X;
            if (ReadUnalignedBits(buffer, ref inoutBitstreamPos, 1) > 0)
                Y = -Y;
            if (ReadUnalignedBits(buffer, ref inoutBitstreamPos, 1) > 0)
                Z = -Z;

            // Handedness
            X = -X;
            halfTheta = -halfTheta;

            float a = Mathf.Sin(halfTheta);
            float b = Mathf.Cos(halfTheta);

            Quaternion result = new Quaternion(a * X, a * Y, a * Z, b);

            //result = Math.FoxToUnityQuaternion(result);

            return result;
        }
    }
}