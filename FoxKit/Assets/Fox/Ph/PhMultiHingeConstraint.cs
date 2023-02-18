namespace Fox.Ph
{
    public partial class PhMultiHingeConstraint : Fox.Ph.PhConstraint
    {
        private PhMultiHingeConstraintParam multiHingeConstraint => param.Get() as PhMultiHingeConstraintParam;

        protected partial UnityEngine.Quaternion Get_axis() => throw new System.NotImplementedException();
        protected partial void Set_axis(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        protected partial bool Get_limitedFlag() => multiHingeConstraint.GetLimitedFlag();
        protected partial void Set_limitedFlag(bool value) => multiHingeConstraint.SetLimitedFlag(value);

        protected partial bool Get_isPoweredFlag() => multiHingeConstraint.GetIsPoweredFlag();
        protected partial void Set_isPoweredFlag(bool value) => multiHingeConstraint.SetIsPoweredFlag(value);

        protected partial float Get_limitHi() => multiHingeConstraint.GetLimitHi();
        protected partial void Set_limitHi(float value) => multiHingeConstraint.SetLimitHi(value);

        protected partial float Get_limitLo() => multiHingeConstraint.GetLimitLo();
        protected partial void Set_limitLo(float value) => multiHingeConstraint.SetLimitLo(value);

        protected partial uint Get_powerControlType() => unchecked((uint)multiHingeConstraint.GetControlType());
        protected partial void Set_powerControlType(uint value) => multiHingeConstraint.SetControlType(unchecked((int)value));

        protected partial float Get_velocityMax() => multiHingeConstraint.GetVelocityMax();
        protected partial void Set_velocityMax(float value) => multiHingeConstraint.SetVelocityMax(value);

        protected partial float Get_torqueMax() => multiHingeConstraint.GetTorqueMax();
        protected partial void Set_torqueMax(float value) => multiHingeConstraint.SetTorqueMax(value);

        protected partial float Get_targetTheta() => multiHingeConstraint.GetTargetTheta();
        protected partial void Set_targetTheta(float value) => multiHingeConstraint.SetTargetTheta(value);

        protected partial float Get_targetVelocity() => multiHingeConstraint.GetTargetVelocity();
        protected partial void Set_targetVelocity(float value) => multiHingeConstraint.SetTargetVelocity(value);

        protected partial float Get_velocityRate() => multiHingeConstraint.GetVelocityRate();
        protected partial void Set_velocityRate(float value) => multiHingeConstraint.SetVelocityRate(value);
    }
}
