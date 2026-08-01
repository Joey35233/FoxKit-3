using Fox.EdCore;
using Fox.Sdx;
using UnityEditor;
using UnityEngine;

namespace Fox.EdSdx
{
    public static class SoundSourceGizmo
    {
        private const string GizmoPath = "../Fox/EdSdx/Gizmos/SoundSource.png";

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(SoundSource soundSource, GizmoType gizmoType)
        {
            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            Transform transform = soundSource.transform;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : EditorColors.GenericUnselectedColor;

            if (isSelected)
                Gizmos.DrawWireSphere(Vector3.zero, soundSource.playRange);

            Gizmos.DrawIcon(transform.position, GizmoPath, true, Gizmos.color);
        }
    }
}
