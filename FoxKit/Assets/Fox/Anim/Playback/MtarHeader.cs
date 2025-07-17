using System;
using System.Runtime.InteropServices;
using Fox;

namespace Fox.Anim
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct MtarFileHeader
    {
        public PathCode Path;
        public uint DataOffset;
        public ushort DataSize;
        public ushort Unknown;
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct Mtar2FileHeader
    {
        public PathCode Path;
        public uint DataOffset;
        public ushort DataSize;

        public ushort FkDataOffset;
        public uint FkDataSize;

        public uint Padding0;
        public uint MotionEventsOffset;

        public uint Padding1;
    };
    
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct Mtar2MiniDataNode
    {
        public StrCode32 Name;

        public uint DataSize;

        public uint NextNodeOffset;

        public uint Padding;

        public Mtar2MiniDataNode* Find(StrCode32 name)
        {
            fixed (Mtar2MiniDataNode* thisPtr = &this)
            {
                byte* selfPtr = (byte*)thisPtr;

                if (Name == name)
                    return (Mtar2MiniDataNode*)selfPtr;

                if (NextNodeOffset == 0)
                    return null;

                return ((Mtar2MiniDataNode*)(selfPtr + NextNodeOffset))->Find(name);
            }
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct MtarMTPBoneAssociation
    {
        public StrCode32 MTPName;

        public StrCode32 BoneName;
    };

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct MtarHeader
    {
        public uint Version;

        public uint FileCount;

        public ushort TrackCount; // Same as FRIG's RigUnit count

        public ushort SegmentCount; // Same as FRIG's count

        public ushort ShaderNodeCount; // Shows up in "_facial" - seems to be the number of SHADER nodes per animation

        public ushort Unknown1; // Shows up in "_facial" normally (always?) as 0x1

        [Flags]
        public enum UnknownFunctionFlags : ushort
        {
            Unknown0x1 = 0x1,
            Unknown0x2 = 0x2,
            Unknown0x4 = 0x4,
            Unknown0x8 = 0x8,
            Unknown0x10 = 0x10,
        }
        public UnknownFunctionFlags UnknownFlags;

        [Flags]
        public enum FeatureFlags : ushort
        {
            New = 0x1000,

            MtpIsBone = 0x4000,
        }
        public FeatureFlags Flags;

        public uint CommonInfoOffset;

        public ulong Padding;

        public MtarFileHeader* GetFileHeaders()
        {
            fixed (MtarHeader* thisPtr = &this)
            {
                byte* selfPtr = (byte*)thisPtr;
                
                return (MtarFileHeader*)(selfPtr + sizeof(MtarHeader));
            }
        }

        public Mtar2FileHeader* GetFile2Headers()
        {
            fixed (MtarHeader* thisPtr = &this)
            {
                byte* selfPtr = (byte*)thisPtr;
                
                return (Mtar2FileHeader*)(selfPtr + sizeof(MtarHeader));
            }
        }

        public TrackHeader* GetLayoutTrack()
        {
            if ((Flags & FeatureFlags.New) == 0)
                return null;

            fixed (MtarHeader* thisPtr = &this)
            {
                byte* selfPtr = (byte*)thisPtr;
                
                Mtar2MiniDataNode* node = (Mtar2MiniDataNode*)(selfPtr + CommonInfoOffset);
		    
                Mtar2MiniDataNode* trackNode = node->Find(HashingBitConverter.ToStrCode32(1337830127));

                if (trackNode == null)
                    return null;
                else
                    return (TrackHeader*)((byte*)trackNode + sizeof(Mtar2MiniDataNode));
            }
        }
    };
}