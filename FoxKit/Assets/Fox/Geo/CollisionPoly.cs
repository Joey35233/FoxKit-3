using CsSystem = System;
using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Geo
{
    public partial class CollisionPoly
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

            CsSystem.Collections.Generic.List<Vector3> _vertices = vertices;
            for (int i = 0; i < _vertices.Count; i++)
                _vertices[i] = Fox.Math.UnityToFoxVector3(_vertices[i]);

            context.OverrideProperty(nameof(vertices), _vertices);
        }
    }
}
