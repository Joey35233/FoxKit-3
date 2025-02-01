using Fox.Core;
using Fox.Core.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Fox.Geox
{
    public partial class GeoxCollisionFreeShape
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            for (int i = 0; i < points.Length; i++)
                points[i] = Fox.Math.FoxToUnityVector3(points[i]);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            Vector3[] _points = points;
            for (int i = 0; i < _points.Length; i++)
                _points[i]=Fox.Math.UnityToFoxVector3(_points[i]);

            context.OverrideProperty(nameof(points), _points);
        }
        public override void Reset()
        {
            base.Reset();
            points[0] = new Vector3(0.5f, 0.5f, 0.5f);
            points[1] = new Vector3(0.5f, 0.5f, -0.5f);
            points[2] = new Vector3(-0.5f, 0.5f, -0.5f);
            points[3] = new Vector3(-0.5f, 0.5f, 0.5f);
            points[4] = new Vector3(0.5f, -0.5f, 0.5f);
            points[5] = new Vector3(0.5f, -0.5f, -0.5f);
            points[6] = new Vector3(-0.5f, -0.5f, -0.5f);
            points[7] = new Vector3(-0.5f, -0.5f, 0.5f);
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
        public void DrawGizmo()
        {
            Gizmos.matrix = gameObject.transform.localToWorldMatrix;

            Gizmos.DrawLine(points[0], points[1]);
            Gizmos.DrawLine(points[0], points[3]);
            Gizmos.DrawLine(points[0], points[4]);
            Gizmos.DrawLine(points[1], points[0]);
            Gizmos.DrawLine(points[1], points[2]);
            Gizmos.DrawLine(points[1], points[5]);
            Gizmos.DrawLine(points[2], points[1]);
            Gizmos.DrawLine(points[2], points[3]);
            Gizmos.DrawLine(points[2], points[6]);
            Gizmos.DrawLine(points[3], points[3]);
            Gizmos.DrawLine(points[3], points[7]);
            Gizmos.DrawLine(points[4], points[5]);
            Gizmos.DrawLine(points[4], points[7]);
            Gizmos.DrawLine(points[5], points[6]);
            Gizmos.DrawLine(points[6], points[7]);
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = UnselectedColor;
            DrawGizmo();
        }

        public void OnDrawGizmosSelected()
        {
            Gizmos.color = SelectedColor;
            DrawGizmo();
        }
    }
}
