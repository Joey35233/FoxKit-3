using Fox.Kernel;

namespace Fox.Sim
{
    public partial class SimAssociationUnit : Fox.Phx.PhxAssociationUnitElement
    {
        private SimAssociationUnitParam associationUnit => param.Get();

        private partial String Get_boneName() => associationUnit.boneName;
        private partial void Set_boneName(String value) => associationUnit.boneName = value;

        private partial bool Get_initialized() => associationUnit.initialized;
        private partial void Set_initialized(bool value) => associationUnit.SetInitialized(value);
    }
}
