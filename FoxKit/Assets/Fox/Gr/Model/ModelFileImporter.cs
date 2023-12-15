using Fox.Fio;
using Fox.Kernel;
using System;
using Unity.Collections;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.Rendering;

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

            private uint FeatureTypes;
            private uint FeaturesDataOffset;
            private FeatureDef[] Features;
            private uint BufferTypes;
            private uint BuffersDataOffset;
            private uint[] BufferOffsets;
            private Action<string> LogError;

            public static FmdlDef Read(FileStreamReader reader, long position, Action<string> logWarning, Action<string> logError)
            {
                uint fileDescOffset = reader.ReadUInt32();
                reader.SkipPadding(4);

                uint featureTypes = reader.ReadUInt32();
                reader.SkipPadding(4);

                uint bufferTypes = reader.ReadUInt32();
                reader.SkipPadding(4);

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

                var def = new FmdlDef
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
                        var type = (FeatureType)reader.ReadByte();
                        Debug.Assert(type < FeatureType.COUNT);

                        Debug.Assert(featureTypes != 0);
                        Debug.Assert((featureTypes & (1 << (int)type)) != 0);
                        featureTypes &= (uint)~(featureTypes & (1 << (int)type));

                        def.Features[(int)type].Count = ((uint)reader.ReadByte() * (UInt16.MaxValue + 1)) + reader.ReadUInt16(); // Not technically accurate for all features; some don't use the overflow feature.
                        def.Features[(int)type].DataOffset = reader.ReadUInt32();
                    }
                    Debug.Assert(featureTypes == 0);

                    for (int i = 0; i < bufferCount; i++)
                    {
                        var type = (BufferType)reader.ReadUInt32();
                        Debug.Assert(type < BufferType.COUNT);
                        if ((int)type == 1)
                            logWarning("Buffer type 1 found, is this a mistake?");

                        Debug.Assert(bufferTypes != 0);
                        Debug.Assert((bufferTypes & (1 << (int)type)) != 0);
                        bufferTypes &= (uint)~(bufferTypes & (1 << (int)type));

                        def.BufferOffsets[(int)type] = reader.ReadUInt32();

                        uint size = reader.ReadUInt32();
                        Debug.Assert(size != 0); // I am not sure if size == 0 is a valid state or not.
                    }
                    Debug.Assert(bufferTypes == 0);
                }
                else
                {
                    logWarning("FileDescOffset is 0; model has no features or buffers.");
                }

                return def;
            }

            public uint GetFeatureCount(FeatureType type) => (FeatureTypes & (1 << (int)type)) == 0 ? 0 : Features[(int)type].Count;

            public bool HasFeature(FeatureType type) => (FeatureTypes & (1 << (int)type)) != 0;

            // No validation.
            public long GetFeaturePositionForIndex(FeatureType type, uint index) => FeaturesDataOffset + Features[(int)type].DataOffset + (FeatureUnitSizes[(int)type] * index);

            public uint GetBufferCount(BufferType type) => (BufferTypes & (1 << (int)type)) == 0 ? 0 : Features[(int)type].Count;

            public long? GetBufferPosition(BufferType type) => (BufferTypes & (1 << (int)type)) == 0 ? null : BuffersDataOffset + BufferOffsets[(int)type];

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

            R16G16B16A16_Float = 6,
            R16G16_Float = 7,
            R8G8B8A8_UNorm = 8,
            R8G8B8A8_UInt = 9,
        }

        private struct AggregateMeshGroupDef
        {
            public uint TotalMeshCount;

            public uint SpanCounter;

            public uint[] MeshDefIndices;

            public Bounds Bounds;

            public uint IBufferSliceStartIndex;
        }

        private struct MeshBufferDesc
        {
            public byte Stride;
            public uint Offset;
            public byte FileBufferIndex;
            public byte Slot;
            public MeshBufferFormatElement[] Elements;
        }

        private struct MeshBufferFormatElement
        {
            public MeshBufferFormatElementUsage Usage;
            public MeshBufferFormatElementType Type;
            public ushort Offset;
        }

        private struct MeshDataLayoutDesc
        {
            public MeshBufferDesc[] BufferDescs;
        }

        private enum FileMeshBufferType : uint
        {
            VBuffer = 0,
            IndexBuffer = 1,
        }

        private const MeshUpdateFlags UpdateFlags = MeshUpdateFlags.DontRecalculateBounds | MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds;

        private static Bounds InvalidBoundingBox = new() { max = new Vector3(-1e10f, -1e10f, -1e10f), min = new Vector3(1e10f, 1e10f, 1e10f) };

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

            var box = new Bounds();
            Vector3 max = reader.ReadPositionHF();
            Vector3 min = reader.ReadPositionHF();

            (min.x, max.x) = (max.x, min.x);

            box.max = max;
            box.min = min;

            reader.Seek(rewindPosition);

            return box;
        }

        public override void OnImportAsset(AssetImportContext context)
        {
            using var reader = new FileStreamReader(System.IO.File.OpenRead(assetPath));

            string name = System.IO.Path.GetFileName(context.assetPath);

            void logWarning(string message)
            {
                Debug.LogWarning($"{name}: {message}");
            }

            void logError(string message)
            {
                Debug.LogError($"{name}: {message}");
            }

            if (reader.ReadUInt32() != 0x4C444D46) // FMDL
            {
                logError("Read failed. Not an FMDL.");
                return;
            }

            if (reader.ReadSingle() != 2.04f)
            {
                logError("Unsupported FMDL version.");
                return;
            }

            var main = new GameObject(name);

            var def = FmdlDef.Read(reader, 0, logWarning, logError);

            // def.ValidateFeatureIndex(FeatureType.AABBs, FeatureType.AABBs, 0);
            // {
            //     BoxCollider boxComponent = main.AddComponent<BoxCollider>();
            //     Bounds box = ReadAABBForIndex(ref def, reader, 0);
            //     boxComponent.center = box.center;
            //     boxComponent.size = box.size;
            // }

#if DEBUG
            uint DEBUG_FinalFlags = 0;
#endif

            // Bones
            Transform[] bones = null;
            Matrix4x4[] bindPoses = null;
            if (def.HasFeature(FeatureType.BoneDefs))
            {
                uint boneCount = def.GetFeatureCount(FeatureType.BoneDefs);

                bones = new Transform[boneCount];
                bindPoses = new Matrix4x4[boneCount];

                for (uint i = 0; i < boneCount; i++)
                {
                    reader.Seek(def.GetFeaturePositionForIndex(FeatureType.BoneDefs, i));

                    ushort nameIndex = reader.ReadUInt16();
                    if (!def.ValidateFeatureIndex(FeatureType.BoneDefs, FeatureType.NameHashes, nameIndex))
                        return;
                    StrCode nameHash = ReadNameForIndex(ref def, reader, nameIndex);

                    var bone = new GameObject(nameHash.ToString());
                    bones[i] = bone.transform;

                    short parentIndex = reader.ReadInt16();
                    if (parentIndex > -1 && !def.ValidateFeatureIndex(FeatureType.BoneDefs, FeatureType.BoneDefs, (uint)parentIndex))
                        return;

                    ushort aabbIndex = reader.ReadUInt16();
                    if (!def.ValidateFeatureIndex(FeatureType.BoneDefs, FeatureType.AABBs, aabbIndex))
                        return;
                    Bounds box = ReadAABBForIndex(ref def, reader, aabbIndex);

                    var flags = (BoneFlags)reader.ReadUInt16();
                    if (((uint)flags & ~1) != 0)
                        logWarning("Unknown BoneFlags.");

                    reader.SkipPadding(8);

                    bone.transform.localPosition = reader.ReadPositionHF();

                    if (parentIndex == -1)
                        bone.transform.SetParent(main.transform, false);
                    else
                        bone.transform.SetParent(bones[parentIndex], false);

                    if (flags.HasFlag(BoneFlags.HasBoundingBox))
                    {
                        Debug.Assert(box != InvalidBoundingBox);

                        BoxCollider boxComponent = bone.AddComponent<BoxCollider>();
                        boxComponent.center = bone.transform.worldToLocalMatrix * new Vector4(box.center.x, box.center.y, box.center.z, 1.0f);
                        boxComponent.size = bone.transform.worldToLocalMatrix * box.size;
                    }
                    else
                    {
                        Debug.Assert(box == InvalidBoundingBox);
                    }

                    bindPoses[i] = bone.transform.worldToLocalMatrix;
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
                    reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MeshGroupHeaders, i));

                    ushort nameIndex = reader.ReadUInt16();
                    if (!def.ValidateFeatureIndex(FeatureType.MeshGroupHeaders, FeatureType.NameHashes, nameIndex))
                        return;
                    StrCode nameHash = ReadNameForIndex(ref def, reader, nameIndex);

                    var flags = (MeshGroupHeaderFlags)reader.ReadUInt16();
                    if (flags.HasFlag(MeshGroupHeaderFlags.A) && bones is not null)
                        logWarning("Mesh has both bones and destruction particles.");
                    if (flags.HasFlag(MeshGroupHeaderFlags.B))
                        logWarning("Mesh has blend shapes flag.");

                    var meshGroup = new GameObject(nameHash.ToString());
                    meshGroups[i] = meshGroup;

                    if (flags.HasFlag(MeshGroupHeaderFlags.Invisible))
                        meshGroup.SetActive(false);

                    short parentIndex = reader.ReadInt16();
                    if (parentIndex > -1 && !def.ValidateFeatureIndex(FeatureType.MeshGroupHeaders, FeatureType.MeshGroupHeaders, (uint)parentIndex))
                        return;

                    meshGroup.transform.SetParent(parentIndex == -1 ? main.transform : meshGroups[parentIndex].transform);

                    short unknownPositionIndex = reader.ReadInt16();
                    Debug.Assert(flags.HasFlag(MeshGroupHeaderFlags.A) == (unknownPositionIndex != -1));

                    if (flags.HasFlag(MeshGroupHeaderFlags.A))
                    {
                        reader.Seek(def.GetBufferPosition(BufferType.MaterialParams).Value + (unknownPositionIndex * 16));

                        meshGroup.transform.localPosition = reader.ReadPositionF();
                    }
                }
            }

            // FileMeshBufferHeaders - TODO - Validate!
            byte[] indexBuffer = null;
            byte[][] vertexBuffers = new byte[def.GetFeatureCount(FeatureType.FileMeshBufferHeaders) - 1][];
            for (uint i = 0, vBufferIndex = 0; i < def.GetFeatureCount(FeatureType.FileMeshBufferHeaders); i++)
            {
                reader.Seek(def.GetFeaturePositionForIndex(FeatureType.FileMeshBufferHeaders, i));

                var type = (FileMeshBufferType)reader.ReadUInt32();
                Debug.Assert(type is FileMeshBufferType.VBuffer or FileMeshBufferType.IndexBuffer);

                uint size = reader.ReadUInt32();
                Debug.Assert(size <= Int32.MaxValue);

                reader.Seek(def.GetBufferPosition(BufferType.Vertices).Value + reader.ReadUInt32());

                if (type == FileMeshBufferType.IndexBuffer)
                {
                    indexBuffer = reader.ReadBytes((int)size);
                }
                else
                {
                    vertexBuffers[vBufferIndex] = reader.ReadBytes((int)size);
                    vBufferIndex++;
                }
            }
            // Not a good validation method - what if there really is no index buffer?
            if (indexBuffer == null)
            {
                logError("No index buffer!");
                return;
            }

            Material defaultMaterial = AssetDatabase.GetBuiltinExtraResource<Material>("Default-Material.mat");
            context.AddObjectToAsset("Material", defaultMaterial);

            // Preprocess MeshGroupDefs
            if (def.HasFeature(FeatureType.MeshGroupDefs))
            {
                var meshGroupDefs = new AggregateMeshGroupDef[meshGroups.Length];

                {
                    uint meshGroupDefCount = def.GetFeatureCount(FeatureType.MeshGroupDefs);

                    // Initial loops for preallocation and input validation
                    for (uint i = 0; i < meshGroupDefCount; i++)
                    {
                        reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MeshGroupDefs, i));

                        uint unknown = reader.ReadUInt32();
                        Debug.Assert(unknown == 0);

                        ushort headerIndex = reader.ReadUInt16();
                        if (!def.ValidateFeatureIndex(FeatureType.MeshGroupDefs, FeatureType.MeshGroupHeaders,
                                headerIndex))
                            return;

                        ushort meshCount = reader.ReadUInt16();
                        ushort meshesStartIndex = reader.ReadUInt16();
                        if (meshCount > 0 && !def.ValidateFeatureIndex(FeatureType.MeshGroupDefs, FeatureType.MeshDefs,
                                (uint)(meshesStartIndex + meshCount - 1)))
                            return;

                        meshGroupDefs[headerIndex].TotalMeshCount += meshCount;

                        ushort aabbIndex = reader.ReadUInt16();
                        if (!def.ValidateFeatureIndex(FeatureType.MeshGroupDefs, FeatureType.AABBs, aabbIndex))
                            return;

                        reader.SkipPadding(4);

                        ushort iBufferSlicesGroupStartIndex = reader.ReadUInt16();
                        if (!def.ValidateFeatureIndex(FeatureType.MeshGroupDefs, FeatureType.IBufferSlices,
                                iBufferSlicesGroupStartIndex))
                            return;

                        reader.SkipPadding(14);
                    }

                    for (uint i = 0; i < meshGroupDefs.LongLength; i++)
                    {
                        ref AggregateMeshGroupDef aggregateMeshGroupDef = ref meshGroupDefs[i];

                        aggregateMeshGroupDef.MeshDefIndices = new uint[aggregateMeshGroupDef.TotalMeshCount];
                        aggregateMeshGroupDef.Bounds = InvalidBoundingBox;
                    }

                    for (uint i = 0; i < meshGroupDefCount; i++)
                    {
                        reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MeshGroupDefs, i));

                        reader.Skip(4);

                        ushort headerIndex = reader.ReadUInt16();

                        ref AggregateMeshGroupDef aggregateMeshGroupDef = ref meshGroupDefs[headerIndex];

                        ushort meshCount = reader.ReadUInt16();
                        ushort meshesStartIndex = reader.ReadUInt16();
                        for (uint j = 0; j < meshCount; j++)
                            aggregateMeshGroupDef.MeshDefIndices[aggregateMeshGroupDef.SpanCounter + j] = meshesStartIndex + j;

                        ushort aabbIndex = reader.ReadUInt16();
                        Bounds box = ReadAABBForIndex(ref def, reader, aabbIndex);
                        if (aggregateMeshGroupDef.Bounds == InvalidBoundingBox)
                            aggregateMeshGroupDef.Bounds = box;
                        else
                            aggregateMeshGroupDef.Bounds.Encapsulate(box);

                        reader.Skip(4);

                        ushort ibufferSlicesStartIndex = reader.ReadUInt16();
                        aggregateMeshGroupDef.IBufferSliceStartIndex = ibufferSlicesStartIndex;

                        aggregateMeshGroupDef.SpanCounter += meshCount;
                    }
                }

                for (uint i = 0; i < meshGroupDefs.LongLength; i++)
                {
                    AggregateMeshGroupDef aggregateMeshGroupDef = meshGroupDefs[i];

                    if (aggregateMeshGroupDef.TotalMeshCount == 0)
                        continue;

                    GameObject meshGroup = meshGroups[i];

                    // MeshDefs
                    var layoutDescs = new MeshDataLayoutDesc[aggregateMeshGroupDef.TotalMeshCount];
                    uint totalVertexCount = 0;
                    uint totalIndexCount = 0;
                    uint maxBufferCount = 0;
                    for (uint j = 0; j < aggregateMeshGroupDef.TotalMeshCount; j++)
                    {
                        reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MeshDefs, aggregateMeshGroupDef.MeshDefIndices[j]));

                        uint flags = reader.ReadUInt32();

                        ushort materialInstanceIndex = reader.ReadUInt16();
                        if (!def.ValidateFeatureIndex(FeatureType.MeshDefs, FeatureType.MaterialInstanceHeaders, materialInstanceIndex))
                            return;

                        ushort boneGroupIndex = reader.ReadUInt16();
                        if (!def.ValidateFeatureIndex(FeatureType.MeshDefs, FeatureType.BoneGroups, boneGroupIndex))
                            return;

                        ushort dataLayoutDescIndex = reader.ReadUInt16();
                        if (!def.ValidateFeatureIndex(FeatureType.MeshDefs, FeatureType.MeshDataLayoutDescs, dataLayoutDescIndex))
                            return;

                        // TODO - Inc. validation
                        ushort vertexCount = reader.ReadUInt16();
                        ushort verticesStartIndex = reader.ReadUInt16(); // Unconfirmed

                        // Bone Group - TODO - Validate
                        {
                            long rewindPos = reader.BaseStream.Position;

                            reader.Seek(def.GetFeaturePositionForIndex(FeatureType.BoneGroups, boneGroupIndex));

                            ushort useWeightCount = reader.ReadUInt16();

                            reader.Seek(rewindPos);
                        }

                        totalVertexCount += vertexCount;

                        reader.SkipPadding(2);

                        // TODO - Inc. validation
                        uint highLodIBufferSliceStartIndex = reader.ReadUInt32();
                        uint highLodIBufferSliceCount = reader.ReadUInt32();

                        uint iBufferSlicesStartIndex = aggregateMeshGroupDef.IBufferSliceStartIndex + reader.ReadUInt32();

                        totalIndexCount += highLodIBufferSliceCount;

                        reader.SkipPadding(20);

                        reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MeshDataLayoutDescs, dataLayoutDescIndex));

                        // MeshDataLayoutDesc
                        byte bufferCount = reader.ReadByte();

                        byte formatElementCount = reader.ReadByte();

                        byte unknownMeshFormatDescByte = reader.ReadByte();
                        if (unknownMeshFormatDescByte != 0)
                            logWarning("unknownMeshFormatDescByte != 0");

                        byte uvCount = reader.ReadByte();

                        ushort bufferHeadersStartIndex = reader.ReadUInt16();
                        if (bufferCount > 0 && !def.ValidateFeatureIndex(FeatureType.MeshDataLayoutDescs, FeatureType.MeshBufferHeaders, (uint)(bufferHeadersStartIndex + bufferCount - 1)))
                            return;

                        ushort formatElementsStartIndex = reader.ReadUInt16();
                        if (formatElementCount > 0 && !def.ValidateFeatureIndex(FeatureType.MeshDataLayoutDescs, FeatureType.MeshBufferFormatElements, (uint)(formatElementsStartIndex + formatElementCount - 1)))
                            return;

                        MeshDataLayoutDesc layoutDesc = layoutDescs[j] = new MeshDataLayoutDesc { BufferDescs = new MeshBufferDesc[bufferCount] };

                        // MeshBufferHeader
                        uint internalFormatElementsIndex = 0;
                        for (uint k = 0; k < bufferCount; k++)
                        {
                            reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MeshBufferHeaders, bufferHeadersStartIndex + k));

                            byte fileMeshBufferHeaderIndex = reader.ReadByte();
                            if (fileMeshBufferHeaderIndex + 1 > maxBufferCount)
                                maxBufferCount = fileMeshBufferHeaderIndex + 1u;

                            byte formatElementCountRelative = reader.ReadByte();

                            byte stride = reader.ReadByte();

                            byte bindSlot = reader.ReadByte();
                            Debug.Assert(bindSlot < 4);

                            uint offset = reader.ReadUInt32();

                            layoutDesc.BufferDescs[k] = new MeshBufferDesc { Stride = stride, Offset = offset, FileBufferIndex = fileMeshBufferHeaderIndex, Elements = new MeshBufferFormatElement[formatElementCountRelative] };

                            // MeshBufferFormatElement
                            for (uint l = 0; l < formatElementCountRelative; l++)
                            {
                                uint index = internalFormatElementsIndex + l;

                                reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MeshBufferFormatElements, formatElementsStartIndex + index));

                                var usage = (MeshBufferFormatElementUsage)reader.ReadByte(); // TODO - validate type

                                var type = (MeshBufferFormatElementType)reader.ReadByte(); // TODO - validate type

                                ushort offsetRelative = reader.ReadUInt16();

                                layoutDesc.BufferDescs[k].Elements[l] = new MeshBufferFormatElement { Usage = usage, Type = type, Offset = offsetRelative };
                            }
                            internalFormatElementsIndex += formatElementCountRelative;
                        }
                    }

                    var uploadHelper = new BufferUploadHelper(maxBufferCount, (uint)layoutDescs.LongLength);
                    uploadHelper.Register(layoutDescs);

                    // Unity Mesh
                    var mesh = new Mesh
                    {
                        name = meshGroup.name
                    };
                    Debug.Assert(totalVertexCount <= Int32.MaxValue);
                    Debug.Assert(totalIndexCount <= Int32.MaxValue);
                    mesh.SetVertexBufferParams((int)totalVertexCount, uploadHelper.GetDescriptorArray());
                    mesh.SetIndexBufferParams((int)totalIndexCount, IndexFormat.UInt16);
                    mesh.subMeshCount = (int)aggregateMeshGroupDef.TotalMeshCount;

                    NativeArray<byte>[] outputBuffers = uploadHelper.CreateVertexBuffers(totalVertexCount);
                    BoneWeight[] weightBuffer = bones == null ? null : new BoneWeight[totalVertexCount];

