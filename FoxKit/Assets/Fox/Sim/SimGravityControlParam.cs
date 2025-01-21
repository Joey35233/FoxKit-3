using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Sim
{
    public partial class SimGravityControlParam
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            customGravity = Fox.Math.FoxToUnityVector3(customGravity);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(customGravity), Fox.Math.UnityToFoxVector3(customGravity));
        }
    }
}
