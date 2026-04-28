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
            Unit = 1,
            UnitDef = 2,
            Packet = 3,
            MaterialInstance = 4,
            BoneGroup = 5,
            TextureRef = 6,
            MaterialParameter = 7,
            MaterialPlatformAlias = 8,
            InputLayoutDesc = 9,
            InputLayoutBindSlotDef = 10,
            InputLayoutElement = 11,
            String = 12,
            BoundingBox = 13,
            FileMeshBufferHeader = 14,
            MeshLodDesc = 16,
            IndexSpan = 17,
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
            0x8,  // 17 - IndexSpan
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
            public ushort ParentIndex;
            public ushort BoundingBoxIndex;
            public BoneFlags Flags; // Assert(Flags.B == 0);

            public ulong _Padding0;
            
            public Vector4 Position;
            public Vector4 WorldPosition;
        }
        
        public enum UnitFlags : ushort
        {
            Invisible         = 1 << 0,
            IsFragment = 1 << 1,
            B		          = 1 << 2,
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x8)]
        public struct UnitHeader
        {
            public ushort NameIdIndex;
            public UnitFlags Flags;
            public ushort ParentIndex;
            public ushort FragmentPositionVectorIndex;
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x20)]
        public struct UnitDef
        {
            public uint Unknown; // Assert(Unknown == 0);

            public ushort HeaderIndex;
            public ushort PacketCount;
            public ushort PacketsStartIndex;

            public ushort BoundingBoxIndex;

            public uint _Padding0; // Assert(Padding0 == 0);

            public ushort IndexSpansStartIndex;

            public ushort _Padding1; // Assert(Padding1 == 0);
            public uint _Padding2; // Assert(Padding2 == 0);
            public ulong _Padding3; // Assert(Padding3 == 0);
        }

        public enum PacketFlags : uint
        {
            
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x30)]
        public struct Packet
        {
            public PacketFlags Flags;

            public ushort MaterialInstanceIndex;
            public ushort BoneGroupIndex;

            public ushort InputLayoutDescIndex;

            public ushort VertexCount;
            public ushort VerticesStartIndex; // Assert(VerticesStartIndex == 0);

            public ushort _Padding0; // Assert(Padding0 == 0);

            public PacketLodIndices HighLodIndicesSpan; // TODO: Is this really just the high LODs? If not, I will remove the span type

            public uint IndexSpansStartIndex; // Only actually used if some EXE byte says to use multiple slices. Each slice's StartIndex is relative to the main slice.
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
        public struct InputLayoutDesc
        {
            public byte BindSlotCount;
            public byte ElementCount;
            public byte Unknown0; //Assert(Unknown0 == 0); //Possibly the first UV set's index.
            public byte UvCount;
            public ushort BindSlotDefsStartIndex;
            public ushort ElementsStartIndex;
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x8)]
        public struct InputLayoutBindSlotDef
        {
            public byte BufferIndex;
            public byte ElementCount;
            public byte Stride;
            public byte BindSlot; // Assert(BindSlot <= 3);
            public uint Offset;
        }
        
        public enum InputElementSemantic : byte
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

        public enum InputElementType : byte
        {
            R32G32B32_Float = 1,

            R16G16B16A16_Float = 6,
            R16G16_Float = 7,
            R8G8B8A8_UNorm = 8,
            R8G8B8A8_UInt = 9,
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x4)]
        public struct InputLayoutElement
        {
            public InputElementSemantic Semantic; // Assert(Usage != 4 && Usage != 5 && Usage != 6 && Usage < 15);
            public InputElementType Type; // Assert(Type != 0 && Type != 2 && Type != 3 && Type != 5 && Type < 10); Assert(Usage != 4);
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
            public Vector4 Max;
            public Vector4 Min;
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
        
        [StructLayout(LayoutKind.Sequential, Size = 0x8)]
        public struct PacketLodIndices
        {
            public uint StartIndex;
            public uint Count;
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x10)]
        public struct PacketsLodDesc
        {
            public ushort LodCount;

            public ushort _Padding0;
            
            public float Unknown0;
            public float Unknown1;
            public float Unknown2;
        }
        
        [StructLayout(LayoutKind.Explicit, Size = 0x80)]
        public struct LodInfo
        {
            [FieldOffset(0x0)] public uint Unknown0;
            [FieldOffset(0x4)] public float SurfaceArea; //Nulling triggers lowest LOD faces.
            [FieldOffset(0x8)] public float SqrtSurfaceAreaDivUVArea;

            [FieldOffset(0xc)] public float Unknown3;

            [FieldOffset(0x10)] public float LodPolygonSize;
            [FieldOffset(0x14)] public float LodNearSize;
            [FieldOffset(0x18)] public float LodFarSize;
            
            [FieldOffset(0x1c)] public byte DrawRejectionLevel; // can be -1. old: "StaticModel's enum gets converted to this number"
            
            [FieldOffset(0x20)] public byte RejectFarRangeShadowCastLevel; // can be negative one, else (value == 0) + 3. old: "StaticModel's enum gets converted to this number"
        }
    }
    
    [ScriptedImporter(2, "fmdl")]
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

            public bool ValidateFeatureIndex(Fmdl.FeatureType owner, Fmdl.FeatureType indexed, uint index)
            {
#if DEBUG
                // TODO: override id or stringid
                if (index >= GetFeatureCount(indexed))
                {
                    LogError($"{owner} referencing {indexed} that does not exist.");
                    return false;
                }
#endif

                return true;
            }
        }

        private struct UnitDefCollector
        {
            public uint DefCount;
            public uint CurrentDefIndex;
            
            public uint[] PacketCounts;
            public uint TotalPacketCount;
            public uint[] PacketStartIndices;
            public uint[] IndexSpansStartIndices;
            
            public Bounds Bounds;
        }

        private const MeshUpdateFlags UpdateFlags = MeshUpdateFlags.DontRecalculateBounds | MeshUpdateFlags.DontResetBoneBounds
