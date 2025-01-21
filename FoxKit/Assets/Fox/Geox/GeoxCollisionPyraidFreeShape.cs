using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Geox
{
    public partial class GeoxCollisionPyraidFreeShape
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
                _points[i] = Fox.Math.UnityToFoxVector3(_points[i]);

            context.OverrideProperty(nameof(points), _points);
        }
    }
}
