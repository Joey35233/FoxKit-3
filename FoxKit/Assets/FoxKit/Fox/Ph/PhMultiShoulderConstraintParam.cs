using Fox.Core;

namespace Fox.Ph
{
    public partial class PhMultiShoulderConstraintParam : Fox.Ph.PhConstraintParam
    {
        internal UnityEngine.Vector3 GetRefVec0() => refVec0;
        internal void SetRefVec0(UnityEngine.Vector3 value) { refVec0 = value; }

        internal UnityEngine.Vector3 GetRefVec1() => refVec1;
        internal void SetRefVec1(UnityEngine.Vector3 value) { refVec1 = value; }

        internal float GetRefLimit0() => refLimit0;
        internal void SetRefLimit0(float value) { refLimit0 = value; }

        internal float GetRefLimit1() => refLimit1;
        internal void SetRefLimit1(float value) { refLimit1 = value; }

        internal float GetVelocityMax() => velocityMax;
        internal void SetVelocityMax(float value) { velocityMax = value; }

        internal float GetTorqueMax() => torqueMax;
        internal void SetTorqueMax(float value) { torqueMax = value; }

        internal float GetVelocityRate() => velocityRate;
        internal void SetVelocityRate(float value) { velocityRate = value; }

        internal bool GetIsPoweredFlag() => isPoweredFlag;
        internal void SetIsPoweredFlag(bool value) { isPoweredFlag = value; }
    }
}
