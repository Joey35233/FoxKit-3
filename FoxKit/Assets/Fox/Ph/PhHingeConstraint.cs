using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhHingeConstraint : Fox.Ph.PhConstraint
    {
        private PhHingeConstraintParam hingeConstraint => param as PhHingeConstraintParam;

        private partial UnityEngine.Quaternion Get_axis() => throw new System.NotImplementedException();
        private partial void Set_axis(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial bool Get_limitedFlag() => hingeConstraint == null ? false : hingeConstraint.GetLimitedFlag();
        private partial void Set_limitedFlag(bool value)
        {
            if (param == null)
                return;

            hingeConstraint.SetLimitedFlag(value);
        }

        private partial float Get_limitHi() => hingeConstraint == null ? 0f : hingeConstraint.GetLimitHi();
        private partial void Set_limitHi(float value)
        {
            if (param == null)
                return;

            hingeConstraint.SetLimitHi(value);
        }

        private partial float Get_limitLo() => hingeConstraint == null ? 0f : hingeConstraint.GetLimitLo();
        private partial void Set_limitLo(float value)
        {
            if (param == null)
                return;

            hingeConstraint.SetLimitLo(value);
        }
    }
}
