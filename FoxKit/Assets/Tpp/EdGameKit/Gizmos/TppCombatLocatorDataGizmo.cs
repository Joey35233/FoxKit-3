using Fox.EdCore;
using Tpp.GameKit;
using UnityEditor;
using UnityEngine;

namespace Tpp.EdGameKit
{
    public static class TppCombatLocatorDataGizmo
    {
        private const string GizmoPath = "../Tpp/EdGameKit/Gizmos/TppCombatLocatorData.png";

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(TppCombatLocatorData locatorData, GizmoType gizmoType)
        {
            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            Transform transform = locatorData.transform;
            Gizmos.matrix = transform.localToWorldMatrix;

            if (isSelected)
            {
                Gizmos.color = EditorColors.HostileColor;
                Gizmos.DrawWireSphere(Vector3.zero, locatorData.radius);

                Gizmos.color = EditorColors.HostileColorDeselected;
                Gizmos.DrawWireSphere(Vector3.zero, locatorData.lostSearchRadius);
            }

            Gizmos.color = isSelected ? EditorColors.HostileColor : Color.white;
            Gizmos.DrawIcon(transform.position, GizmoPath, true, Gizmos.color);
        }
    }
}
