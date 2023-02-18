namespace Fox.Ph
{
    public partial class PhStiffConstraint : Fox.Ph.PhConstraint
    {
        private PhStiffConstraintParam stiffConstraint => param.Get() as PhStiffConstraintParam;

        protected partial UnityEngine.Vector3 Get_endurancePower() => stiffConstraint.GetEndurancePower();
        protected partial void Set_endurancePower(UnityEngine.Vector3 value) => stiffConstraint.SetEndurancePower(value);

        protected partial UnityEngine.Vector3 Get_enduranceTorque() => stiffConstraint.GetEnduranceTorque();
        protected partial void Set_enduranceTorque(UnityEngine.Vector3 value) => stiffConstraint.SetEnduranceTorque(value);
    }
}
