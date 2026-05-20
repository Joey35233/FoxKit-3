using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Demo
{
    public partial class DemoControlCharacterDesc
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            translation = Fox.Math.FoxToUnityVector3(translation);
            rotation = Fox.Math.FoxToUnityQuaternion(rotation);

            startTranslation = Fox.Math.FoxToUnityVector3(startTranslation);
            startRotation = Fox.Math.FoxToUnityQuaternion(startRotation);
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            context.OverrideProperty(nameof(translation), Fox.Math.UnityToFoxVector3(translation));
            context.OverrideProperty(nameof(rotation), Fox.Math.UnityToFoxQuaternion(rotation));

            context.OverrideProperty(nameof(startTranslation), Fox.Math.UnityToFoxVector3(startTranslation));
            context.OverrideProperty(nameof(startRotation), Fox.Math.UnityToFoxQuaternion(startRotation));
        }
    }
}
