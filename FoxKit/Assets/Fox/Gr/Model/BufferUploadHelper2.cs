using System;
using System.Diagnostics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Rendering;
using Debug = UnityEngine.Debug;

namespace Fox.Gr
{
    public unsafe partial class ModelFileImporter2
    {
        private struct MeshBufferUploadHelper
        {
            // Indexed by MeshBufferFormatElementUsage
            public static readonly VertexAttribute[] UnityAttributeSemanticTable =
            {
                VertexAttribute.Position,
                VertexAttribute.BlendWeight,
                VertexAttribute.Normal,
                VertexAttribute.Color,

                // Invalid
                VertexAttribute.TexCoord7,
                VertexAttribute.TexCoord7,
                VertexAttribute.TexCoord7,

                VertexAttribute.BlendIndices,
                VertexAttribute.TexCoord0,
                VertexAttribute.TexCoord1,
                VertexAttribute.TexCoord2,
                VertexAttribute.TexCoord3,

                // Remap weight 1 and index 1 to spare texcoords
                VertexAttribute.TexCoord4,
                VertexAttribute.TexCoord5,

                VertexAttribute.Tangent,
            };

            // Indexed by MeshBufferFormatElementType
            public static readonly (VertexAttributeFormat, int, ushort)[] UnityAttributeTypeTable =
            {
                // Invalid
                (VertexAttributeFormat.UInt32, -1, 0),

                (VertexAttributeFormat.Float32, 3, 12),

                // Invalid
                (VertexAttributeFormat.UInt32, -1, 0),
                (VertexAttributeFormat.UInt32, -1, 0),

                // Wiki says UINT16 is an option but I don't know under what Semantic that would ever come up.
                //(VertexAttributeFormat.UInt16, 1, 2),
                (VertexAttributeFormat.UInt32, -1, 0),

                // Invalid
                (VertexAttributeFormat.UInt32, -1, 0),

                (VertexAttributeFormat.Float16, 4, 8),
                (VertexAttributeFormat.Float16, 2, 4),
                (VertexAttributeFormat.UNorm8, 4, 4),
                (VertexAttributeFormat.UInt8, 4, 4),
            };

            private struct MeshBufferDesc
            {
                public byte Stride;
                public uint Offset;
                public byte FileBufferIndex;
                public byte Slot;

                public uint ElementCount;
                public Fmdl.InputLayoutElement* Elements;
            }

            private struct RemapDesc
            {
                public Fmdl.InputElementSemantic Semantic;
                public Fmdl.InputElementType Type;
                public ushort InputOffset;
                public ushort InputSize;
                public uint OutputOffset;
                public ushort OutputSize;
            }
            
            private struct PlacedUnityAttributeDescriptor
            {
                public UnityEngine.Rendering.VertexAttributeDescriptor UnityDescriptor;
                public ushort Size;
                public uint Offset;
            }

            private Mesh Mesh;
            
            // Sparse mapping into 
            private uint[] DescriptorMapCounts;
            private uint[,] DescriptorMapIndices;
            private PlacedUnityAttributeDescriptor[,] UnityDescriptors;
            
            private readonly uint[] RemapDescCounts;
            private readonly RemapDesc[,] RemapDescs;
            
            public MeshBufferUploadHelper(Mesh mesh)
            {
                Mesh = mesh;
                DescriptorMapCounts = null;
                DescriptorMapIndices = null;
                UnityDescriptors = null;
                RemapDescCounts = null;
                RemapDescs = null;
            }
            
