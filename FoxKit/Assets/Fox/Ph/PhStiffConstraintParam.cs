using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhStiffConstraintParam : Fox.Ph.PhConstraintParam
    {
        internal UnityEngine.Vector3 GetEndurancePower() => endurancePower;
        internal void SetEndurancePower(UnityEngine.Vector3 value) => endurancePower = value;

        internal UnityEngine.Vector3 GetEnduranceTorque() => enduranceTorque;
        
        internal void SetEnduranceTorque(UnityEngine.Vector3 value) => enduranceTorque = value; 
        
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            enduranceTorque = Fox.Math.FoxToUnityVector3(enduranceTorque);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(enduranceTorque), Fox.Math.UnityToFoxVector3(enduranceTorque));
        }
    }
}
