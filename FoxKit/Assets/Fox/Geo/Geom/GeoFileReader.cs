using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Fox.Geo
{
    public enum GeoPayloadType : uint
    {
        Type1 = 0x10,
        Type2 = 0x40,
        Bone = 0xB,
        BoundingGroup = 0x0,
        Group = 0x6,
    }
    public enum GeoCollisionTags : ulong
    {
        Padding0 = 1,
        RECOIL = 2,
        CHARA = 4,
        SOUND_MGS4 = 8,

        PLAYER = 0x10,
        ENEMY = 0x20,
        BULLET = 0x40,
        MISSILE = 0x80,

        BOMB = 0x100,
        RADOR_MGS4 = 0x200,
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
        Padding1 = 0x8000000,

        Padding2 = 0x10000000,
        DOUBLE_SIDE = 0x20000000,
        WATER_SURFACE = 0x40000000,
        CHARA_Part2 = 0x80000000,

        TARGET_BLOCK = 0x100000000,
        DOG = 0x200000000,
        Padding3 = 0x400000000,
        NO_EFFECT = 0x800000000,

        EVENT_PHYSICS = 0x1000000000,
        NO_WALL_MOVE = 0x2000000000,
        MISSILE2 = 0x4000000000,
        Padding4 = 0x8000000000,

        TppReserve1 = 0x1 * (0x10 * 10),
        TppReserve2 = 0x2 * (0x10 * 10),
        TppReserve3 = 0x4 * (0x10 * 10),
        TppReserve4 = 0x8 * (0x10 * 10),

        Padding5 = 0x1 * (0x10 * 11),
        Padding6 = 0x2 * (0x10 * 11),
        Padding7 = 0x4 * (0x10 * 11),
        Padding8 = 0x8 * (0x10 * 11),

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
    };
    public class GeoFileReader
    {
        private readonly TaskLogger logger = new TaskLogger("ReadGEOM");
        public void Read(FileStreamReader reader)
        {
            var header = new FoxDataHeaderContext(reader, reader.BaseStream.Position);
            header.Validate(version: 201406020, flags: 0);

            reader.Seek(header.Position);
            var fileNameHash = reader.ReadUInt32();

            for (FoxDataNodeContext? _node = header.GetFirstNode(); _node.HasValue; _node = _node.Value.GetNextNode())
            {
                FoxDataNodeContext node = _node.Value;

                reader.Seek(node.Position);
                var nodeNameHash = reader.ReadUInt32(); Debug.Log($"nodeNameHash: {nodeNameHash}");
                var flags = node.GetFlags();

                for (FoxDataNodeContext? _childNode = node.GetChildNode(); _childNode.HasValue; _childNode = _childNode.Value.GetNextNode())
                {
                    FoxDataNodeContext childNode = _childNode.Value;

                    reader.Seek(childNode.Position);
                    var childNodeNameHash = reader.ReadUInt32(); Debug.Log($"childNodeNameHash: {childNodeNameHash}");
                    GeoPayloadType childFlags = (GeoPayloadType)childNode.GetFlags();

                    var payloadPosition = childNode.GetDataPosition();
                    if (payloadPosition is null)
                        continue;
                    var payloadEndPosition = (long)payloadPosition + childNode.GetDataSize();

                    reader.Seek((long)payloadPosition);
                    switch (childFlags) 
                    {
                        case GeoPayloadType.Type1:
                        case GeoPayloadType.Type2:
                        default:
                            break;
                        case GeoPayloadType.Bone:
                            reader.Seek((long)payloadPosition);
                            var boneNameHash = reader.ReadUInt32();
                            var boneNameLength = reader.ReadInt32();
                            string boneNameString = reader.ReadChars(boneNameLength).ToString();
                            break;
                        case GeoPayloadType.BoundingGroup:
                            if (childNode.GetDataOffset()!=0)
                            {
                                reader.Seek((long)payloadPosition);
                                ReadBoundingVolume(reader);
                                reader.Align(0x10);
                            }
                            ReadGroup(reader, payloadEndPosition);
                            break;
                        case GeoPayloadType.Group:
                            reader.Seek((long)payloadPosition);
                            ReadGroup(reader, payloadEndPosition);
                            break;
                    }
                }
            }
        }
        public void ReadBoundingVolume(FileStreamReader reader)
        {
            var payloadPosition = reader.BaseStream.Position; Debug.Log($"BoundingVolume @{payloadPosition}");
            Vector3 BoundingBoxCorner = reader.ReadPositionF();
            ushort GridTotalDataSize = reader.ReadUInt16();
            ushort BlockCount = reader.ReadUInt16();
            Vector3 BoundingBoxExtents = reader.ReadPositionF();
            uint NextSectionOffset = reader.ReadUInt32();
            Vector3 GridSize = reader.ReadPositionF();
            Debug.Log($"{BoundingBoxCorner},{BoundingBoxExtents},{GridSize}");
            uint[] CellCount = new uint[3] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() };
            GeoCollisionTags Tags = (GeoCollisionTags)reader.ReadUInt64();

            uint totalCellCount = CellCount[0] * CellCount[1] * CellCount[2];
            short[] NodeOffsets = new short[totalCellCount];
            for (int i = 0; i < CellCount[0] * CellCount[1] * CellCount[2]; i++)
            {
                reader.Seek(payloadPosition + 0x40 + i * 2);
                NodeOffsets.SetValue(reader.ReadInt16(), i);
                if (NodeOffsets[i] == -1)
                    continue;

                reader.Seek(payloadPosition + NodeOffsets[i]);
                ushort CellBlockCount = reader.ReadUInt16();
                ushort[] CellBlockIndex = new ushort[CellBlockCount];
                for (int j = 0; j < CellBlockCount; j++)
                    CellBlockIndex.SetValue(reader.ReadUInt16(), j);
            }
        }
        public void ReadGroup(FileStreamReader reader, long payloadEndPosition)
        {
            long BlocksStartPos = reader.BaseStream.Position;
            while(reader.ReadBoolean()!=true)
            {
                reader.BaseStream.Position -= 1;
                long blockStartPos = reader.BaseStream.Position;

                bool IsFinalBlock = reader.ReadBoolean();

                byte ShapesTotalSizeInEntries = reader.ReadByte();
                ushort ShapeDataSize = reader.ReadUInt16();

                ushort LastHeaderOffsetMaybe = reader.ReadUInt16();
                Debug.Assert(reader.ReadUInt16() == 0);
                ushort FirstHeaderOffsetMaybe = reader.ReadUInt16();
                Debug.Assert(reader.ReadUInt16() == 0);

                uint VertexBufferOffset = reader.ReadUInt32();
                uint RootAABBHeaderOffset = reader.ReadUInt32();
                uint NextSectionOffset = reader.ReadUInt32();

                GeoCollisionTags Tags = (GeoCollisionTags)reader.ReadUInt64();

                reader.Seek(blockStartPos + RootAABBHeaderOffset);

                ulong[] ptrs = new ulong[6];
                ptrs.SetValue(blockStartPos + RootAABBHeaderOffset,0);
                uint j = 1;
                uint j_minusOne;
                int iteratorIndex = 0;
                int iteratorIndex_minusOne;
                ulong ptr;

                do
                {
                    ptr = ptrs[iteratorIndex];

                    j_minusOne = j - 1;
                    iteratorIndex_minusOne = iteratorIndex - 1;

                    reader.Seek((long)ptr + 4);
                    if (reader.ReadUInt32() != 0) // if (Shape.Header.NextHeaderOffset != 0)
                    {
                        ptrs[j - 1] = ptr + reader.ReadUInt32() * 16; // Shape.Header.NextHeaderOffset

                        j_minusOne = j;
                        iteratorIndex_minusOne = iteratorIndex;
                    }

                    j = j_minusOne;
                    iteratorIndex = iteratorIndex_minusOne;
                    reader.Seek((long)ptr);
                    if ((reader.ReadUInt32() & 0x200) == 0) // if (Shape.Header.Info.Flags & GEO_SHAPE_FLAGS_NO_CHILD == 0)
                    {
                        var geoHeader = new GeomHeaderContext(reader, reader.BaseStream.Position, GeomHeaderContext.OffsetSize.Bytes);

                        var type = geoHeader.Type;
                        var count = geoHeader.PrimCount;

                        reader.Seek(geoHeader.GetDataPosition());
                        switch (type)
                        {
                            case GeoPrimType.AABB:
                                Vector3 BoundingBoxRadii = reader.ReadPaddedVector3();
                                Vector3 BoundingBoxCenter = reader.ReadPaddedVector3();
                                Debug.Log($"{BoundingBoxRadii},{BoundingBoxCenter}");
                                break;
                            case GeoPrimType.Quad:
                                for (int k = 0; k < count; k++)
                                {
                                    short[] Indices = new short[] { reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16() };
                                    Debug.Log($"Indices: {Indices[0]},{Indices[1]},{Indices[2]},{Indices[3]}");
                                    ushort GeoQuadMaterialInfo = reader.ReadUInt16();
                                    bool NoUseMaterial = ((GeoQuadMaterialInfo) & 1) != 0;
                                    bool NoUseAuxMaterial = ((GeoQuadMaterialInfo >> 1) & 1) != 0;
                                    byte MaterialIndex = (byte)((GeoQuadMaterialInfo >> 2) | 0x7F);
                                    byte AuxMaterialIndex = (byte)((GeoQuadMaterialInfo >> 9) | 0x7F);
                                }
                                reader.Align(16);
                                break;
                            default:
                                Debug.LogError($"Unknown GEO_PRIM_TYPE type detected! @{geoHeader.Position}");
                                break;
                        }

                        if (geoHeader.ChildHeaderOffset != 0)
                        {
                            if (true)
                            {
                                j = j_minusOne + 1;
                                iteratorIndex = iteratorIndex_minusOne + 1;
                                ptrs[j_minusOne] = ptr + (ulong)(geoHeader.ChildHeaderOffset * 16);
                            }
                        }
                    }
                } while (j > 0);

                reader.Seek(blockStartPos + VertexBufferOffset);

                uint VertexCount = reader.ReadUInt32();
                uint VerticesIndexOffset = reader.ReadUInt32();
                Debug.Assert(reader.ReadUInt32() is 0 or 1);
                uint OriginIndex = reader.ReadUInt32();
                long VertexDataOffset = reader.ReadInt64();
                uint FmdlVertexBufferOffset = reader.ReadUInt32();
                Debug.Assert(reader.ReadUInt32() == 0);

                reader.Seek(blockStartPos + 0x20);
            }
            reader.Skip(32);

            byte MaterialsOffsetInEntries = reader.ReadByte();
            byte MaterialsTotalSizeInEntries = reader.ReadByte();
            byte AuxMaterialsOffsetInEntries = reader.ReadByte();
            byte AuxMaterialsTotalSizeInEntries = reader.ReadByte();

            long MaterialsStartPos = reader.BaseStream.Position;
            reader.Seek(MaterialsStartPos + MaterialsOffsetInEntries * 12);

            while(reader.ReadUInt32()!=0)
            {
                reader.BaseStream.Position-=4;
                uint MaterialName = reader.ReadUInt32(); Debug.Log($"materialName: {MaterialName}");

                Debug.Assert(reader.ReadUInt64() == 0);
            }

            reader.Skip(12);

            reader.Seek(MaterialsStartPos + AuxMaterialsOffsetInEntries * 12);

            while (reader.ReadUInt32() != 0)
            {
                reader.BaseStream.Position -= 4;
                uint MaterialName = reader.ReadUInt32(); Debug.Log($"materialName: {MaterialName}");

                Debug.Assert(reader.ReadUInt64() == 0);
            }

            reader.Skip(12);

            reader.Align(16);

        }
    }
}
