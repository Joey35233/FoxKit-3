using System.Runtime.InteropServices;
using Fox.Kernel;

namespace Fox.Anim
{
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct TrackUnit
    {
        public enum UnitFlags : byte
        {
            Loop = 1 << 0,
            HermiteVectorInterpolation = 1 << 1,
            NoFrames = 1 << 2,
        };
        
        public StrCode32 Name;

        public byte SegmentCount;

        public UnitFlags Flags;

        public ushort Padding;

        public TrackData* GetData(uint segmentIndex)
        {
            if (segmentIndex >= SegmentCount)
                return null;

            fixed (TrackUnit* thisPtr = &this)
            {
                byte* selfPtr = (byte*)thisPtr;

                TrackData* trackData = (TrackData*)(selfPtr + sizeof(TrackUnit));

                uint i = 0;
                while (i++ != segmentIndex)
                    trackData = (TrackData*)((byte*)trackData + trackData->NextEntryOffset);

                return trackData;
            }
        }
    }
}