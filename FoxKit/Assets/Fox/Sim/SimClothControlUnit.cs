using UnityEditor.ShaderKeywordFilter;

namespace Fox.Sim
{
    public partial class SimClothControlUnit : Fox.Core.DataElement
    {
        private SimClothControlUnitParam param => controlUnitParam;

        private partial float Get_mass() => param == null ? 0.0f : param.GetMass();
        private partial void Set_mass(float value)
        {
            if (param == null)
                return;
            
            param.SetMass(value);
        }

        private partial float Get_thickness() => param == null ? 0.0f : param.GetThickness();
        private partial void Set_thickness(float value)
        {
            if (param == null)
                return;
            
            param.SetThickness(value);
        }

        private partial float Get_limit() => param == null ? 0.0f : param.GetLimit();
        private partial void Set_limit(float value)
        {
            if (param == null)
                return;
            
            param.SetLimit(value);
        }

        private partial float Get_expansionRatio() => param == null ? 1.0f : param.GetExpansionRatio();
        private partial void Set_expansionRatio(float value)
        {
            if (param == null)
                return;
            
            param.SetExpansionRatio(value);
        }

        private partial float Get_contractionRatio() => param == null ? 1.0f : param.GetContractionRatio();
        private partial void Set_contractionRatio(float value)
        {
            if (param == null)
                return;
            
            param.SetContractionRatio(value);
        }
    }
}
