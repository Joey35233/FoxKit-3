using Fox.Core;
using Fox.Core.Utils;
using Fox;
using UnityEngine;

namespace Fox.Sim
{
    public partial class SimAssociationUnit : Fox.Phx.PhxAssociationUnitElement
    {
        private partial string Get_boneName() => param == null ? null : param.boneName;
        private partial void Set_boneName(string value)
        {
            if (param == null)
                return;
            
            param.boneName = value;
        }

        private partial bool Get_initialized() => param == null ? false : param.initialized;
        private partial void Set_initialized(bool value)
        {
            if (param == null)
                return;
            
            param.SetInitialized(value);
        }
    }
}
