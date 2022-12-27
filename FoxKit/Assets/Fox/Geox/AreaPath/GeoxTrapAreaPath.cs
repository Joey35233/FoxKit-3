using Fox.Core;
using Fox.Fio;
using Fox.Geo;
using Fox.Graphx;
using Fox.Kernel;
using System;
using UnityEngine;

namespace Fox.Geox
{
    public partial class GeoxTrapAreaPath : Fox.Graphx.GraphxPathData
    {
        public override void InitializeGameObject(GameObject gameObject)
        {
            base.InitializeGameObject(gameObject);
            gameObject.AddComponent<GeoxTrapAreaPathGizmo>();
        }

        public static GeoTriggerTrap Deserialize(GeomHeaderContext header)
        {
            FileStreamReader reader = header.Reader;

            Debug.Assert(header.Type == GeoPrimType.AreaPath);

            //GameObject triggerTrapGameObject = new GameObject(header.Name.ToString());
            GeoTriggerTrap triggerTrap = new GeoTriggerTrap();
            //triggerTrapGameObject.AddComponent<FoxEntity>().Entity = triggerTrap;
            TransformEntity triggerTrapTransformEntity = TransformEntity.GetDefault();
            triggerTrap.inheritTransform = false;
            triggerTrap.SetTransform(triggerTrapTransformEntity);
            //triggerTrap.InitializeGameObject(triggerTrapGameObject);

            triggerTrap.name = new Kernel.String(header.Name.ToString());
            triggerTrap.enable = true;
            triggerTrap.groupTags = TagUtils.GetEnumTags<GeoTriggerTrap.Tags>((ulong)header.GetTags<GeoTriggerTrap.Tags>());

            for (int i = 0; i < header.PrimCount; i++)
            {
                reader.Seek(header.GetDataPosition() + 16 * i);
                float yMin = reader.ReadSingle();
                float yMax = reader.ReadSingle();
                uint vertexCount = reader.ReadUInt32();
                int vertexDataOffset = reader.ReadInt32();
                Debug.Assert(vertexCount >= 2);
                if (vertexCount >= 2 && vertexDataOffset != 0)
                {
                    GeoxTrapAreaPath trapAreaPath = new GeoxTrapAreaPath();
                    TransformEntity transformEntity = TransformEntity.GetDefault();
                    transformEntity.translation = new Vector3(0, yMin, 0);
                    trapAreaPath.SetTransform(transformEntity);
                    trapAreaPath.name = new Kernel.String(header.Name.ToString());

                    trapAreaPath.height = yMax - yMin;

                    triggerTrap.AddChild(trapAreaPath);

                    for (int j = 0; j < vertexCount; j++)
                    {
                        reader.Seek(header.GetDataPosition() + vertexDataOffset + 16 * j);
                        GraphxSpatialGraphDataNode node = new GraphxSpatialGraphDataNode();
                        node.position = reader.ReadPositionF();
                        node.SetOwner(trapAreaPath);

                        trapAreaPath.nodes.Add(new EntityPtr<GraphxSpatialGraphDataNode>(node));
                    }

                    GraphxSpatialGraphDataNode prevNode = null;
                    GraphxSpatialGraphDataNode nextNode = null;
                    {
                        GraphxSpatialGraphDataEdge loopEdge = new GraphxSpatialGraphDataEdge();
                        prevNode = trapAreaPath.nodes[(int)(vertexCount - 1)].Get();
                        nextNode = trapAreaPath.nodes[0].Get();
                        loopEdge.nextNode = EntityHandle.Get(nextNode);
                        nextNode.inlinks.Add(loopEdge.nextNode);
                        loopEdge.prevNode = EntityHandle.Get(prevNode);
                        prevNode.outlinks.Add(loopEdge.prevNode);

                        trapAreaPath.edges.Add(new EntityPtr<GraphxSpatialGraphDataEdge>(loopEdge));
                    }

                    for (int j = 0; j < vertexCount - 1; j++)
                    {
                        prevNode = trapAreaPath.nodes[j].Get();
                        nextNode = trapAreaPath.nodes[j + 1].Get();

                        GraphxSpatialGraphDataEdge edge = new GraphxSpatialGraphDataEdge();
                        edge.nextNode = EntityHandle.Get(nextNode);
                        nextNode.inlinks.Add(edge.nextNode);
                        edge.prevNode = EntityHandle.Get(prevNode);
                        prevNode.outlinks.Add(edge.prevNode);

                        trapAreaPath.edges.Add(new EntityPtr<GraphxSpatialGraphDataEdge>(edge));
                    }
                }
            }

            return triggerTrap;
        }
    }
}
