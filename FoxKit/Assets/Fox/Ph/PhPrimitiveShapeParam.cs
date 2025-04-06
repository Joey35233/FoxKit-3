using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhPrimitiveShapeParam : Fox.Ph.PhShapeParam
    {
        private static Mesh CylinderMesh;

        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            offset = Fox.Math.FoxToUnityVector3(offset);
            rotation = Fox.Math.FoxToUnityQuaternion(rotation);

            base.OnDeserializeEntity(gameObject, logger);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            context.OverrideProperty("offset", Fox.Math.UnityToFoxVector3(offset));
            context.OverrideProperty("rotation", Fox.Math.FoxToUnityQuaternion(rotation));

            base.OverridePropertiesForExport(context);
        }

        internal override void DrawGizmos()
        {
            Gizmos.color = Color.green;
            switch (type)
            {
                case PhShapeType.BOX:
                    Gizmos.matrix *= Matrix4x4.TRS(offset, rotation, size);
                    Gizmos.DrawWireCube(Vector3.zero, size);
                    break;
                case PhShapeType.SPHERE:
                    Gizmos.matrix *= Matrix4x4.TRS(offset, rotation, size);
                    Gizmos.DrawWireSphere(Vector3.zero, size.magnitude);
                    break;
                case PhShapeType.CYLINDER:
                    Gizmos.matrix *= Matrix4x4.TRS(offset, rotation, size);
                    if (CylinderMesh == null)
                        CylinderMesh = Resources.GetBuiltinResource<Mesh>("Cylinder.fbx");
                    Gizmos.DrawWireMesh(CylinderMesh);
                    break;
                case PhShapeType.CAPSULE:
                    if (CylinderMesh == null)
                        CylinderMesh = Resources.GetBuiltinResource<Mesh>("Cylinder.fbx");
                    
                    Matrix4x4 matrix = Matrix4x4.TRS(offset, rotation, size);
                    
                    float sphereScale = size.z;
                    Gizmos.DrawWireSphere(matrix * Vector3.up, sphereScale);
                    Gizmos.DrawWireSphere(matrix * Vector3.down, sphereScale);
                    
                    Gizmos.matrix *= matrix;
                    Gizmos.DrawWireMesh(CylinderMesh);
                    break;
            }
        }
    }
}