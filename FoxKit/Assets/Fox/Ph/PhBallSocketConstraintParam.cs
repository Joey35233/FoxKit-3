namespace Fox.Ph
{
    public partial class PhBallsocketConstraintParam : Fox.Ph.PhConstraintParam
    {
        internal bool GetLimitedFlag() => limitedFlag;
        internal void SetLimitedFlag(bool value) => limitedFlag = value;

        internal UnityEngine.Vector3 GetRefA() => refA;
        internal void SetRefA(UnityEngine.Vector3 value) => refA = value;

        internal UnityEngine.Vector3 GetRefB() => refB;
        internal void SetRefB(UnityEngine.Vector3 value) => refB = value;

        internal float GetLimit() => limit;
        internal void SetLimit(float value) => limit = value;

        internal bool GetSpringFlag() => springFlag;
        internal void SetSpringFlag(bool value) => springFlag = value;

        internal bool GetSpringRefCustomFlag() => springRefCustomFlag;
        internal void SetSpringRefCustomFlag(bool value) => springRefCustomFlag = value;

        internal UnityEngine.Vector3 GetSpringRef() => springRef;
        internal void SetSpringRef(UnityEngine.Vector3 value) => springRef = value;

        internal float GetSpringConstant() => springConstant;
        internal void SetSpringConstant(float value) => springConstant = value;

        internal float GetFlexibility() => flexibility;
        internal void SetFlexibility(float value) => flexibility = value;

        internal bool GetStopTwistFlag() => stopTwistFlag;
        internal void SetStopTwistFlag(bool value) => stopTwistFlag = value;
    }
}
