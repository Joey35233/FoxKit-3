using UnityEditor;
using UnityEngine;

namespace Fox.GameCore
{
    public partial class GameObjectLocator : Fox.Core.TransformData
    {
        [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected)]
        static void DrawGizmo(GameObjectLocator obj, GizmoType gizmoType)
        {
            // TODO Consider separate icon depending on GameObject type
            Gizmos.DrawIcon(obj.transform.position, "Fox/GameCore/GameObjectLocator.png");
        }
    }
}