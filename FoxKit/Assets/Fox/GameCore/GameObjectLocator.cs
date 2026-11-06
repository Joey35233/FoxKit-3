namespace Fox.GameCore
{
    public partial class GameObjectLocator
    {
        public uint GroupId { get => groupId; set => groupId = value; }
        public Fox.Core.DataElement Parameters { get => parameters; set => parameters = value; }
        public string TypeName { get => typeName; set => typeName = value; }
    }
}
