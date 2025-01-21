﻿using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhCylinderConstraint : Fox.Ph.PhConstraint
    {
        private PhCylinderConstraintParam cylinderConstraint => param as PhCylinderConstraintParam;

        private partial UnityEngine.Quaternion Get_axis() => throw new System.NotImplementedException();
        private partial void Set_axis(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        private partial float Get_radius() => cylinderConstraint.GetRadius();
        private partial void Set_radius(float value) => cylinderConstraint.SetRadius(value);

        private partial float Get_heightMin() => cylinderConstraint.GetHeightMin();
        private partial void Set_heightMin(float value) => cylinderConstraint.SetHeightMin(value);

        private partial float Get_heightMax() => cylinderConstraint.GetHeightMax();
        private partial void Set_heightMax(float value) => cylinderConstraint.SetHeightMax(value);
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            axis = Fox.Math.FoxToUnityQuaternion(axis);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(axis), Fox.Math.UnityToFoxQuaternion(axis));
        }
    }
}
