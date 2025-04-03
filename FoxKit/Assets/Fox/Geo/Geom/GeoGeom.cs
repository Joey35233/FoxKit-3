using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.Geo
{
    public static class GeoGeom
    {
        [Flags]
        public enum GeoCollisionTags : ulong
        {
            // Padding0 = 1,
            RECOIL = 2,
            CHARA = 4,
            SOUND = 8,

            PLAYER = 0x10,
            ENEMY = 0x20,
            BULLET = 0x40,
            MISSILE = 0x80,

            BOMB = 0x100,
            // RADOR_MGS4 = 0x200,
            BLOOD = 0x400,
            IK = 0x800,

            STAIRWAY = 0x1000,
            STOP_EYE = 0x2000,
            CLIFF = 0x4000,
            TYPTHROUGH_MGS4 = 0x8000,

            LEAN_MGS4 = 0x10000,
            DONT_FALL = 0x20000,
            CAMERA = 0x40000,
            SHADOW_MGS4 = 0x80000,

            INTRUDE_MGS4 = 0x100000,
            ATTACK_GUARD_MGS4 = 0x200000,
            CLIFF_FLOOR = 0x400000,
            BULLET_MARK = 0x800000,

            HEIGHT_LIMIT = 0x1000000,
            NO_BEHIND_MGS4 = 0x2000000,
            BEHIND_THROUGH_MGS4 = 0x4000000,
            // Padding1 = 0x8000000,

            // Padding2 = 0x10000000,
            DOUBLE_SIDE = 0x20000000,
            WATER_SURFACE = 0x40000000,
            // CHARA_Part2 = 0x80000000,

            TARGET_BLOCK = 0x100000000,
            DOG = 0x200000000,
            // Padding3 = 0x400000000,
            NO_EFFECT = 0x800000000,

            EVENT_PHYSICS = 0x1000000000,
            NO_WALL_MOVE = 0x2000000000,
            MISSILE2 = 0x4000000000,
            // Padding4 = 0x8000000000,

            TppReserve1 = 0x1 * (0x10 * 10),
            TppReserve2 = 0x2 * (0x10 * 10),
            TppReserve3 = 0x4 * (0x10 * 10),
            TppReserve4 = 0x8 * (0x10 * 10),

            // Padding5 = 0x1 * (0x10 * 11),
            // Padding6 = 0x2 * (0x10 * 11),
            // Padding7 = 0x4 * (0x10 * 11),
            // Padding8 = 0x8 * (0x10 * 11),

            Sahelan = 0x1 * (0x10 * 12),
            RIDE_ON_OUTER = 0x2 * (0x10 * 12),
            FLAME = 0x4 * (0x10 * 12),
            IGNORE_PHYSICS = 0x8 * (0x10 * 12),

            CLIMB = 0x1 * (0x10 * 13),
            HORSE = 0x2 * (0x10 * 13),
            VEHICLE = 0x4 * (0x10 * 13),
            MARKER = 0x8 * (0x10 * 13),

            RIDE_ON = 0x1 * (0x10 * 14),
            THROUGH_LINE_OF_FIRE = 0x2 * (0x10 * 14),
            THROUGH_ITEM_CHECK = 0x4 * (0x10 * 14),
            NO_CREEP = 0x8 * (0x10 * 14),

            NO_FULTON = 0x1 * (0x10 * 15),
            FULTON = 0x2 * (0x10 * 15),
            ITEM = 0x4 * (0x10 * 15),
            BOSS = 0x8 * (0x10 * 15),
        }
        
        public enum NodePayloadType : uint
        {
            Type1 = 0x10,
            Type2 = 0x40,
            Bone = 0xB,
            Group = 0x0,
            Block = 0x6,
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct GeoBone
        {
            public StrCode32 NameHash;

            public uint NameStringLength;
            
            private GeoBone* GetSelfPointer()
            {
                fixed (GeoBone* selfPtr = &this)
                {
                    return selfPtr;
                }
            }

            public string ReadString()
            {
                var intPtr = new IntPtr((byte*)GetSelfPointer() + 8);
                return Marshal.PtrToStringAnsi(intPtr, (int)NameStringLength);
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct GeoBlock
        {
            [FieldOffset(0)]
            public bool IsFinalEntry;

            [FieldOffset(1)]
            public byte HeaderCount;
            
            [FieldOffset(2)]
            public ushort HeadersDataSize;
	
            [FieldOffset(4)]
            public ushort VertexBufferOffset_Unused;
	
            [FieldOffset(8)]
            public ushort HeadersOffset_Unused;
	
            [FieldOffset(12)]
            public uint VertexBufferOffset;

            [FieldOffset(16)]
            public uint HeadersOffset;

            [FieldOffset(20)]
            public uint MaterialsHeaderOffset;
	
            [FieldOffset(24)]
            public GeoCollisionTags Tags;
        }
        
        public enum GeoPrimType
        {
            Dot = 0,
            Line = 1,
            Poly = 2,
            Box = 3,
            AABB = 4,
            Reference = 5,
            Unknown6 = 6,
            Pyramid = 7,
            Path = 8,
            Unknown9 = 6,
            Unknown10 = 7,
            FreeArea = 11,
        }

        [Flags]
        public enum GeomHeaderFlags
        {
            Unknown6 = 0x1,
            Unknown9 = 0x2,
            Unknown4 = 0x4,
            
            Disable = 0x20,
            DoubleSided = 0x200,
            UseFmdlVertices = 0x800,
            HasChild = 0x2000,
            StopCheck = 0x4000,
            HasReference = 0x8000,
            Unknown3 = 0x8000,
            Unknown5 = 0x80000,
        }

        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct GeomHeader
        {
            [FieldOffset(0)]
            public uint Info;

            [FieldOffset(4)]
            public uint NextHeaderOffset;

            [FieldOffset(8)]
            public uint PreviousHeaderOffset;

            [FieldOffset(12)]
            public uint ChildHeaderOffset;

            [FieldOffset(16)]
            public GeoCollisionTags Tags;

            [FieldOffset(24)]
            public StrCode32 Name;

            [FieldOffset(28)]
            public uint VertexBufferOffset;
        }
        
        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct GeoPrimAabb
        {
            [FieldOffset(0)]
            public Vector3 BoundingBoxRadii;
            [FieldOffset(16)]
            public Vector3 BoundingBoxCenter;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct GeoPrimPoly
        {
            public ushort IndexA;
            public ushort IndexB;
            public ushort IndexC;
            public ushort IndexD;
            public short Info;
        }

        [StructLayout(LayoutKind.Sequential, Size = 32)]
        public unsafe struct PolyVertexHeader
        {
            public uint VertexCount;
            public uint VerticesIndexOffset;
            public uint Unknown0or1;
            public uint OriginIndex;
            public long VertexDataOffset;
            public uint FmdlVertexBufferOffset;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct GeoGroup
        {	
            public Vector3 BoundingBoxCorner;

            public ushort GridTotalDataSize;
            public ushort BlockCount;

            public Vector3 BoundingBoxExtents;

            public uint BlocksOffset;

            public Vector3 CellSize;
	
            public uint CellCountX;
            public uint CellCountY;
            public uint CellCountZ;
	
            public GeoCollisionTags Tags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct GeoBlockMaterialsHeader
        {
            public byte MaterialsIndexOffset;
            public byte MaterialsCount;
            public byte AuxMaterialsIndexOffset;
            public byte AuxMaterialsCount;
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 12)]
        public unsafe struct GeoMaterial
        {
            public StrCode32 Name;
        }
    }
}