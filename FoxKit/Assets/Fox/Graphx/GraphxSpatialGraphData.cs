using Fox.Core;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphData
    {
        public Matrix4x4 GetGraphWorldMatrix() => Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);

        public Vector3 GetGraphWorldPosition(Vector3 pos) => GetGraphWorldMatrix().MultiplyPoint(pos);

        public int IndexOf(GraphxSpatialGraphDataNode node)
        {
            return this.nodes.IndexOf(node);
        }

        public GraphxSpatialGraphDataNode GetGraphNode(int index)
        {
            return this.nodes[index];
        }

        private static readonly Color Color = Color.white;
        private static readonly Vector3 Scale = Vector3.one * 0.1f;
        private static readonly Vector3 ScaleNode = Vector3.one * 0.25f;

        public void OnDrawGizmos()
        {
            Gizmos.matrix = Matrix4x4.identity;

            for (int nodeIndex = 0; nodeIndex < nodes.Count; nodeIndex++)
            {
                Graphx.GraphxSpatialGraphDataNode node = nodes[nodeIndex];

                Gizmos.color = EditorColors.PlayerUtilityColor;
                Gizmos.DrawWireCube(this.transform.position + node.position, ScaleNode);

                for (int edgeIndex = 0; edgeIndex < node.outlinks.Count; edgeIndex++)
                {
                    var edge = node.outlinks[edgeIndex] as GraphxSpatialGraphDataEdge;

                    var prevNode = edge.prevNode as GraphxSpatialGraphDataNode;
                    var nextNode = edge.nextNode as GraphxSpatialGraphDataNode;

                    Vector3 prevNodePos = this.transform.TransformPoint(prevNode.position);
                    Vector3 nextNodePos = this.transform.TransformPoint(nextNode.position);

                    Gizmos.DrawLine(prevNodePos, nextNodePos);
                }
            }
        }
    }
}