using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Tactical
{
    public partial class GkTacticalActionWaypoint
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            position = Fox.Math.FoxToUnityVector3(position);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(position), Fox.Math.UnityToFoxVector3(position));
        }
    }
}
