using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Rendering;

namespace Fox.Gr
{
    public partial class ModelFileImporter
    {
        private class BufferUploadHelper
        {
            // Indexed by MeshBufferFormatElementUsage
            private VertexAttribute[] UnityAttributeUsageLUT =
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
            private (VertexAttributeFormat, int, ushort)[] UnityAttributeTypeLUT =
            {
                // Invalid
                (VertexAttributeFormat.UInt32, -1, 0),

                (VertexAttributeFormat.Float32, 3, 12),

                // Invalid
                (VertexAttributeFormat.UInt32, -1, 0),
                (VertexAttributeFormat.UInt32, -1, 0),

                // Wiki says UINT16 is an option but I don't know under what Usage that would ever come up.
                //(VertexAttributeFormat.UInt16, 1, 2),
                (VertexAttributeFormat.UInt32, -1, 0),

                // Invalid
                (VertexAttributeFormat.UInt32, -1, 0),

                (VertexAttributeFormat.Float16, 4, 8),
                (VertexAttributeFormat.Float16, 2, 4),
                (VertexAttributeFormat.UNorm8, 4, 4),
                (VertexAttributeFormat.UInt8, 4, 4),
            };

            struct RemapDesc
            {
                public MeshBufferFormatElementUsage Usage;
                public MeshBufferFormatElementType Type;
                public ushort InputOffset;
                public ushort InputSize;
                public uint OutputOffset;
                public ushort OutputSize;
            }

            struct ExpandedVertexAttributeDescriptor
            {
                public VertexAttributeDescriptor Descriptor;
                public ushort Size;
                public uint Offset;
            }

            private int[] DescriptorCounts;
            private int[,] DescriptorIndices;
            private ExpandedVertexAttributeDescriptor[,] Descriptors;

            private uint[,] RemapDescCounts;
            private RemapDesc[,,] RemapDescs;

            public BufferUploadHelper(uint bufferCount, uint meshCount)
            {
                DescriptorCounts = new int[bufferCount];
                DescriptorIndices = new int[DescriptorCounts.LongLength, (uint)MeshBufferFormatElementUsage.COUNT];
                for (uint i = 0; i < DescriptorIndices.GetLongLength(0); i++)
                    for (uint j = 0; j < DescriptorIndices.GetLongLength(1); j++)
                        DescriptorIndices[i, j] = -1;
                Descriptors = new ExpandedVertexAttributeDescriptor[DescriptorIndices.GetLongLength(0), DescriptorIndices.GetLongLength(1)];

                RemapDescCounts = new uint[bufferCount, meshCount];
                RemapDescs = new RemapDesc[RemapDescCounts.GetLongLength(0), RemapDescCounts.GetLongLength(1), (uint)MeshBufferFormatElementUsage.COUNT];
            }