#if DEBUG
        ;
#else
        | MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontValidateLodRanges;
#endif
        
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

            Vector3 max = Fox.Math.FoxToUnityVector4(box->Max);
            Vector3 min = Fox.Math.FoxToUnityVector4(box->Min);

            (min.x, max.x) = (max.x, min.x);

            var result = new Bounds
            {
                max = max,
                min = min
            };

            return result;
        }

        private enum ErrorCode
        {
            InvalidSignature,
            UnsupportedVersion,
            InvalidIndex,
            Success,
        }

        public override void OnImportAsset(AssetImportContext context)
        {
            ErrorCode errorCode = Import(context);
        }
        
        private ErrorCode Import(AssetImportContext context)
        {
            string name = System.IO.Path.GetFileName(context.assetPath);

            void logWarning(string message) => Debug.LogWarning($"{name}: {message}");
            void logError(string message) => Debug.LogError($"{name}: {message}");

            byte[] fileData = System.IO.File.ReadAllBytes(assetPath);

            fixed (byte* ptr = fileData)
            {
                Fmdl.Header* header = (Fmdl.Header*)ptr;

                if (header->Signature != 0x4C444D46) // FMDL
                {
                    return ErrorCode.InvalidSignature;
                }

                if (header->Version < 2.02f)
                {
                    return ErrorCode.InvalidIndex;
                }

                var rootObject = new GameObject(name);
                context.AddObjectToAsset(name, rootObject);
                context.SetMainObject(rootObject);

                ModelDataAccessor accessor = new(header, logWarning, logError);

                if (!accessor.ValidateFeatureIndex(Fmdl.FeatureType.BoundingBox, Fmdl.FeatureType.BoundingBox, 0))
                    return ErrorCode.InvalidIndex;
                BoxCollider rootBoundsComponent = rootObject.AddComponent<BoxCollider>();
                Bounds rootBounds = ReadBoundingBox(ref accessor, 0);
                rootBoundsComponent.center = rootBounds.center;
                rootBoundsComponent.size = rootBounds.size;

    #if DEBUG
                uint DEBUG_FinalFlags = 0;
                float DEBUG_SurfaceArea = 0.0f;
                float DEBUG_UVArea = 0.0f;
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

                        if (!accessor.ValidateFeatureIndex(Fmdl.FeatureType.BoneUnit, Fmdl.FeatureType.StringId, boneUnit->NameIdIndex))
                            return ErrorCode.InvalidIndex;
                        string boneName = ReadId(ref accessor, boneUnit->NameIdIndex);

                        GameObject bone = new GameObject(boneName);
                        bones[i] = bone.transform;

                        ushort parentIndex = boneUnit->ParentIndex;
                        if (parentIndex != ushort.MaxValue)
                            if (!accessor.ValidateFeatureIndex(Fmdl.FeatureType.BoneUnit, Fmdl.FeatureType.BoneUnit, (uint)parentIndex))
                                return ErrorCode.InvalidIndex;

                        ushort boundingBoxIndex = boneUnit->BoundingBoxIndex;
                        if (!accessor.ValidateFeatureIndex(Fmdl.FeatureType.BoneUnit, Fmdl.FeatureType.BoundingBox, boundingBoxIndex))
                            return ErrorCode.InvalidIndex;
                        Bounds box = ReadBoundingBox(ref accessor, boundingBoxIndex);

                        Fmdl.BoneFlags flags = boneUnit->Flags;
                        if (((uint)flags & ~(uint)Fmdl.BoneFlags.HasBoundingBox) != 0)
                            logWarning("Unknown BoneFlags.");

                        bone.transform.localPosition = Fox.Math.FoxToUnityVector3(boneUnit->Position);

                        bone.transform.SetParent(parentIndex == ushort.MaxValue ? rootObject.transform : bones[parentIndex], false);

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

                // Process UnitHeaders. This is done as a pre-step because (all?) models have a stub UnitHeader that owns all other UnitHeaders but to which no UnitDefs belong.
                uint unitCount = accessor.GetFeatureCount(Fmdl.FeatureType.Unit);
                GameObject[] unitGameObjects = new GameObject[unitCount];

                Fmdl.UnitHeader* unitHeaders = accessor.GetFeature<Fmdl.UnitHeader>(Fmdl.FeatureType.Unit);
                for (uint i = 0; i < unitCount; i++)
                {
                    Fmdl.UnitHeader* unitHeader = unitHeaders + i;

                    ushort nameIdIndex = unitHeader->NameIdIndex;
                    if (!accessor.ValidateFeatureIndex(Fmdl.FeatureType.Unit, Fmdl.FeatureType.StringId, nameIdIndex))
                        return ErrorCode.InvalidIndex;
                    string unitName = ReadId(ref accessor, nameIdIndex);

                    Fmdl.UnitFlags flags = unitHeader->Flags;
                    if (flags.HasFlag(Fmdl.UnitFlags.IsFragment) && bones is not null)
                        logWarning("Mesh has both bones and fragment offsets.");
                    if (flags.HasFlag(Fmdl.UnitFlags.B))
                        logWarning("Mesh has B flag.");

                    var unitGameObject = new GameObject(unitName);
                    unitGameObjects[i] = unitGameObject;
                    context.AddObjectToAsset(name, unitGameObject);

                    if (flags.HasFlag(Fmdl.UnitFlags.Invisible))
                        unitGameObject.SetActive(false);

                    ushort parentIndex = unitHeader->ParentIndex;
                    if (parentIndex != ushort.MaxValue)
                        if (!accessor.ValidateFeatureIndex(Fmdl.FeatureType.Unit, Fmdl.FeatureType.Unit, parentIndex))
                            return ErrorCode.InvalidIndex;

                    unitGameObject.transform.SetParent(parentIndex == ushort.MaxValue ? rootObject.transform : unitGameObjects[parentIndex].transform);

                    ushort fragmentPositionVectorIndex = unitHeader->FragmentPositionVectorIndex;
                    Debug.Assert(flags.HasFlag(Fmdl.UnitFlags.IsFragment) == (fragmentPositionVectorIndex != ushort.MaxValue));

                    if (flags.HasFlag(Fmdl.UnitFlags.IsFragment))
                    {
                        if (fragmentPositionVectorIndex == ushort.MaxValue)
                            return ErrorCode.InvalidIndex;
                        
                        Vector4* vectors = (Vector4*)accessor.GetBuffer(Fmdl.BufferType.Vector);

                        Vector3 fragmentPosition = vectors[fragmentPositionVectorIndex];
                        unitGameObject.transform.localPosition = Fox.Math.FoxToUnityVector3(fragmentPosition);
                    }
                }

                Span<ushort> indexBuffer = null;
                byte*[] vBuffers = null;
                int[] vBufferSizes = null;
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
                    vBufferSizes = new int[vBufferCount];
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
                            indexBuffer = new Span<ushort>(data, (int)dataSize);
                        }
                        else
                        {
                            vBuffers[vBufferIndex] = data;
                            vBufferSizes[vBufferIndex] = (int)dataSize;
                            vBufferIndex++;
                        }
                    }
                }

                // Preprocess UnitDefs
                if (accessor.HasFeature(Fmdl.FeatureType.UnitDef))
                {
                    UnitDefCollector[] unitDefCollectors = new UnitDefCollector[unitGameObjects.Length];

                    uint unitDefCount = accessor.GetFeatureCount(Fmdl.FeatureType.UnitDef);
                    Fmdl.UnitDef* unitDefs = accessor.GetFeature<Fmdl.UnitDef>(Fmdl.FeatureType.UnitDef);
                    
                    // Very early pre-loop to calculate total packet counts for each unit
                    for (uint i = 0; i < unitDefCount; i++)
                    {
                        Fmdl.UnitDef* unitDef = unitDefs + i;
                        
                        ushort headerIndex = unitDef->HeaderIndex;
                        if (!accessor.ValidateFeatureIndex(Fmdl.FeatureType.UnitDef, Fmdl.FeatureType.Unit, headerIndex))
                            return ErrorCode.InvalidIndex;
                        
                        unitDefCollectors[headerIndex].DefCount += 1;
                    }

                    // Loop to allocate index array and setup bounds
                    for (uint i = 0; i < unitCount; i++)
                    {
                        ref UnitDefCollector collector = ref unitDefCollectors[i];
                        collector.PacketStartIndices = new uint[collector.DefCount];
                        collector.PacketCounts = new uint[collector.DefCount];
                        collector.IndexSpansStartIndices = new uint[collector.DefCount];
                        collector.Bounds = InvalidBoundingBox;
                    }

                    // Loop to complete collectors
                    Fmdl.Packet* packets = accessor.GetFeature<Fmdl.Packet>(Fmdl.FeatureType.Packet);
                    Fmdl.InputLayoutDesc* inputLayoutDescs = accessor.GetFeature<Fmdl.InputLayoutDesc>(Fmdl.FeatureType.InputLayoutDesc);
                    Fmdl.InputLayoutBindSlotDef* inputLayoutBindSlotDefs = accessor.GetFeature<Fmdl.InputLayoutBindSlotDef>(Fmdl.FeatureType.InputLayoutBindSlotDef);
                    Fmdl.InputLayoutElement* inputLayoutElements = accessor.GetFeature<Fmdl.InputLayoutElement>(Fmdl.FeatureType.InputLayoutElement);
                    for (uint i = 0; i < unitDefCount; i++)
                    {
                        Fmdl.UnitDef* unitDef = unitDefs + i;

                        Debug.Assert(unitDef->Unknown == 0);

                        ushort headerIndex = unitDef->HeaderIndex;
                        if (!accessor.ValidateFeatureIndex(Fmdl.FeatureType.UnitDef, Fmdl.FeatureType.Unit, headerIndex))
                            return ErrorCode.InvalidIndex;

                        ref UnitDefCollector collector = ref unitDefCollectors[headerIndex];
                        
                        ushort packetCount = unitDef->PacketCount;
                        ushort packetsStartIndex = unitDef->PacketsStartIndex;
                        if (packetCount > 0)
                            if (!accessor.ValidateFeatureIndex(Fmdl.FeatureType.UnitDef, Fmdl.FeatureType.Packet, (uint)(packetsStartIndex + packetCount - 1)))
                                return ErrorCode.InvalidIndex;
                        collector.PacketCounts[collector.CurrentDefIndex] = packetCount;
                        collector.TotalPacketCount += packetCount;
                        collector.PacketStartIndices[collector.CurrentDefIndex] = packetsStartIndex;
                        
                        ushort boundingBoxIndex = unitDef->BoundingBoxIndex;
                        if (!accessor.ValidateFeatureIndex(Fmdl.FeatureType.UnitDef, Fmdl.FeatureType.BoundingBox, boundingBoxIndex))
                            return ErrorCode.InvalidIndex;
                        Bounds bounds = ReadBoundingBox(ref accessor, boundingBoxIndex);
                        if (collector.Bounds == InvalidBoundingBox)
                            collector.Bounds = bounds;
                        else
                            collector.Bounds.Encapsulate(bounds);

                        ushort indexSpansStartIndex = unitDef->IndexSpansStartIndex;
                        if (!accessor.ValidateFeatureIndex(Fmdl.FeatureType.UnitDef, Fmdl.FeatureType.IndexSpan, indexSpansStartIndex))
                            return ErrorCode.InvalidIndex;
                        collector.IndexSpansStartIndices[collector.CurrentDefIndex] = indexSpansStartIndex;

                        collector.CurrentDefIndex++;
                    }
                    
                    // Materials
                    Material[] sharedMaterials =
                    {
                        AssetDatabase.LoadAssetAtPath<Material>("Assets/Fox/Gr/Model/DebugDrawFlags.mat")
                    };

                    for (uint i = 0; i < unitCount; i++)
                    {
                        ref UnitDefCollector collector = ref unitDefCollectors[i];
                        if (collector.TotalPacketCount == 0)
                            continue;

                        GameObject unitGameObject = unitGameObjects[i];

                        uint unitPacketIndex = 0;
                        for (uint j = 0; j < collector.DefCount; j++)
                        {
                            uint defPacketCount = collector.PacketCounts[j];
                            uint defPacketsStartIndex = collector.PacketStartIndices[j];
                            uint defIndexSpansStartIndex = collector.IndexSpansStartIndices[j];
                            
                            uint absUnitPacketIndex = defPacketsStartIndex;
                            for (uint k = 0; k < defPacketCount; k++, unitPacketIndex++, absUnitPacketIndex++)
                            {
                                Fmdl.Packet* packet = packets + absUnitPacketIndex;
                                
                                // ================
                                // MAKE MESH
                                // ================
                                GameObject packetGameObject = new GameObject($"{unitGameObject.name}[{unitPacketIndex:0000}]");
                                packetGameObject.transform.SetParent(unitGameObject.transform);
                                Mesh packetMesh = new Mesh
                                {
                                    name = packetGameObject.name,
                                    subMeshCount = 1
                                };

                                // TODO: Extensive flag validation
                                Fmdl.PacketFlags flags = packet->Flags;

                                ushort materialInstanceIndex = packet->MaterialInstanceIndex;
                                if (!accessor.ValidateFeatureIndex(Fmdl.FeatureType.Packet, Fmdl.FeatureType.MaterialInstance, materialInstanceIndex))
                                    return ErrorCode.InvalidIndex;
                                
                                ushort boneGroupIndex = packet->BoneGroupIndex;
                                if (bones != null && !accessor.ValidateFeatureIndex(Fmdl.FeatureType.Packet, Fmdl.FeatureType.BoneGroup, boneGroupIndex))
                                    return ErrorCode.InvalidIndex;

                                Fmdl.BoneGroup* boneGroup = null;
                                if (bones != null)
                                {
                                    boneGroup = accessor.GetFeature<Fmdl.BoneGroup>(Fmdl.FeatureType.BoneGroup) + boneGroupIndex;
                                    // TODO - Inc. validation
                                    ushort useWeightCount = boneGroup->UseWeightCount;
                                }
                                
                                ushort inputLayoutDescIndex =  packet->InputLayoutDescIndex;
                                if (!accessor.ValidateFeatureIndex(Fmdl.FeatureType.Packet, Fmdl.FeatureType.InputLayoutDesc, inputLayoutDescIndex))
                                    return ErrorCode.InvalidIndex;
                                
                                Debug.Assert(packet->_Padding0 == 0);
                                
                                // TODO - Inc. validation
                                ushort vertexCount = packet->VertexCount;
                                ushort verticesStartIndex = packet->VerticesStartIndex;
                                
                                // Input layout
                                Fmdl.InputLayoutDesc* inputLayoutDesc = inputLayoutDescs + inputLayoutDescIndex;

                                byte bindSlotCount = inputLayoutDesc->BindSlotCount;
                                ushort bindSlotDefsStartIndex = inputLayoutDesc->BindSlotDefsStartIndex;
                                if (bindSlotCount > 0)
                                    if (!accessor.ValidateFeatureIndex(Fmdl.FeatureType.InputLayoutDesc, Fmdl.FeatureType.InputLayoutBindSlotDef, (uint)(bindSlotDefsStartIndex + bindSlotCount - 1)))
                                        return ErrorCode.InvalidIndex;

                                byte elementCount = inputLayoutDesc->ElementCount;
                                ushort elementsStartIndex = inputLayoutDesc->ElementsStartIndex;
                                if (elementCount > 0)
                                    if (!accessor.ValidateFeatureIndex(Fmdl.FeatureType.InputLayoutDesc, Fmdl.FeatureType.InputLayoutElement, (uint)(elementsStartIndex + elementCount - 1)))
                                        return ErrorCode.InvalidIndex;

                                // TODO: Figure out
                                byte firstUvSetIndex = inputLayoutDesc->Unknown0;
                                byte uvCount = inputLayoutDesc->UvCount;
                                Debug.Assert(uvCount <= 2);
                                Debug.Assert((firstUvSetIndex == byte.MaxValue) == (uvCount == 0));
                                if (firstUvSetIndex != 0 && firstUvSetIndex != byte.MaxValue)
                                    logWarning("PacketDataLayoutDesc.Unknown0 != 0");

                                //MeshBufferUploadHelper uploadHelper = new MeshBufferUploadHelper(packetMesh);
                                //uploadHelper.Register(new Span<Fmdl.InputLayoutBindSlotDef>(inputLayoutBindSlotDefs + bindSlotDefsStartIndex, bindSlotCount), new Span<Fmdl.InputLayoutElement>());

                                // Iterate over bind slots once to set up input layout
                                const int TODO_MAX_BINDSLOT = 4;
                                uint absLayoutElementIndex = 0;
                                VertexAttributeDescriptor[] unityElementAttributeDescs = new VertexAttributeDescriptor[elementCount - (uvCount - 1)];
                                for (uint l = 0; l < bindSlotCount; l++)
                                {
                                    Fmdl.InputLayoutBindSlotDef* bindSlotDef = inputLayoutBindSlotDefs + bindSlotDefsStartIndex + l;
                                    Debug.Assert(bindSlotDef->BindSlot < TODO_MAX_BINDSLOT);
                                    
                                    byte stride = bindSlotDef->Stride;
                                    uint offset = bindSlotDef->Offset;
                                    
                                    // Elements
                                    byte bufferIndex = bindSlotDef->BufferIndex;
                                    uint attributeWriteIndex = 0;
                                    for (uint m = 0; m < bindSlotDef->ElementCount; m++, absLayoutElementIndex++)
                                    {
                                        Fmdl.InputLayoutElement* inputElement = inputLayoutElements + inputLayoutDesc->ElementsStartIndex + absLayoutElementIndex;

                                        Fmdl.InputElementSemantic semantic = inputElement->Semantic; // TODO - validate type
                                        Fmdl.InputElementType type = inputElement->Type; // TODO - validate type
                                        ushort offsetRelative = inputElement->Offset;
                                        
                                        // TEMP - Fix handedness
                                        if (semantic is Fmdl.InputElementSemantic.Position or Fmdl.InputElementSemantic.Normal or Fmdl.InputElementSemantic.Tangent)
                                        {
                                            byte* vBuffer = vBuffers[bufferIndex];
                                            if (type == Fmdl.InputElementType.R32G32B32_Float)
                                                for (uint n = 0; n < vertexCount; n++)
                                                    vBuffer[offset + n * stride + offsetRelative + 3] ^= 0x80;
                                            else if (type == Fmdl.InputElementType.R16G16B16A16_Float)
                                                for (uint n = 0; n < vertexCount; n++)
                                                    vBuffer[offset + n * stride + offsetRelative + 1] ^= 0x80;
                                        }
                                        
                                        if (semantic is Fmdl.InputElementSemantic.UV1 or Fmdl.InputElementSemantic.UV2 or Fmdl.InputElementSemantic.UV3)
                                            continue;
                                        
                                        VertexAttribute unityElementAttribute = MeshBufferUploadHelper.UnityAttributeSemanticTable[(uint)semantic];
                                        (VertexAttributeFormat unityElementFormat, int unityElementDimension, ushort unityElementSize) = MeshBufferUploadHelper.UnityAttributeTypeTable[(uint)type];
                                        VertexAttributeDescriptor unityElementAttributeDesc = new VertexAttributeDescriptor
                                        {
                                            attribute = MeshBufferUploadHelper.UnityAttributeSemanticTable[(uint)semantic],
                                            format = unityElementFormat,
                                            dimension = unityElementDimension,
                                            stream = bufferIndex,
                                        };
                                        unityElementAttributeDescs[absLayoutElementIndex] = unityElementAttributeDesc;

                                        attributeWriteIndex++;
                                    }
                                }
                                packetMesh.SetVertexBufferParams(vertexCount, unityElementAttributeDescs);
                                
                                // Do it again for copies
                                const int TODO_MAX_BUFFERCOUNT = 2;
                                Span<bool> wasBufferCopied = stackalloc bool[TODO_MAX_BUFFERCOUNT];
                                for (uint l = 0; l < bindSlotCount; l++)
                                {
                                    Fmdl.InputLayoutBindSlotDef* bindSlotDef = inputLayoutBindSlotDefs + bindSlotDefsStartIndex + l;
                                    
                                    // Copy buffer
                                    byte bufferIndex = bindSlotDef->BufferIndex;
                                    if (!wasBufferCopied[bufferIndex])
                                    {
                                        byte* vBuffer = vBuffers[bufferIndex];
                                        int vBufferSize = vBufferSizes[bufferIndex];
                                        NativeArray<byte> vertexBufferNativeArray = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(vBuffer, vBufferSize, Allocator.None);
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                                        NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref vertexBufferNativeArray, AtomicSafetyHandle.GetTempUnsafePtrSliceHandle());
#endif
                                        
                                        byte stride = bindSlotDef->Stride;
                                        uint offset = bindSlotDef->Offset;
                                        Debug.Assert(offset <= Int32.MaxValue);
                                        
                                        packetMesh.SetVertexBufferData(vertexBufferNativeArray, (int)offset, 0, vertexCount * stride, bufferIndex, UpdateFlags | MeshUpdateFlags.DontNotifyMeshUsers);
                                        wasBufferCopied[bufferIndex] = true;
                                    }
                                }
                                
                                // TODO - Inc. validation
                                Fmdl.PacketLodIndices hiLodIndicesSpan = packet->HighLodIndicesSpan;
                                
                                Debug.Assert(hiLodIndicesSpan.Count <= Int32.MaxValue);
                                packetMesh.SetIndexBufferParams((int)hiLodIndicesSpan.Count, IndexFormat.UInt16);
                                NativeArray<ushort> indexBufferNativeArray = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray(indexBuffer, Allocator.None);
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                                NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref indexBufferNativeArray, AtomicSafetyHandle.GetTempUnsafePtrSliceHandle());
#endif
                                packetMesh.SetIndexBufferData(indexBufferNativeArray, (int)hiLodIndicesSpan.StartIndex, 0, (int)hiLodIndicesSpan.Count, UpdateFlags | MeshUpdateFlags.DontNotifyMeshUsers);
                                
                                uint indexSpansStartIndex = packet->IndexSpansStartIndex;
                                // If this is the first Packet in the current UnitDef...
                                if (k == 0)
                                    Debug.Assert(defIndexSpansStartIndex == indexSpansStartIndex);
                                packetMesh.SetSubMesh(0, new SubMeshDescriptor { topology = MeshTopology.Triangles, indexStart = 0, indexCount = (int)hiLodIndicesSpan.Count, firstVertex = 0, vertexCount = vertexCount, baseVertex = 0 }, UpdateFlags);
                                packetMesh.RecalculateBounds();
                                packetMesh.UploadMeshData(false);

#if DEBUG
                                {
                                    Vector3[] vertices = packetMesh.vertices;
                                    int[] triangles = packetMesh.triangles;

                                    float result = 0f;
                                    for(int p = 0; p < triangles.Length; p += 3)
                                    {
                                        Vector3 a = vertices[triangles[p + 1]] - vertices[triangles[p]];
                                        Vector3 b = vertices[triangles[p + 2]] - vertices[triangles[p]];
                                        Vector3 cross = Vector3.Cross(a, b);
                                        result += cross.magnitude / 2.0f;
                                    }

                                    DEBUG_SurfaceArea += result;
                                    // Debug.Log($"Area = {result}");
                                    // Debug.Log($"Area/Tri = {result / (triangles.Length / 3)}");
                                }
                                
                                {
                                    Vector2[] uvs = packetMesh.uv;
                                    int[] triangles = packetMesh.triangles;

                                    float result = 0f;
                                    for(int p = 0; p < triangles.Length; p += 3)
                                    {
                                        Vector2 a = uvs[triangles[p + 1]] - uvs[triangles[p]];
                                        Vector2 b = uvs[triangles[p + 2]] - uvs[triangles[p]];
                                        float cross = Mathf.Abs(a.x * b.y - a.y * b.x);
                                        result += cross / 2.0f;
                                    }

                                    DEBUG_UVArea += result;
                                    // Debug.Log($"UV Area = {result}");
                                    // Debug.Log($"UV Area/Tri = {result / (triangles.Length / 3)}");
                                }
#endif

                                // Renderer setup
                                if (bones != null)
                                {
                                    ReadOnlySpan<ushort> boneIndices = new ReadOnlySpan<ushort>((byte*)boneGroup + 4, boneGroup->BoneCount);
                                    Transform[] boneGroupBones = new Transform[boneGroup->BoneCount];
                                    for (int l = 0; l < boneGroupBones.Length; l++)
                                        boneGroupBones[l] = bones[boneIndices[l]];
                                    
                                    //BoneWeight weightBuffer = new BoneWeight()
                                    //uploadHelper.CopyBoneWeights(weightBuffer, vBuffers[1], layoutDescs[j], layoutDescs[j].BufferDescs[1].Offset, layoutDescs[j].BufferDescs[1].Stride, vertexStart, vertexCount, boneIndices);
                                    
                                    // packetMesh.boneWeights = weightBuffer;
                                    packetMesh.bindposes = bindPoses;
                        
                                    SkinnedMeshRenderer packetRenderer = packetGameObject.AddComponent<SkinnedMeshRenderer>();
                        
                                    // Change bounds over to local space
                                    Bounds globalBounds = packetMesh.bounds;
                                    Bounds localBounds = new Bounds
                                    {
                                        center = rootObject.transform.worldToLocalMatrix.MultiplyPoint(globalBounds.center),
                                        size = rootObject.transform.worldToLocalMatrix.MultiplyVector(globalBounds.size)
                                    };

                                    packetRenderer.localBounds = localBounds;
                                    packetRenderer.bones = boneGroupBones;
                                    packetRenderer.sharedMesh = packetMesh;
                                    packetRenderer.rootBone = bones[0];

                                    packetRenderer.sharedMaterials = sharedMaterials;
                                }
                                else
                                {
                                    MeshFilter meshFilter = packetGameObject.AddComponent<MeshFilter>();
                                    meshFilter.sharedMesh = packetMesh;

                                    MeshRenderer meshRenderer = packetGameObject.AddComponent<MeshRenderer>();
                                    meshRenderer.sharedMaterials = sharedMaterials;
                                }

                                context.AddObjectToAsset(packetMesh.name, packetMesh);
                            }
                        }
                    }
                }

#if DEBUG
                if (accessor.HasFeature(Fmdl.FeatureType.LodInfo))
                {
                    Fmdl.LodInfo* lodInfo = accessor.GetFeature<Fmdl.LodInfo>(Fmdl.FeatureType.LodInfo);

                    Debug.Log($"DEBUG | Unknown1: {lodInfo->SurfaceArea}, Calculated: {DEBUG_SurfaceArea}");
                    Debug.Log($"DEBUG | Unknown1: {lodInfo->SqrtSurfaceAreaDivUVArea}, Calculated: {Mathf.Sqrt(DEBUG_SurfaceArea / DEBUG_UVArea)}");
                }
#endif

                return ErrorCode.Success;
            }
        }
    }
}