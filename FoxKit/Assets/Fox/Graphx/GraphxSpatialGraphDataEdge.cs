using UnityEngine;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphDataEdge
    {
        public void OnDrawGizmos()
        {
            if (transform.parent.GetComponent<GraphxSpatialGraphData>() is not { } graph)
                return;

            Gizmos.matrix = graph.GetGraphWorldMatrix();

            Gizmos.DrawLine((prevNode as GraphxSpatialGraphDataNode).position,
                (nextNode as GraphxSpatialGraphDataNode).position);
        }
    }
}