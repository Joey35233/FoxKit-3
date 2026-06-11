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

        private partial float Get_refLimit0() => multiShoulderConstraint == null ? 0.0f : multiShoulderConstraint.GetRefLimit0();
        private partial void Set_refLimit0(float value)
        {
            if (param == null)
                return;

            multiShoulderConstraint.SetRefLimit0(value);
        }

        private partial float Get_refLimit1() => multiShoulderConstraint == null ? 0.0f : multiShoulderConstraint.GetRefLimit1();
        private partial void Set_refLimit1(float value)
        {
            if (param == null)
                return;

            multiShoulderConstraint.SetRefLimit1(value);
        }

        private partial float Get_velocityMax() => multiShoulderConstraint == null ? 0.0f : multiShoulderConstraint.GetVelocityMax();
        private partial void Set_velocityMax(float value)
        {
            if (param == null)
                return;

            multiShoulderConstraint.SetVelocityMax(value);
        }

        private partial float Get_torqueMax() => multiShoulderConstraint == null ? 0.0f : multiShoulderConstraint.GetTorqueMax();
        private partial void Set_torqueMax(float value)
        {
            if (param == null)
                return;

            multiShoulderConstraint.SetTorqueMax(value);
        }

        private partial float Get_velocityRate() => multiShoulderConstraint == null ? 0.0f : multiShoulderConstraint.GetVelocityRate();
        private partial void Set_velocityRate(float value)
        {
            if (param == null)
                return;

            multiShoulderConstraint.SetVelocityRate(value);
        }

        private partial bool Get_isPoweredFlag() => multiShoulderConstraint == null ? false : multiShoulderConstraint.GetIsPoweredFlag();
        private partial void Set_isPoweredFlag(bool value)
        {
            if (param == null)
                return;

            multiShoulderConstraint.SetIsPoweredFlag(value);
        }
    }
}
