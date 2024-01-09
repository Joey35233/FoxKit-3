﻿using Fox.Core.Utils;
using UnityEngine;

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

        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            refA = Fox.Kernel.Math.FoxToUnityVector3(refA);
            refB = Fox.Kernel.Math.FoxToUnityVector3(refB);
            springRef = Fox.Kernel.Math.FoxToUnityVector3(springRef);

            base.OnDeserializeEntity(gameObject, logger);
        }

        public override void DrawGizmos()
        {
            if (limitedFlag && limit > 0)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(Vector3.zero, refA * 0.1f);
                Gizmos.DrawLine(Vector3.zero, refB * 0.1f);

                if (springFlag && springConstant > 0)
                {
                    Vector3 actualSpringRef = springRefCustomFlag ? springRef : refB;
                    Gizmos.color = Color.magenta;
                    Gizmos.DrawLine(Vector3.zero, actualSpringRef * 0.1f);
                }
            }
        }
    }
}