            // public void Register(Span<Fmdl.InputLayoutBindSlotDef> bindSlots, Span<Fmdl.InputLayoutElement> elements)
            // {
            //     // Copied from constructor. I won't 
            //     // uint semanticCount = (uint)Fmdl.InputElementSemantic.COUNT;
            //     //
            //     // DescriptorMapCounts = new uint[bindSlotCount];
            //     // DescriptorMapIndices = new uint[bindSlotCount, semanticCount];
            //     // for (uint i = 0; i < bindSlotCount; i++)
            //     // for (uint j = 0; j < semanticCount; j++)
            //     //     DescriptorMapIndices[i, j] = uint.MaxValue;
            //     // UnityDescriptors = new PlacedUnityAttributeDescriptor[bindSlotCount, semanticCount];
            //     //
            //     // RemapDescCounts = new uint[bindSlotCount];
            //     // RemapDescs = new RemapDesc[RemapDescCounts.LongLength, semanticCount];
            //     
            //     for (uint i = 0; i < layoutDesc.BufferDescs.LongLength; i++)
            //     {
            //         MeshBufferDesc bufferDesc = layoutDesc.BufferDescs[i];
            //
            //         uint bufferIndex = bufferDesc.FileBufferIndex;
            //         for (uint j = 0; j < bufferDesc.ElementCount; j++)
            //         {
            //             Fmdl.InputLayoutElement element = bufferDesc.Elements[j];
            //
            //             (VertexAttributeFormat unityFormat, int unityDimension, ushort size) = UnityAttributeTypeTable[(uint)element.Type];
            //
            //             // Later, the Fox bone weights, which rely on 32-bone groups, will be unpacked to an "absolute" index.
            //             ushort outputSize = size;
            //             if (element.Semantic is Fmdl.InputElementSemantic.BoneIndex0 or Fmdl.InputElementSemantic.BoneIndex1)
            //             {
            //                 Debug.Assert(element.Type == Fmdl.InputElementType.R8G8B8A8_UInt);
            //                 outputSize = 8;
            //             }
            //             // if (element.Semantic is Fmdl.InputElementSemantic.BoneWeight0 or Fmdl.InputElementSemantic.BoneWeight1)
            //             // {
            //             //     Debug.Assert(element.Type == Fmdl.InputElementType.R8G8B8A8_UNorm);
            //             //     outputSize = 16;
            //             // }
            //
            //             // If this is a new element for the inflated buffer.
            //             ref int descriptorIndex = ref DescriptorMapIndices[bufferIndex, (uint)element.Usage];
            //             if (descriptorIndex == -1)
            //             {
            //                 // Set descriptor index
            //                 descriptorIndex = DescriptorMapCounts[bufferIndex]++;
            //
            //                 // Add UnityEngine format info
            //                 var descriptor = new VertexAttributeDescriptor
            //                 {
            //                     attribute = UnityAttributeSemanticTable[(uint)element.Usage],
            //                     format = unityFormat,
            //                     dimension = unityDimension,
            //                     stream = (int)bufferIndex,
            //                 };
            //                 UnityDescriptors[bufferIndex, descriptorIndex] = new PlacedUnityAttributeDescriptor { UnityDescriptor = descriptor, Offset = 0, Size = outputSize };
            //             }
            //
            //             // First pass on remap desc. Intentionally don't fill out output offset.
            //             var remapDesc = new RemapDesc
            //             {
            //                 Semantic = element.Usage,
            //                 Type = element.Type,
            //                 InputOffset = element.Offset,
            //                 InputSize = size,
            //                 OutputOffset = 0, // Leave at 0 for prepass.
            //                 OutputSize = outputSize,
            //             };
            //             RemapDescs[bufferIndex, i, RemapDescCounts[bufferIndex, i]++] = remapDesc;
            //         }
            //     }
            //
            //     for (int i = 0; i < DescriptorMapCounts.Length; i++) // Buffer
            //     {
            //         for (int j = 1; j < DescriptorMapCounts[i]; j++) // Element
            //             UnityDescriptors[i, j].Offset = UnityDescriptors[i, j - 1].Offset + UnityDescriptors[i, j - 1].Size;
            //     }
            //
            //     // Loop over buffers
            //     for (uint i = 0; i < RemapDescCounts.GetLongLength(0); i++)
            //     {
            //         // Loop over packets
            //         for (uint j = 0; j < RemapDescCounts.GetLongLength(1); j++)
            //         {
            //             for (uint k = 1; k < RemapDescCounts[i, j]; k++) // Element
            //                 RemapDescs[i, j, k].OutputOffset = UnityDescriptors[i, DescriptorMapIndices[i, (uint)RemapDescs[i, j, k].Semantic]].Offset;
            //         }
            //     }
            // }
            
            public NativeArray<VertexAttributeDescriptor> GetDescriptorArray()
            {
                int bufferCount = 0;
                foreach (int count in DescriptorMapCounts)
                    bufferCount += count;
            
                var result = new NativeArray<VertexAttributeDescriptor>(bufferCount, Allocator.Temp);
            
                int absoluteIndex = 0;
                for (int i = 0; i < DescriptorMapCounts.Length; i++)
                {
                    for (int j = 0; j < DescriptorMapCounts[i]; j++)
                    {
                        result[absoluteIndex] = UnityDescriptors[i, j].UnityDescriptor;
            
                        absoluteIndex++;
                    }
                }
            
                return result;
            }
            
            public NativeArray<byte>[] CreateVertexBuffers(uint vertexCount)
            {
                var result = new NativeArray<byte>[DescriptorMapCounts.Length];
                for (uint i = 0; i < RemapDescCounts.GetLongLength(0); i++)
                {
                    PlacedUnityAttributeDescriptor lastDescriptor = UnityDescriptors[i, DescriptorMapCounts[i] - 1];
                    uint size = vertexCount * (lastDescriptor.Offset + lastDescriptor.Size);
                    Debug.Assert(size < Int32.MaxValue);
                    result[i] = new NativeArray<byte>((int)size, Allocator.Temp, NativeArrayOptions.ClearMemory);
                }
            
                return result;
            }
            
