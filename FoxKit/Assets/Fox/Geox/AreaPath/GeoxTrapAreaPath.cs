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
        public static GeoTriggerTrap Deserialize(GeomHeaderContext header)
        {
            FileStreamReader reader = header.Reader;

            Debug.Assert(header.Type == GeoPrimType.AreaPath);

            GeoTriggerTrap triggerTrap = new GameObject(header.Name.ToString()).AddComponent<GeoTriggerTrap>();
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
                        loopEdge.nextNode = nextNode;
                        nextNode.inlinks.Add(loopEdge.nextNode);
                        loopEdge.prevNode = prevNode;
                        prevNode.outlinks.Add(loopEdge.prevNode);

                        trapAreaPath.edges.Add(new EntityPtr<GraphxSpatialGraphDataEdge>(loopEdge));
                    }

                    for (int j = 0; j < vertexCount - 1; j++)
                    {
                        prevNode = trapAreaPath.nodes[j].Get();
                        nextNode = trapAreaPath.nodes[j + 1].Get();

                        GraphxSpatialGraphDataEdge edge = new GameObject().AddComponent<GraphxSpatialGraphDataEdge>();
                        edge.SetOwner(trapAreaPath);

                        edge.nextNode = nextNode;
                        nextNode.inlinks.Add(edge.nextNode);
                        edge.prevNode = prevNode;
                        prevNode.outlinks.Add(edge.prevNode);

                        trapAreaPath.edges.Add(new EntityPtr<GraphxSpatialGraphDataEdge>(edge));
                    }
                }
            }

            return triggerTrap;
        }

        private static readonly Color Color = Color.red;

        public void DrawGizmos(bool isSelected)
        {
            if (gameObject.GetComponent<GeoxTrapAreaPath>() is not { } trapPath)
                return;

            Gizmos.matrix = Matrix4x4.identity;
            Gizmos.color = isSelected ? Color.white : Color;

            foreach (EntityPtr<GraphxSpatialGraphDataEdge> edgePtr in trapPath.edges)
            {
                GraphxSpatialGraphDataEdge edge = edgePtr.Get();
                var prevNode = edge.prevNode as GraphxSpatialGraphDataNode;
                var nextNode = edge.nextNode as GraphxSpatialGraphDataNode;

                float yMin = this.transform.position.y;
                float yMax = yMin + trapPath.height;

                Gizmos.DrawLine(new Vector3(prevNode.position.x, yMin, prevNode.position.z), new Vector3(nextNode.position.x, yMin, nextNode.position.z));
                Gizmos.DrawLine(new Vector3(prevNode.position.x, yMax, prevNode.position.z), new Vector3(nextNode.position.x, yMax, nextNode.position.z));

                Gizmos.DrawLine(new Vector3(nextNode.position.x, yMin, nextNode.position.z), new Vector3(nextNode.position.x, yMax, nextNode.position.z));
            }
        }

        public void OnDrawGizmos() => DrawGizmos(false);

        public void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}
