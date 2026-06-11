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

                // R32G32B32_Float
                (VertexAttributeFormat.Float32, 3, 12),

                // Invalid
                (VertexAttributeFormat.UInt32, -1, 0),
                (VertexAttributeFormat.UInt32, -1, 0),

                // Wiki says UINT16 is an option but I don't know under what Semantic that would ever come up.
                //(VertexAttributeFormat.UInt16, 1, 2),
                (VertexAttributeFormat.UInt32, -1, 0),

                // Invalid
                (VertexAttributeFormat.UInt32, -1, 0),

                // R16G16B16A16_Float
                (VertexAttributeFormat.Float16, 4, 8),
                // R16G16_Float
                (VertexAttributeFormat.Float16, 2, 4),
                // R8G8B8A8_UNorm
                (VertexAttributeFormat.UNorm8, 4, 4),
                // R8G8B8A8_UInt
                (VertexAttributeFormat.UInt8, 4, 4),
            };

            private struct CopyInfo
            {
                public uint SourceBufferIndex;
                public uint SourceBufferOffset;
                public uint SourceBufferStride;
                
                public Fmdl.InputElementSemantic Semantic;
                public Fmdl.InputElementType Type;
                
                public ushort SourceOffset;
                public ushort SourceSize;
                
                public uint DestOffset;
            }
            
            private struct PlacedUnityAttributeDescriptor
            {
                public VertexAttributeDescriptor UnityDescriptor;
                public ushort Size;
                public uint Offset;
            }
            
            // Sparse mapping into 
            private uint BufferCount;
            private uint[] UnityDescriptorCounts;
            private uint[,] UnityDescriptorIndices;
            private PlacedUnityAttributeDescriptor[,] UnityDescriptorsPool;
            
            private uint[] CopyInfoCounts;
            private CopyInfo[,] CopyInfos;

            public enum ErrorCode
            {
                Success,
                UnityIncompatible,
                InvalidFormat,
            }
            
            public ErrorCode Register(Fmdl.InputLayoutBindSlotDef* bindSlots, uint bindSlotCount, Fmdl.InputLayoutElement* elements, uint elementCount)
            {
                // Loop over all elements directly to determine Unity buffer count
                uint needBufferCount = 0;
                bool needWeightBuffer = false;
                for (uint i = 0; i < elementCount; i++)
                {
                    switch (elements[i].Semantic)
                    {
                        case Fmdl.InputElementSemantic.Position or Fmdl.InputElementSemantic.Normal or Fmdl.InputElementSemantic.Tangent:
                            needBufferCount = 1;
                            break;
                        case Fmdl.InputElementSemantic.BoneIndex0 or Fmdl.InputElementSemantic.BoneWeight0:
                            needWeightBuffer = true;
                            break;
                        default:
                            needBufferCount = 2;
                            break;
                    }
                }
                
                Debug.Assert(needBufferCount is 1 or 2);
                if (needBufferCount is 0)
                    return ErrorCode.UnityIncompatible;

                // If weights exist, they go in second buffer if the second is unused, else the third buffer
                if (needWeightBuffer == true)
                    needBufferCount++;
                
                // Remap info now that number of final buffers is known
                uint semanticCount = (uint)Fmdl.InputElementSemantic.COUNT;
                
                // Sparse mapping into Unity descriptors
                BufferCount = needBufferCount;
                UnityDescriptorCounts = new uint[BufferCount];
                UnityDescriptorIndices = new uint[BufferCount, semanticCount];
                for (uint i = 0; i < BufferCount; i++)
                    for (uint j = 0; j < semanticCount; j++)
                        UnityDescriptorIndices[i, j] = uint.MaxValue;
                UnityDescriptorsPool = new PlacedUnityAttributeDescriptor[BufferCount, semanticCount];
                
                // Info for copying from source to desc buffer
                CopyInfoCounts = new uint[BufferCount];
                CopyInfos = new CopyInfo[BufferCount, semanticCount];

                // Build map. Looping using bind slots this time because element.Offset is relative (multiple == 0's, one per buffer) 
                for (uint i = 0, absElementIndex = 0; i < bindSlotCount; i++)
                {
                    Fmdl.InputLayoutBindSlotDef bindSlotDef = bindSlots[i];
                    
                    for (uint j = 0; j < bindSlotDef.ElementCount; j++, absElementIndex++)
                    {
                        Fmdl.InputLayoutElement element = elements[absElementIndex];
                        
                        uint unityBufferIndex = element.Semantic switch
                        {
                            Fmdl.InputElementSemantic.Position or Fmdl.InputElementSemantic.Normal or Fmdl.InputElementSemantic.Tangent => 0,
                            Fmdl.InputElementSemantic.BoneIndex0 or Fmdl.InputElementSemantic.BoneWeight0 => BufferCount - 1,
                            _ => 1,
                        };
                        
                        (VertexAttributeFormat unityFormat, int unityDimension, ushort size) = UnityAttributeTypeTable[(uint)element.Type];
            
                        ushort unitySize = size;
                        // Later, the Fox bone weights, which rely on 32-bone groups, will be unpacked to an "absolute" index.
                        if (element.Semantic is Fmdl.InputElementSemantic.BoneIndex0 or Fmdl.InputElementSemantic.BoneIndex1)
                        {
                            Debug.Assert(element.Type == Fmdl.InputElementType.R8G8B8A8_UInt);
                        
                            unityFormat = VertexAttributeFormat.UInt16;
                            unitySize = 8;
                        }
            
                        // If this is a new element for the inflated buffer.
                        ref uint descriptorIndex = ref UnityDescriptorIndices[unityBufferIndex, (uint)element.Semantic];
                        if (descriptorIndex == uint.MaxValue)
                        {
                            // Set descriptor index
                            descriptorIndex = UnityDescriptorCounts[unityBufferIndex]++;
            
                            // Add UnityEngine format info
                            var descriptor = new VertexAttributeDescriptor
                            {
                                attribute = UnityAttributeSemanticTable[(uint)element.Semantic],
                                format = unityFormat,
                                dimension = unityDimension,
                                stream = (int)unityBufferIndex,
                            };
                            
                            UnityDescriptorsPool[unityBufferIndex, descriptorIndex] = new PlacedUnityAttributeDescriptor
                            {
                                UnityDescriptor = descriptor, 
                                Offset = 0, 
                                Size = unitySize,
                            };
                        }
                        else
                        {
                            return ErrorCode.InvalidFormat;
                        }
                        
                        // First pass on remap desc. Intentionally don't fill out output offset.
                        var remapDesc = new CopyInfo
                        {
                            SourceBufferIndex = bindSlotDef.BufferIndex,
                            SourceBufferOffset = bindSlotDef.Offset,
                            SourceBufferStride = bindSlotDef.Stride,
                            
                            Semantic = element.Semantic,
                            Type = element.Type,
                            
                            SourceOffset = element.Offset,
                            SourceSize = size,
                            
                            DestOffset = 0, // Leave at 0 for prepass.
                        };
                        CopyInfos[unityBufferIndex, CopyInfoCounts[unityBufferIndex]++] = remapDesc;
                    }
                }
            
                // Calculate offsets
                for (uint i = 0; i < BufferCount; i++)
                    for (uint j = 1; j < UnityDescriptorCounts[i]; j++)
                        UnityDescriptorsPool[i, j].Offset = UnityDescriptorsPool[i, j - 1].Offset + UnityDescriptorsPool[i, j - 1].Size;
            
                // Loop over buffers
                for (uint i = 0; i < BufferCount; i++)
                {
                    for (uint j = 1; j < CopyInfoCounts[i]; j++)
                    {
                        ref CopyInfo copyInfo = ref CopyInfos[i, j];
                        
                        uint descriptorIndex = UnityDescriptorIndices[i, (uint)copyInfo.Semantic];
                        copyInfo.DestOffset = UnityDescriptorsPool[i, descriptorIndex].Offset;
                    }
                }

                return ErrorCode.Success;
            }
            
            public NativeArray<VertexAttributeDescriptor> GetDescriptorArray()
            {
                uint totalDescriptorCount = 0;
                foreach (uint count in UnityDescriptorCounts)
                    totalDescriptorCount += count;
            
                var result = new NativeArray<VertexAttributeDescriptor>((int)totalDescriptorCount, Allocator.Temp);
            
                int absoluteIndex = 0;
                for (uint i = 0; i < BufferCount; i++)
                {
                    for (uint j = 0; j < UnityDescriptorCounts[i]; j++)
                    {
                        result[absoluteIndex] = UnityDescriptorsPool[i, j].UnityDescriptor;
            
                        absoluteIndex++;
                    }
                }
            
                return result;
            }
            
            public NativeArray<byte>[] CreateVertexBuffers(uint vertexCount)
            {
                var buffers = new NativeArray<byte>[BufferCount];
                for (uint i = 0; i < BufferCount; i++)
                {
                    PlacedUnityAttributeDescriptor lastDescriptor = UnityDescriptorsPool[i, UnityDescriptorCounts[i] - 1];
                    uint size = vertexCount * (lastDescriptor.Offset + lastDescriptor.Size);
                    
                    Debug.Assert(size < Int32.MaxValue);
                    buffers[i] = new NativeArray<byte>((int)size, Allocator.Temp);
                }
            
                return buffers;
            }
            
            public uint GetUnityBufferStride(uint bufferIndex)
            {
                PlacedUnityAttributeDescriptor lastDescriptor = UnityDescriptorsPool[bufferIndex, UnityDescriptorCounts[bufferIndex] - 1];
                return lastDescriptor.Offset + lastDescriptor.Size;
            }
            
            public void CopyVertexData(Mesh mesh, byte*[] sourceBuffers, NativeArray<byte>[] destBuffers, uint vertexCount, Fmdl.BoneGroup* boneGroup)
            {
                ushort* boneGroupData = (ushort*)((byte*)boneGroup + 4);
                
                for (uint i = 0; i < destBuffers.LongLength; i++)
                {
                    NativeArray<byte> destBuffer = destBuffers[i];
                    
                    byte* destData = (byte*)destBuffer.GetUnsafePtr();
                    uint outputDataStride = GetUnityBufferStride(i);
                
                    for (uint j = 0; j < vertexCount; j++)
                    {
                        for (uint k = 0; k < CopyInfoCounts[i]; k++)
                        {
                            CopyInfo copyInfo = CopyInfos[i, k];

                            byte* sourceData = sourceBuffers[copyInfo.SourceBufferIndex] + copyInfo.SourceBufferOffset + j * copyInfo.SourceBufferStride;
                
                            // InputSize will be too small when copying bone indices so the space after them is undefined but overwritten when the indices are expanded below.
                            UnsafeUtility.MemCpy(destData + copyInfo.DestOffset, sourceData + copyInfo.SourceOffset, copyInfo.SourceSize);
                
                            if (copyInfo.Semantic is Fmdl.InputElementSemantic.Position or Fmdl.InputElementSemantic.Normal or Fmdl.InputElementSemantic.Tangent)
                            {
                                if (copyInfo.Type == Fmdl.InputElementType.R32G32B32_Float)
                                    *(destData + copyInfo.DestOffset + 3) ^= 0x80;
                                else if (copyInfo.Type == Fmdl.InputElementType.R16G16B16A16_Float)
                                    *(destData + copyInfo.DestOffset + 1) ^= 0x80;
                            }
                            else if (copyInfo.Semantic is Fmdl.InputElementSemantic.BoneIndex0)
                            {
                                byte* compressedBoneWeights = destData + copyInfo.DestOffset;
                                ushort boneWeight0 = boneGroupData[compressedBoneWeights[0]];
                                ushort boneWeight1 = boneGroupData[compressedBoneWeights[1]];
                                ushort boneWeight2 = boneGroupData[compressedBoneWeights[2]];
                                ushort boneWeight3 = boneGroupData[compressedBoneWeights[3]];
                            
                                ushort* uncompressedBoneWeights = (ushort*)compressedBoneWeights;
                                uncompressedBoneWeights[0] = boneWeight0;
                                uncompressedBoneWeights[1] = boneWeight1;
                                uncompressedBoneWeights[2] = boneWeight2;
                                uncompressedBoneWeights[3] = boneWeight3;
                            }
                        }
                
                        destData += outputDataStride;
                    }
                    
                    Debug.Assert(vertexCount * outputDataStride <= Int32.MaxValue);
                    mesh.SetVertexBufferData(destBuffer, 0, 0, (int)(vertexCount * outputDataStride), (int)i, UpdateFlags | MeshUpdateFlags.DontNotifyMeshUsers);
                }
            }
        }
    }
}