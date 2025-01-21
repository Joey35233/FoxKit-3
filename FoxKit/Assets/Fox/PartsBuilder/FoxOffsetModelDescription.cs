using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.PartsBuilder
{
    public partial class FoxOffsetModelDescription
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            offsetTranslation = Fox.Math.FoxToUnityVector3(offsetTranslation);
            offsetRotQuat = Fox.Math.FoxToUnityQuaternion(offsetRotQuat);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(offsetTranslation), Fox.Math.UnityToFoxVector3(offsetTranslation));
            context.OverrideProperty(nameof(offsetRotQuat), Fox.Math.UnityToFoxQuaternion(offsetRotQuat));
        }
    }
}
