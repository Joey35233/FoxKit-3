using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Core
{
    public partial class CapsuleShape
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            point0 = Fox.Math.FoxToUnityVector3(point0);
            point1 = Fox.Math.FoxToUnityVector3(point1);
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            context.OverrideProperty(nameof(point0), Fox.Math.UnityToFoxVector3(point0));
            context.OverrideProperty(nameof(point1), Fox.Math.UnityToFoxVector3(point1));
        }
    }
}
