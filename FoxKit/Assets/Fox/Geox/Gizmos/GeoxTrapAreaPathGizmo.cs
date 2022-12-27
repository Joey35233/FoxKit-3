using Fox.Core;
using Fox.Graphx;
using UnityEngine;

namespace Fox.Geox
{
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class GeoxTrapAreaPathGizmo : MonoBehaviour
    {
        [HideInInspector]
        public Color Color = Color.red;

        public void DrawGizmos(bool isSelected)
        {
            if (gameObject.GetComponent<FoxEntity>()?.Entity is not GeoxTrapAreaPath trapPath)
                return;

            if (isSelected)
                Gizmos.color = Color.white;
            else
                Gizmos.color = Color;

            foreach (var edgePtr in trapPath.edges)
            {
                GraphxSpatialGraphDataEdge edge = edgePtr.Get();
                GraphxSpatialGraphDataNode prevNode = edge.prevNode.Entity as GraphxSpatialGraphDataNode;
                GraphxSpatialGraphDataNode nextNode = edge.nextNode.Entity as GraphxSpatialGraphDataNode;

                float yMin = transform.position.y;
                float yMax = yMin + trapPath.height;

                Gizmos.DrawLine(new Vector3(prevNode.position.x, yMin, prevNode.position.z), new Vector3(nextNode.position.x, yMin, nextNode.position.z));
                Gizmos.DrawLine(new Vector3(prevNode.position.x, yMax, prevNode.position.z), new Vector3(nextNode.position.x, yMax, nextNode.position.z));

                Gizmos.DrawLine(new Vector3(nextNode.position.x, yMin, nextNode.position.z), new Vector3(nextNode.position.x, yMax, nextNode.position.z));
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
