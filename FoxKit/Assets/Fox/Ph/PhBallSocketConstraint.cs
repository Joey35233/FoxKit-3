using Fox.Core;

namespace Fox.Ph
{
    public partial class PhBallsocketConstraint : Fox.Ph.PhConstraint
    {
        private PhBallsocketConstraintParam ballsocketConstraint => (param.Get() as PhBallsocketConstraintParam);

        protected partial bool Get_limitedFlag() => ballsocketConstraint.GetLimitedFlag();
        protected partial void Set_limitedFlag(bool value) { ballsocketConstraint.SetLimitedFlag(value); }

        protected partial UnityEngine.Quaternion Get_refA() => throw new System.NotImplementedException();
        protected partial void Set_refA(UnityEngine.Quaternion value) { throw new System.NotImplementedException(); }

        protected partial UnityEngine.Quaternion Get_refB() => throw new System.NotImplementedException();
        protected partial void Set_refB(UnityEngine.Quaternion value) { throw new System.NotImplementedException(); }

        protected partial float Get_limit() => ballsocketConstraint.GetLimit();
        protected partial void Set_limit(float value) { ballsocketConstraint.SetLimit(value); }

        protected partial bool Get_springFlag() => ballsocketConstraint.GetSpringFlag();
        protected partial void Set_springFlag(bool value) { ballsocketConstraint.SetSpringFlag(value); }

        protected partial bool Get_springRefCustomFlag() => ballsocketConstraint.GetSpringRefCustomFlag();
        protected partial void Set_springRefCustomFlag(bool value) { ballsocketConstraint.SetSpringRefCustomFlag(value); }

        protected partial UnityEngine.Quaternion Get_springRef() => throw new System.NotImplementedException();
        protected partial void Set_springRef(UnityEngine.Quaternion value) { throw new System.NotImplementedException(); }

        protected partial float Get_springConstant() => ballsocketConstraint.GetSpringConstant();
        protected partial void Set_springConstant(float value) { ballsocketConstraint.SetSpringConstant(value); }

        protected partial float Get_flexibility() => ballsocketConstraint.GetFlexibility();
        protected partial void Set_flexibility(float value) { ballsocketConstraint.SetFlexibility(value); }

        protected partial bool Get_stopTwist() => ballsocketConstraint.GetStopTwistFlag();
        protected partial void Set_stopTwist(bool value) { ballsocketConstraint.SetStopTwistFlag(value); }
    }
}
