using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhClothVConstraintParam
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            refA = Fox.Math.FoxToUnityVector3(refA);
            refB = Fox.Math.FoxToUnityVector3(refB);
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            context.OverrideProperty(nameof(refA), Fox.Math.UnityToFoxVector3(refA));
            context.OverrideProperty(nameof(refB), Fox.Math.UnityToFoxVector3(refB));
        }
    }
}
