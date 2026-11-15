using Fox.EdCore;
using Fox.Geox;
using Fox.Graphx;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGeox
{
    public static class GeoxTrapAreaPathGizmo
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(GeoxTrapAreaPath path, GizmoType gizmoType)
        {
            if (path.Nodes.Count == 0)
                return;

            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            // Node positions and the height extrusion are in world space.
            Gizmos.matrix = Matrix4x4.identity;
            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : EditorColors.GenericUnselectedColor;

            float minHeight = path.Nodes[0].transform.position.y;
            for (int i = 1; i < path.Nodes.Count; i++)
            {
                float y = path.Nodes[i].transform.position.y;
                if (y < minHeight)
                    minHeight = y;
            }

            float maxHeight = minHeight + path.Height;
            foreach (GraphxSpatialGraphDataEdge edge in path.Edges)
            {
                Vector3 prevNodePos = edge.PrevNode.transform.position;
                Vector3 nextNodePos = edge.NextNode.transform.position;

                Gizmos.DrawLine(new Vector3(prevNodePos.x, minHeight, prevNodePos.z), new Vector3(nextNodePos.x, minHeight, nextNodePos.z));
                Gizmos.DrawLine(new Vector3(prevNodePos.x, maxHeight, prevNodePos.z), new Vector3(nextNodePos.x, maxHeight, nextNodePos.z));

                Gizmos.DrawLine(new Vector3(nextNodePos.x, minHeight, nextNodePos.z), new Vector3(nextNodePos.x, maxHeight, nextNodePos.z));
            }
        }
    }
}
