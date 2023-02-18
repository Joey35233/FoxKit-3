namespace Fox.Ph
{
    public partial class PhMultiShoulderConstraint : Fox.Ph.PhConstraint
    {
        private PhMultiShoulderConstraintParam multiShoulderConstraint => param.Get() as PhMultiShoulderConstraintParam;

        protected partial UnityEngine.Quaternion Get_refVec0() => throw new System.NotImplementedException();
        protected partial void Set_refVec0(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        protected partial UnityEngine.Quaternion Get_refVec1() => throw new System.NotImplementedException();
        protected partial void Set_refVec1(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        protected partial float Get_refLimit0() => multiShoulderConstraint.GetRefLimit0();
        protected partial void Set_refLimit0(float value) => multiShoulderConstraint.SetRefLimit0(value);

        protected partial float Get_refLimit1() => multiShoulderConstraint.GetRefLimit1();
        protected partial void Set_refLimit1(float value) => multiShoulderConstraint.SetRefLimit1(value);

        protected partial float Get_velocityMax() => multiShoulderConstraint.GetVelocityMax();
        protected partial void Set_velocityMax(float value) => multiShoulderConstraint.SetVelocityMax(value);

        protected partial float Get_torqueMax() => multiShoulderConstraint.GetTorqueMax();
        protected partial void Set_torqueMax(float value) => multiShoulderConstraint.SetTorqueMax(value);

        protected partial float Get_velocityRate() => multiShoulderConstraint.GetVelocityRate();
        protected partial void Set_velocityRate(float value) => multiShoulderConstraint.SetVelocityRate(value);

        protected partial bool Get_isPoweredFlag() => multiShoulderConstraint.GetIsPoweredFlag();
        protected partial void Set_isPoweredFlag(bool value) => multiShoulderConstraint.SetIsPoweredFlag(value);
    }
}
