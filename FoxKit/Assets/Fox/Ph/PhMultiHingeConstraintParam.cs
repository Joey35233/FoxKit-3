using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhMultiHingeConstraintParam : Fox.Ph.PhConstraintParam
    {
        internal UnityEngine.Vector3 GetAxis() => axis;
        internal void SetAxis(UnityEngine.Vector3 value) => axis = value;

        internal bool GetLimitedFlag() => limitedFlag;
        internal void SetLimitedFlag(bool value) => limitedFlag = value;

        internal bool GetIsPoweredFlag() => isPoweredFlag;
        internal void SetIsPoweredFlag(bool value) => isPoweredFlag = value;

        internal float GetLimitHi() => limitHi;
        internal void SetLimitHi(float value) => limitHi = value;

        internal float GetLimitLo() => limitLo;
        internal void SetLimitLo(float value) => limitLo = value;

        internal int GetControlType() => controlType;
        internal void SetControlType(int value) => controlType = value;

        internal float GetVelocityMax() => velocityMax;
        internal void SetVelocityMax(float value) => velocityMax = value;

        internal float GetTorqueMax() => torqueMax;
        internal void SetTorqueMax(float value) => torqueMax = value;

        internal float GetTargetTheta() => targetTheta;
        internal void SetTargetTheta(float value) => targetTheta = value;

        internal float GetTargetVelocity() => targetVelocity;
        internal void SetTargetVelocity(float value) => targetVelocity = value;

        internal float GetVelocityRate() => velocityRate;
        internal void SetVelocityRate(float value) => velocityRate = value;
        
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            axis = Fox.Math.FoxToUnityVector3(axis);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(axis), Fox.Math.UnityToFoxVector3(axis));
        }
    }
}
