﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Debug = UnityEngine.Debug;

namespace Fox.Core
{
    [StructLayout(LayoutKind.Sequential, Size = SelfSize)]
    public unsafe struct FoxDataNodeAttribute
    {
        public const int SelfSize = 0x10;
        
        public enum DataType : ushort
        {
            UInt = 0,
            String = 1,
            Float = 2,
        }

        public DataType Type;
        public short NextParameterOffset;
        public FoxDataString Name;

        private const uint ValueOffset = 12;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private FoxDataNodeAttribute* GetSelfPointer()
        {
            fixed (FoxDataNodeAttribute* selfPtr = &this)
            {
                return selfPtr;
            }
        }

        public uint GetUIntValue()
        {
            Debug.Assert(Type == DataType.UInt);

            return *(uint*)((byte*)GetSelfPointer() + ValueOffset);
        }

        public float GetFloatValue()
        {
            Debug.Assert(Type == DataType.Float);

            return *(float*)((byte*)GetSelfPointer() + ValueOffset);
        }

        public FoxDataString* GetStringValue()
        {
            Debug.Assert(Type == DataType.String);

            return (FoxDataString*)((byte*)GetSelfPointer() + ValueOffset);
        }

        public FoxDataNodeAttribute* GetNext() => NextParameterOffset == 0 ? null : (FoxDataNodeAttribute*)((byte*)GetSelfPointer() + NextParameterOffset);
    }
}