namespace Fox.Phx
{
    public partial class PhxAssociation : Fox.Core.Data
    {
        private PhAssociationParam associationParam => param.Get();

        protected partial uint Get_connectType() => associationParam.GetConnectType();
        protected partial void Set_connectType(uint value) => associationParam.SetConnectType(value);
    }
}
