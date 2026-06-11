using UnityEngine;

namespace Fox.Ph
{
    public partial class PhShoulderConstraint : Fox.Ph.PhConstraint
    {
        private PhShoulderConstraintParam shoulderConstraint => param as PhShoulderConstraintParam;

        private partial bool Get_limitedFlag() => shoulderConstraint == null ? false : shoulderConstraint.GetLimitedFlag();
        private partial void Set_limitedFlag(bool value)
        {
            if (param == null)
                return;

            shoulderConstraint.SetLimitedFlag(value);
        }

        private partial UnityEngine.Vector3 Get_refA() => shoulderConstraint == null ? Vector3.zero : shoulderConstraint.GetRefA();
        private partial void Set_refA(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            shoulderConstraint.SetRefA(value);
        }

        private partial UnityEngine.Vector3 Get_refB() => shoulderConstraint == null ? Vector3.zero : shoulderConstraint.GetRefB();
        private partial void Set_refB(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            shoulderConstraint.SetRefB(value);
        }

        private partial float Get_limit() => shoulderConstraint == null ? 0.0f : shoulderConstraint.GetLimit();
        private partial void Set_limit(float value)
        {
            if (param == null)
                return;

            shoulderConstraint.SetLimit(value);
        }

        private partial bool Get_limitedFlag1() => shoulderConstraint == null ? false : shoulderConstraint.GetLimitedFlag1();
        private partial void Set_limitedFlag1(bool value)
        {
            if (param == null)
                return;

            shoulderConstraint.SetLimitedFlag1(value);
        }

        private partial UnityEngine.Vector3 Get_refA1() => shoulderConstraint == null ? Vector3.zero : shoulderConstraint.GetRefA1();
        private partial void Set_refA1(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            shoulderConstraint.SetRefA1(value);
        }

        private partial UnityEngine.Vector3 Get_refB1() => shoulderConstraint == null ? Vector3.zero : shoulderConstraint.GetRefB1();
        private partial void Set_refB1(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            shoulderConstraint.SetRefB1(value);
        }

        private partial float Get_limit1() => shoulderConstraint == null ? 0.0f : shoulderConstraint.GetLimit1();
        private partial void Set_limit1(float value)
        {
            if (param == null)
                return;

            shoulderConstraint.SetLimit1(value);
        }
    }
}
