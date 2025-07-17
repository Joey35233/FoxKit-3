using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Phx
{
    public partial class PhxAssociationUnitElement
    {

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            
            bodyOffsetPos = Fox.Math.FoxToUnityVector3(bodyOffsetPos);
            constraintOffsetPos = Fox.Math.FoxToUnityVector3(constraintOffsetPos);
            offsetRot = Fox.Math.FoxToUnityQuaternion(offsetRot);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);
            
            context.OverrideProperty(nameof(bodyOffsetPos), Fox.Math.UnityToFoxVector3(bodyOffsetPos));
            context.OverrideProperty(nameof(constraintOffsetPos), Fox.Math.UnityToFoxVector3(constraintOffsetPos)); ;
            context.OverrideProperty(nameof(offsetRot), Fox.Math.UnityToFoxQuaternion(offsetRot));
        }
    }
}
