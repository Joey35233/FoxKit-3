using Fox.Core;
using Fox.Core.Utils;
using Fox;
using UnityEngine;

namespace Fox.Sim
{
    public partial class SimAssociationUnit : Fox.Phx.PhxAssociationUnitElement
    {
        private SimAssociationUnitParam associationUnit => param;

        private partial string Get_boneName() => associationUnit.boneName;
        private partial void Set_boneName(string value) => associationUnit.boneName = value;

        private partial bool Get_initialized() => associationUnit.initialized;
        private partial void Set_initialized(bool value) => associationUnit.SetInitialized(value);
    }
}
