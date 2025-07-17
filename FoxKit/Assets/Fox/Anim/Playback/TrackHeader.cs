using System.Runtime.InteropServices;

namespace Fox.Anim
{
    
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct TrackHeader
    {
        public uint ChannelCount;

        public uint TrackCount;

        public ushort HeaderIndex; // Used in SAND. In GANI, 0 for FK, 1 for IK

        public byte Unknown;

        public byte Flag;

        public uint FrameCount;

        public uint TickBase;

        public TrackUnit* GetUnit(uint channelIndex)
        {
            if (channelIndex >= ChannelCount)
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