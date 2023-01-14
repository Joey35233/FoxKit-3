using UnityEngine;
using UnityEditor.AssetImporters;
using Fox.Fio;
using System;
using Fox.Kernel;
using UnityEngine.Rendering;
using System.Collections.Generic;

namespace Fox.Gr
{
    [ScriptedImporter(0, "fmdl")]
    public partial class ModelFileImporter : ScriptedImporter
    {
        private enum FeatureType : uint
        {
            BoneDefs = 0,
            MeshGroupHeaders = 1,
            MeshGroupDefs = 2,
            MeshDefs = 3,
            MaterialInstanceHeaders = 4,
            BoneGroups = 5,
            TextureRefs = 6,
            MaterialParams = 7,
            MaterialPlatformAliases = 8,
            MeshDataLayoutDescs = 9,
            MeshBufferHeaders = 10,
            MeshBufferFormatElements = 11,
            StringHeader = 12,
            AABBs = 13,
            FileMeshBufferHeaders = 14,
            LODInfo = 16,
            IBufferSlices = 17,
            Unk18 = 18,
            Unk19 = 19,
            Unk20 = 20,
            PathHashes = 21,
            NameHashes = 22,

            // Last real type + 1
            COUNT,
        }

        private enum BufferType : uint
        {
            MaterialParams = 0,
            Vertices = 2,
            Strings = 3,

            COUNT,
        }

        private static readonly uint[] FeatureUnitSizes =
        {
            0x30, // 0  - BoneUnit
            0x8,  // 1  - MeshGroupHeader
            0x20, // 2  - MeshGroupDef
            0x30, // 3  - MeshUnit
            0x10, // 4  - MaterialInstanceHeader
            0x44, // 5  - BoneGroup
            0x4,  // 6  - TextureRef
            0x4,  // 7  - MaterialParameter
            0x4,  // 8  - MaterialPlatformAlias
            0x8,  // 9  - MeshDataLayoutDesc
            0x8,  // 10 - MeshBufferHeader
            0x4,  // 11 - MeshBufferFormatElement

            0x0,  // 12 - StringHeader

            0x20, // 13 - AABB
            0x10, // 14 - FileMeshBufferHeader

            0x0,  // 15 - Unknown

            0x10, // 16 - LodInfo
            0x8,  // 17 - IBufferSlice
            0x8,  // 18 - Type18

            0x0,  // 19 - Unknown

            0x80, // 20 - Type20

            0x8,  // 21 - Path
            0x8,  // 22 - Name
        };


        private struct FmdlDef
        {
            private struct FeatureDef
            {
                public uint Count;
                public uint DataOffset;
            }

            uint FeatureTypes;
            uint FeaturesDataOffset;
            FeatureDef[] Features;

            uint BufferTypes;
            uint BuffersDataOffset;
            uint[] BufferOffsets;

            Action<string> LogError;

