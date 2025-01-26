using Fox.Fio;
using Fox;
using System;
using System.IO;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.Rendering;

namespace Fox.Gr
{ 
    class Fmdl
    {
        public enum FeatureType : byte
        {
            BoneUnit = 0,
            MeshHeader = 1,
            MeshDef = 2,
            MeshPacket = 3,
            MaterialInstance = 4,
            BoneGroup = 5,
            TextureRef = 6,
            MaterialParameter = 7,
            MaterialPlatformAlias = 8,
            PacketDataLayoutDesc = 9,
            MeshBufferHeader = 10,
            MeshBufferFormatElements = 11,
            String = 12,
            BoundingBox = 13,
            FileMeshBufferHeader = 14,
            MeshLodDesc = 16,
            LodIndexSlice = 17,
            Unk18 = 18,
            Unk19 = 19,
            LodInfo = 20,
            Path = 21,
            StringId = 22,

            // Last real type + 1
            COUNT,
        }
        
        public static readonly uint[] FeatureUnitSizes =
        {
            0x30, // 0  - BoneUnit
            0x8,  // 1  - MeshHeader
            0x20, // 2  - MeshDef
            0x30, // 3  - MeshPacket
            0x10, // 4  - MaterialInstance
            0x44, // 5  - BoneGroup
            0x4,  // 6  - TextureRef
            0x4,  // 7  - MaterialParameter
            0x4,  // 8  - MaterialPlatformAlias
            0x8,  // 9  - PacketDataLayoutDesc
            0x8,  // 10 - MeshBufferHeader
            0x4,  // 11 - MeshBufferFormatElement

            0x0,  // 12 - String

            0x20, // 13 - BoundingBox
            0x10, // 14 - FileMeshBufferHeader

            0x0,  // 15 - Unknown

            0x10, // 16 - MeshLodDesc
            0x8,  // 17 - LodIndexSlice
            0x8,  // 18 - Type18

            0x0,  // 19 - Unknown

            0x80, // 20 - LodInfo

            0x8,  // 21 - Path
            0x8,  // 22 - StringId
        };
        
        public struct Header
        {
            public uint Signature; // char Signature[4]; Assert(Signature == "FMDL");

            public float Version; // Assert(Version == 2.03f || Version == 2.04f);

            public uint FileDescOffset;
            public uint _Padding0; // Assert(Padding0 == 0);

            public uint FeatureTypes;
            public uint _Padding1; // Assert(Padding1 == 0);

            public uint BufferTypes;
            public uint _Padding2; // Assert(Padding1 == 0);
	
            public uint FeatureCount;
            public uint BufferCount;
            public uint FeaturesDataOffset;
            public uint FeaturesDataSize;
            public uint BuffersDataOffset;
            public uint BuffersDataSize;
        }

        public struct FeatureHeader
        {
            public FeatureType Type;
            public byte CountOverflow;
            public ushort EntryCount; // Entry count == CountOverflow * (UINT16_MAX + 1) + EntryCount
            public uint DataOffset;
        }

        public enum BufferType : uint
        {
            Vector = 0,
            Poly = 2,
            String = 3,
            
            COUNT,
        }
        
        public struct BufferHeader
        {
            public BufferType Type;
            public uint DataOffset;
            public uint DataSize;
        }
        
        public enum BoneFlags : ushort
        {
            HasBoundingBox = 1 << 0,
            B =              1 << 1,
            C =              1 << 2,
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x30)]
        public struct BoneUnit 
        {
            public ushort NameIdIndex;
            public short ParentIndex;
            public ushort BoundingBoxIndex;
            public BoneFlags Flags; // Assert(Flags.B == 0);

            public ulong _Padding0;
            
            public Vector4 Position;
            public Vector4 WorldPosition;
        }
        
