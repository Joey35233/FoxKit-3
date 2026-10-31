using Fox.Core;
using Fox;
using Fox.Sim;
using UnityEditor;
using UnityEngine;

namespace Fox.EdSim
{
    public static class SimAssociationUnitGizmo
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        static void DrawGizmo(SimAssociationUnit unit, GizmoType gizmoType)
        {
            string boneName = unit.boneName;
            if (boneName == null)
                return;
            
            var bone = GameObject.Find(unit.boneName);
            if (bone == null)
                return;

            Gizmos.matrix = bone.transform.localToWorldMatrix * Matrix4x4.Rotate(unit.OffsetRot);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(unit.BodyOffsetPos, 0.025f);
            Gizmos.DrawWireCube(unit.ConstraintOffsetPos, Vector3.one * 0.025f);
        }
    }
}