            public uint GetOutputBufferStride(uint bufferIndex)
            {
                PlacedUnityAttributeDescriptor lastDescriptor = UnityDescriptors[bufferIndex, DescriptorMapCounts[bufferIndex] - 1];
                return lastDescriptor.Offset + lastDescriptor.Size;
            }
            
            // public void CopyVertexData(NativeArray<byte> outputData, uint bufferIndex, uint meshIndex, byte* inputData, uint inputDataOffset, uint inputDataStride, uint vertexStart, uint vertexCount)
            // {
            //     uint outputDataStride = GetOutputBufferStride(bufferIndex);
            //
            //     byte* outputDataPtr = (byte*)outputData.GetUnsafePtr() + (ulong)vertexStart * outputDataStride;
            //
            //     inputData += inputDataOffset;
            //
            //     for (uint i = 0; i < vertexCount; i++)
            //     {
            //         for (uint j = 0; j < RemapDescCounts[bufferIndex, meshIndex]; j++) // Elements
            //         {
            //             RemapDesc remapDesc = RemapDescs[bufferIndex, meshIndex, j];
            //
            //             UnsafeUtility.MemCpy(outputDataPtr + remapDesc.OutputOffset, inputData + remapDesc.InputOffset, remapDesc.OutputSize);
            //
            //             if (remapDesc.Semantic is Fmdl.InputElementSemantic.Position or Fmdl.InputElementSemantic.Normal or Fmdl.InputElementSemantic.Tangent)
            //             {
            //                 if (remapDesc.Type == Fmdl.InputElementType.R32G32B32_Float)
            //                     *(outputDataPtr + remapDesc.OutputOffset + 3) ^= 0x80;
            //                 else if (remapDesc.Type == Fmdl.InputElementType.R16G16B16A16_Float)
            //                     *(outputDataPtr + remapDesc.OutputOffset + 1) ^= 0x80;
            //             }
            //         }
            //
            //         outputDataPtr += outputDataStride;
            //         inputData += inputDataStride;
            //     }
            // }
            
            // public void CopyBoneWeights(BoneWeight[] outputWeights, byte* inputData, MeshDataLayoutDesc layoutDesc, uint inputDataOffset, uint inputDataStride, uint vertexStart, uint vertexCount, ReadOnlySpan<ushort> boneGroup)
            // {
            //     MeshBufferFormatElement? boneWeightsFormatElement = null;
            //     MeshBufferFormatElement? boneIndicesFormatElement = null;
            //     foreach (MeshBufferDesc bufferDesc in layoutDesc.BufferDescs)
            //     {
            //         foreach (MeshBufferFormatElement element in bufferDesc.Elements)
            //         {
            //             if (element.Usage == Fmdl.InputElementSemantic.BoneWeight0)
            //                 boneWeightsFormatElement = element;
            //             else if (element.Usage == Fmdl.InputElementSemantic.BoneIndex0)
            //                 boneIndicesFormatElement = element;
            //         }
            //     }
            //
            //     Debug.Assert(boneWeightsFormatElement.HasValue && boneIndicesFormatElement.HasValue);
            //
            //     Debug.Assert(boneWeightsFormatElement.Value.Type == Fmdl.InputElementType.R8G8B8A8_UNorm);
            //     Debug.Assert(boneIndicesFormatElement.Value.Type == Fmdl.InputElementType.R8G8B8A8_UInt);
            //
            //     long inputDataIndex = inputDataOffset;
            //     for (uint i = 0; i < vertexCount; i++)
            //     {
            //         ref BoneWeight weight = ref outputWeights[vertexStart + i];
            //         weight.weight0 = inputData[inputDataIndex + boneWeightsFormatElement.Value.Offset + 0] / (float)Byte.MaxValue;
            //         weight.boneIndex0 = boneGroup[inputData[inputDataIndex + boneIndicesFormatElement.Value.Offset + 0]];
            //         weight.weight1 = inputData[inputDataIndex + boneWeightsFormatElement.Value.Offset + 1] / (float)Byte.MaxValue;
            //         weight.boneIndex1 = boneGroup[inputData[inputDataIndex + boneIndicesFormatElement.Value.Offset + 1]];
            //         weight.weight2 = inputData[inputDataIndex + boneWeightsFormatElement.Value.Offset + 2] / (float)Byte.MaxValue;
            //         weight.boneIndex2 = boneGroup[inputData[inputDataIndex + boneIndicesFormatElement.Value.Offset + 2]];
            //         weight.weight3 = inputData[inputDataIndex + boneWeightsFormatElement.Value.Offset + 3] / (float)Byte.MaxValue;
            //         weight.boneIndex3 = boneGroup[inputData[inputDataIndex + boneIndicesFormatElement.Value.Offset + 3]];
            //
            //         inputDataIndex += inputDataStride;
            //     }
            // }
        }
    }
}