using Fox.GameCore;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGameCore
{
    public static class GameObjectLocatorGizmo
    {
        private const string GizmoPath = "../Fox/EdGameCore/Gizmos/GameObjectLocator.png";

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(GameObjectLocator locator, GizmoType gizmoType)
        {
            // TODO Consider separate icon depending on GameObject type
            Gizmos.DrawIcon(locator.transform.position, GizmoPath);
        }
    }
}