using Fox.Core;

namespace Fox.Phx
{
    public partial class PhxAssociation : Fox.Core.Data
    {
        private PhAssociationParam associationParam => (param.Get() as PhAssociationParam);

        protected partial uint Get_connectType() => associationParam.GetConnectType();
        protected partial void Set_connectType(uint value) { associationParam.SetConnectType(value); }
    }
}
