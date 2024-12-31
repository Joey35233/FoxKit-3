using Fox.Core;
using Fox.Core.Utils;
using Fox;
using UnityEngine;

namespace Fox.Sim
{
    public partial class SimAssociationUnit : Fox.Phx.PhxAssociationUnitElement
    {
        private SimAssociationUnitParam associationUnit => param;

        private partial string Get_boneName() => associationUnit.boneName;
        private partial void Set_boneName(string value) => associationUnit.boneName = value;

        private partial bool Get_initialized() => associationUnit.initialized;
        private partial void Set_initialized(bool value) => associationUnit.SetInitialized(value);

        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            bodyOffsetPos = Fox.Math.FoxToUnityVector3(bodyOffsetPos);
            constraintOffsetPos = Fox.Math.FoxToUnityVector3(constraintOffsetPos);
            offsetRot = Fox.Math.FoxToUnityQuaternion(offsetRot);

            base.OnDeserializeEntity(gameObject, logger);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            context.OverrideProperty("bodyOffsetPos", Math.UnityToFoxVector3(bodyOffsetPos));
            context.OverrideProperty("constraintOffsetPos", Math.UnityToFoxVector3(constraintOffsetPos));
            context.OverrideProperty("offsetRot", Math.FoxToUnityQuaternion(offsetRot));

            base.OverridePropertiesForExport(context);
        }
    }
}
