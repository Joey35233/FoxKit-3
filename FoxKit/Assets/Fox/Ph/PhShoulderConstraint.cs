namespace Fox.Ph
{
    public partial class PhShoulderConstraint : Fox.Ph.PhConstraint
    {
        private PhShoulderConstraintParam shoulderConstraint => param.Get() as PhShoulderConstraintParam;

        protected partial bool Get_limitedFlag() => shoulderConstraint.GetLimitedFlag();
        protected partial void Set_limitedFlag(bool value) => shoulderConstraint.SetLimitedFlag(value);

        protected partial UnityEngine.Vector3 Get_refA() => shoulderConstraint.GetRefA();
        protected partial void Set_refA(UnityEngine.Vector3 value) => shoulderConstraint.SetRefA(value);

        protected partial UnityEngine.Vector3 Get_refB() => shoulderConstraint.GetRefB();
        protected partial void Set_refB(UnityEngine.Vector3 value) => shoulderConstraint.SetRefB(value);

        protected partial float Get_limit() => shoulderConstraint.GetLimit();
        protected partial void Set_limit(float value) => shoulderConstraint.SetLimit(value);

        protected partial bool Get_limitedFlag1() => shoulderConstraint.GetLimitedFlag1();
        protected partial void Set_limitedFlag1(bool value) => shoulderConstraint.SetLimitedFlag1(value);

        protected partial UnityEngine.Vector3 Get_refA1() => shoulderConstraint.GetRefA1();
        protected partial void Set_refA1(UnityEngine.Vector3 value) => shoulderConstraint.SetRefA1(value);

        protected partial UnityEngine.Vector3 Get_refB1() => shoulderConstraint.GetRefB1();
        protected partial void Set_refB1(UnityEngine.Vector3 value) => shoulderConstraint.SetRefB1(value);

        protected partial float Get_limit1() => shoulderConstraint.GetLimit1();
        protected partial void Set_limit1(float value) => shoulderConstraint.SetLimit1(value);
    }
}
