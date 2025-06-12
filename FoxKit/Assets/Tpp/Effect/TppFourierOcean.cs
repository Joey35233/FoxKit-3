using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.Effect
{
    public partial class TppFourierOcean
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            (windDirectionX, _, windDirectionZ) = Fox.Math.FoxToUnityVectorComponents(new Vector3(windDirectionX, 0, windDirectionZ));
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            (float _windDirectionX, _, float _windDirectionZ) = Fox.Math.UnityToFoxVectorComponents(new Vector3(windDirectionX, 0, windDirectionZ));
            context.OverrideProperty(nameof(windDirectionX), _windDirectionX);
            context.OverrideProperty(nameof(windDirectionZ), _windDirectionZ);
        }
    }
}
