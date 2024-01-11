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
            offset = Fox.Kernel.Math.FoxToUnityVector3(offset);
            rotation = Fox.Kernel.Math.FoxToUnityQuaternion(rotation);

            base.OnDeserializeEntity(gameObject, logger);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            context.OverrideProperty("offset", Kernel.Math.UnityToFoxVector3(offset));
            context.OverrideProperty("rotation", Kernel.Math.FoxToUnityQuaternion(rotation));

            base.OverridePropertiesForExport(context);
        }

        internal override void DrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.matrix = Gizmos.matrix *= Matrix4x4.TRS(offset, rotation, size);
            switch (type)
            {
                case PhShapeType.BOX:
                    Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
                    break;
                case PhShapeType.SPHERE:
                    Gizmos.DrawWireSphere(Vector3.zero, 1.0f);
                    break;
                case PhShapeType.CAPSULE:
                    if (CylinderMesh == null)
                        CylinderMesh = Resources.GetBuiltinResource<Mesh>("Cylinder.fbx");
                    Gizmos.DrawWireMesh(CylinderMesh);
                    break;
            }
        }
    }
}