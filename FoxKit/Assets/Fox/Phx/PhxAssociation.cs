namespace Fox.Phx
{
    public partial class PhxAssociation : Fox.Core.Data
    {
        private PhAssociationParam associationParam => param;

        private partial uint Get_connectType() => associationParam.GetConnectType();
        private partial void Set_connectType(uint value) => associationParam.SetConnectType(value);
    }
}
