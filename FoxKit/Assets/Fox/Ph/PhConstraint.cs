namespace Fox.Ph
{
    public partial class PhConstraint : Fox.Ph.PhSubObject
    {
        private PhConstraintParam constraint => param.Get();

        protected partial UnityEngine.Vector3 Get_defaultPosition() => constraint.GetDefaultPosition();
        protected partial void Set_defaultPosition(UnityEngine.Vector3 value) => constraint.SetDefaultPosition(value);
    }
}
