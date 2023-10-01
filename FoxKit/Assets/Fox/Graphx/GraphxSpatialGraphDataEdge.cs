using UnityEngine;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphDataEdge
    {
        public void OnDrawGizmos()
        {
            Matrix4x4 mat = transform.parent.localToWorldMatrix;

            Gizmos.DrawLine(mat.MultiplyPoint((prevNode as GraphxSpatialGraphDataNode).position),
                mat.MultiplyPoint((nextNode as GraphxSpatialGraphDataNode).position));
        }
    }
}