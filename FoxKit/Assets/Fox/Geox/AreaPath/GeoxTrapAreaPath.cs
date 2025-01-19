using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using Fox.Geo;
using Fox.Graphx;
using Fox;
using UnityEngine;
using System;

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

            triggerTrap.name = header.Name.ToString();
            triggerTrap.enable = true;
            TagUtils.AddEnumTags<GeoTriggerTrap.Tags>(triggerTrap.groupTags, (ulong)header.GetTags<GeoTriggerTrap.Tags>());

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

                        trapAreaPath.nodes.Add(node);
                    }

                    GraphxSpatialGraphDataNode prevNode;

                    GraphxSpatialGraphDataNode nextNode;
                    {
                        GraphxSpatialGraphDataEdge loopEdge = new GameObject().AddComponent<GraphxSpatialGraphDataEdge>();
                        loopEdge.SetOwner(trapAreaPath);

                        prevNode = trapAreaPath.nodes[(int)(vertexCount - 1)];
                        nextNode = trapAreaPath.nodes[0];
                        loopEdge.nextNode = nextNode;
                        nextNode.inlinks.Add(loopEdge.nextNode);
                        loopEdge.prevNode = prevNode;
                        prevNode.outlinks.Add(loopEdge.prevNode);

                        trapAreaPath.edges.Add(loopEdge);
                    }

                    for (int j = 0; j < vertexCount - 1; j++)
                    {
                        prevNode = trapAreaPath.nodes[j];
                        nextNode = trapAreaPath.nodes[j + 1];

                        GraphxSpatialGraphDataEdge edge = new GameObject().AddComponent<GraphxSpatialGraphDataEdge>();
                        edge.SetOwner(trapAreaPath);

                        edge.nextNode = nextNode;
                        nextNode.inlinks.Add(edge.nextNode);
                        edge.prevNode = prevNode;
                        prevNode.outlinks.Add(edge.prevNode);

                        trapAreaPath.edges.Add(edge);
                    }
                }
            }

            return triggerTrap;
        }

        private static readonly Color Color = Color.red;
        public override Type GetNodeType() => typeof(GraphxSpatialGraphDataNode);

        public void DrawGizmos(bool isSelected)
        {
            if (gameObject.GetComponent<GeoxTrapAreaPath>() is not { } trapPath)
                return;

            Gizmos.matrix = Matrix4x4.identity;
            Gizmos.color = isSelected ? Color.white : Color;

            foreach (GraphxSpatialGraphDataEdge edgePtr in trapPath.edges)
            {
                GraphxSpatialGraphDataEdge edge = edgePtr;
                var prevNode = edge.prevNode as GraphxSpatialGraphDataNode;
                var nextNode = edge.nextNode as GraphxSpatialGraphDataNode;

                float yMin = this.transform.position.y;
                float yMax = this.transform.TransformPoint(new Vector3(0, trapPath.height, 0)).y;

                Vector3 prevNodePos = this.transform.TransformPoint(prevNode.position);
                Vector3 nextNodePos = this.transform.TransformPoint(nextNode.position);

                float prevNodex = this.transform.position.x + prevNode.position.x;
                float prevNodez = this.transform.position.z + prevNode.position.z;
                float nextNodex = this.transform.position.x + nextNode.position.x;
                float nextNodez = this.transform.position.z + nextNode.position.z;

                Gizmos.DrawLine(new Vector3(prevNodePos.x, yMin, prevNodePos.z), new Vector3(nextNodePos.x, yMin, nextNodePos.z));
                Gizmos.DrawLine(new Vector3(prevNodePos.x, yMax, prevNodePos.z), new Vector3(nextNodePos.x, yMax, nextNodePos.z));

                Gizmos.DrawLine(new Vector3(nextNodePos.x, yMin, nextNodePos.z), new Vector3(nextNodePos.x, yMax, nextNodePos.z));
            }
        }

        public void OnDrawGizmos() => DrawGizmos(false);

        public void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}
