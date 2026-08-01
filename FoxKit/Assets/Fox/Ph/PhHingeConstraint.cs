using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhHingeConstraint : Fox.Ph.PhConstraint
    {
        private PhHingeConstraintParam hingeConstraint => param as PhHingeConstraintParam;

        private partial UnityEngine.Quaternion axis_Get() => throw new System.NotImplementedException();
        private partial void axis_Set(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial bool limitedFlag_Get() => hingeConstraint == null ? false : hingeConstraint.GetLimitedFlag();
        private partial void limitedFlag_Set(bool value)
        {
            if (param == null)
                return;

            hingeConstraint.SetLimitedFlag(value);
        }

        private partial float limitHi_Get() => hingeConstraint == null ? 0f : hingeConstraint.GetLimitHi();
        private partial void limitHi_Set(float value)
        {
            if (param == null)
                return;

            hingeConstraint.SetLimitHi(value);
        }

        private partial float limitLo_Get() => hingeConstraint == null ? 0f : hingeConstraint.GetLimitLo();
        private partial void limitLo_Set(float value)
        {
            if (param == null)
                return;

            hingeConstraint.SetLimitLo(value);
        }
    }
}
