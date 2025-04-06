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
            Gizmos.matrix *= Matrix4x4.TRS(offset, rotation, Vector3.one);
            
            switch (type)
            {
                case PhShapeType.BOX:
                    if (size.x > 0 && size.y > 0 && size.z > 0)
                    {
                        float radius = size.magnitude;
                        Vector3 scale = new Vector3(radius, radius, radius);
                    
                        Gizmos.DrawWireCube(Vector3.zero, scale);
                    }
                    break;
                case PhShapeType.SPHERE:
                    if (size.x > 0)
                    {
                        float radius = size.x;
                        
                        Gizmos.DrawWireSphere(Vector3.zero, radius);
                    }
                    break;
                case PhShapeType.CYLINDER:
                    if (size.x > 0 && size.y > 0)
                    {
                        if (CylinderMesh == null)
                            CylinderMesh = Resources.GetBuiltinResource<Mesh>("Cylinder.fbx");
                        
                        float radius = size.x;
                        float halfHeight = size.y;
                        Vector3 scale = new Vector3(radius, halfHeight, radius);
                        
                        Gizmos.DrawWireMesh(CylinderMesh, Vector3.zero, Quaternion.identity, scale);
                    }
                    break;
                case PhShapeType.CAPSULE:
                    if (size.x > 0 && size.y > 0)
                    {
                        if (CylinderMesh == null)
                            CylinderMesh = Resources.GetBuiltinResource<Mesh>("Cylinder.fbx");
                        
                        float radius = size.x;
                        float halfHeight = size.y;
                        Vector3 scale = new Vector3(radius, halfHeight, radius);
                        
                        Gizmos.DrawWireSphere(halfHeight * Vector3.up, radius);
                        Gizmos.DrawWireSphere(halfHeight * Vector3.down, radius);
                        
                        Gizmos.DrawWireMesh(CylinderMesh, Vector3.zero, Quaternion.identity, scale);
                    }
                    break;
            }
        }
    }
}