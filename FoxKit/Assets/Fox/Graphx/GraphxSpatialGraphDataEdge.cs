using UnityEngine;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphDataEdge
    {
        public void OnDrawGizmos()
        {
            Gizmos.DrawLine((prevNode as GraphxSpatialGraphDataNode).position, (nextNode as GraphxSpatialGraphDataNode).position);
        }
    }
}