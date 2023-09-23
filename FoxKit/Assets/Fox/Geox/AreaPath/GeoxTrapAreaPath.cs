using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using Fox.Geo;
using Fox.Graphx;
using Fox.Kernel;
using UnityEngine;

namespace Fox.Geox
{
    public partial class GeoxTrapAreaPath : Fox.Graphx.GraphxPathData
    {
        public override void InitializeGameObject(GameObject gameObject, TaskLogger logger)
        {
            base.InitializeGameObject(gameObject, logger);
            _ = gameObject.AddComponent<GeoxTrapAreaPathGizmo>();
        }

        public static GeoTriggerTrap Deserialize(GeomHeaderContext header)
        {
            FileStreamReader reader = header.Reader;

            Debug.Assert(header.Type == GeoPrimType.AreaPath);

            //GameObject triggerTrapGameObject = new GameObject(header.Name.ToString());
            var triggerTrap = new GeoTriggerTrap();
            //triggerTrapGameObject.AddComponent<FoxEntity>().Entity = triggerTrap;
            var triggerTrapTransformEntity = TransformEntity.GetDefault();
            triggerTrap.inheritTransform = false;
            triggerTrap.SetTransform(triggerTrapTransformEntity);
            //triggerTrap.InitializeGameObject(triggerTrapGameObject);

            triggerTrap.name = new Kernel.String(header.Name.ToString());
            triggerTrap.enable = true;
            triggerTrap.groupTags = TagUtils.GetEnumTags<GeoTriggerTrap.Tags>((ulong)header.GetTags<GeoTriggerTrap.Tags>());

            for (int i = 0; i < header.PrimCount; i++)
            {
                reader.Seek(header.GetDataPosition() + (16 * i));
                float yMin = reader.ReadSingle();
                float yMax = reader.ReadSingle();
                uint vertexCount = reader.ReadUInt32();
                int vertexDataOffset = reader.ReadInt32();
                Debug.Assert(vertexCount >= 2);
                if (vertexCount >= 2 && vertexDataOffset != 0)
                {
                    GeoxTrapAreaPath trapAreaPath = new GameObject(header.Name.ToString()).AddComponent<GeoxTrapAreaPath>();
                    var transform = TransformEntity.GetDefault();
                    transform.translation = new Vector3(0, yMin, 0);
                    trapAreaPath.SetTransform(transform);

                    trapAreaPath.height = yMax - yMin;

                    triggerTrap.AddChild(trapAreaPath);

                    for (int j = 0; j < vertexCount; j++)
                    {
                        reader.Seek(header.GetDataPosition() + vertexDataOffset + (16 * j));

                        GraphxSpatialGraphDataNode node = new GameObject().AddComponent<GraphxSpatialGraphDataNode>();
                        node.SetOwner(trapAreaPath);
                        node.position = reader.ReadPositionF();

                        trapAreaPath.nodes.Add(new EntityPtr<GraphxSpatialGraphDataNode>(node));
                    }

                    GraphxSpatialGraphDataNode prevNode;

                    GraphxSpatialGraphDataNode nextNode;
                    {
                        GraphxSpatialGraphDataEdge loopEdge = new GameObject().AddComponent<GraphxSpatialGraphDataEdge>();
                        loopEdge.SetOwner(trapAreaPath);

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

                        GraphxSpatialGraphDataEdge edge = new GameObject().AddComponent<GraphxSpatialGraphDataEdge>();
                        edge.SetOwner(trapAreaPath);

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
