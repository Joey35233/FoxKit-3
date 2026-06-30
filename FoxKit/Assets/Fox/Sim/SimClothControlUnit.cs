using UnityEditor.ShaderKeywordFilter;

namespace Fox.Sim
{
    public partial class SimClothControlUnit : Fox.Core.DataElement
    {
        private SimClothControlUnitParam param => controlUnitParam;

        private partial float mass_Get() => param == null ? 0.0f : param.GetMass();
        private partial void mass_Set(float value)
        {
            if (param == null)
                return;
            
            param.SetMass(value);
        }

        private partial float thickness_Get() => param == null ? 0.0f : param.GetThickness();
        private partial void thickness_Set(float value)
        {
            if (param == null)
                return;
            
            param.SetThickness(value);
        }

        private partial float limit_Get() => param == null ? 0.0f : param.GetLimit();
        private partial void limit_Set(float value)
        {
            if (param == null)
                return;
            
            param.SetLimit(value);
        }

        private partial float expansionRatio_Get() => param == null ? 1.0f : param.GetExpansionRatio();
        private partial void expansionRatio_Set(float value)
        {
            if (param == null)
                return;
            
            param.SetExpansionRatio(value);
        }

        private partial float contractionRatio_Get() => param == null ? 1.0f : param.GetContractionRatio();
        private partial void contractionRatio_Set(float value)
        {
            if (param == null)
                return;
            
            param.SetContractionRatio(value);
        }
    }
}
