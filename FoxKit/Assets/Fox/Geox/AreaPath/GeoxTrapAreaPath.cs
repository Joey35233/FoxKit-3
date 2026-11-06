using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using Fox.Geo;
using Fox.Graphx;
using Fox;
using UnityEngine;
using System;
using System.IO;

namespace Fox.Geox
{
    public partial class GeoxTrapAreaPath : Fox.Graphx.GraphxPathData
    {
        public static GeoTriggerTrap Deserialize(GeomHeaderContext header)
        {
            FileStreamReader reader = header.Reader;

            Debug.Assert(header.Type == GeoPrimType.AreaPath);

            GeoTriggerTrap triggerTrap = new GameObject(header.Name.ToString()).AddComponent<GeoTriggerTrap>();
            triggerTrap.SetTransform(TransformEntity.GetDefault());
            //triggerTrap.InitializeGameObject(triggerTrapGameObject);

            triggerTrap.name = header.Name.ToString();
            triggerTrap.enable = true;
            TagUtils.AddEnumTags<GeoTriggerTrap.Tags>(triggerTrap.GroupTags, (ulong)header.GetTags<GeoTriggerTrap.Tags>());

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
                    GeoxTrapAreaPath trapAreaPath = new GameObject($"{header.Name.ToString()}|GeoxTrapAreaPath{i:D4}").AddComponent<GeoxTrapAreaPath>();
                    trapAreaPath.SetTransform(TransformEntity.GetDefault());

                    trapAreaPath.height = yMax - yMin;

                    triggerTrap.AddChild(trapAreaPath);

                    for (int j = 0; j < vertexCount; j++)
                    {
                        reader.Seek(header.GetDataPosition() + vertexDataOffset + (16 * j));

                        GraphxSpatialGraphDataNode node = new GameObject().AddComponent<GraphxSpatialGraphDataNode>();
                        node.SetOwner(trapAreaPath);
                        node.name = $"{node.GetType().Name}{j:D4}";
                        node.Position = reader.ReadPositionF();
                        node.transform.position = node.Position;

                        trapAreaPath.Nodes.Add(node);
                    }

                    GraphxSpatialGraphDataNode prevNode;

                    GraphxSpatialGraphDataNode nextNode;
                    {
                        GraphxSpatialGraphDataEdge loopEdge = new GameObject().AddComponent<GraphxSpatialGraphDataEdge>();
                        loopEdge.SetOwner(trapAreaPath);
                        loopEdge.name = $"{loopEdge.GetType().Name}{0:D4}";

                        prevNode = trapAreaPath.Nodes[(int)(vertexCount - 1)];
                        nextNode = trapAreaPath.Nodes[0];
                        loopEdge.NextNode = nextNode;
                        nextNode.Inlinks.Add(loopEdge.NextNode);
                        loopEdge.PrevNode = prevNode;
                        prevNode.Outlinks.Add(loopEdge.PrevNode);

                        trapAreaPath.Edges.Add(loopEdge);
                    }

                    for (int j = 0; j < vertexCount - 1; j++)
                    {
                        prevNode = trapAreaPath.Nodes[j];
                        nextNode = trapAreaPath.Nodes[j + 1];

                        GraphxSpatialGraphDataEdge edge = new GameObject().AddComponent<GraphxSpatialGraphDataEdge>();
                        edge.SetOwner(trapAreaPath);
                        edge.name = $"{edge.GetType().Name}{j+1:D4}";

                        edge.PrevNode = prevNode;
                        prevNode.Outlinks.Add(edge.PrevNode);
                        edge.NextNode = nextNode;
                        nextNode.Outlinks.Add(edge.NextNode);

                        trapAreaPath.Edges.Add(edge);
                    }
                }
            }

            return triggerTrap;
        }

        public const uint MaxNodeCount = 256;

        private void OnValidate()
        {
            if (Nodes.Count > MaxNodeCount)
            {
                Debug.Log("TrapAreaPath has a max node count of 256 per fox::geox::GeoxTrapAreaFunctor::GetTrapAreaPathInfo.");
                
                for (int i = Nodes.Count - 1; i >= MaxNodeCount; i--)
                    RemoveNode(Nodes[i]);
            }
        }

        private static readonly Color Color = Color.red;
        public override Type GetNodeType() => typeof(GraphxSpatialGraphDataNode);

        public void DrawGizmos(bool isSelected)
        {
            if (Nodes.Count < 0)
                return;
            
            Gizmos.color = isSelected ? Color.white : Color;
            
            float minHeight = Nodes[0].transform.position.y;
            for (int i = 1; i < Nodes.Count; i++)
            {
                float y = Nodes[i].transform.position.y;
                if (y < minHeight)
                    minHeight = y;
            }

            foreach (GraphxSpatialGraphDataEdge edgePtr in Edges)
            {
                GraphxSpatialGraphDataEdge edge = edgePtr;

                Vector3 prevNodePos = edge.PrevNode.transform.position;
                Vector3 nextNodePos = edge.NextNode.transform.position;

                Gizmos.DrawLine(new Vector3(prevNodePos.x, minHeight, prevNodePos.z), new Vector3(nextNodePos.x, minHeight, nextNodePos.z));
                Gizmos.DrawLine(new Vector3(prevNodePos.x, minHeight + height, prevNodePos.z), new Vector3(nextNodePos.x, minHeight + height, nextNodePos.z));

                Gizmos.DrawLine(new Vector3(nextNodePos.x, minHeight, nextNodePos.z), new Vector3(nextNodePos.x, minHeight + height, nextNodePos.z));
            }
        }

        public new void OnDrawGizmos() => DrawGizmos(false);

        public new void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}
