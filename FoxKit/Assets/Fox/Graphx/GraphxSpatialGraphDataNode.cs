using UnityEngine;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphDataNode
    {
        private static readonly Vector3 Scale = Vector3.one * 0.25f;

        public void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(position, Scale);
        }
    }
}