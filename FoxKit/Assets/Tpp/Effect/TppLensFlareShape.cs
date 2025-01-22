using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.Effect
{
    public partial class TppLensFlareShape
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            baseOffsetX = -baseOffsetX;
            screenSpaceRotSpeedX = -screenSpaceRotSpeedX;
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(baseOffsetX), -baseOffsetX);
            context.OverrideProperty(nameof(screenSpaceRotSpeedX), -screenSpaceRotSpeedX);
        }
    }
}
