using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Grx
{
    public partial class Occluder
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            basePoint0 = Fox.Math.FoxToUnityVector3(basePoint0);
            basePoint1 = Fox.Math.FoxToUnityVector3(basePoint1);
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            context.OverrideProperty(nameof(basePoint0), Fox.Math.UnityToFoxVector3(basePoint0));
            context.OverrideProperty(nameof(basePoint1), Fox.Math.UnityToFoxVector3(basePoint1));
        }
    }
}
