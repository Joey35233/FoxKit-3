using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Grx
{
    public partial class OccluderEx
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            for (int positionIndex = 0; positionIndex < positions.Length; positionIndex++)
                positions[positionIndex] = Fox.Math.FoxToUnityVector3(positions[positionIndex]);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            Vector3[] _positions = positions;
            for (int i = 0; i < _positions.Length; i++)
                _positions[i] = Fox.Math.UnityToFoxVector3(_positions[i]);

            context.OverrideProperty(nameof(positions), _positions);
        }
    }
}
