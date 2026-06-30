using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhBallsocketConstraint : Fox.Ph.PhConstraint
    {
        private PhBallsocketConstraintParam ballsocketConstraint => param as PhBallsocketConstraintParam;

        private partial bool limitedFlag_Get() => ballsocketConstraint == null ? false : ballsocketConstraint.GetLimitedFlag();
        private partial void limitedFlag_Set(bool value)
        {
            if (param == null)
                return;

            ballsocketConstraint.SetLimitedFlag(value);
        }

        private partial UnityEngine.Quaternion refA_Get() => throw new System.NotImplementedException();
        private partial void refA_Set(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial UnityEngine.Quaternion refB_Get() => throw new System.NotImplementedException();
        private partial void refB_Set(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial float limit_Get() => ballsocketConstraint == null ? 0f : ballsocketConstraint.GetLimit();
        private partial void limit_Set(float value)
        {
            if (param == null)
                return;

            ballsocketConstraint.SetLimit(value);
        }

        private partial bool springFlag_Get() => ballsocketConstraint == null ? false : ballsocketConstraint.GetSpringFlag();
        private partial void springFlag_Set(bool value)
        {
            if (param == null)
                return;

            ballsocketConstraint.SetSpringFlag(value);
        }

        private partial bool springRefCustomFlag_Get() => ballsocketConstraint == null ? false : ballsocketConstraint.GetSpringRefCustomFlag();
        private partial void springRefCustomFlag_Set(bool value)
        {
            if (param == null)
                return;

            ballsocketConstraint.SetSpringRefCustomFlag(value);
        }

        private partial UnityEngine.Quaternion springRef_Get() => throw new System.NotImplementedException();
        private partial void springRef_Set(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial float springConstant_Get() => ballsocketConstraint == null ? 0f : ballsocketConstraint.GetSpringConstant();
        private partial void springConstant_Set(float value)
        {
            if (param == null)
                return;

            ballsocketConstraint.SetSpringConstant(value);
        }

        private partial float flexibility_Get() => ballsocketConstraint == null ? 0f : ballsocketConstraint.GetFlexibility();
        private partial void flexibility_Set(float value)
        {
            if (param == null)
                return;

            ballsocketConstraint.SetFlexibility(value);
        }

        private partial bool stopTwist_Get() => ballsocketConstraint == null ? false : ballsocketConstraint.GetStopTwistFlag();
        private partial void stopTwist_Set(bool value)
        {
            if (param == null)
                return;

            ballsocketConstraint.SetStopTwistFlag(value);
        }
    }
}
