using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhStiffConstraint : Fox.Ph.PhConstraint
    {
        private PhStiffConstraintParam stiffConstraint => param as PhStiffConstraintParam;

        private partial UnityEngine.Vector3 endurancePower_Get() => stiffConstraint == null ? Vector3.zero : stiffConstraint.GetEndurancePower();
        private partial void endurancePower_Set(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;
            
            stiffConstraint.SetEndurancePower(value);
        }

        private partial UnityEngine.Vector3 enduranceTorque_Get() => stiffConstraint == null ? Vector3.zero : stiffConstraint.GetEnduranceTorque();
        private partial void enduranceTorque_Set(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;
            
            stiffConstraint.SetEnduranceTorque(value);
        }
    }
}