            public static FmdlDef Read(FileStreamReader reader, long position, Action<string> logWarning, Action<string> logError)
            {
                uint fileDescOffset = reader.ReadUInt32(); reader.SkipPadding(4);

                uint featureTypes = reader.ReadUInt32(); reader.SkipPadding(4);

                uint bufferTypes = reader.ReadUInt32(); reader.SkipPadding(4);

                uint featureCount = reader.ReadUInt32();

                uint bufferCount = reader.ReadUInt32();

                uint featuresDataOffset = reader.ReadUInt32();

                uint featuresDataSize = reader.ReadUInt32();

                uint buffersDataOffset = reader.ReadUInt32();

                uint buffersDataSize = reader.ReadUInt32();

                if (featureTypes == 0 || featuresDataOffset == 0 || featuresDataSize == 0)
                    Debug.Assert(featureTypes == 0 && featuresDataOffset == 0 && featuresDataSize == 0);

                if (bufferTypes == 0 || buffersDataOffset == 0 || buffersDataSize == 0)
                    Debug.Assert(bufferTypes == 0 && buffersDataOffset == 0 && buffersDataSize == 0);

                reader.SkipPadding(8);

                FmdlDef def = new FmdlDef
                {
                    FeatureTypes = featureTypes,
                    FeaturesDataOffset = featuresDataOffset,
                    Features = new FeatureDef[(int)FeatureType.COUNT],
                    BufferTypes = bufferTypes,
                    BuffersDataOffset = buffersDataOffset,
                    BufferOffsets = new uint[(int)BufferType.COUNT],

                    LogError = logError,
                };

                if (fileDescOffset != 0)
                {
                    reader.Seek(position + fileDescOffset);

                    for (int i = 0; i < featureCount; i++)
                    {
                        FeatureType type = (FeatureType)reader.ReadByte(); Debug.Assert(type < FeatureType.COUNT);

                        Debug.Assert(featureTypes != 0);
                        Debug.Assert((featureTypes & (1 << (int)type)) != 0);
                        featureTypes &= (uint)~(featureTypes & (1 << (int)type));

                        def.Features[(int)type].Count = (uint)reader.ReadByte() * (ushort.MaxValue + 1) + reader.ReadUInt16(); // Not technically accurate for all features; some don't use the overflow feature.
                        def.Features[(int)type].DataOffset = reader.ReadUInt32();
                    }
                    Debug.Assert(featureTypes == 0);

                    for (int i = 0; i < bufferCount; i++)
                    {
                        BufferType type = (BufferType)reader.ReadUInt32(); Debug.Assert(type < BufferType.COUNT);
                        if ((int)type == 1)
                            logWarning("Buffer type 1 found, is this a mistake?");

                        Debug.Assert(bufferTypes != 0);
                        Debug.Assert((bufferTypes & (1 << (int)type)) != 0);
                        bufferTypes &= (uint)~(bufferTypes & (1 << (int)type));

                        def.BufferOffsets[(int)type] = reader.ReadUInt32();

                        uint size = reader.ReadUInt32(); Debug.Assert(size != 0); // I am not sure if size == 0 is a valid state or not.
                    }
                    Debug.Assert(bufferTypes == 0);
                }
                else
                {
                    logWarning("FileDescOffset is 0; model has no features or buffers.");
                }

                return def;
            }

            public uint GetFeatureCount(FeatureType type)
            {
                if ((FeatureTypes & (1 << (int)type)) == 0)
                    return 0;

                return Features[(int)type].Count;
            }

            public bool HasFeature(FeatureType type)
            {
                return (FeatureTypes & (1 << (int)type)) != 0;
            }

            // No validation.
            public long GetFeaturePositionForIndex(FeatureType type, uint index) => FeaturesDataOffset + Features[(int)type].DataOffset + FeatureUnitSizes[(int)type] * index;

            public uint GetBufferCount(BufferType type)
            {
                if ((BufferTypes & (1 << (int)type)) == 0)
                    return 0;

                return Features[(int)type].Count;
            }

            public long? GetBufferPosition(BufferType type)
            {
                if ((BufferTypes & (1 << (int)type)) == 0)
                    return null;

                return BuffersDataOffset + BufferOffsets[(int)type];
            }

            public bool ValidateFeatureIndex(FeatureType owner, FeatureType indexed, uint index)
            {
#if DEBUG
                if (index > GetFeatureCount(indexed))
                {
                    LogError($"{owner} referencing {indexed} that does not exist.");
                    return false;
                }
                return true;
#else
                return true;
#endif
            }
        }

        private enum BoneFlags : ushort
        {
            HasBoundingBox = 1,
            B = 2,
            C = 4,
        }

        private enum MeshGroupHeaderFlags : ushort
        {
            Invisible = 1,
            A = 2,
            B = 4,
        }

        private enum MeshBufferFormatElementUsage : byte
        {
            Position = 0,
            BoneWeight0 = 1,
            Normal = 2,
            Color = 3,

            BoneIndex0 = 7,

            UV0 = 8,
            UV1 = 9,
            UV2 = 10,
            UV3 = 11,

            BoneWeight1 = 12,
            BoneIndex1 = 13,

            Tangent = 14,

            COUNT,
        }

        private enum MeshBufferFormatElementType : byte
        {
            R32G32B32_Float = 1,
            R16_UInt = 4,
            R16G16B16A16_Float = 6,
            R16G16_Float = 7,
            R8G8B8A8_UNorm = 8,
            R8G8B8A8_UInt = 9,
        }

        struct MeshBufferDesc
        {
            public uint Offset;
            public byte FileBufferIndex;
            public byte Slot;
            public MeshBufferFormatElement[] Elements;
        }

