using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhCylinderConstraintParam : Fox.Ph.PhConstraintParam
    {
        internal UnityEngine.Vector3 GetAxis() => axis;
        internal void SetAxis(UnityEngine.Vector3 value) => axis = value;

        internal float GetRadius() => radius;
        internal void SetRadius(float value) => radius = value;

        internal float GetHeightMin() => heightMin;
        internal void SetHeightMin(float value) => heightMin = value;

        internal float GetHeightMax() => heightMax;
        internal void SetHeightMax(float value) => heightMax = value;
        
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            axis = Fox.Math.FoxToUnityVector3(axis);
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            context.OverrideProperty(nameof(axis), Fox.Math.UnityToFoxVector3(axis));
        }
    }
}
