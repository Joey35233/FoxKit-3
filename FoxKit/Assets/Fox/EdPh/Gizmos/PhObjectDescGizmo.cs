using System.Collections.Generic;
using Fox.Core;
using Fox;
using Fox.Ph;
using UnityEditor;
using UnityEngine;

namespace Fox.EdPh
{
    public static class PhObjectDescGizmo
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        static void DrawGizmo(PhObjectDesc attached, GizmoType gizmoType)
        {
            PhRigidBodyParam mostRecentRigidBody = null;
            for (int i = 0; i < attached.bodies.Count; i++)
            {
                Entity entry = attached.bodies[i];
                if (entry == null)
                    continue;
                
                if (entry is PhRigidBodyParam body)
                {
                    mostRecentRigidBody = body;
                }
                else
                {
                    if (mostRecentRigidBody != null)
                    {
                        Gizmos.matrix = Matrix4x4.TRS(mostRecentRigidBody.GetDefaultPosition(), mostRecentRigidBody.GetDefaultRotation(), Vector3.one);
                        PhShapeParam param = entry as PhShapeParam;
                        if (param != null)
                            param.DrawGizmos();
                    }
                }
            }

            int constraintIndex = 0;
            for (int i = 0; i < attached.bodyIndices.Count; i += 2)
            {
                PhConstraintParam constraint = attached.constraints[constraintIndex];
                if (constraint == null)
                    continue;

                // Draw linked bodies - this is not the same as in the EXE because there,
                // all bodies and shapes are registered first, regardless of if they are used or not
                int bodyAIndex = attached.bodyIndices[i];
                if (bodyAIndex < 0)
                    continue;
                
                int bodyBIndex = attached.bodyIndices[i + 1];
                PhRigidBodyParam bodyA = null;
                PhRigidBodyParam bodyB = null;

                int realBodyIndex = 0;
                for (int j = 0; j < attached.bodies.Count; j++)
                {
                    if (attached.bodies[j] is PhRigidBodyParam body)
                    {
                        if (realBodyIndex == bodyAIndex)
                            bodyA = body;
                        else if (realBodyIndex == bodyBIndex)
                            bodyB = body;

                        if (bodyA != null && (bodyB != null || bodyBIndex < 0))
                            break;
                        
                        realBodyIndex++;
                    }
                }
                if (bodyA == null)
                    continue;

                // Draw constraint
                Vector3 defaultPos = constraint.GetDefaultPosition();
                Gizmos.matrix = Matrix4x4.Translate(defaultPos);

                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(Vector3.zero, 0.02f);

                Gizmos.DrawLine(Vector3.zero, bodyA.GetDefaultPosition() - defaultPos);
                if (bodyB != null)
                    Gizmos.DrawLine(Vector3.zero, bodyB.GetDefaultPosition() - defaultPos);

                constraint.DrawGizmos();

                constraintIndex++;
            }
        }
    }
}