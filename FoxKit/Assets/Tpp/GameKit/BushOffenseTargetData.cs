using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.GameKit
{
    public partial class BushOffenseTargetData
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            direction = Fox.Math.FoxToUnityVector3(direction);
        }
        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(direction), Fox.Math.UnityToFoxVector3(direction));
        }
    }
}