        struct MeshBufferFormatElement
        {
            public MeshBufferFormatElementUsage Usage;
            public MeshBufferFormatElementType Type;
            public ushort Offset;
        }

        struct MeshDataLayoutDesc
        {
            public MeshBufferDesc[] BufferDescs;
        }

        private static Bounds InvalidBoundingBox = new Bounds { max = new Vector3(-1e10f, -1e10f, -1e10f), min = new Vector3(1e10f, 1e10f, 1e10f) };

        private StrCode ReadNameForIndex(ref FmdlDef def, FileStreamReader reader, ushort index)
        {
            long rewindPosition = reader.BaseStream.Position;

            reader.Seek(def.GetFeaturePositionForIndex(FeatureType.NameHashes, index));

            StrCode result = reader.ReadStrCode();

            reader.Seek(rewindPosition);

            return result;
        }

        private Bounds ReadAABBForIndex(ref FmdlDef def, FileStreamReader reader, ushort index)
        {
            long rewindPosition = reader.BaseStream.Position;

            reader.Seek(def.GetFeaturePositionForIndex(FeatureType.AABBs, index));

            Bounds box = new Bounds();
            Vector3 max = reader.ReadPositionHF();
            Vector3 min = reader.ReadPositionHF();

            float flippedMinX = max.x;
            max.x = min.x;
            min.x = flippedMinX;

            box.max = max;
            box.min = min;

            reader.Seek(rewindPosition);

            return box;
        }

        public override void OnImportAsset(AssetImportContext context)
        {
            using FileStreamReader reader = new FileStreamReader(System.IO.File.OpenRead(assetPath));
            
            string name = System.IO.Path.GetFileName(context.assetPath);

            void logWarning(string message)
            {
                Debug.LogWarning($"{name}: {message}");
            }

            void logError(string message)
            {
                Debug.LogError($"{name}: {message}");
            }

            if (reader.ReadUInt32() != 0x4C444D46)
            {
                logError("Read failed. Not an FMDL.");
            }

            if (reader.ReadSingle() != 2.04f)
            {
                logError("Unsupported FMDL version.");
            }

            GameObject main = new GameObject(name);

            FmdlDef def = FmdlDef.Read(reader, 0, logWarning, logError);
            {
                BoxCollider boxComponent = main.AddComponent<BoxCollider>();
                Bounds box = ReadAABBForIndex(ref def, reader, 0);
                boxComponent.center = box.center;
                boxComponent.size = box.size;
            }

            // Bones
            Transform[] boneLookup = null;
            if (def.HasFeature(FeatureType.BoneDefs))
            {
                uint boneCount = def.GetFeatureCount(FeatureType.BoneDefs);

                boneLookup = new Transform[boneCount];

                for (uint i = 0; i < boneCount; i++)
                {
                    reader.Seek(def.GetFeaturePositionForIndex(FeatureType.BoneDefs, i));

                    ushort nameIndex = reader.ReadUInt16(); if (!def.ValidateFeatureIndex(FeatureType.BoneDefs, FeatureType.NameHashes, nameIndex)) return;
                    StrCode nameHash = ReadNameForIndex(ref def, reader, nameIndex);

                    GameObject bone = new GameObject(nameHash.ToString());
                    boneLookup[i] = bone.transform;

                    short parentIndex = reader.ReadInt16(); if (parentIndex > -1 && !def.ValidateFeatureIndex(FeatureType.BoneDefs, FeatureType.BoneDefs, (uint)parentIndex)) return;

                    ushort aabbIndex = reader.ReadUInt16(); if (!def.ValidateFeatureIndex(FeatureType.BoneDefs, FeatureType.AABBs, aabbIndex)) return;
                    Bounds box = ReadAABBForIndex(ref def, reader, aabbIndex);

                    BoneFlags flags = (BoneFlags)reader.ReadUInt16();
                    if (((uint)flags & ~1) != 0)
                        logWarning("Unknown BoneFlags.");

                    reader.SkipPadding(8);

                    bone.transform.localPosition = reader.ReadPositionHF();

                    if (parentIndex == -1)
                        bone.transform.SetParent(main.transform, false);
                    else
                        bone.transform.SetParent(boneLookup[parentIndex], false);

                    if (flags.HasFlag(BoneFlags.HasBoundingBox))
                    {
                        Debug.Assert(box != InvalidBoundingBox);

                        BoxCollider boxComponent = bone.AddComponent<BoxCollider>();
                        boxComponent.center = bone.transform.InverseTransformPoint(box.center);
                        boxComponent.size = box.size;
                    }
                    else
                    {
                        Debug.Assert(box == InvalidBoundingBox);
                    }
                }
            }

            // Process MeshGroupHeaders. This is done as a pre-step because (all?) models have a stub MeshGroupHeader that owns all other MeshGroupHeaders but to which no MeshGroupDefs belong.
            GameObject[] meshGroups = null;
            if (def.HasFeature(FeatureType.MeshGroupHeaders))
            {
                uint meshGroupHeaderCount = def.GetFeatureCount(FeatureType.MeshGroupHeaders);

                meshGroups = new GameObject[meshGroupHeaderCount];

                for (uint i = 0; i < meshGroupHeaderCount; i++)
                {
                    reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MeshGroupHeaders,i));

                    ushort nameIndex = reader.ReadUInt16(); if (!def.ValidateFeatureIndex(FeatureType.MeshGroupHeaders, FeatureType.NameHashes, nameIndex)) return;
                    StrCode nameHash = ReadNameForIndex(ref def, reader, nameIndex);

                    MeshGroupHeaderFlags flags = (MeshGroupHeaderFlags)reader.ReadUInt16();

                    GameObject meshGroup = new GameObject(nameHash.ToString());
                    meshGroups[i] = meshGroup;

                    if (flags.HasFlag(MeshGroupHeaderFlags.Invisible))
                        meshGroup.SetActive(false);

                    short parentIndex = reader.ReadInt16(); if (parentIndex > -1 && !def.ValidateFeatureIndex(FeatureType.MeshGroupHeaders, FeatureType.MeshGroupHeaders, (uint)parentIndex)) return;

                    if (parentIndex == -1)
                        meshGroup.transform.SetParent(main.transform);
                    else
                        meshGroup.transform.SetParent(meshGroups[parentIndex].transform);

                    short unknown = reader.ReadInt16(); Debug.Assert(unknown == -1);
                }
            }

