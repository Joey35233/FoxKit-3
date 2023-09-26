using UnityEngine;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphDataEdge
    {
        public void OnDrawGizmos()
        {
            Gizmos.DrawLine((prevNode.Entity as GraphxSpatialGraphDataNode).position, (nextNode.Entity as GraphxSpatialGraphDataNode).position);
        }
    }
}