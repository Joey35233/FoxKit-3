using System.Runtime.InteropServices;

namespace Fox.Anim
{
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct TrackHeader
    {
        public uint UnitCount;

        public uint SegmentCount;

        public ushort TrackId;

        public byte UnknownA;
        public byte UnknownB;

        public uint FrameCount;

        public uint FrameRate;

        public TrackUnit* GetUnit(uint unitIndex)
        {
            if (unitIndex >= UnitCount)
                return null;
            
            fixed (TrackHeader* thisPtr = &this)
            {
                byte* selfPtr = (byte*)thisPtr;

                uint* unitOffsets = (uint*)(selfPtr + sizeof(TrackHeader));

                return (TrackUnit*)(selfPtr + unitOffsets[unitIndex]);
            }
        }
    };
    
    [StructLayout(LayoutKind.Sequential)]
    internal struct TrackMiniParam
    {
        public StrCode32 Name;
        public float Value;
    };
    
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct TrackMiniHeader
    {
        public uint FrameCount;

        private byte Padding0;
        public byte ParamCount;
        private ushort Padding1;
        
        // public bool TryGetParam(StrCode32 name, out float outValue)
        // {
        //     fixed (TrackMiniHeader* thisPtr = &this)
        //     {
        //         byte* selfPtr = (byte*)thisPtr;
        //
        //         for (uint i = 0; i < ParamCount; i++)
        //         {
        //             GaniMiniParam* param = (GaniMiniParam*)(selfPtr + sizeof(TrackMiniHeader)) + i;
        //             if (param->Name == name)
        //             {
        //                 outValue = param->Value;
        //                 return true;
        //             }
        //         }
        //     }
        //
        //     outValue = 0.0f;
        //     return false;
        // }

        // public TrackUnit.Flags GetUnitFlags(uint unitIndex)
        // {
        //     fixed (TrackMiniHeader* thisPtr = &this)
        //     {
        //         byte* data = (byte*)(thisPtr + 1) + ParamCount * sizeof(TrackMiniParam);
        //
        //         TrackUnit.Flags* flags = (TrackUnit.Flags*)data;
        //
        //         return flags[unitIndex];
        //     }
        // }
    };
    
    
}