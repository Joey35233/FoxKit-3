using Fox.Core;
using Fox.Core.Utils;
using Fox.Geo;
using static Fox.Geo.GeoGeom;
using Fox.Graphx;
using Fox;
using UnityEngine;
using System;

namespace Fox.Geox
{
    public partial class GeoxTrapAreaPath : Fox.Graphx.GraphxPathData
    {
        public static unsafe void Deserialize(IntPtr geomHeaderPtr, GameObject parent)
        {
            GeomHeader* geomHeader = (GeomHeader*)geomHeaderPtr;

            byte primCount = (byte)(geomHeader->Info >> 24 & 0xFF);
            byte* payload = (byte*)(geomHeader + 1);

            GeoTriggerTrap triggerTrap = new GameObject(geomHeader->Name.ToString()).AddComponent<GeoTriggerTrap>();
            triggerTrap.transform.parent = parent.transform;
            triggerTrap.SetTransform(TransformEntity.GetDefault());
            triggerTrap.enable = true;
            TagUtils.AddEnumTags<GeoTriggerTrap.Tags>(triggerTrap.groupTags, (ulong)geomHeader->Tags);

            for (int i = 0; i < primCount; i++)
            {
                byte* prim = payload + (16 * i);
                float yMin = *(float*)prim;
                float yMax = *(float*)(prim + 4);
                uint vertexCount = *(uint*)(prim + 8);
                int vertexDataOffset = *(int*)(prim + 12);

                if (vertexCount >= 2 && vertexDataOffset != 0)
                {
                    GeoxTrapAreaPath trapAreaPath = new GameObject($"{geomHeader->Name.ToString()}|GeoxTrapAreaPath{i:D4}").AddComponent<GeoxTrapAreaPath>();
                    trapAreaPath.SetTransform(TransformEntity.GetDefault());
                    trapAreaPath.transform.position = new Vector3(0, yMin, 0);
                    bool transformSet = false;

                    trapAreaPath.height = yMax - yMin;

                    triggerTrap.AddChild(trapAreaPath);

                    byte* vertices = payload + vertexDataOffset;
                    for (int j = 0; j < vertexCount; j++)
                    {
                        GraphxSpatialGraphDataNode node = new GameObject().AddComponent<GraphxSpatialGraphDataNode>();
                        node.SetOwner(trapAreaPath);
                        node.name = $"{node.GetType().Name}{j:D4}";
                        node.position = Fox.Math.FoxToUnityVector3(*(Vector3*)(vertices + (16 * j)));

                        if (!transformSet)
                        {
                            trapAreaPath.transform.position = new Vector3(node.position.x, yMin, node.position.z);
                            node.position = new Vector3(0, node.position.y - yMin, 0);
                            transformSet = true;
                        }
                        else
                        {
                            node.position -= trapAreaPath.transform.position;
                        }

                        trapAreaPath.nodes.Add(node);
                    }

                    GraphxSpatialGraphDataNode prevNode;

                    GraphxSpatialGraphDataNode nextNode;
                    {
                        GraphxSpatialGraphDataEdge loopEdge = new GameObject().AddComponent<GraphxSpatialGraphDataEdge>();
                        loopEdge.SetOwner(trapAreaPath);
                        loopEdge.name = $"{loopEdge.GetType().Name}{0:D4}";

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
                        edge.name = $"{edge.GetType().Name}{j + 1:D4}";

                        edge.prevNode = prevNode;
                        prevNode.outlinks.Add(edge.prevNode);
                        edge.nextNode = nextNode;
                        nextNode.outlinks.Add(edge.nextNode);

                        trapAreaPath.edges.Add(edge);
                    }
                }
            }
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

                Gizmos.DrawLine(new Vector3(prevNodePos.x, yMin, prevNodePos.z), new Vector3(nextNodePos.x, yMin, nextNodePos.z));
                Gizmos.DrawLine(new Vector3(prevNodePos.x, yMax, prevNodePos.z), new Vector3(nextNodePos.x, yMax, nextNodePos.z));

                Gizmos.DrawLine(new Vector3(nextNodePos.x, yMin, nextNodePos.z), new Vector3(nextNodePos.x, yMax, nextNodePos.z));
            }
        }

        public void OnDrawGizmos() => DrawGizmos(false);

        public void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}
