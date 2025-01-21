using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Grx
{
    public partial class Occluder
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            basePoint0 = Fox.Math.FoxToUnityVector3(basePoint0);
            basePoint1 = Fox.Math.FoxToUnityVector3(basePoint1);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(basePoint0), Fox.Math.UnityToFoxVector3(basePoint0));
            context.OverrideProperty(nameof(basePoint1), Fox.Math.UnityToFoxVector3(basePoint1));
        }
    }
}
