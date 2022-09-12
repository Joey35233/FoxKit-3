using Fox.Core;

namespace Fox.Sim
{
    public partial class SimClothControlUnitParam : Fox.Core.Entity
    {
        internal float GetMass() => mass;
        internal void SetMass(float value) { mass = value; }

        internal float GetThickness() => thickness;
        internal void SetThickness(float value) { thickness = value; }

        internal float GetLimit() => limit;
        internal void SetLimit(float value) { limit = value; }

        internal float GetExpansionRatio() => expansionRatio;
        internal void SetExpansionRatio(float value) { expansionRatio = value; }

        internal float GetContractionRatio() => contractionRatio;
        internal void SetContractionRatio(float value) { contractionRatio = value; }
    }
}
