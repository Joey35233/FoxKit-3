using Fox.Core;

namespace Fox.Ph
{
    public partial class PhHingeConstraintParam : Fox.Ph.PhConstraintParam
    {
        internal UnityEngine.Vector3 GetAxis() => axis;
        internal void SetAxis(UnityEngine.Vector3 value) { axis = value; }

        internal bool GetLimitedFlag() => limitedFlag;
        internal void SetLimitedFlag(bool value) { limitedFlag = value; }

        internal float GetLimitHi() => limitHi;
        internal void SetLimitHi(float value) { limitHi = value; }

        internal float GetLimitLo() => limitLo;
        internal void SetLimitLo(float value) { limitLo = value; }
    }
}
