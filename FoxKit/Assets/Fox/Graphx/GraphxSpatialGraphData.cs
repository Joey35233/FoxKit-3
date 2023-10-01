using UnityEngine;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphData
    {
        public Matrix4x4 GetGraphWorldMatrix() => Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);

        public Vector3 GetGraphWorldPosition(Vector3 pos) => GetGraphWorldMatrix().MultiplyPoint(pos);
    }
}