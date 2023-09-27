namespace Fox.Ph
{
    public partial class PhMultiHingeConstraint : Fox.Ph.PhConstraint
    {
        private PhMultiHingeConstraintParam multiHingeConstraint => param.Get() as PhMultiHingeConstraintParam;

        private partial UnityEngine.Quaternion Get_axis() => throw new System.NotImplementedException();
        private partial void Set_axis(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial bool Get_limitedFlag() => multiHingeConstraint.GetLimitedFlag();
        private partial void Set_limitedFlag(bool value) => multiHingeConstraint.SetLimitedFlag(value);

        private partial bool Get_isPoweredFlag() => multiHingeConstraint.GetIsPoweredFlag();
        private partial void Set_isPoweredFlag(bool value) => multiHingeConstraint.SetIsPoweredFlag(value);

        private partial float Get_limitHi() => multiHingeConstraint.GetLimitHi();
        private partial void Set_limitHi(float value) => multiHingeConstraint.SetLimitHi(value);

        private partial float Get_limitLo() => multiHingeConstraint.GetLimitLo();
        private partial void Set_limitLo(float value) => multiHingeConstraint.SetLimitLo(value);

        private partial uint Get_powerControlType() => unchecked((uint)multiHingeConstraint.GetControlType());
        private partial void Set_powerControlType(uint value) => multiHingeConstraint.SetControlType(unchecked((int)value));

        private partial float Get_velocityMax() => multiHingeConstraint.GetVelocityMax();
        private partial void Set_velocityMax(float value) => multiHingeConstraint.SetVelocityMax(value);

        private partial float Get_torqueMax() => multiHingeConstraint.GetTorqueMax();
        private partial void Set_torqueMax(float value) => multiHingeConstraint.SetTorqueMax(value);

        private partial float Get_targetTheta() => multiHingeConstraint.GetTargetTheta();
        private partial void Set_targetTheta(float value) => multiHingeConstraint.SetTargetTheta(value);

        private partial float Get_targetVelocity() => multiHingeConstraint.GetTargetVelocity();
        private partial void Set_targetVelocity(float value) => multiHingeConstraint.SetTargetVelocity(value);

        private partial float Get_velocityRate() => multiHingeConstraint.GetVelocityRate();
        private partial void Set_velocityRate(float value) => multiHingeConstraint.SetVelocityRate(value);
    }
}
