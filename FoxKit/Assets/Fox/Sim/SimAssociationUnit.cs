using Fox.Core;
using Fox.Core.Utils;
using Fox;
using UnityEngine;

namespace Fox.Sim
{
    public partial class SimAssociationUnit : Fox.Phx.PhxAssociationUnitElement
    {
        private partial string boneName_Get() => param == null ? null : param.boneName;
        private partial void boneName_Set(string value)
        {
            if (param == null)
                return;
            
            param.boneName = value;
        }

        private partial bool initialized_Get() => param == null ? false : param.initialized;
        private partial void initialized_Set(bool value)
        {
            if (param == null)
                return;
            
            param.SetInitialized(value);
        }
    }
}
