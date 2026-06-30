namespace Fox.Phx
{
    public partial class PhxAssociation : Fox.Core.Data
    {
        private PhAssociationParam associationParam => param;

        private partial uint connectType_Get() => associationParam.GetConnectType();
        private partial void connectType_Set(uint value) => associationParam.SetConnectType(value);
    }
}
