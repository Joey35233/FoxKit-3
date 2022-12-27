using UnityEngine;

namespace Fox.Geox
{
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class GeoxPath2Gizmo : MonoBehaviour
    {
        [HideInInspector]
        public Color Color = Color.white;

        [HideInInspector]
        public Vector3 Scale = Vector3.one * 0.1f;

        [HideInInspector]
        public Vector3 ScaleNode = Vector3.one * 0.25f;

        public void OnDrawGizmos()
        {
            if (gameObject.GetComponent<Fox.Core.FoxEntity>()?.Entity is not GeoxPath2 path)
                return;

            for (int nodeIndex = 0; nodeIndex < path.nodes.Count; nodeIndex++)
            {
                var node = path.nodes[nodeIndex].Get();

                Gizmos.DrawWireCube(node.position, ScaleNode);

                for (int edgeIndex = 0; edgeIndex < node.outlinks.Count; edgeIndex++)
                {
                    var edge = node.outlinks[edgeIndex].Entity as GeoxPathEdge;

                    var prevNode = edge.prevNode.Entity as GeoxPathNode;
                    var nextNode = edge.nextNode.Entity as GeoxPathNode;
                    Gizmos.DrawLine(prevNode.position, nextNode.position);
                }
            }
        }
    }
}
