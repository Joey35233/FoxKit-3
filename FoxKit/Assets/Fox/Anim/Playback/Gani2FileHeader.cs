using System.Runtime.InteropServices;
using Fox;

namespace Fox.Anim
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Gani2Param
    {
        public StrCode32 Name;
        public float Value;
    };
    
    [StructLayout(LayoutKind.Sequential)]
    internal struct Gani2TrackData
    {
        private uint Packed_ComponentBitSize_DataOffset;
        public uint ComponentBitSize => Packed_ComponentBitSize_DataOffset & 0xFF;
        public uint DataOffset => (Packed_ComponentBitSize_DataOffset >> 8);
    };

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct Gani2TrackHeader
    {
        public uint FrameCount;

        public byte Padding0;

        public byte ParamCount;

        public ushort Padding1;

        public bool TryGetParam(StrCode32 name, out float outValue)
        {
            fixed (Gani2TrackHeader* thisPtr = &this)
            {
                byte* selfPtr = (byte*)thisPtr;

                for (uint i = 0; i < ParamCount; i++)
                {
                    Gani2Param* param = (Gani2Param*)(selfPtr + sizeof(Gani2TrackHeader)) + i;
                    if (param->Name == name)
                    {
                        outValue = param->Value;
                        return true;
                    }
                }
            }

            outValue = 0.0f;
            return false;
        }

        public TrackUnit.UnitFlags GetUnitFlags(uint index)
        {
            fixed (Gani2TrackHeader* thisPtr = &this)
            {
                byte* selfPtr = (byte*)thisPtr;

                TrackUnit.UnitFlags* flagsPtr =
                    (TrackUnit.UnitFlags*)(selfPtr + sizeof(Gani2TrackHeader) + ParamCount * sizeof(Gani2Param));
                
                return flagsPtr[index];
            }
        }
    };
}