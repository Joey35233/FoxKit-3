using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace Tpp.Effect
{
    public partial class TppFootPrint
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            for (int i = 0; i < matrices.Count; i++)
                matrices[i] = Fox.Math.FoxToUnityMatrix(matrices[i]);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            List<Matrix4x4> _matrices = new(matrices);
            for (int i = 0; i < _matrices.Count; i++)
                _matrices[i] = Fox.Math.UnityToFoxMatrix(_matrices[i]);
            context.OverrideProperty(nameof(matrices), _matrices);
        }
    }
}
