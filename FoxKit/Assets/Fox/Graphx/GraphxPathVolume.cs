using System;
using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Graphx
{
    public partial class GraphxPathVolume : Fox.Graphx.GraphxPathData
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            topPos = Fox.Math.FoxToUnityVector3(topPos);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(topPos), Fox.Math.UnityToFoxVector3(topPos));
        }
    }
}
