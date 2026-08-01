using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhMultiHingeConstraint : Fox.Ph.PhConstraint
    {
        private PhMultiHingeConstraintParam multiHingeConstraint => param as PhMultiHingeConstraintParam;

        private partial UnityEngine.Quaternion axis_Get() => throw new System.NotImplementedException();
        private partial void axis_Set(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial bool limitedFlag_Get() => multiHingeConstraint == null ? false : multiHingeConstraint.GetLimitedFlag();
        private partial void limitedFlag_Set(bool value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetLimitedFlag(value);
        }

        private partial bool isPoweredFlag_Get() => multiHingeConstraint == null ? false : multiHingeConstraint.GetIsPoweredFlag();
        private partial void isPoweredFlag_Set(bool value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetIsPoweredFlag(value);
        }

        private partial float limitHi_Get() => multiHingeConstraint == null ? 0f : multiHingeConstraint.GetLimitHi();
        private partial void limitHi_Set(float value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetLimitHi(value);
        }

        private partial float limitLo_Get() => multiHingeConstraint == null ? 0f : multiHingeConstraint.GetLimitLo();
        private partial void limitLo_Set(float value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetLimitLo(value);
        }

        private partial uint powerControlType_Get() => multiHingeConstraint == null ? 0u : unchecked((uint)multiHingeConstraint.GetControlType());
        private partial void powerControlType_Set(uint value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetControlType(unchecked((int)value));
        }

        private partial float velocityMax_Get() => multiHingeConstraint == null ? 0f : multiHingeConstraint.GetVelocityMax();
        private partial void velocityMax_Set(float value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetVelocityMax(value);
        }

        private partial float torqueMax_Get() => multiHingeConstraint == null ? 0f : multiHingeConstraint.GetTorqueMax();
        private partial void torqueMax_Set(float value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetTorqueMax(value);
        }

        private partial float targetTheta_Get() => multiHingeConstraint == null ? 0f : multiHingeConstraint.GetTargetTheta();
        private partial void targetTheta_Set(float value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetTargetTheta(value);
        }

        private partial float targetVelocity_Get() => multiHingeConstraint == null ? 0f : multiHingeConstraint.GetTargetVelocity();
        private partial void targetVelocity_Set(float value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetTargetVelocity(value);
        }

        private partial float velocityRate_Get() => multiHingeConstraint == null ? 0f : multiHingeConstraint.GetVelocityRate();
        private partial void velocityRate_Set(float value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetVelocityRate(value);
        }
    }
}
