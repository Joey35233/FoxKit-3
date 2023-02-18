namespace Fox.Phx
{
    public partial class PhAssociationParam : Fox.Core.Entity
    {
        internal uint GetConnectType() => connectType;
        internal void SetConnectType(uint value) => connectType = value;
    }
}
