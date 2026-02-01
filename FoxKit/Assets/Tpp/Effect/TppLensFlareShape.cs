using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.Effect
{
    public partial class TppLensFlareShape
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            (baseOffsetX, baseOffsetY, _) = Fox.Math.FoxToUnityVectorComponents(new Vector3(baseOffsetX, baseOffsetY, 0));
            (screenSpaceRotSpeedX, screenSpaceRotSpeedY, _) = Fox.Math.FoxToUnityVectorComponents(new Vector3(screenSpaceRotSpeedX, screenSpaceRotSpeedY, 0));
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);
            
            (float _baseOffsetX, float _baseOffsetY, _) = Fox.Math.UnityToFoxVectorComponents(new Vector3(baseOffsetX, baseOffsetY, 0));
            context.OverrideProperty(nameof(baseOffsetX), _baseOffsetX);
            context.OverrideProperty(nameof(baseOffsetY), _baseOffsetY);
            
            (float _screenSpaceRotSpeedX, float _screenSpaceRotSpeedY, _) = Fox.Math.UnityToFoxVectorComponents(new Vector3(screenSpaceRotSpeedX, screenSpaceRotSpeedY, 0));
            context.OverrideProperty(nameof(screenSpaceRotSpeedX), _screenSpaceRotSpeedX);
            context.OverrideProperty(nameof(screenSpaceRotSpeedY), _screenSpaceRotSpeedY);
        }
    }
}
