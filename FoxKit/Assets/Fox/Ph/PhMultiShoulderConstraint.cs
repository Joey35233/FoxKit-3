using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhMultiShoulderConstraint : Fox.Ph.PhConstraint
    {
        private PhMultiShoulderConstraintParam multiShoulderConstraint => param as PhMultiShoulderConstraintParam;

        private partial UnityEngine.Quaternion refVec0_Get() => throw new System.NotImplementedException();
        private partial void refVec0_Set(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial UnityEngine.Quaternion refVec1_Get() => throw new System.NotImplementedException();
        private partial void refVec1_Set(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial float refLimit0_Get() => multiShoulderConstraint == null ? 0.0f : multiShoulderConstraint.GetRefLimit0();
        private partial void refLimit0_Set(float value)
        {
            if (param == null)
                return;

            multiShoulderConstraint.SetRefLimit0(value);
        }

        private partial float refLimit1_Get() => multiShoulderConstraint == null ? 0.0f : multiShoulderConstraint.GetRefLimit1();
        private partial void refLimit1_Set(float value)
        {
            if (param == null)
                return;

            multiShoulderConstraint.SetRefLimit1(value);
        }

        private partial float velocityMax_Get() => multiShoulderConstraint == null ? 0.0f : multiShoulderConstraint.GetVelocityMax();
        private partial void velocityMax_Set(float value)
        {
            if (param == null)
                return;

            multiShoulderConstraint.SetVelocityMax(value);
        }

        private partial float torqueMax_Get() => multiShoulderConstraint == null ? 0.0f : multiShoulderConstraint.GetTorqueMax();
        private partial void torqueMax_Set(float value)
        {
            if (param == null)
                return;

            multiShoulderConstraint.SetTorqueMax(value);
        }

        private partial float velocityRate_Get() => multiShoulderConstraint == null ? 0.0f : multiShoulderConstraint.GetVelocityRate();
        private partial void velocityRate_Set(float value)
        {
            if (param == null)
                return;

            multiShoulderConstraint.SetVelocityRate(value);
        }

        private partial bool isPoweredFlag_Get() => multiShoulderConstraint == null ? false : multiShoulderConstraint.GetIsPoweredFlag();
        private partial void isPoweredFlag_Set(bool value)
        {
            if (param == null)
                return;

            multiShoulderConstraint.SetIsPoweredFlag(value);
        }
    }
}
