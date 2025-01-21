using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhStiffConstraint : Fox.Ph.PhConstraint
    {
        private PhStiffConstraintParam stiffConstraint => param as PhStiffConstraintParam;

        private partial UnityEngine.Vector3 Get_endurancePower() => stiffConstraint.GetEndurancePower();
        private partial void Set_endurancePower(UnityEngine.Vector3 value) => stiffConstraint.SetEndurancePower(value);

        private partial UnityEngine.Vector3 Get_enduranceTorque() => stiffConstraint.GetEnduranceTorque();
        private partial void Set_enduranceTorque(UnityEngine.Vector3 value) => stiffConstraint.SetEnduranceTorque(value);
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            enduranceTorque = Fox.Math.FoxToUnityVector3(enduranceTorque);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(enduranceTorque), Fox.Math.UnityToFoxVector3(enduranceTorque));
        }
    }
}
