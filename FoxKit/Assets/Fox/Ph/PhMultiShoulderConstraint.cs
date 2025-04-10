using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhMultiShoulderConstraint : Fox.Ph.PhConstraint
    {
        private PhMultiShoulderConstraintParam multiShoulderConstraint => param as PhMultiShoulderConstraintParam;

        private partial UnityEngine.Quaternion Get_refVec0() => throw new System.NotImplementedException();
        private partial void Set_refVec0(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial UnityEngine.Quaternion Get_refVec1() => throw new System.NotImplementedException();
        private partial void Set_refVec1(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial float Get_refLimit0() => multiShoulderConstraint.GetRefLimit0();
        private partial void Set_refLimit0(float value) => multiShoulderConstraint.SetRefLimit0(value);

        private partial float Get_refLimit1() => multiShoulderConstraint.GetRefLimit1();
        private partial void Set_refLimit1(float value) => multiShoulderConstraint.SetRefLimit1(value);

        private partial float Get_velocityMax() => multiShoulderConstraint.GetVelocityMax();
        private partial void Set_velocityMax(float value) => multiShoulderConstraint.SetVelocityMax(value);

        private partial float Get_torqueMax() => multiShoulderConstraint.GetTorqueMax();
        private partial void Set_torqueMax(float value) => multiShoulderConstraint.SetTorqueMax(value);

        private partial float Get_velocityRate() => multiShoulderConstraint.GetVelocityRate();
        private partial void Set_velocityRate(float value) => multiShoulderConstraint.SetVelocityRate(value);

        private partial bool Get_isPoweredFlag() => multiShoulderConstraint.GetIsPoweredFlag();
        private partial void Set_isPoweredFlag(bool value) => multiShoulderConstraint.SetIsPoweredFlag(value);
    }
}
