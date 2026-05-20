using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.Effect
{
    public partial class TppLensFlareRoot
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            (lightPositionX, lightPositionY, _) = Fox.Math.FoxToUnityVectorComponents(new Vector3(lightPositionX, lightPositionY, 0));
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            
            (float _lightPositionX, float _lightPositionY, _) = Fox.Math.UnityToFoxVectorComponents(new Vector3(lightPositionX, lightPositionY, 0));
            context.OverrideProperty(nameof(lightPositionX), _lightPositionX);
            context.OverrideProperty(nameof(lightPositionY), _lightPositionY);
            
            context.OverrideProperty(nameof(lightPositionX), -lightPositionX);
        }
    }
}
