using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Core
{
    public partial class CapsuleShape
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            point0 = Fox.Math.FoxToUnityVector3(point0);
            point1 = Fox.Math.FoxToUnityVector3(point1);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(point0), Fox.Math.UnityToFoxVector3(point0));
            context.OverrideProperty(nameof(point1), Fox.Math.UnityToFoxVector3(point1));
        }
    }
}
