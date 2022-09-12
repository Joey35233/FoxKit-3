using Fox.Core;
using Fox.Kernel;

namespace Fox.Sim
{
    public partial class SimAssociationUnit : Fox.Phx.PhxAssociationUnitElement
    {
        private SimAssociationUnitParam associationUnit => (param.Get() as SimAssociationUnitParam);

        protected partial String Get_boneName() => associationUnit.boneName;
        protected partial void Set_boneName(String value) { associationUnit.boneName = value; }

        protected partial bool Get_initialized() => associationUnit.initialized;
        protected partial void Set_initialized(bool value) { associationUnit.SetInitialized(value); }
    }
}
