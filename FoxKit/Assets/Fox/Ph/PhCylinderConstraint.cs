using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhCylinderConstraint : Fox.Ph.PhConstraint
    {
        private PhCylinderConstraintParam cylinderConstraint => param as PhCylinderConstraintParam;

        private partial UnityEngine.Quaternion Get_axis() => throw new System.NotImplementedException();
        private partial void Set_axis(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial float Get_radius() => cylinderConstraint == null ? 0f : cylinderConstraint.GetRadius();
        private partial void Set_radius(float value)
        {
            if (param == null)
                return;

            cylinderConstraint.SetRadius(value);
        }

        private partial float Get_heightMin() => cylinderConstraint == null ? 0f : cylinderConstraint.GetHeightMin();
        private partial void Set_heightMin(float value)
        {
            if (param == null)
                return;

            cylinderConstraint.SetHeightMin(value);
        }

        private partial float Get_heightMax() => cylinderConstraint == null ? 0f : cylinderConstraint.GetHeightMax();
        private partial void Set_heightMax(float value)
        {
            if (param == null)
                return;

            cylinderConstraint.SetHeightMax(value);
        }
    }
}
