using System.Runtime.InteropServices;

namespace Fox.Anim
{
    
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct TrackHeader
    {
        public uint UnitCount;

        public uint SegmentCount;

        public ushort Id;

        public byte UnknownA;
        public byte UnknownB;

        public uint FrameCount;

        public uint FrameRate;

        public TrackUnit* GetUnit(uint channelIndex)
        {
            if (channelIndex >= UnitCount)
                return null;
            
            fixed (TrackHeader* thisPtr = &this)
            {
                byte* selfPtr = (byte*)thisPtr;

                uint* unitOffsets = (uint*)(selfPtr + sizeof(TrackHeader));

                return (TrackUnit*)(selfPtr + unitOffsets[channelIndex]);
            }
        }
    };
}