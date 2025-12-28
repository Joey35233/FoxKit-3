using System;
using System.Runtime.InteropServices;
using Fox;

namespace Fox.Anim
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct MtarTableList
    {
        public PathCode Path;
        public uint TracksOffset;
        private ushort _TracksDataSize; public uint TracksDataSize => (uint)_TracksDataSize << 4;
        public ushort Unknown;
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct MtarTableList2
    {
        public PathCode Path;
        
        public uint TracksOffset;
        private ushort _UnitTracksDataSize; public uint UnitTracksDataSize => (uint)_UnitTracksDataSize << 4;
        
        public ushort _MotionPointTracksOffset; public uint MotionPointTracksOffset => (uint)_MotionPointTracksOffset << 4;
        private ushort _MotionPointTracksDataSize; public uint MotionPointTracksDataSize => (uint)_MotionPointTracksDataSize << 4;
        
        public ushort _ShaderTracksOffset; public uint ShaderTracksOffset => (uint)_ShaderTracksOffset << 4;
        private ushort _ShaderTracksDataSize; public uint ShaderTracksDataSize => (uint)_ShaderTracksDataSize << 4;
        public ushort Padding0;
        
        public uint MotionEventsOffset;

        public uint Padding1;
    };
    
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct MtarMiniDataNode
    {
        public StrCode32 Name;

        public uint DataSize;

        public uint NextNodeOffset;

        public uint Padding;

        public MtarMiniDataNode* Find(StrCode32 name)
        {
            fixed (MtarMiniDataNode* thisPtr = &this)
            {
                byte* selfPtr = (byte*)thisPtr;

                if (Name == name)
                    return (MtarMiniDataNode*)selfPtr;

                if (NextNodeOffset == 0)
                    return null;

                return ((MtarMiniDataNode*)(selfPtr + NextNodeOffset))->Find(name);
            }
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct MotionPointList2
    {
        public StrCode32 Name;

        public StrCode32 ParentName;
    };

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct MtarHeader
    {
        public uint Version;

        public uint FileCount;

        public ushort UnitCount;

        public ushort SegmentCount;

        public ushort ShaderNodeCount;

        public ushort ShaderUnitCount;

        public ushort MotionPointUnitCount;

        [Flags]
        public enum MtarFlags : ushort
        {
            New = 0x1000,

            HasSkelList = 0x4000,
        }
        public MtarFlags Flags;

        public uint CommonInfoOffset;

        public ulong Padding;
    };
}