using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Demox
{
    public partial class DemoData
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            cameraTranslation = Fox.Math.FoxToUnityVector3(cameraTranslation);
            cameraRotation = Fox.Math.FoxToUnityQuaternion(cameraRotation);

            cameraStartTranslation = Fox.Math.FoxToUnityVector3(cameraStartTranslation);
            cameraStartRotation = Fox.Math.FoxToUnityQuaternion(cameraStartRotation);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(cameraTranslation), Fox.Math.UnityToFoxVector3(cameraTranslation));
            context.OverrideProperty(nameof(cameraRotation), Fox.Math.UnityToFoxQuaternion(cameraRotation));

            context.OverrideProperty(nameof(cameraStartTranslation), Fox.Math.UnityToFoxVector3(cameraStartTranslation));
            context.OverrideProperty(nameof(cameraStartRotation), Fox.Math.UnityToFoxQuaternion(cameraStartRotation));
        }
    }
}
