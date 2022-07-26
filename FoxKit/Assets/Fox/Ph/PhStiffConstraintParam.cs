using Fox.Core;

namespace Fox.Ph
{
    public partial class PhStiffConstraintParam : Fox.Ph.PhConstraintParam
    {
        internal UnityEngine.Vector3 GetEndurancePower() => endurancePower;
        internal void SetEndurancePower(UnityEngine.Vector3 value) => endurancePower = value;

        internal UnityEngine.Vector3 GetEnduranceTorque() => enduranceTorque;
        internal void SetEnduranceTorque(UnityEngine.Vector3 value) => enduranceTorque = value;
    }
}
