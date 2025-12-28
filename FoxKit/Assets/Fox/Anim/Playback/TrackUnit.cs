using System.Runtime.InteropServices;
using Fox;

namespace Fox.Anim
{
    public enum UnitFlags : byte
    {
        Loop = 1 << 0,
        HermiteVectorInterpolation = 1 << 1,
        IsStatic = 1 << 2,
    };
    
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct TrackUnit
    {
        
        public StrCode32 Name;

        public byte SegmentCount;

        public UnitFlags Flags;

        private ushort _Padding;

        public TrackData* GetSegment(uint id)
        {
            fixed (TrackUnit* thisPtr = &this)
            {
                byte* selfPtr = (byte*)thisPtr;

                TrackData* segment = (TrackData*)(selfPtr + sizeof(TrackUnit));

                while (segment->SegmentId != id)
                    segment = (TrackData*)((byte*)segment + segment->NextEntryOffset);

                return segment;
            }
        }
    }
}