using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhMultiHingeConstraint : Fox.Ph.PhConstraint
    {
        private PhMultiHingeConstraintParam multiHingeConstraint => param as PhMultiHingeConstraintParam;

        private partial UnityEngine.Quaternion Get_axis() => throw new System.NotImplementedException();
        private partial void Set_axis(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial bool Get_limitedFlag() => multiHingeConstraint == null ? false : multiHingeConstraint.GetLimitedFlag();
        private partial void Set_limitedFlag(bool value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetLimitedFlag(value);
        }

        private partial bool Get_isPoweredFlag() => multiHingeConstraint == null ? false : multiHingeConstraint.GetIsPoweredFlag();
        private partial void Set_isPoweredFlag(bool value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetIsPoweredFlag(value);
        }

        private partial float Get_limitHi() => multiHingeConstraint == null ? 0f : multiHingeConstraint.GetLimitHi();
        private partial void Set_limitHi(float value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetLimitHi(value);
        }

        private partial float Get_limitLo() => multiHingeConstraint == null ? 0f : multiHingeConstraint.GetLimitLo();
        private partial void Set_limitLo(float value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetLimitLo(value);
        }

        private partial uint Get_powerControlType() => multiHingeConstraint == null ? 0u : unchecked((uint)multiHingeConstraint.GetControlType());
        private partial void Set_powerControlType(uint value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetControlType(unchecked((int)value));
        }

        private partial float Get_velocityMax() => multiHingeConstraint == null ? 0f : multiHingeConstraint.GetVelocityMax();
        private partial void Set_velocityMax(float value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetVelocityMax(value);
        }

        private partial float Get_torqueMax() => multiHingeConstraint == null ? 0f : multiHingeConstraint.GetTorqueMax();
        private partial void Set_torqueMax(float value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetTorqueMax(value);
        }

        private partial float Get_targetTheta() => multiHingeConstraint == null ? 0f : multiHingeConstraint.GetTargetTheta();
        private partial void Set_targetTheta(float value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetTargetTheta(value);
        }

        private partial float Get_targetVelocity() => multiHingeConstraint == null ? 0f : multiHingeConstraint.GetTargetVelocity();
        private partial void Set_targetVelocity(float value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetTargetVelocity(value);
        }

        private partial float Get_velocityRate() => multiHingeConstraint == null ? 0f : multiHingeConstraint.GetVelocityRate();
        private partial void Set_velocityRate(float value)
        {
            if (param == null)
                return;

            multiHingeConstraint.SetVelocityRate(value);
        }
    }
}
