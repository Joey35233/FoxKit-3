using Fox.Kernel;
using Fox.Core;
using System;
using System.IO;
using UnityEditor.SceneManagement;
using UnityEngine;
using static UnityEngine.Debug;
using String = Fox.Kernel.String;
using Fox.Fio;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

namespace Fox.Geox
{
    public class GeoxPathFixedPackReader
    {
        public UnityEngine.SceneManagement.Scene Read(FileStreamReader reader)
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            FoxDataHeaderContext header = new FoxDataHeaderContext(reader, reader.BaseStream.Position);
            header.Validate(version: 201209110, flags: 0);

            uint pathIndex = 0;

            for (FoxDataNodeContext? node = header.GetFirstNode(); node.HasValue; node = node.Value.GetNextNode())
            {
                FoxDataNodeContext realNode = node.Value;
                uint payloadOffset = (uint)(realNode.Position + realNode.GetDataOffset());

                //Payload
                reader.Seek(payloadOffset);
                reader.Skip(60);
                uint dataOffset = reader.ReadUInt32();

                reader.Seek(payloadOffset + dataOffset);
                uint pathCount = reader.ReadUInt32();
                for (uint i = 0; i < pathCount; i++)
                {
                    reader.Seek(payloadOffset + dataOffset + 8 + 4 * i);
                    uint offsetToPath = reader.ReadUInt32();
                    reader.Seek(payloadOffset + offsetToPath);

                    uint geoPathGeomHeader = reader.ReadUInt32();
                    uint geoPrimType = geoPathGeomHeader & 0xF;
                    uint geoShapeFlags = (geoPathGeomHeader & 0xFFFFF0) >> 4;
                    uint primCount = geoPathGeomHeader >> 24;
                    reader.Skip(12);

                    ulong geoPathTags = reader.ReadUInt64();
                    uint name = reader.ReadUInt32();//strcode32
                    uint vertexBufferOffset = reader.ReadUInt32();

                    var pathGo = new GameObject();
                    pathGo.name = $"GeoxPath2{pathIndex.ToString("D4")}";

                    //Edges and nodes
                    uint nodeCount = 0;
                    for (uint k = 0; k < primCount; k++)
                    {
                        uint geoEdgeTags = reader.ReadUInt32();
                        ushort inIndex = reader.ReadUInt16();
                        ushort outIndex = reader.ReadUInt16();

                        if (inIndex > nodeCount)
                            nodeCount = inIndex;
                        if (outIndex > nodeCount)
                            nodeCount = outIndex;
                    }

                    reader.Seek(payloadOffset + offsetToPath + vertexBufferOffset);

                    for (uint k = 0; k < nodeCount + 1; k++)
                    {
                        Vector3 nodePosition = reader.ReadPositionF();
                        uint geoNodeTags = reader.ReadUInt32();
                        var nodeGo = new GameObject();

                        nodeGo.name = $"{pathGo.name}_GeoxPathNode{k.ToString("D4")}";
                        nodeGo.transform.position = nodePosition;
                        nodeGo.transform.SetParent(pathGo.transform);
                        GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.SetParent(nodeGo.transform, false);
                    }

                    pathIndex++;
                }
            }

            return scene;
        }
    }
}