#if DEBUG
                    DEBUG_FinalFlags = 0;
#endif

                    uint vertexStart = 0;
                    uint indexStart = 0;
                    for (uint j = 0; j < aggregateMeshGroupDef.TotalMeshCount; j++)
                    {
                        reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MeshDefs, aggregateMeshGroupDef.MeshDefIndices[j]));

                        uint flags = reader.ReadUInt32();

#if DEBUG
                        DEBUG_FinalFlags |= flags;
#endif

                        ushort materialInstanceIndex = reader.ReadUInt16();

                        ushort boneGroupIndex = reader.ReadUInt16();

                        ushort dataLayoutDescIndex = reader.ReadUInt16();

                        ushort vertexCount = reader.ReadUInt16();
                        ushort verticesStartIndex = reader.ReadUInt16(); // TODO - Unconfirmed

                        reader.SkipPadding(2);

                        uint highLodIBufferSliceStartIndex = reader.ReadUInt32();
                        Debug.Assert(highLodIBufferSliceStartIndex <= Int32.MaxValue);
                        uint highLodIBufferSliceCount = reader.ReadUInt32();
                        Debug.Assert(highLodIBufferSliceCount <= Int32.MaxValue);

                        // TODO: Fix properly
                        reader.Skip(4);
                        //uint iBufferSlicesStartIndex = iBufferSlicesGroupStartIndex + reader.ReadUInt32();

                        // Bone Group
                        reader.Seek(def.GetFeaturePositionForIndex(FeatureType.BoneGroups, boneGroupIndex));

                        ushort useWeightCount = reader.ReadUInt16();

                        ushort boneCount = reader.ReadUInt16();

                        Span<ushort> boneGroup = stackalloc ushort[32];
                        for (int k = 0; k < boneCount; k++)
                        {
                            boneGroup[k] = reader.ReadUInt16();
                        }

                        // TODO - hack!
                        for (uint k = 0; k < vertexBuffers.LongLength; k++)
                        {
                            uploadHelper.CopyVertexData(outputBuffers[k], k, j, vertexBuffers[k], layoutDescs[j].BufferDescs[k].Offset, layoutDescs[j].BufferDescs[k].Stride, vertexStart, vertexCount);
                            mesh.SetVertexBufferData(outputBuffers[k], (int)vertexStart * (int)uploadHelper.GetOutputBufferStride(k), (int)vertexStart * (int)uploadHelper.GetOutputBufferStride(k), vertexCount * (int)uploadHelper.GetOutputBufferStride(k), (int)k, UpdateFlags | MeshUpdateFlags.DontNotifyMeshUsers);
                        }

                        // TODO - Even more of a hack!
                        if (bones != null)
                            uploadHelper.CopyBoneWeights(weightBuffer, vertexBuffers[1], layoutDescs[j], layoutDescs[j].BufferDescs[1].Offset, layoutDescs[j].BufferDescs[1].Stride, vertexStart, vertexCount, boneGroup[..boneCount]);

                        mesh.SetIndexBufferData(indexBuffer, (int)highLodIBufferSliceStartIndex * 2, (int)indexStart * 2, (int)highLodIBufferSliceCount * 2, UpdateFlags | MeshUpdateFlags.DontNotifyMeshUsers);

                        mesh.SetSubMesh((int)j, new SubMeshDescriptor { topology = MeshTopology.Triangles, indexStart = (int)indexStart, indexCount = (int)highLodIBufferSliceCount, firstVertex = (int)vertexStart, vertexCount = vertexCount, baseVertex = (int)vertexStart }, UpdateFlags);

                        vertexStart += vertexCount;
                        indexStart += highLodIBufferSliceCount;
                    }

