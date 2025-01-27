using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace Tpp.Effect
{
    public partial class TppRainFilterInterrupt
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            for (int i = 0; i < planeMatrices.Count; i++)
                planeMatrices[i] = Fox.Math.FoxToUnityMatrix(planeMatrices[i]);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            List<Matrix4x4> _planeMatrices = new(planeMatrices);
            for (int i = 0; i < _planeMatrices.Count; i++)
                _planeMatrices[i] = Fox.Math.UnityToFoxMatrix(_planeMatrices[i]);
            context.OverrideProperty(nameof(planeMatrices), _planeMatrices);
        }

        public void OnDrawGizmos()
        {
            foreach (Matrix4x4 mat in planeMatrices)
            {
                Gizmos.matrix = transform.localToWorldMatrix * mat;

                Gizmos.DrawCube(Vector3.zero, new Vector3(2, 0, 2));
            }
        }
    }
}