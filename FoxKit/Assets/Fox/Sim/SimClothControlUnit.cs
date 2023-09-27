namespace Fox.Sim
{
    public partial class SimClothControlUnit : Fox.Core.DataElement
    {
        private SimClothControlUnitParam param => controlUnitParam.Get();

        private partial float Get_mass() => param.GetMass();
        private partial void Set_mass(float value) => param.SetMass(value);

        private partial float Get_thickness() => param.GetThickness();
        private partial void Set_thickness(float value) => param.SetThickness(value);

        private partial float Get_limit() => param.GetLimit();
        private partial void Set_limit(float value) => param.SetLimit(value);

        private partial float Get_expansionRatio() => param.GetExpansionRatio();
        private partial void Set_expansionRatio(float value) => param.SetExpansionRatio(value);

        private partial float Get_contractionRatio() => param.GetContractionRatio();
        private partial void Set_contractionRatio(float value) => param.SetContractionRatio(value);
    }
}
