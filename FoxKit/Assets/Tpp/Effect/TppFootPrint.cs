using CsSystem = System;
using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.Effect
{
    public partial class TppFootPrint
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            for (int i = 0; i < matrices.Count; i++)
            {
                matrices[i] = Fox.Math.FoxToUnityMatrix(matrices[i]);
            }
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            var convertedMatrices = new CsSystem.Collections.Generic.List<Matrix4x4>(matrices);
            for (int i = 0; i < convertedMatrices.Count; i++)
            {
                convertedMatrices[i] = Fox.Math.UnityToFoxMatrix(convertedMatrices[i]);
            }

            context.OverrideProperty(nameof(matrices), convertedMatrices);
        }
    }
}
