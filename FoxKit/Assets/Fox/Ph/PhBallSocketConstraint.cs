using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhBallsocketConstraint : Fox.Ph.PhConstraint
    {
        private PhBallsocketConstraintParam ballsocketConstraint => param as PhBallsocketConstraintParam;

        private partial bool Get_limitedFlag() => ballsocketConstraint.GetLimitedFlag();
        private partial void Set_limitedFlag(bool value) => ballsocketConstraint.SetLimitedFlag(value);

        private partial UnityEngine.Quaternion Get_refA() => throw new System.NotImplementedException();
        private partial void Set_refA(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial UnityEngine.Quaternion Get_refB() => throw new System.NotImplementedException();
        private partial void Set_refB(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial float Get_limit() => ballsocketConstraint.GetLimit();
        private partial void Set_limit(float value) => ballsocketConstraint.SetLimit(value);

        private partial bool Get_springFlag() => ballsocketConstraint.GetSpringFlag();
        private partial void Set_springFlag(bool value) => ballsocketConstraint.SetSpringFlag(value);

        private partial bool Get_springRefCustomFlag() => ballsocketConstraint.GetSpringRefCustomFlag();
        private partial void Set_springRefCustomFlag(bool value) => ballsocketConstraint.SetSpringRefCustomFlag(value);

        private partial UnityEngine.Quaternion Get_springRef() => throw new System.NotImplementedException();
        private partial void Set_springRef(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial float Get_springConstant() => ballsocketConstraint.GetSpringConstant();
        private partial void Set_springConstant(float value) => ballsocketConstraint.SetSpringConstant(value);

        private partial float Get_flexibility() => ballsocketConstraint.GetFlexibility();
        private partial void Set_flexibility(float value) => ballsocketConstraint.SetFlexibility(value);

        private partial bool Get_stopTwist() => ballsocketConstraint.GetStopTwistFlag();
        private partial void Set_stopTwist(bool value) => ballsocketConstraint.SetStopTwistFlag(value);
    }
}
