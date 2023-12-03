using Fox.Fio;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.UIElements;
using String = Fox.Kernel.String;

namespace Fox.Core
{
    [StructLayout(LayoutKind.Sequential, Size = 0x20)]
    public unsafe struct FoxDataHeader
    {
        public uint Version;
        public uint NodesOffset;
        public uint FileSize;
        public FoxDataString Name;

        public uint Flags;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private FoxDataHeader* GetSelfPointer()
        {
            fixed (FoxDataHeader* selfPtr = &this)
            {
                return selfPtr;
            }
        }

        public FoxDataNode* GetNodes() => NodesOffset == 0 ? null : (FoxDataNode*)((byte*)GetSelfPointer() + NodesOffset);
    }
}