            // MeshGroupDefs
            if (def.HasFeature(FeatureType.MeshGroupDefs))
            {
                uint meshGroupDefCount = def.GetFeatureCount(FeatureType.MeshGroupDefs);
                
                for (uint i = 0; i < meshGroupDefCount; i++)
                {
                    reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MeshGroupDefs, i));
                    uint unknown = reader.ReadUInt32(); Debug.Assert(unknown == 0);

                    ushort headerIndex = reader.ReadUInt16(); if (!def.ValidateFeatureIndex(FeatureType.MeshGroupDefs, FeatureType.MeshGroupHeaders, headerIndex)) return;
                    GameObject meshGroup = meshGroups[headerIndex];

                    ushort meshCount = reader.ReadUInt16();

                    ushort meshesStartIndex = reader.ReadUInt16(); if (meshCount > 0 && !def.ValidateFeatureIndex(FeatureType.MeshGroupDefs, FeatureType.MeshDefs, (uint)(meshesStartIndex + meshCount - 1))) return;

                    ushort aabbIndex = reader.ReadUInt16(); if (!def.ValidateFeatureIndex(FeatureType.MeshGroupDefs, FeatureType.AABBs, headerIndex)) return;
                    Bounds box = ReadAABBForIndex(ref def, reader, aabbIndex);
                    BoxCollider boxComponent = meshGroup.AddComponent<BoxCollider>();
                    boxComponent.center = box.center;
                    boxComponent.size = box.size;

                    reader.SkipPadding(4);

                    ushort iBufferSlicesGroupStartIndex = reader.ReadUInt16(); if (!def.ValidateFeatureIndex(FeatureType.MeshGroupDefs, FeatureType.IBufferSlices, headerIndex)) return;

                    reader.SkipPadding(14);

                    MeshDataLayoutDesc[] layoutDescs = new MeshDataLayoutDesc[meshCount];

