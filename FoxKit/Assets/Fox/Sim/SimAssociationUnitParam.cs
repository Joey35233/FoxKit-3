namespace Fox.Sim
{
    public partial class SimAssociationUnitParam : Fox.Core.Entity
    {
        public string BoneName { get => boneName; set => boneName = value; }
        public bool Initialized => initialized;

        internal void SetInitialized(bool value) => initialized = value;
    }
}
