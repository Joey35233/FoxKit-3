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
    }
}
