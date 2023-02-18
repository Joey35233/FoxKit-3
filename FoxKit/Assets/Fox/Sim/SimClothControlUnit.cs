namespace Fox.Sim
{
    public partial class SimClothControlUnit : Fox.Core.DataElement
    {
        private SimClothControlUnitParam param => controlUnitParam.Get();

        protected partial float Get_mass() => param.GetMass();
        protected partial void Set_mass(float value) => param.SetMass(value);

        protected partial float Get_thickness() => param.GetThickness();
        protected partial void Set_thickness(float value) => param.SetThickness(value);

        protected partial float Get_limit() => param.GetLimit();
        protected partial void Set_limit(float value) => param.SetLimit(value);

        protected partial float Get_expansionRatio() => param.GetExpansionRatio();
        protected partial void Set_expansionRatio(float value) => param.SetExpansionRatio(value);

        protected partial float Get_contractionRatio() => param.GetContractionRatio();
        protected partial void Set_contractionRatio(float value) => param.SetContractionRatio(value);
    }
}