#if DEBUG
                    mesh.name += $"<{Convert.ToString(DEBUG_FinalFlags, 2).PadLeft(32, '0')}>";
#endif

                    mesh.bounds = aggregateMeshGroupDef.Bounds;

                    Bounds localBounds = mesh.bounds;
                    localBounds.center = main.transform.worldToLocalMatrix * new Vector4(localBounds.center.x, localBounds.center.y, localBounds.center.z, 1.0f);
                    localBounds.size = main.transform.worldToLocalMatrix * localBounds.size;

                    var sharedMaterials = new Material[mesh.subMeshCount];
                    for (uint j = 0; j < sharedMaterials.Length; j++)
                        sharedMaterials[j] = new Material(Shader.Find("Fox/Gr/DebugDrawFlags"));

                    if (bones == null)
                    {
                        MeshFilter meshFilter = meshGroup.AddComponent<MeshFilter>();

                        meshFilter.sharedMesh = mesh;

                        MeshRenderer meshRenderer = meshGroup.AddComponent<MeshRenderer>();

                        meshRenderer.sharedMaterials = sharedMaterials;
                    }
                    else
                    {
                        mesh.boneWeights = weightBuffer;
                        mesh.bindposes = bindPoses;

                        SkinnedMeshRenderer skinnedMeshRenderer = meshGroup.AddComponent<SkinnedMeshRenderer>();
                        skinnedMeshRenderer.localBounds = localBounds;
                        skinnedMeshRenderer.bones = bones;
                        skinnedMeshRenderer.sharedMesh = mesh;
                        skinnedMeshRenderer.rootBone = bones[0];

                        skinnedMeshRenderer.sharedMaterials = sharedMaterials;
                    }

                    context.AddObjectToAsset(mesh.name, mesh);
                }
            }

            context.AddObjectToAsset(name, main);

            context.SetMainObject(main);

            return;
        }
    }
}