        public enum MeshHeaderFlags : ushort
        {
            Invisible         = 1 << 0,
            HasFragmentOffset = 1 << 1,
            B		          = 1 << 2,
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x8)]
        public struct MeshHeader
        {
            public ushort NameIdIndex;
            public MeshHeaderFlags Flags;
            public short ParentIndex;
            public short FragmentOffsetVectorIndex;
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x20)]
        public struct MeshDef
        {
            public uint Unknown; // Assert(Unknown == 0);

            public ushort HeaderIndex;
            public ushort PacketCount;
            public ushort PacketsStartIndex;

            public ushort BoundingBoxIndex;

            public uint _Padding0; // Assert(Padding0 == 0);

            public ushort LodIndexSlicesStartIndex;

            public ushort _Padding1; // Assert(Padding1 == 0);
            public uint _Padding2; // Assert(Padding2 == 0);
            public ulong _Padding3; // Assert(Padding3 == 0);
        }

        public enum MeshPacketFlags : uint
        {
            
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x30)]
        public struct MeshPacket
        {
            public MeshPacketFlags Flags;

            public ushort MaterialInstanceIndex;
            public ushort BoneGroupIndex;

            public ushort DataLayoutDescIndex;

            public ushort VertexCount;
            public ushort VerticesStartIndex; // Assert(VerticesStartIndex == 0);

            public ushort _Padding0; // Assert(Padding0 == 0);

            public LodIndexSlice HighLodSlice;

            public uint LodIndexSlicesStartIndex; // Only actually used if some EXE byte says to use multiple slices. Each slice's StartIndex is relative to the main slice.
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x10)]
        public struct MaterialInstance
        {
            public ushort NameIdIndex;

            public ushort _Padding0; // Assert(Padding0 == 0);

            public ushort MaterialIdIndex;
            public byte TextureParamCount;
            public byte VectorParamCount;
            public ushort TextureParamsStartIndex;
            public ushort VectorParamsStartIndex;
	    
            public uint _Padding1; // Assert(Padding1 == 0);
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x44)]
        public struct BoneGroup
        {
            public ushort UseWeightCount; // Assert(UseWeightCount <= 4);
            public ushort BoneCount; // Assert(UseWeightCount <= BoneCount);
            // ushort BoneIndices[BoneCount];
            // FSkip(0x40 - BoneCount * sizeof(ushort));
        } 
        
        [StructLayout(LayoutKind.Sequential, Size = 0x4)]
        public struct TextureRefUnit
        {
            public ushort NameIdIndex; // For "/Assets/path/name.ftex" this is StrCode("name") if TPP or just "name.ext" (ext can be tga, psd, etc.) if GZ
            public ushort PathIndex; // For "/Assets/path/name.ftex" this is PathCode64("/Assets/path/name.ftex") if TPP or just "/Assets/path/" if GZ
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x4)]
        public struct MaterialParameter
        {
            public ushort ParamIdIndex;
            public ushort ReferenceIndex; // Can be either a path index to a .ftex or an index into the material params buffer 
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x4)]
        public struct MaterialPlatformAlias
        {
            public ushort ShaderIdIndex;
            public ushort TechniqueIdIndex;
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x8)]
        public struct PacketDataLayoutDesc
        {
            public byte BufferCount;
            public byte FormatElementCount;
            public sbyte PROBABLE_FirstUvSetIndex; //Assert(Unknown0 == 0); //Possibly the first UV set's index.
            public byte UvCount;
            public ushort BufferHeadersStartIndex;
            public ushort FormatElementsStartIndex;
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x8)]
        public struct MeshBufferHeader
        {
            public byte FileMeshBufferHeaderIndex;
            public byte FormatElementCount;
            public byte Stride;
            public byte BindSlot; // Assert(BindSlot <= 3);
            public uint Offset;
        }
        
        public enum MeshBufferFormatElementUsage : byte
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

        public enum MeshBufferFormatElementType : byte
        {
            R32G32B32_Float = 1,

            R16G16B16A16_Float = 6,
            R16G16_Float = 7,
            R8G8B8A8_UNorm = 8,
            R8G8B8A8_UInt = 9,
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x4)]
        public struct MeshBufferFormatElement
        {
            public MeshBufferFormatElementUsage Usage; // Assert(Usage != 4 && Usage != 5 && Usage != 6 && Usage < 15);
            public MeshBufferFormatElementType Type; // Assert(Type != 0 && Type != 2 && Type != 3 && Type != 5 && Type < 10); Assert(Usage != 4);
            public ushort Offset;
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x8)]
        public struct String
        {
            public ushort BufferType; // Assert((BufferType)BufferType == BufferType.Strings);
            public ushort Length;
            public uint Offset;
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x20)]
        public struct BoundingBox
        {
            public Vector4 Min;
            public Vector4 Max;
        }
        
        public enum FileMeshBufferType : ushort
        {
            VBuffer = 0,
            IndexBuffer = 1,
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x10)]
        public struct FileMeshBufferHeader
        {
            public FileMeshBufferType Type;
            
            public ushort _Padding0;

            public uint DataSize;
            public uint DataOffset;
	    
            public uint _Padding1; // Assert(Padding == 0);
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x10)]
        public struct MeshLodDesc
        {
            ushort LodCount;

            ushort _Padding0;
            
            float Unknown0;
            float Unknown1;
            float Unknown2;
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x8)]
        public struct LodIndexSlice
        {
            public uint StartIndex;
            public uint Count;
        }
        
        [StructLayout(LayoutKind.Explicit, Size = 0x80)]
        public struct LodInfo
        {
            [FieldOffset(0x0)] public uint Unknown0;
            [FieldOffset(0x4)] public float Unknown1; //Nulling triggers lowest LOD faces.
            [FieldOffset(0x8)] public float Unknown2;

            [FieldOffset(0xc)] public float Unknown3;

            [FieldOffset(0x10)] public float LodPolygonSize; //Always a whole number?
            [FieldOffset(0x14)] public float LodNearSize;
            [FieldOffset(0x18)] public float LodFarSize;
            
            [FieldOffset(0x1c)] public byte DrawRejectionLevel; // StaticModel's enum gets converted to this number
            
            [FieldOffset(0x20)] public byte RejectFarRangeShadowCastLevel; // StaticModel's enum gets converted to this number
        } 
            
    }
    
    [ScriptedImporter(1, "fmdl")]
    public unsafe partial class ModelFileImporter2 : ScriptedImporter
    {
        private struct ModelDataAccessor
        {
            private Fmdl.Header* Header;

            private static uint FeatureTypes = 0;
            private static Fmdl.FeatureHeader*[] FeatureHeaders = new Fmdl.FeatureHeader*[(int)Fmdl.FeatureType.COUNT];
            
            private static uint BufferTypes = 0;
            private static uint[] BufferOffsets = new uint[(int)Fmdl.BufferType.COUNT];
            
            private Action<string> LogWarning;
            private Action<string> LogError;

            public ModelDataAccessor(Fmdl.Header* header, Action<string> logWarning, Action<string> logError)
            {
                Header = header;
                LogWarning = logWarning;
                LogError = logError;
                
                if (header->FeatureTypes == 0 || header->FeaturesDataOffset == 0 || header->FeaturesDataSize == 0)
                    Debug.Assert(header->FeatureTypes == 0 && header->FeaturesDataOffset == 0 && header->FeaturesDataSize == 0);

                if (header->BufferTypes == 0 || header->BuffersDataOffset == 0 || header->BuffersDataSize == 0)
                    Debug.Assert(header->BufferTypes == 0 && header->BuffersDataOffset == 0 && header->BuffersDataSize == 0);
                
                if (header->FileDescOffset != 0)
                {
                    FeatureTypes = header->FeatureTypes;
                    Fmdl.FeatureHeader* featureHeaders = (Fmdl.FeatureHeader*)((byte*)header + header->FileDescOffset);

                    uint featureCount = header->FeatureCount;
                    uint featureTypesValidator = FeatureTypes;
                    for (uint i = 0; i < featureCount; i++)
                    {
                        Fmdl.FeatureHeader* featureHeader = featureHeaders + i;
                        
                        var type = featureHeader->Type;
                        Debug.Assert(type < Fmdl.FeatureType.COUNT);

                        Debug.Assert(featureTypesValidator != 0);
                        Debug.Assert((featureTypesValidator & (1 << (int)type)) != 0);
                        featureTypesValidator &= (uint)~(featureTypesValidator & (1 << (int)type));

                        FeatureHeaders[(int)type] = featureHeader; // .Count = ((uint)reader.ReadByte() * (UInt16.MaxValue + 1)) + reader.ReadUInt16(); // Not technically accurate for all features; some don't use the overflow feature.
                    }
                    Debug.Assert(featureTypesValidator == 0);

                    BufferTypes = header->BufferTypes;
                    Fmdl.BufferHeader* bufferHeaders = (Fmdl.BufferHeader*)(featureHeaders + featureCount);
                    
                    uint bufferCount = header->BufferCount;
                    uint bufferTypesValidator = BufferTypes;
                    for (uint i = 0; i < bufferCount; i++)
                    {
                        Fmdl.BufferHeader* bufferHeader = bufferHeaders + i;

                        var type = bufferHeader->Type;
                        Debug.Assert(type < Fmdl.BufferType.COUNT);
                        if ((int)type == 1)
                            logWarning("BufferType 1 found.");

                        Debug.Assert(bufferTypesValidator != 0);
                        Debug.Assert((bufferTypesValidator & (1 << (int)type)) != 0);
                        bufferTypesValidator &= (uint)~(bufferTypesValidator & (1 << (int)type));

                        BufferOffsets[(int)type] = bufferHeader->DataOffset;
                        
                        Debug.Assert(bufferHeader->DataSize != 0); // I am not sure if size == 0 is a valid state or not.
                    }
                    Debug.Assert(bufferTypesValidator == 0);
                }
                else
                {
                    logWarning("FileDescOffset is 0; model has no features or buffers.");
                }
            }
            
            public bool HasFeature(Fmdl.FeatureType type) => (FeatureTypes & (1 << (int)type)) != 0;

            public uint GetFeatureCount(Fmdl.FeatureType type)
            {
                if (HasFeature(type))
                {
                    Fmdl.FeatureHeader* header = FeatureHeaders[(int)type];
                    
                    return header->CountOverflow * (ushort.MaxValue + 1u) + header->EntryCount;
                }

                return 0;
            }

            // No validation.
            public T* GetFeature<T>(Fmdl.FeatureType type) where T : unmanaged
            {
                if (HasFeature(type))
                {
                    byte* ptr = (byte*)Header + Header->FeaturesDataOffset + FeatureHeaders[(int)type]->DataOffset;
                    return (T*)ptr;
                }

                return null;
            }

            public bool HasBuffer(Fmdl.BufferType type) => (BufferTypes & (1 << (int)type)) != 0;
            
            public byte* GetBuffer(Fmdl.BufferType type)
            {
                if (HasBuffer(type))
                {
                    byte* ptr = (byte*)Header + Header->BuffersDataOffset + BufferOffsets[(int)type];
                    return ptr;
                }

                return null;
            }

            public void ValidateFeatureIndex(Fmdl.FeatureType owner, Fmdl.FeatureType indexed, uint index)
            {
#if DEBUG
                // TODO: override id or stringid
                if (index >= GetFeatureCount(indexed))
                {
                    LogError($"{owner} referencing {indexed} that does not exist.");
                    throw new InvalidDataException($"{owner} referencing {indexed} that does not exist.");
                }
#else
                return true;
#endif
            }
        }

        private struct AggregateMeshDef
        {
            public uint TotalPacketCount;

            public uint SpanCounter;

            public uint[] PacketIndices;

            public Bounds Bounds;

            public uint LodIndexSlicesStartIndex;
        }

        private struct MeshBufferDesc
        {
            public byte Stride;
            public uint Offset;
            public byte FileBufferIndex;
            public byte Slot;
            public MeshBufferFormatElement[] Elements;
        }

        private struct MeshDataLayoutDesc
        {
            public MeshBufferDesc[] BufferDescs;
        }

        private const MeshUpdateFlags UpdateFlags = MeshUpdateFlags.DontRecalculateBounds | MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds;

        private static Bounds InvalidBoundingBox = new() { max = new Vector3(-1e10f, -1e10f, -1e10f), min = new Vector3(1e10f, 1e10f, 1e10f) };

        private string ReadId(ref ModelDataAccessor accessor, ushort index)
        {
            string result = null;
            if (accessor.HasFeature(Fmdl.FeatureType.String))
            {
                Fmdl.String stringHeader = accessor.GetFeature<Fmdl.String>(Fmdl.FeatureType.String)[index];
                // TODO
                result = $"TODO_STRINGHEADER_{stringHeader.Offset}";
            }
            else
            {
                StrCode stringId = accessor.GetFeature<StrCode>(Fmdl.FeatureType.StringId)[index];
                result = stringId.ToString();
            }
            
            return result;
        }

        private Bounds ReadBoundingBox(ref ModelDataAccessor accessor, ushort index)
        {
            Fmdl.BoundingBox* box = accessor.GetFeature<Fmdl.BoundingBox>(Fmdl.FeatureType.BoundingBox);
            box += index;

            Vector3 max = Fox.Math.FoxToUnityVector4(box->Min);
            Vector3 min = Fox.Math.FoxToUnityVector4(box->Max);

            (min.x, max.x) = (max.x, min.x);

            var result = new Bounds
            {
                max = max,
                min = min
            };

            return result;
        }

        public override void OnImportAsset(AssetImportContext context)
        {
            string name = System.IO.Path.GetFileName(context.assetPath);

            void logWarning(string message)
            {
                Debug.LogWarning($"{name}: {message}");
            }

            void logError(string message)
            {
                Debug.LogError($"{name}: {message}");
            }

            byte[] fileData = System.IO.File.ReadAllBytes(assetPath);

            fixed (byte* ptr = fileData)
            {
                Fmdl.Header* header = (Fmdl.Header*)ptr;

                if (header->Signature != 0x4C444D46) // FMDL
                {
                    logError("Signature check failed.");
                    return;
                }

                if (header->Version < 2.02f)
                {
                    logError("Unsupported FMDL version.");
                    return;
                }

                var main = new GameObject(name);

                ModelDataAccessor accessor = new(header, logWarning, logError);

                accessor.ValidateFeatureIndex(Fmdl.FeatureType.BoundingBox, Fmdl.FeatureType.BoundingBox, 0);
                {
                    BoxCollider boxComponent = main.AddComponent<BoxCollider>();
                    Bounds box = ReadBoundingBox(ref accessor, 0);
                    boxComponent.center = box.center;
                    boxComponent.size = box.size;
                }

    #if DEBUG
                uint DEBUG_FinalFlags = 0;
    #endif

                // Bones
                Transform[] bones = null;
                Matrix4x4[] bindPoses = null;
                if (accessor.HasFeature(Fmdl.FeatureType.BoneUnit))
                {
                    uint boneCount = accessor.GetFeatureCount(Fmdl.FeatureType.BoneUnit);

                    bones = new Transform[boneCount];
                    bindPoses = new Matrix4x4[boneCount];

                    Fmdl.BoneUnit* boneUnits = accessor.GetFeature<Fmdl.BoneUnit>(Fmdl.FeatureType.BoneUnit);
                    for (uint i = 0; i < boneCount; i++)
                    {
                        Fmdl.BoneUnit* boneUnit = boneUnits + i;

                        accessor.ValidateFeatureIndex(Fmdl.FeatureType.BoneUnit, Fmdl.FeatureType.StringId, boneUnit->NameIdIndex);
                        string boneName = ReadId(ref accessor, boneUnit->NameIdIndex);

                        var bone = new GameObject(boneName);
                        bones[i] = bone.transform;

                        short parentIndex = boneUnit->ParentIndex;
                        if (parentIndex > -1)
                            accessor.ValidateFeatureIndex(Fmdl.FeatureType.BoneUnit, Fmdl.FeatureType.BoneUnit, (uint)parentIndex);

                        ushort boundingBoxIndex = boneUnit->BoundingBoxIndex;
                        accessor.ValidateFeatureIndex(Fmdl.FeatureType.BoneUnit, Fmdl.FeatureType.BoundingBox, boundingBoxIndex);
                        Bounds box = ReadBoundingBox(ref accessor, boundingBoxIndex);

                        Fmdl.BoneFlags flags = boneUnit->Flags;
                        if (((uint)flags & ~(uint)Fmdl.BoneFlags.HasBoundingBox) != 0)
                            logWarning("Unknown BoneFlags.");

                        bone.transform.localPosition = Fox.Math.FoxToUnityVector3(boneUnit->Position);

                        bone.transform.SetParent(parentIndex == -1 ? main.transform : bones[parentIndex], false);

                        if (flags.HasFlag(Fmdl.BoneFlags.HasBoundingBox))
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

                // Process MeshHeaders. This is done as a pre-step because (all?) models have a stub MeshHeader that owns all other MeshHeaders but to which no MeshDefs belong.
                GameObject[] meshes = null;
                if (accessor.HasFeature(Fmdl.FeatureType.MeshHeader))
                {
                    uint meshHeaderCount = accessor.GetFeatureCount(Fmdl.FeatureType.MeshHeader);

                    meshes = new GameObject[meshHeaderCount];

                    Fmdl.MeshHeader* meshHeaders = accessor.GetFeature<Fmdl.MeshHeader>(Fmdl.FeatureType.MeshHeader);
                    for (uint i = 0; i < meshHeaderCount; i++)
                    {
                        Fmdl.MeshHeader* meshHeader = meshHeaders + i;

                        ushort nameIdIndex = meshHeader->NameIdIndex;
                        accessor.ValidateFeatureIndex(Fmdl.FeatureType.MeshHeader, Fmdl.FeatureType.StringId, nameIdIndex);
                        string meshName = ReadId(ref accessor, nameIdIndex);

                        Fmdl.MeshHeaderFlags flags = meshHeader->Flags;
                        if (flags.HasFlag(Fmdl.MeshHeaderFlags.HasFragmentOffset) && bones is not null)
                            logWarning("Mesh has both bones and fragment offsets.");
                        if (flags.HasFlag(Fmdl.MeshHeaderFlags.B))
                            logWarning("Mesh has B flag.");

                        var mesh = new GameObject(meshName);
                        meshes[i] = mesh;

                        if (flags.HasFlag(Fmdl.MeshHeaderFlags.Invisible))
                            mesh.SetActive(false);

                        short parentIndex = meshHeader->ParentIndex;
                        if (parentIndex > -1)
                            accessor.ValidateFeatureIndex(Fmdl.FeatureType.MeshHeader, Fmdl.FeatureType.MeshHeader, (uint)parentIndex);

                        mesh.transform.SetParent(parentIndex == -1 ? main.transform : meshes[parentIndex].transform);

                        short fragmentOffsetVectorIndex = meshHeader->FragmentOffsetVectorIndex;
                        Debug.Assert(flags.HasFlag(Fmdl.MeshHeaderFlags.HasFragmentOffset) == (fragmentOffsetVectorIndex != -1));

                        if (flags.HasFlag(Fmdl.MeshHeaderFlags.HasFragmentOffset))
                        {
                            Vector4* vectors = (Vector4*)accessor.GetBuffer(Fmdl.BufferType.Vector);
                            
                            mesh.transform.localPosition = Fox.Math.FoxToUnityVector3(vectors[fragmentOffsetVectorIndex]);
                        }
                    }
                }

                byte[] indexBuffer = null;
                byte*[] vBuffers = null;
                if (accessor.HasFeature(Fmdl.FeatureType.FileMeshBufferHeader))
                {
                    uint meshBufferHeaderCount = accessor.GetFeatureCount(Fmdl.FeatureType.FileMeshBufferHeader);
                    
                    Fmdl.FileMeshBufferHeader* meshBufferHeaders = accessor.GetFeature<Fmdl.FileMeshBufferHeader>(Fmdl.FeatureType.FileMeshBufferHeader);

                    uint vBufferCount = 0;
                    for (uint i = 0; i < meshBufferHeaderCount; i++)
                    {
                        Fmdl.FileMeshBufferHeader* meshBufferHeader = meshBufferHeaders + i;

                        Fmdl.FileMeshBufferType type = meshBufferHeader->Type;
                        if (type == Fmdl.FileMeshBufferType.VBuffer)
                            vBufferCount++;
                    }
                    
                    vBuffers = new byte*[vBufferCount];

                    for (uint i = 0, vBufferIndex = 0; i < meshBufferHeaderCount; i++)
                    {
                        Fmdl.FileMeshBufferHeader* meshBufferHeader = meshBufferHeaders + i;

                        Fmdl.FileMeshBufferType type = meshBufferHeader->Type;
                        Debug.Assert(type is Fmdl.FileMeshBufferType.VBuffer or Fmdl.FileMeshBufferType.IndexBuffer);

                        uint dataSize = meshBufferHeader->DataSize;
                        Debug.Assert(dataSize <= Int32.MaxValue);

                        byte* data = accessor.GetBuffer(Fmdl.BufferType.Poly) + meshBufferHeader->DataOffset;

                        if (type == Fmdl.FileMeshBufferType.IndexBuffer)
                        {
                            indexBuffer = new byte[dataSize];
                            Marshal.Copy(new IntPtr(data), indexBuffer, 0, (int)dataSize);
                        }
                        else
                        {
                            vBuffers[vBufferIndex] = data;
                            vBufferIndex++;
                        }
                    }
                }
                
                Material defaultMaterial = AssetDatabase.GetBuiltinExtraResource<Material>("Default-Material.mat");
                context.AddObjectToAsset("Material", defaultMaterial);

                // Preprocess MeshGroupDefs
                if (accessor.HasFeature(Fmdl.FeatureType.MeshDef))
                {
                    var aggregateMeshDefs = new AggregateMeshDef[meshes.Length];

                    uint meshDefCount = accessor.GetFeatureCount(Fmdl.FeatureType.MeshDef);

                    // Initial loops for input validation and collecting of data for AggregateMeshDefs
                    Fmdl.MeshDef* meshDefs = accessor.GetFeature<Fmdl.MeshDef>(Fmdl.FeatureType.MeshDef);
                    for (uint i = 0; i < meshDefCount; i++)
                    {
                        Fmdl.MeshDef* meshDef = meshDefs + i;

                        uint unknown = meshDef->Unknown;
                        Debug.Assert(unknown == 0);

                        ushort headerIndex = meshDef->HeaderIndex;
                        accessor.ValidateFeatureIndex(Fmdl.FeatureType.MeshDef, Fmdl.FeatureType.MeshHeader, headerIndex);

                        ushort packetCount = meshDef->PacketCount;
                        ushort packetsStartIndex = meshDef->PacketsStartIndex;
                        if (packetCount > 0)
                            accessor.ValidateFeatureIndex(Fmdl.FeatureType.MeshDef, Fmdl.FeatureType.MeshPacket, (uint)(packetsStartIndex + packetCount - 1));

                        aggregateMeshDefs[headerIndex].TotalPacketCount += packetCount;

                        ushort boundingBoxIndex = meshDef->BoundingBoxIndex;
                        accessor.ValidateFeatureIndex(Fmdl.FeatureType.MeshDef, Fmdl.FeatureType.BoundingBox, boundingBoxIndex);

                        ushort lodIndexSlicesStartIndex = meshDef->LodIndexSlicesStartIndex;
                        accessor.ValidateFeatureIndex(Fmdl.FeatureType.MeshDef, Fmdl.FeatureType.LodIndexSlice, lodIndexSlicesStartIndex);
                    }

                    // Create packet index remap array and initialize bounds
                    for (uint i = 0; i < aggregateMeshDefs.LongLength; i++)
                    {
                        ref AggregateMeshDef aggregateMeshDef = ref aggregateMeshDefs[i];

                        aggregateMeshDef.PacketIndices = new uint[aggregateMeshDef.TotalPacketCount];
                        aggregateMeshDef.Bounds = InvalidBoundingBox;
                    }

                    // Actually set packet indices and update bounds
                    for (uint i = 0; i < meshDefCount; i++)
                    {
                        Fmdl.MeshDef* meshDef = meshDefs + i;

                        ushort headerIndex = meshDef->HeaderIndex;

                        ref AggregateMeshDef aggregateMeshDef = ref aggregateMeshDefs[headerIndex];

                        ushort packetCount = meshDef->PacketCount;
                        ushort packetsStartIndex = meshDef->PacketsStartIndex;
                        for (uint j = 0; j < packetCount; j++)
                            aggregateMeshDef.PacketIndices[aggregateMeshDef.SpanCounter + j] = packetsStartIndex + j;

                        ushort boundingBoxIndex = meshDef->BoundingBoxIndex;
                        Bounds box = ReadBoundingBox(ref accessor, boundingBoxIndex);
                        if (aggregateMeshDef.Bounds == InvalidBoundingBox)
                            aggregateMeshDef.Bounds = box;
                        else
                            aggregateMeshDef.Bounds.Encapsulate(box);

                        aggregateMeshDef.LodIndexSlicesStartIndex = meshDef->LodIndexSlicesStartIndex;

                        aggregateMeshDef.SpanCounter += packetCount;
                    }

                    // Create and set data for each mesh
                    for (uint i = 0; i < aggregateMeshDefs.LongLength; i++)
                    {
                        AggregateMeshDef aggregateMeshDef = aggregateMeshDefs[i];

                        if (aggregateMeshDef.TotalPacketCount == 0)
                            continue;

                        GameObject meshGameObject = meshes[i];
                        
                        // MeshDefs
                        var layoutDescs = new MeshDataLayoutDesc[aggregateMeshDef.TotalPacketCount];
                        uint totalVertexCount = 0;
                        uint totalIndexCount = 0;
                        uint bufferCountToAllocate = 0;
                        Fmdl.PacketDataLayoutDesc* packetDataLayoutDescs = accessor.GetFeature<Fmdl.PacketDataLayoutDesc>(Fmdl.FeatureType.PacketDataLayoutDesc);
                        Fmdl.MeshPacket* meshPackets = accessor.GetFeature<Fmdl.MeshPacket>(Fmdl.FeatureType.MeshPacket);
                        for (uint j = 0; j < aggregateMeshDef.TotalPacketCount; j++)
                        {
                            Fmdl.MeshPacket* meshPacket = meshPackets + aggregateMeshDef.PacketIndices[j];

                            // TODO: Extensive flag validation
                            Fmdl.MeshPacketFlags flags = meshPacket->Flags;

                            ushort materialInstanceIndex = meshPacket->MaterialInstanceIndex;
                            accessor.ValidateFeatureIndex(Fmdl.FeatureType.MeshPacket, Fmdl.FeatureType.MaterialInstance, materialInstanceIndex);

                            ushort boneGroupIndex = meshPacket->BoneGroupIndex;
                            if (bones != null)
                            {
                                accessor.ValidateFeatureIndex(Fmdl.FeatureType.MeshPacket, Fmdl.FeatureType.BoneGroup, boneGroupIndex);
                                {
                                    // TODO - Inc. validation
                                    Fmdl.BoneGroup* boneGroup = accessor.GetFeature<Fmdl.BoneGroup>(Fmdl.FeatureType.BoneGroup) + boneGroupIndex;
                                    ushort useWeightCount = boneGroup->UseWeightCount;
                                }
                            }

                            ushort dataLayoutDescIndex =  meshPacket->DataLayoutDescIndex;
                            accessor.ValidateFeatureIndex(Fmdl.FeatureType.MeshPacket, Fmdl.FeatureType.PacketDataLayoutDesc, dataLayoutDescIndex);

                            // TODO - Inc. validation
                            ushort vertexCount = meshPacket->VertexCount;
                            ushort verticesStartIndex = meshPacket->VerticesStartIndex;

                            totalVertexCount += vertexCount;

                            // TODO - Inc. validation
                            Fmdl.LodIndexSlice hiLodSlice = meshPacket->HighLodSlice;

                            uint lodIndexSlicesStartIndex = aggregateMeshDef.LodIndexSlicesStartIndex + meshPacket->LodIndexSlicesStartIndex;

                            totalIndexCount += hiLodSlice.Count;

                            // Data layout
                            Fmdl.PacketDataLayoutDesc* packetDataLayoutDesc = packetDataLayoutDescs + dataLayoutDescIndex;

                            byte bufferCount = packetDataLayoutDesc->BufferCount;

                            byte formatElementCount = packetDataLayoutDesc->FormatElementCount;

                            // TODO: Figure out
                            sbyte firstUvSetIndex = packetDataLayoutDesc->PROBABLE_FirstUvSetIndex;
                            if (firstUvSetIndex != 0 && firstUvSetIndex != -128)
                                logWarning("PacketDataLayoutDesc.Unknown0 != 0");

                            byte uvCount = packetDataLayoutDesc->UvCount;
                            
                            Debug.Assert((firstUvSetIndex == -128) == (uvCount == 0));

                            ushort bufferHeadersStartIndex = packetDataLayoutDesc->BufferHeadersStartIndex;
                            if (bufferCount > 0)
                                accessor.ValidateFeatureIndex(Fmdl.FeatureType.PacketDataLayoutDesc, Fmdl.FeatureType.MeshBufferHeader, (uint)(bufferHeadersStartIndex + bufferCount - 1));

                            ushort formatElementsStartIndex = packetDataLayoutDesc->FormatElementsStartIndex;
                            if (formatElementCount > 0)
                                accessor.ValidateFeatureIndex(Fmdl.FeatureType.PacketDataLayoutDesc, Fmdl.FeatureType.MeshBufferFormatElements, (uint)(formatElementsStartIndex + formatElementCount - 1));

                            MeshDataLayoutDesc layoutDesc = layoutDescs[j] = new MeshDataLayoutDesc { BufferDescs = new MeshBufferDesc[bufferCount] };

                            // MeshBufferHeader
                            uint internalFormatElementsIndex = 0;
                            Fmdl.MeshBufferHeader* meshBufferHeaders = accessor.GetFeature<Fmdl.MeshBufferHeader>(Fmdl.FeatureType.MeshBufferHeader);
                            for (uint k = 0; k < bufferCount; k++)
                            {
                                Fmdl.MeshBufferHeader* meshBufferHeader = meshBufferHeaders + bufferHeadersStartIndex + k;

                                byte fileMeshBufferHeaderIndex = meshBufferHeader->FileMeshBufferHeaderIndex;
                                if (fileMeshBufferHeaderIndex + 1 > bufferCountToAllocate)
                                    bufferCountToAllocate = fileMeshBufferHeaderIndex + 1u;

                                byte formatElementCountRelative = meshBufferHeader->FormatElementCount;

                                byte stride = meshBufferHeader->Stride;

                                byte bindSlot = meshBufferHeader->BindSlot;
                                Debug.Assert(bindSlot < 4);

                                uint offset = meshBufferHeader->Offset;

                                layoutDesc.BufferDescs[k] = new MeshBufferDesc { Stride = stride, Offset = offset, FileBufferIndex = fileMeshBufferHeaderIndex, Elements = new MeshBufferFormatElement[formatElementCountRelative] };

                                // MeshBufferFormatElement
                                Fmdl.MeshBufferFormatElement* meshBufferFormatElements = accessor.GetFeature<Fmdl.MeshBufferFormatElement>(Fmdl.FeatureType.MeshBufferFormatElements);
                                for (uint l = 0; l < formatElementCountRelative; l++)
                                {
                                    uint index = internalFormatElementsIndex + l;

                                    Fmdl.MeshBufferFormatElement* meshBufferFormatElement = meshBufferFormatElements + formatElementsStartIndex + index;

                                    Fmdl.MeshBufferFormatElementUsage usage = meshBufferFormatElement->Usage; // TODO - validate type

                                    Fmdl.MeshBufferFormatElementType type = meshBufferFormatElement->Type; // TODO - validate type

                                    ushort offsetRelative = meshBufferFormatElement->Offset;

                                    layoutDesc.BufferDescs[k].Elements[l] = new MeshBufferFormatElement { Usage = usage, Type = type, Offset = offsetRelative };
                                }
                                internalFormatElementsIndex += formatElementCountRelative;
                            }
                        }

                        var uploadHelper = new BufferUploadHelper(bufferCountToAllocate, (uint)layoutDescs.LongLength);
                        uploadHelper.Register(layoutDescs);

                        // Unity Mesh
                        var unityMesh = new Mesh
                        {
                            name = meshGameObject.name
                        };
                        Debug.Assert(totalVertexCount <= Int32.MaxValue);
                        Debug.Assert(totalIndexCount <= Int32.MaxValue);
                        unityMesh.SetVertexBufferParams((int)totalVertexCount, uploadHelper.GetDescriptorArray());
                        unityMesh.SetIndexBufferParams((int)totalIndexCount, IndexFormat.UInt16);
                        unityMesh.subMeshCount = (int)aggregateMeshDef.TotalPacketCount;

                        NativeArray<byte>[] outVBuffers = uploadHelper.CreateVertexBuffers(totalVertexCount);
                        //NativeArray<uint>[] outIBuffers = uploadHelper.CreateIndexBuffers(totalIndexCount);
                        BoneWeight[] weightBuffer = bones == null ? null : new BoneWeight[totalVertexCount];;

    #if DEBUG
                        DEBUG_FinalFlags = 0;
    #endif

                        // Populate vertex buffer for each submesh from packet info
                        uint vertexStart = 0;
                        uint indexStart = 0;
                        for (uint j = 0; j < aggregateMeshDef.TotalPacketCount; j++)
                        {
                            Fmdl.MeshPacket* meshPacket = meshPackets + aggregateMeshDef.PacketIndices[j];

                            Fmdl.MeshPacketFlags flags = meshPacket->Flags;

    #if DEBUG
                            DEBUG_FinalFlags |= (uint)flags;
    #endif

                            ushort vertexCount = meshPacket->VertexCount;

                            Fmdl.LodIndexSlice highLodSlice = meshPacket->HighLodSlice;
                            Debug.Assert(highLodSlice.StartIndex <= Int32.MaxValue);
                            Debug.Assert(highLodSlice.Count <= Int32.MaxValue);

                            // TODO: Fix properly
                            //uint iBufferSlicesStartIndex = iBufferSlicesGroupStartIndex + reader.ReadUInt32();


                            // TODO - hack!
                            for (uint k = 0; k < vBuffers.LongLength; k++)
                            {
                                uploadHelper.CopyVertexData(outVBuffers[k], k, j, vBuffers[k], layoutDescs[j].BufferDescs[k].Offset, layoutDescs[j].BufferDescs[k].Stride, vertexStart, vertexCount);
                                unityMesh.SetVertexBufferData(outVBuffers[k], (int)vertexStart * (int)uploadHelper.GetOutputBufferStride(k), (int)vertexStart * (int)uploadHelper.GetOutputBufferStride(k), vertexCount * (int)uploadHelper.GetOutputBufferStride(k), (int)k, UpdateFlags | MeshUpdateFlags.DontNotifyMeshUsers);
                            }

                            // TODO - Even more of a hack!
                            // Bone Group
                            if (bones != null)
                            {
                                ushort boneGroupIndex = meshPacket->BoneGroupIndex;
                                Fmdl.BoneGroup* boneGroup = accessor.GetFeature<Fmdl.BoneGroup>(Fmdl.FeatureType.BoneGroup) + boneGroupIndex;

                                ReadOnlySpan<ushort> boneIndices = new ReadOnlySpan<ushort>((byte*)boneGroup + 4, boneGroup->BoneCount);
                                uploadHelper.CopyBoneWeights(weightBuffer, vBuffers[1], layoutDescs[j], layoutDescs[j].BufferDescs[1].Offset, layoutDescs[j].BufferDescs[1].Stride, vertexStart, vertexCount, boneIndices);
                            }

                            // TODO: Validate doesn't consider *2s
                            unityMesh.SetIndexBufferData(indexBuffer, (int)highLodSlice.StartIndex * 2, (int)indexStart * 2, (int)highLodSlice.Count * 2, UpdateFlags | MeshUpdateFlags.DontNotifyMeshUsers);

                            unityMesh.SetSubMesh((int)j, new SubMeshDescriptor { topology = MeshTopology.Triangles, indexStart = (int)indexStart, indexCount = (int)highLodSlice.Count, firstVertex = (int)vertexStart, vertexCount = vertexCount, baseVertex = (int)vertexStart }, UpdateFlags);

                            vertexStart += vertexCount;
                            indexStart += highLodSlice.Count;
                        }

                        // Debug flags
                        // TODO: REPLACE
    #if DEBUG
                        unityMesh.name += $"<{Convert.ToString(DEBUG_FinalFlags, 2).PadLeft(32, '0')}>";
    #endif

                        unityMesh.bounds = aggregateMeshDef.Bounds;

                        // Change bounds over to local space
                        Bounds localBounds = unityMesh.bounds;
                        localBounds.center = main.transform.worldToLocalMatrix * new Vector4(localBounds.center.x, localBounds.center.y, localBounds.center.z, 1.0f);
                        localBounds.size = main.transform.worldToLocalMatrix * localBounds.size;

                        // Materials
                        // TODO: Move
                        var sharedMaterials = new Material[unityMesh.subMeshCount];
                        for (uint j = 0; j < sharedMaterials.Length; j++)
                            sharedMaterials[j] = AssetDatabase.LoadAssetAtPath<Material>("Assets/Fox/Gr/Model/DebugDrawFlags.mat");

                        // Set up requisite Components
                        if (bones == null)
                        {
                            MeshFilter meshFilter = meshGameObject.AddComponent<MeshFilter>();
                            meshFilter.sharedMesh = unityMesh;

                            MeshRenderer meshRenderer = meshGameObject.AddComponent<MeshRenderer>();
                            meshRenderer.sharedMaterials = sharedMaterials;
                        }
                        else
                        {
                            unityMesh.boneWeights = weightBuffer;
                            unityMesh.bindposes = bindPoses;

                            SkinnedMeshRenderer skinnedMeshRenderer = meshGameObject.AddComponent<SkinnedMeshRenderer>();
                            skinnedMeshRenderer.localBounds = localBounds;
                            skinnedMeshRenderer.bones = bones;
                            skinnedMeshRenderer.sharedMesh = unityMesh;
                            skinnedMeshRenderer.rootBone = bones[0];

                            skinnedMeshRenderer.sharedMaterials = sharedMaterials;
                        }

                        context.AddObjectToAsset(unityMesh.name, unityMesh);
                    }
                }

                context.AddObjectToAsset(name, main);

                context.SetMainObject(main);

                return;
            }
        }
    }
}