            public void Register(MeshDataLayoutDesc[] layoutDescs)
            {
                for (uint i = 0; i < layoutDescs.LongLength; i++)
                {
                    for (uint j = 0; j < layoutDescs[i].BufferDescs.LongLength; j++)
                    {
                        MeshBufferDesc bufferDesc = layoutDescs[i].BufferDescs[j];

                        uint bufferIndex = bufferDesc.FileBufferIndex;

                        for (uint k = 0; k < bufferDesc.Elements.LongLength; k++)
                        {
                            MeshBufferFormatElement element = bufferDesc.Elements[k];

                            (VertexAttributeFormat format, int dimension, ushort size) = UnityAttributeTypeLUT[(uint)element.Type];

                            // Later, the fox bone weights, which rely on 32-bone groups, will be unpacked to an "absolute" index.
                            ushort outputSize = size;
                            if (element.Usage == MeshBufferFormatElementUsage.BoneIndex0 || element.Usage == MeshBufferFormatElementUsage.BoneWeight0)
                                continue;
                            //if (element.Usage == MeshBufferFormatElementUsage.BoneIndex0)
                            //{
                            //    Debug.Assert(element.Type == MeshBufferFormatElementType.R8G8B8A8_UInt);
                            //    format = VertexAttributeFormat.UInt16;
                            //    outputSize = 8;
                            //}

                            // If this is a new element for the inflated buffer.
                            ref int descriptorIndex = ref DescriptorIndices[bufferIndex, (uint)element.Usage];
                            if (descriptorIndex == -1)
                            {
                                // Set descriptor index
                                descriptorIndex = DescriptorCounts[bufferIndex]++;

                                // Add UnityEngine format info
                                VertexAttributeDescriptor descriptor = new VertexAttributeDescriptor
                                {
                                    attribute = UnityAttributeUsageLUT[(uint)element.Usage],
                                    format = format,
                                    dimension = dimension,
                                    stream = (int)bufferIndex,
                                };
                                Descriptors[bufferIndex, descriptorIndex] = new ExpandedVertexAttributeDescriptor { Descriptor = descriptor, Offset = 0, Size = outputSize };
                            }

                            // First pass on remap desc. Intentionally don't fill out output offset.
                            RemapDesc remapDesc = new RemapDesc
                            {
                                Usage = element.Usage,
                                Type = element.Type,
                                InputOffset = element.Offset,
                                InputSize = size,
                                OutputOffset = 0, // Leave at 0 for prepass.
                                OutputSize = outputSize,
                            };
                            RemapDescs[bufferIndex, i, RemapDescCounts[bufferIndex, i]++] = remapDesc;
                        }
                    }
                }

                for (int i = 0; i < DescriptorCounts.Length; i++) // Buffer
                    for (int j = 1; j < DescriptorCounts[i]; j++) // Element
                        Descriptors[i, j].Offset = Descriptors[i, j - 1].Offset + Descriptors[i, j - 1].Size;

                for (uint i = 0; i < RemapDescCounts.GetLongLength(0); i++) // Buffer
                    for (uint j = 0; j < RemapDescCounts.GetLongLength(1); j++) // Mesh
                        for (uint k = 1; k < RemapDescCounts[i, j]; k++) // Element
                            RemapDescs[i, j, k].OutputOffset = Descriptors[i, DescriptorIndices[i, (uint)RemapDescs[i, j, k].Usage]].Offset;
            }

            public NativeArray<VertexAttributeDescriptor> GetDescriptorArray()
            {
                int bufferCount = 0;
                foreach (var count in DescriptorCounts)
                    bufferCount += count;

                NativeArray<VertexAttributeDescriptor> result = new NativeArray<VertexAttributeDescriptor>(bufferCount, Allocator.Temp);

                int absoluteIndex = 0;
                for (int i = 0; i < DescriptorCounts.Length; i++)
                {
                    for (int j = 0; j < DescriptorCounts[i]; j++)
                    {
                        result[absoluteIndex] = Descriptors[i, j].Descriptor;

                        absoluteIndex++;
                    }
                }

                return result;
            }

            public NativeArray<byte>[] CreateVertexBuffers(uint vertexCount)
            {
                var result = new NativeArray<byte>[DescriptorCounts.Length];
                for (uint i = 0; i < RemapDescCounts.GetLongLength(0); i++)
                {
                    ExpandedVertexAttributeDescriptor lastDescriptor = Descriptors[i, DescriptorCounts[i] - 1];
                    uint size = vertexCount * (lastDescriptor.Offset + lastDescriptor.Size);
                    Debug.Assert(size < int.MaxValue);
                    result[i] = new NativeArray<byte>((int)size, Allocator.Temp, NativeArrayOptions.ClearMemory);
                }

                return result;
            }

            public uint GetOutputBufferStride(uint bufferIndex)
            {
                ExpandedVertexAttributeDescriptor lastDescriptor = Descriptors[bufferIndex, DescriptorCounts[bufferIndex] - 1];
                return lastDescriptor.Offset + lastDescriptor.Size;
            }

