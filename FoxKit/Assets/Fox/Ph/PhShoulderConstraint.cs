using UnityEngine;

namespace Fox.Ph
{
    public partial class PhShoulderConstraint : Fox.Ph.PhConstraint
    {
        private PhShoulderConstraintParam shoulderConstraint => param as PhShoulderConstraintParam;

        private partial bool limitedFlag_Get() => shoulderConstraint == null ? false : shoulderConstraint.GetLimitedFlag();
        private partial void limitedFlag_Set(bool value)
        {
            if (param == null)
                return;

            shoulderConstraint.SetLimitedFlag(value);
        }

        private partial UnityEngine.Vector3 refA_Get() => shoulderConstraint == null ? Vector3.zero : shoulderConstraint.GetRefA();
        private partial void refA_Set(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            shoulderConstraint.SetRefA(value);
        }

        private partial UnityEngine.Vector3 refB_Get() => shoulderConstraint == null ? Vector3.zero : shoulderConstraint.GetRefB();
        private partial void refB_Set(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            shoulderConstraint.SetRefB(value);
        }

        private partial float limit_Get() => shoulderConstraint == null ? 0.0f : shoulderConstraint.GetLimit();
        private partial void limit_Set(float value)
        {
            if (param == null)
                return;

            shoulderConstraint.SetLimit(value);
        }

        private partial bool limitedFlag1_Get() => shoulderConstraint == null ? false : shoulderConstraint.GetLimitedFlag1();
        private partial void limitedFlag1_Set(bool value)
        {
            if (param == null)
                return;

            shoulderConstraint.SetLimitedFlag1(value);
        }

        private partial UnityEngine.Vector3 refA1_Get() => shoulderConstraint == null ? Vector3.zero : shoulderConstraint.GetRefA1();
        private partial void refA1_Set(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            shoulderConstraint.SetRefA1(value);
        }

        private partial UnityEngine.Vector3 refB1_Get() => shoulderConstraint == null ? Vector3.zero : shoulderConstraint.GetRefB1();
        private partial void refB1_Set(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            shoulderConstraint.SetRefB1(value);
        }

        private partial float limit1_Get() => shoulderConstraint == null ? 0.0f : shoulderConstraint.GetLimit1();
        private partial void limit1_Set(float value)
        {
            if (param == null)
                return;

            shoulderConstraint.SetLimit1(value);
        }
    }
}
