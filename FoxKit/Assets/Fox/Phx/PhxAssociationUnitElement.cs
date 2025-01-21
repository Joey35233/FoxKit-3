using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Phx
{
    public partial class PhxAssociationUnitElement
    {

        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            bodyOffsetPos = Fox.Math.FoxToUnityVector3(bodyOffsetPos);
            constraintOffsetPos = Fox.Math.FoxToUnityVector3(constraintOffsetPos);
            offsetRot = Fox.Math.FoxToUnityQuaternion(offsetRot);

            base.OnDeserializeEntity(gameObject, logger);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            context.OverrideProperty(nameof(bodyOffsetPos), Fox.Math.UnityToFoxVector3(bodyOffsetPos));
            context.OverrideProperty(nameof(constraintOffsetPos), Fox.Math.UnityToFoxVector3(constraintOffsetPos)); ;
            context.OverrideProperty(nameof(offsetRot), Fox.Math.UnityToFoxQuaternion(offsetRot));

            base.OverridePropertiesForExport(context);
        }
    }
}
