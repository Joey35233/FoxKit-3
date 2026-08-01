using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhCylinderConstraint : Fox.Ph.PhConstraint
    {
        private PhCylinderConstraintParam cylinderConstraint => param as PhCylinderConstraintParam;

        private partial UnityEngine.Quaternion axis_Get() => throw new System.NotImplementedException();
        private partial void axis_Set(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial float radius_Get() => cylinderConstraint == null ? 0f : cylinderConstraint.GetRadius();
        private partial void radius_Set(float value)
        {
            if (param == null)
                return;

            cylinderConstraint.SetRadius(value);
        }

        private partial float heightMin_Get() => cylinderConstraint == null ? 0f : cylinderConstraint.GetHeightMin();
        private partial void heightMin_Set(float value)
        {
            if (param == null)
                return;

            cylinderConstraint.SetHeightMin(value);
        }

        private partial float heightMax_Get() => cylinderConstraint == null ? 0f : cylinderConstraint.GetHeightMax();
        private partial void heightMax_Set(float value)
        {
            if (param == null)
                return;

            cylinderConstraint.SetHeightMax(value);
        }
    }
}
