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
using Fox.Geo;
using Fox.Graphx;

namespace Fox.Geox
{
    public class GeoxPathFixedPackReader
    {
        public UnityEngine.SceneManagement.Scene Read(FileStreamReader reader)
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            FoxDataHeaderContext header = new FoxDataHeaderContext(reader, reader.BaseStream.Position);
            header.Validate(version: 201209110, flags: 0);

            for (FoxDataNodeContext? foxDataNode = header.GetFirstNode(); foxDataNode.HasValue; foxDataNode = foxDataNode.Value.GetNextNode())
            {
                FoxDataNodeContext realNode = foxDataNode.Value;
                uint payloadOffset = (uint)(realNode.Position + realNode.GetDataOffset());

                //Payload
                reader.Seek(payloadOffset);
                reader.Skip(60);
                uint dataOffset = reader.ReadUInt32();

                reader.Seek(payloadOffset + dataOffset);
                uint pathCount = reader.ReadUInt32();
                for (uint pathIndex = 0; pathIndex < pathCount; pathIndex++)
                {
                    reader.Seek(payloadOffset + dataOffset + 8 + 4 * pathIndex);
                    uint offsetToPath = reader.ReadUInt32();
                    reader.Seek(payloadOffset + offsetToPath);

                    uint geoPathGeomHeader = reader.ReadUInt32();
                    uint edgeCount = geoPathGeomHeader >> 24;
                    reader.Skip(12);

                    GeoxPath2_PATH_TAG geoPathTags = (GeoxPath2_PATH_TAG)reader.ReadUInt64();
                    uint name = reader.ReadUInt32();//strcode32
                    uint vertexBufferOffset = reader.ReadUInt32();

                    var pathGameObject = new GameObject();
                    pathGameObject.name = name.ToString();
                    var pathFoxEntityComponent = pathGameObject.AddComponent<FoxEntity>();
                    GeoxPath2 pathEntity = (GeoxPath2)(pathFoxEntityComponent.Entity = new GeoxPath2());
                    pathEntity.InitializeGameObject(pathGameObject);

                    TransformEntity pathTransformEntity = new TransformEntity();
                    pathTransformEntity.owner = EntityHandle.Get(pathEntity);
                    pathEntity.transform = new EntityPtr<TransformEntity>(pathTransformEntity);

                    foreach (GeoxPath2_PATH_TAG tag in Enum.GetValues(geoPathTags.GetType()))
                        if (geoPathTags.HasFlag(tag))
                            pathEntity.tags.Add(new String(tag.ToString()));

                    //Edges and nodes
                    uint nodeCount = 0;
                    ushort[] prevNodeIndices = new ushort[edgeCount];
                    ushort[] nextNodeIndices = new ushort[edgeCount];
                    for (uint edgeIndex = 0; edgeIndex < edgeCount; edgeIndex++)
                    {
                        GeoxPathEdge edge = new GeoxPathEdge();
                        edge.owner = EntityHandle.Get(pathEntity);

                        GeoxPath2_EDGE_TAG geoEdgeTags = (GeoxPath2_EDGE_TAG)reader.ReadUInt32();
                        prevNodeIndices[edgeIndex] = reader.ReadUInt16();
                        nextNodeIndices[edgeIndex] = reader.ReadUInt16();

                        if (prevNodeIndices[edgeIndex] > nodeCount)
                            nodeCount = prevNodeIndices[edgeIndex];
                        if (nextNodeIndices[edgeIndex] > nodeCount)
                            nodeCount = nextNodeIndices[edgeIndex];

                        foreach (GeoxPath2_EDGE_TAG tag in Enum.GetValues(geoEdgeTags.GetType()))
                            if (geoEdgeTags.HasFlag(tag))
                                edge.edgeTags.Add(new String(tag.ToString()));

                        pathEntity.edges.Add(new EntityPtr<GraphxSpatialGraphDataEdge>(edge));
                    }

                    reader.Seek(payloadOffset + offsetToPath + vertexBufferOffset);

                    for (uint nodeIndex = 0; nodeIndex < nodeCount + 1; nodeIndex++)
                    {
                        GeoxPathNode node = new GeoxPathNode();
                        node.owner = EntityHandle.Get(pathEntity);

                        Vector3 nodePosition = reader.ReadPositionF();
                        if (nodeIndex==0)
                            pathGameObject.transform.position = nodePosition;
                        else
                            node.position = pathGameObject.transform.InverseTransformPoint(nodePosition);

                        GeoxPath2_NODE_TAG geoNodeTags = (GeoxPath2_NODE_TAG)reader.ReadUInt32();
                        foreach (GeoxPath2_NODE_TAG tag in Enum.GetValues(geoNodeTags.GetType()))
                            if (geoNodeTags.HasFlag(tag))
                                node.nodeTags.Add(new String(tag.ToString()));

                        pathEntity.nodes.Add(new EntityPtr<GraphxSpatialGraphDataNode>(node));

                        for (int edgeIndex = 0; edgeIndex < edgeCount; edgeIndex++)
                        {
                            if (nodeIndex == prevNodeIndices[edgeIndex])
                            {
                                GeoxPathEdge edge = pathEntity.edges[edgeIndex].Get() as GeoxPathEdge;
                                edge.prevNode = EntityHandle.Get(node);
                                node.outlinks.Add(EntityHandle.Get(edge));
                            }
                            if (nodeIndex == nextNodeIndices[edgeIndex])
                            {
                                GeoxPathEdge edge = pathEntity.edges[edgeIndex].Get() as GeoxPathEdge;
                                edge.nextNode = EntityHandle.Get(node);
                                node.outlinks.Add(EntityHandle.Get(edge));
                            }
                        }
                    }
                }
            }

            return scene;
        }
    }
}
