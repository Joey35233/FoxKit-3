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
            // The bodies list should be body, param, body, param, etc.
            PhRigidBodyParam mostRecentRigidBody = null;
            for (int i = 0; i < attached.Bodies.Count; i++)
            {
                Entity entry = attached.Bodies[i];
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
                        if (entry is PhShapeParam param)
                        {
                            Gizmos.matrix = Matrix4x4.TRS(mostRecentRigidBody.GetDefaultPosition(), mostRecentRigidBody.GetDefaultRotation(), Vector3.one);
                            param.DrawGizmos();
                        }
                    }
                }
            }
            
            // Draw nothing if invalid
            if (attached.BodyIndices.Count % 2 != 0)
                return;

            for (int i = 0; i < attached.BodyIndices.Count / 2; i++)
            {
                if (attached.Constraints.Count < 1)
                    return;
                
                PhConstraintParam constraint = attached.Constraints[i];
                if (constraint == null)
                    continue;

                // Draw linked bodies - this is not the same as in the EXE because there,
                // all bodies and shapes are registered first, regardless of if they are used or not
                int bodyAIndex = attached.BodyIndices[2 * i];
                if (bodyAIndex < 0)
                    continue;
                
                // This one can be -1 
                int bodyBIndex = attached.BodyIndices[2 * i + 1];
                
                PhRigidBodyParam bodyA = null;
                PhRigidBodyParam bodyB = null;

                // If we were able to prepare a list of just bodies from the earlier bodies loop, we wouldn't need to filter out other things (PhShapeParam).
                // Look for bodyA and (optional) bodyB in single loop
                int realBodyIndex = 0;
                for (int j = 0; j < attached.Bodies.Count; j++)
                {
                    if (attached.Bodies[j] is PhRigidBodyParam body)
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
            }
        }
    }
}