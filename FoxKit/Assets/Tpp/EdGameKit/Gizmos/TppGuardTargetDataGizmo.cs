using Fox.EdCore;
using Tpp.GameKit;
using UnityEditor;
using UnityEngine;

namespace Tpp.EdGameKit
{
    public static class TppGuardTargetDataGizmo
    {
        private const string GizmoPath = "../Tpp/EdGameKit/Gizmos/TppGuardTargetData.png";

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(TppGuardTargetData guardTargetData, GizmoType gizmoType)
        {
            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            Transform transform = guardTargetData.transform;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : Color.white;

            if (isSelected)
                Gizmos.DrawWireSphere(Vector3.zero, guardTargetData.radius);

            Gizmos.DrawIcon(transform.position, GizmoPath, true, Gizmos.color);
        }
    }
}