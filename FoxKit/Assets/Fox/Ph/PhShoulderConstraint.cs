using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhShoulderConstraint : Fox.Ph.PhConstraint
    {
        private PhShoulderConstraintParam shoulderConstraint => param as PhShoulderConstraintParam;

        private partial bool Get_limitedFlag() => shoulderConstraint.GetLimitedFlag();
        private partial void Set_limitedFlag(bool value) => shoulderConstraint.SetLimitedFlag(value);

        private partial UnityEngine.Vector3 Get_refA() => shoulderConstraint.GetRefA();
        private partial void Set_refA(UnityEngine.Vector3 value) => shoulderConstraint.SetRefA(value);

        private partial UnityEngine.Vector3 Get_refB() => shoulderConstraint.GetRefB();
        private partial void Set_refB(UnityEngine.Vector3 value) => shoulderConstraint.SetRefB(value);

        private partial float Get_limit() => shoulderConstraint.GetLimit();
        private partial void Set_limit(float value) => shoulderConstraint.SetLimit(value);

        private partial bool Get_limitedFlag1() => shoulderConstraint.GetLimitedFlag1();
        private partial void Set_limitedFlag1(bool value) => shoulderConstraint.SetLimitedFlag1(value);

        private partial UnityEngine.Vector3 Get_refA1() => shoulderConstraint.GetRefA1();
        private partial void Set_refA1(UnityEngine.Vector3 value) => shoulderConstraint.SetRefA1(value);

        private partial UnityEngine.Vector3 Get_refB1() => shoulderConstraint.GetRefB1();
        private partial void Set_refB1(UnityEngine.Vector3 value) => shoulderConstraint.SetRefB1(value);

        private partial float Get_limit1() => shoulderConstraint.GetLimit1();
        private partial void Set_limit1(float value) => shoulderConstraint.SetLimit1(value);
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            refA = Fox.Math.FoxToUnityVector3(refA);
            refB = Fox.Math.FoxToUnityVector3(refB);
            refA1 = Fox.Math.FoxToUnityVector3(refA1);
            refB1 = Fox.Math.FoxToUnityVector3(refB1);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(refA), Fox.Math.UnityToFoxVector3(refA));
            context.OverrideProperty(nameof(refB), Fox.Math.UnityToFoxVector3(refB));
            context.OverrideProperty(nameof(refA1), Fox.Math.UnityToFoxVector3(refA1));
            context.OverrideProperty(nameof(refB1), Fox.Math.UnityToFoxVector3(refB1));
        }
    }
}
