namespace Fox.GameCore
{
    public partial class GameObject
    {
        public uint GroupId { get => groupId; set => groupId = value; }
        public Fox.Core.DataElement Parameters { get => parameters; set => parameters = value; }
        public uint RealizedCount { get => realizedCount; set => realizedCount = value; }
        public uint TotalCount { get => totalCount; set => totalCount = value; }
        public string TypeName { get => typeName; set => typeName = value; }
    }
}
