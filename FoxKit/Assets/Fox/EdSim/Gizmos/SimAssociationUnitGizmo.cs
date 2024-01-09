using Fox.Core;
using Fox.Kernel;
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
            var bone = GameObject.Find(unit.boneName.Hash.ToString());
            if (bone == null)
                return;

            Gizmos.matrix = bone.transform.localToWorldMatrix * Matrix4x4.Rotate(unit.offsetRot);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(unit.bodyOffsetPos, 0.025f);
            Gizmos.DrawWireCube(unit.constraintOffsetPos, Vector3.one * 0.025f);
        }
    }
}