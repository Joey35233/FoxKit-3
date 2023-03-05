using UnityEngine;

namespace Fox.GameService
{
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class GsRouteDataGizmo : MonoBehaviour
    {
        [HideInInspector]
        public static readonly Color DefaultColor = new Color(1.0f, (float)100 / System.Byte.MaxValue, (float)43 / System.Byte.MaxValue);
        public static readonly Color SelectedColor = Color.yellow;

        [HideInInspector]
        public Vector3 Scale = Vector3.one * 0.1f;

        [HideInInspector]
        public Vector3 ScaleNode = Vector3.one * 0.25f;

        private void DrawGizmos(bool isSelected)
        {
            if (gameObject.GetComponent<Fox.Core.FoxEntity>()?.Entity is not GsRouteData route)
                return;

            Gizmos.color = isSelected ? SelectedColor : DefaultColor;

            for (int nodeIndex = 0; nodeIndex < route.nodes.Count; nodeIndex++)
            {
                var node = (GsRouteDataNode)route.nodes[nodeIndex].Get();

                Gizmos.DrawWireCube(node.position, ScaleNode);

                for (int edgeIndex = 0; edgeIndex < node.outlinks.Count; edgeIndex++)
                {
                    var edge = node.outlinks[edgeIndex].Entity as GsRouteDataEdge;

                    var prevNode = edge.prevNode.Entity as GsRouteDataNode;
                    var nextNode = edge.nextNode.Entity as GsRouteDataNode;
                    Gizmos.DrawLine(prevNode.position, nextNode.position);
                }
            }
        }

        public void OnDrawGizmos()
        {
            DrawGizmos(false);
        }

        public void OnDrawGizmosSelected()
        {
            DrawGizmos(true);
        }
    }
}
