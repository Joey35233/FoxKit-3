using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhPrimitiveShapeParam : Fox.Ph.PhShapeParam
    {
        private static Mesh CylinderMesh;

        public new PhPrimitiveShapeType GetType() => (PhPrimitiveShapeType)type;

        internal override void DrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.matrix *= Matrix4x4.TRS(offset, rotation, Vector3.one);
            
            switch (type)
            {
                case PhShapeType.BOX:
                    if (size.x > 0 && size.y > 0 && size.z > 0)
                    {
                        Vector3 radii = size;
                    
                        Gizmos.DrawWireCube(Vector3.zero, 2*radii);
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