namespace Fox.Ph
{
    public partial class PhCylinderConstraint : Fox.Ph.PhConstraint
    {
        private PhCylinderConstraintParam cylinderConstraint => param.Get() as PhCylinderConstraintParam;

        protected partial UnityEngine.Quaternion Get_axis() => throw new System.NotImplementedException();
        protected partial void Set_axis(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        protected partial float Get_radius() => cylinderConstraint.GetRadius();
        protected partial void Set_radius(float value) => cylinderConstraint.SetRadius(value);

        protected partial float Get_heightMin() => cylinderConstraint.GetHeightMin();
        protected partial void Set_heightMin(float value) => cylinderConstraint.SetHeightMin(value);

        protected partial float Get_heightMax() => cylinderConstraint.GetHeightMax();
        protected partial void Set_heightMax(float value) => cylinderConstraint.SetHeightMax(value);
    }
}
