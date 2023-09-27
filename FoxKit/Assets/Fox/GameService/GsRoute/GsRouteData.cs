using Fox.Core.Utils;
using UnityEngine;

namespace Fox.GameService
{
    public partial class GsRouteData : Fox.Graphx.GraphxSpatialGraphData
    {
        private static readonly Color DefaultColor = new Color(1.0f, (float)100 / System.Byte.MaxValue, (float)43 / System.Byte.MaxValue);
        private static readonly Color SelectedColor = Color.yellow;
        private static readonly Vector3 Scale = Vector3.one * 0.1f;
        private static readonly Vector3 ScaleNode = Vector3.one * 0.25f;

        private void DrawGizmos(bool isSelected)
        {
            Gizmos.matrix = this.transform.localToWorldMatrix;
            Gizmos.color = isSelected ? SelectedColor : DefaultColor;

            for (int nodeIndex = 0; nodeIndex < nodes.Count; nodeIndex++)
            {
                var node = (GsRouteDataNode)nodes[nodeIndex].Get();

                Gizmos.DrawWireCube(node.position, ScaleNode);

                for (int edgeIndex = 0; edgeIndex < node.outlinks.Count; edgeIndex++)
                {
                    var edge = node.outlinks[edgeIndex] as GsRouteDataEdge;

                    var prevNode = edge.prevNode as GsRouteDataNode;
                    var nextNode = edge.nextNode as GsRouteDataNode;
                    Gizmos.DrawLine(prevNode.position, nextNode.position);
                }
            }
        }

        public void OnDrawGizmos() => DrawGizmos(false);

        public void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}