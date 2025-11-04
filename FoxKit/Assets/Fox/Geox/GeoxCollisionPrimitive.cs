using Fox.Core;
using System.Collections.Generic;
using UnityEngine;

namespace Fox.Geox
{
    public partial class GeoxCollisionPrimitive
    {
        public override void Reset()
        {
            base.Reset();
            collisionMaterial = "MTR_NONE_A";
            collisionAttributeNames = new List<string>()
            {
                "CHARA",
                "PLAYER",
                "ENEMY",
            };
        }
        public Color UnselectedColor = EditorColors.GenericUnselectedColor;
        public Color SelectedColor = EditorColors.GenericSelectedColor;
        public void DrawPrimitiveGizmo()
        {
            Gizmos.matrix = gameObject.transform.localToWorldMatrix;

            switch (primitiveType)
            {
                case CollisionPrimitive_PrimType.PRIM_CIRCLE:
                    Gizmos.DrawCube(Vector3.zero,Vector3.one);
                    break;
                case CollisionPrimitive_PrimType.PRIM_RECT:
                    Gizmos.DrawSphere(Vector3.zero, 1);
                    break;
            }
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = UnselectedColor;
            DrawPrimitiveGizmo();
        }

        public void OnDrawGizmosSelected()
        {
            Gizmos.color = SelectedColor;
            DrawPrimitiveGizmo();
        }
    }
}