                    // MeshDefs
                    for (uint j = 0; j < meshCount; j++)
                    {
                        reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MeshDefs, meshesStartIndex + j));

                        uint flags = reader.ReadUInt32();

                        ushort materialInstanceIndex = reader.ReadUInt16(); if (!def.ValidateFeatureIndex(FeatureType.MeshDefs, FeatureType.MaterialInstanceHeaders, materialInstanceIndex)) return;

                        ushort boneGroupIndex = reader.ReadUInt16(); if (!def.ValidateFeatureIndex(FeatureType.MeshDefs, FeatureType.BoneGroups, boneGroupIndex)) return;

                        ushort dataLayoutDescIndex = reader.ReadUInt16(); if (!def.ValidateFeatureIndex(FeatureType.MeshDefs, FeatureType.MeshDataLayoutDescs, dataLayoutDescIndex)) return;

                        // TODO - Inc. validation
                        ushort vertexCount = reader.ReadUInt16();
                        ushort verticesStartIndex = reader.ReadUInt16(); // Unconfirmed

                        reader.SkipPadding(2);

                        // TODO - Inc. validation
                        uint highLodIBufferSliceStartIndex = reader.ReadUInt32();
                        uint highLodIBufferSliceCount = reader.ReadUInt32();

                        uint iBufferSlicesStartIndex = iBufferSlicesGroupStartIndex + reader.ReadUInt32();

                        reader.SkipPadding(20);

                        // Actually create mesh from FMDL buffers
                        GameObject meshGameObject = new GameObject($"Mesh{meshesStartIndex + j:D4}");
                        meshGameObject.transform.SetParent(meshGroup.transform);

                        reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MeshDataLayoutDescs, dataLayoutDescIndex));

                        // MeshDataLayoutDesc
                        byte bufferCount = reader.ReadByte();

                        byte formatElementCount = reader.ReadByte();

                        byte unknownMeshFormatDescByte = reader.ReadByte();

                        byte uvCount = reader.ReadByte();

                        ushort bufferHeadersStartIndex = reader.ReadUInt16(); if (bufferCount > 0 && !def.ValidateFeatureIndex(FeatureType.MeshDataLayoutDescs, FeatureType.MeshBufferHeaders, (uint)(bufferHeadersStartIndex + bufferCount - 1))) return;

                        ushort formatElementsStartIndex = reader.ReadUInt16(); if (formatElementCount > 0 && !def.ValidateFeatureIndex(FeatureType.MeshDataLayoutDescs, FeatureType.MeshBufferFormatElements, (uint)(formatElementsStartIndex + formatElementCount - 1))) return;

                        ref MeshDataLayoutDesc layoutDesc = ref layoutDescs[j];
                        layoutDesc = new MeshDataLayoutDesc { BufferDescs = new MeshBufferDesc[bufferCount] };

                        // MeshBufferHeader
                        uint internalFormatElementsIndex = 0;
                        for (uint k = 0; k < bufferCount; k++)
                        {
                            reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MeshBufferHeaders, bufferHeadersStartIndex + k));

                            byte fileMeshBufferHeaderIndex = reader.ReadByte();

                            byte formatElementCountRelative = reader.ReadByte();

                            byte stride = reader.ReadByte();

                            byte bindSlot = reader.ReadByte(); Debug.Assert(bindSlot < 4);

                            uint offset = reader.ReadUInt32();

                            layoutDesc.BufferDescs[k] = new MeshBufferDesc { Offset = offset, FileBufferIndex = fileMeshBufferHeaderIndex, Elements = new MeshBufferFormatElement[formatElementCountRelative] };

                            // MeshBufferFormatElement
                            for (uint l = 0; l < formatElementCountRelative; l++)
                            {
                                uint index = internalFormatElementsIndex + l;

                                reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MeshBufferFormatElements, formatElementsStartIndex + index));

                                MeshBufferFormatElementUsage usage = (MeshBufferFormatElementUsage)reader.ReadByte(); // TODO - validate type

                                MeshBufferFormatElementType type = (MeshBufferFormatElementType)reader.ReadByte(); // TODO - validate type

                                ushort offsetRelative = reader.ReadUInt16();

                                layoutDesc.BufferDescs[k].Elements[i] = new MeshBufferFormatElement { Usage = usage, Type = type, Offset = offsetRelative };
                            }
                            internalFormatElementsIndex += formatElementCountRelative;
                        }
                    }
                }
            }

            context.AddObjectToAsset(name, main);

            context.SetMainObject(main);

            return;
        }
    }
}