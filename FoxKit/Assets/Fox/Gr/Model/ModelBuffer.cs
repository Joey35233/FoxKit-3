using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using UnityEngine.Rendering;
using static UnityEngine.EventSystems.EventTrigger;

namespace Fox.Gr
{
    public partial class ModelFileImporter
    {
        private class BufferRemap
        {
            private VertexAttribute[] AttributeUsageLUT =
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

            private (VertexAttributeFormat, int, ushort)[] AttributeTypeLUT =
            {
                // Invalid
                (VertexAttributeFormat.UInt32, -1, 0),

                (VertexAttributeFormat.Float32, 3, 12),

                // Invalid
                (VertexAttributeFormat.UInt32, -1, 0),
                (VertexAttributeFormat.UInt32, -1, 0),

                // Wiki says UINT16 is an option but I don't know under what Usage that would ever come up.
                (VertexAttributeFormat.UInt16, 1, 2),

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
                public ushort OutputOffset;
                public ushort OutputSize;
            }

            private int[,] DescriptorIndices;
            private List<VertexAttributeDescriptor>[] Descriptors;

            private RemapDesc[,] RemapDescs;

            public BufferRemap(uint bufferCount, uint meshCount)
            {
                DescriptorIndices = new int[bufferCount, (uint)MeshBufferFormatElementUsage.COUNT];
                for (uint i = 0; i < DescriptorIndices.GetLength(0); i++)
                    for (uint j = 0; j < DescriptorIndices.GetLength(1); j++)
                        DescriptorIndices[i, j] = -1;

                Descriptors = new List<VertexAttributeDescriptor>[bufferCount];
                for (uint i = 0; i < Descriptors.Length; i++)
                    Descriptors[i] = new List<VertexAttributeDescriptor>((int)MeshBufferFormatElementUsage.COUNT);

                RemapDescs = new RemapDesc[bufferCount, meshCount];
            }

            public void Register(MeshBufferDesc bufferDesc)
            {
                uint bufferIndex = bufferDesc.FileBufferIndex;

                var descriptors = Descriptors[bufferIndex];

                for (uint i = 0; i < bufferDesc.Elements.LongLength; i++)
                {
                    MeshBufferFormatElement element = bufferDesc.Elements[i];

                    ref int descriptorIndex = ref DescriptorIndices[bufferIndex, (uint)element.Usage];
                    if (descriptorIndex == -1)
                    {
                        // Set index
                        descriptorIndex = descriptors.Count;

                        // Do descriptors and remap desc
                        (VertexAttributeFormat format, int dimension, ushort size) = AttributeTypeLUT[(uint)element.Type];

                        ushort outputSize = size;
                        if (element.Usage == MeshBufferFormatElementUsage.BoneIndex0)
                        {
                            Debug.Assert(element.Type == MeshBufferFormatElementType.R8G8B8A8_UInt);
                            format = VertexAttributeFormat.UInt16;
                            outputSize = 4;
                        }

                        VertexAttributeDescriptor descriptor = new VertexAttributeDescriptor
                        {
                            attribute = AttributeUsageLUT[(uint)element.Usage],
                            format = format,
                            dimension = dimension,
                            stream = (int)bufferIndex,
                        };

                        descriptors.Add(descriptor);

                        RemapDesc remapDesc = new RemapDesc
                        {
                            Usage = element.Usage,
                            Type = element.Type,
                            InputOffset = 0,
                            InputSize = size,
                            OutputOffset = 0,
                            OutputSize = outputSize,
                        };
                    }
                    else
                    {

                    }
                }
            }
        }

        //private void InflateBuffer(MeshDataLayoutDesc[] layoutDescs)
        //{
        //    uint maxBufferCount = 0;
        //    foreach (var desc in layoutDescs)
        //        if (desc.BufferDescs.Length > maxBufferCount)
        //            maxBufferCount = (uint)desc.BufferDescs.Length;

        //    MeshDataLayoutDesc inflatedMeshLayout = new MeshDataLayoutDesc { BufferDescs = new MeshBufferDesc[maxBufferCount] };
        //    for (uint j = 0; j < inflatedMeshLayout.BufferDescs.Length; j++)
        //    {
        //        inflatedMeshLayout.BufferDescs[j] = new MeshBufferDesc { Elements = new MeshBufferFormatElement[(uint)MeshBufferFormatElementUsage.COUNT] };
        //        for (uint k = 0; k < inflatedMeshLayout.BufferDescs[j].Elements.Length; k++)
        //            inflatedMeshLayout.BufferDescs[j].Elements[k].Offset = -1;
        //    }
        //    for (uint j = 0; j < layoutDescs.Length; j++)
        //    {
        //        MeshDataLayoutDesc compressedMeshLayout = layoutDescs[j];
        //        for (uint k = 0; k < compressedMeshLayout.BufferDescs.Length; k++)
        //        {
        //            MeshBufferDesc compressedBufferDesc = compressedMeshLayout.BufferDescs[k];
        //            ref MeshBufferDesc inflatedBufferDesc = ref inflatedMeshLayout.BufferDescs[k];
        //            for (uint l = 0; l < compressedBufferDesc.Elements.Length; l++)
        //            {
        //                if (inflatedBufferDesc.Elements.Any(element => element.Usage == compressedBufferDesc.Elements[(int)l].Usage))
        //                    continue;
        //                MeshBufferFormatElement lastInflatedElement = inflatedBufferDesc.Elements.Last();
        //                inflatedBufferDesc.Elements.Add(compressedBufferDesc.Elements[(int)l]);
        //            }
        //        }
        //    }
        //}
    }
}