namespace Fox.Ph
{
    public partial class PhHingeConstraint : Fox.Ph.PhConstraint
    {
        private PhHingeConstraintParam hingeConstraint => param.Get() as PhHingeConstraintParam;

        protected partial UnityEngine.Quaternion Get_axis() => throw new System.NotImplementedException();
        protected partial void Set_axis(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        protected partial bool Get_limitedFlag() => hingeConstraint.GetLimitedFlag();
        protected partial void Set_limitedFlag(bool value) => hingeConstraint.SetLimitedFlag(value);

        protected partial float Get_limitHi() => hingeConstraint.GetLimitHi();
        protected partial void Set_limitHi(float value) => hingeConstraint.SetLimitHi(value);

        protected partial float Get_limitLo() => hingeConstraint.GetLimitLo();
        protected partial void Set_limitLo(float value) => hingeConstraint.SetLimitLo(value);
    }
}
