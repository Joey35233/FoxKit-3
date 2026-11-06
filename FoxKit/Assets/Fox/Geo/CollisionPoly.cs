using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace Fox.Geo
{
    public partial class CollisionPoly
    {
        public IReadOnlyList<Vector3> Vertices => vertices;

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            for (int i = 0; i < vertices.Count; i++)
                vertices[i] = Fox.Math.FoxToUnityVector3(vertices[i]);
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            List<Vector3> _vertices = new(vertices);
            for (int i = 0; i < _vertices.Count; i++)
                _vertices[i] = Fox.Math.UnityToFoxVector3(_vertices[i]);
            context.OverrideProperty(nameof(vertices), _vertices);
        }
    }
}
