using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace Fox.Geox
{
    public partial class GeoxDynamicPolygon
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            for (int i = 0; i < vertices.Count; i++)
                vertices[i] = Fox.Math.FoxToUnityVector3(vertices[i]);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            List<Vector3> _vertices = new(vertices);
            for (int i = 0; i < _vertices.Count; i++)
                _vertices[i] = Fox.Math.UnityToFoxVector3(_vertices[i]);
            context.OverrideProperty(nameof(vertices), _vertices);
        }
        public override void Reset()
        {
            base.Reset();
            collisionAttributeTags = new List<string>()
            {
                "CHARA",
                "PLAYER",
                "ENEMY",
            };
        }
        public Color UnselectedColor = EditorColors.GenericUnselectedColor;
        public Color SelectedColor = EditorColors.GenericSelectedColor;
        public void DrawPolygonGizmo()
        {
            Gizmos.matrix = gameObject.transform.localToWorldMatrix;

            for (int i = 0; i < vertices.Count - 1; i++)
                Gizmos.DrawLine(vertices[i], vertices[i+1]);
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = UnselectedColor;
            DrawPolygonGizmo();
        }

        public void OnDrawGizmosSelected()
        {
            Gizmos.color = SelectedColor;
            DrawPolygonGizmo();
        }
    }
}
