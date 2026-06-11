using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhShoulderConstraintParam : Fox.Ph.PhConstraintParam
    {
        internal bool GetLimitedFlag() => limitedFlag;
        internal void SetLimitedFlag(bool value) => limitedFlag = value;

        internal UnityEngine.Vector3 GetRefA() => refA;
        internal void SetRefA(UnityEngine.Vector3 value) => refA = value;

        internal UnityEngine.Vector3 GetRefB() => refB;
        internal void SetRefB(UnityEngine.Vector3 value) => refB = value;

        internal float GetLimit() => limit;
        internal void SetLimit(float value) => limit = value;

        internal bool GetLimitedFlag1() => limitedFlag1;
        internal void SetLimitedFlag1(bool value) => limitedFlag1 = value;

        internal UnityEngine.Vector3 GetRefA1() => refA1;
        internal void SetRefA1(UnityEngine.Vector3 value) => refA1 = value;

        internal UnityEngine.Vector3 GetRefB1() => refB1;
        internal void SetRefB1(UnityEngine.Vector3 value) => refB1 = value;

        internal float GetLimit1() => limit1;
        internal void SetLimit1(float value) => limit1 = value;
        
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            refA = Fox.Math.FoxToUnityVector3(refA);
            refB = Fox.Math.FoxToUnityVector3(refB);
            refA1 = Fox.Math.FoxToUnityVector3(refA1);
            refB1 = Fox.Math.FoxToUnityVector3(refB1);
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            context.OverrideProperty(nameof(refA), Fox.Math.UnityToFoxVector3(refA));
            context.OverrideProperty(nameof(refB), Fox.Math.UnityToFoxVector3(refB));
            context.OverrideProperty(nameof(refA1), Fox.Math.UnityToFoxVector3(refA1));
            context.OverrideProperty(nameof(refB1), Fox.Math.UnityToFoxVector3(refB1));
        }
    }
}