            public void CopyVertexData(NativeArray<byte> outputData, uint bufferIndex, uint meshIndex, byte[] inputData, uint inputDataOffset, uint inputDataStride, uint vertexStart, uint vertexCount)
            {
                uint outputDataStride = GetOutputBufferStride(bufferIndex);

                unsafe
                {
                    byte* outputDataPtr = (byte*)outputData.GetUnsafePtr() + (ulong)vertexStart * outputDataStride;

                    fixed (byte* fixedInputData = inputData)
                    {
                        byte* inputDataPtr = fixedInputData + inputDataOffset;

                        for (uint i = 0; i < vertexCount; i++)
                        {
                            for (uint j = 0; j < RemapDescCounts[bufferIndex, meshIndex]; j++) // Elements
                            {
                                RemapDesc remapDesc = RemapDescs[bufferIndex, meshIndex, j];

                                UnsafeUtility.MemCpy(outputDataPtr + remapDesc.OutputOffset, inputDataPtr + remapDesc.InputOffset, remapDesc.OutputSize);

                                if (remapDesc.Usage == MeshBufferFormatElementUsage.Position || remapDesc.Usage == MeshBufferFormatElementUsage.Normal || remapDesc.Usage == MeshBufferFormatElementUsage.Tangent)
                                    if (remapDesc.Type == MeshBufferFormatElementType.R32G32B32_Float)
                                        *(outputDataPtr + remapDesc.OutputOffset + 3) ^= 0x80;
                                    else if (remapDesc.Type == MeshBufferFormatElementType.R16G16B16A16_Float)
                                        *(outputDataPtr + remapDesc.OutputOffset + 1) ^= 0x80;
                            }

                            outputDataPtr += outputDataStride;
                            inputDataPtr += inputDataStride;
                        }
                    }
                }
            }

            public void CopyBoneWeights(BoneWeight[] outputWeights, byte[] inputData, MeshDataLayoutDesc layoutDesc, uint inputDataOffset, uint inputDataStride, uint vertexStart, uint vertexCount, Span<ushort> boneGroup)
            {
                MeshBufferFormatElement? boneWeightsFormatElement = null;
                MeshBufferFormatElement? boneIndicesFormatElement = null;
                foreach (var bufferDesc in layoutDesc.BufferDescs)
                {
                    foreach (var element in bufferDesc.Elements)
                    {
                        if (element.Usage == MeshBufferFormatElementUsage.BoneWeight0)
                            boneWeightsFormatElement = element;
                        else if (element.Usage == MeshBufferFormatElementUsage.BoneIndex0)
                            boneIndicesFormatElement = element;
                    }
                }

                Debug.Assert(boneWeightsFormatElement.HasValue && boneIndicesFormatElement.HasValue);

                Debug.Assert(boneWeightsFormatElement.Value.Type == MeshBufferFormatElementType.R8G8B8A8_UNorm);
                Debug.Assert(boneIndicesFormatElement.Value.Type == MeshBufferFormatElementType.R8G8B8A8_UInt);

                long inputDataIndex = inputDataOffset;
                for (uint i = 0; i < vertexCount; i++)
                {
                    ref BoneWeight weight = ref outputWeights[vertexStart + i];
                    weight.weight0 = inputData[inputDataIndex + boneWeightsFormatElement.Value.Offset + 0] / (float)byte.MaxValue;
                    weight.boneIndex0 = boneGroup[inputData[inputDataIndex + boneIndicesFormatElement.Value.Offset + 0]];
                    weight.weight1 = inputData[inputDataIndex + boneWeightsFormatElement.Value.Offset + 1] / (float)byte.MaxValue;
                    weight.boneIndex1 = boneGroup[inputData[inputDataIndex + boneIndicesFormatElement.Value.Offset + 1]];
                    weight.weight2 = inputData[inputDataIndex + boneWeightsFormatElement.Value.Offset + 2] / (float)byte.MaxValue;
                    weight.boneIndex2 = boneGroup[inputData[inputDataIndex + boneIndicesFormatElement.Value.Offset + 2]];
                    weight.weight3 = inputData[inputDataIndex + boneWeightsFormatElement.Value.Offset + 3] / (float)byte.MaxValue;
                    weight.boneIndex3 = boneGroup[inputData[inputDataIndex + boneIndicesFormatElement.Value.Offset + 3]];

                    inputDataIndex += inputDataStride;
                }
            }
        }
    }
}