using Fox.Core;
using Fox.Kernel;
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
            // TODO: Move this out of gizmo code
            var bodies = new DynamicArray<PhRigidBodyParam>(attached.bodies.Count);
            PhRigidBodyParam mostRecentRigidBody = null;
            for (int i = 0; i < attached.bodies.Count; i++)
            {
                Entity entry = attached.bodies[i];
                if (entry != null && entry is PhRigidBodyParam body)
                {
                    bodies.Add(body);
                    mostRecentRigidBody = body;
                }
                else
                {
                    if (mostRecentRigidBody != null)
                        mostRecentRigidBody.ShapeParam = entry as PhShapeParam;
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
                PhRigidBodyParam bodyA = bodyAIndex < 0 ? null : bodies[bodyAIndex];
                if (bodyA == null)
                    continue;

                int bodyBIndex = attached.bodyIndices[i + 1];
                PhRigidBodyParam bodyB = bodyBIndex < 0 ? null : bodies[bodyBIndex];

                constraint.BodyA = bodyA;
                constraint.BodyB = bodyB;

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