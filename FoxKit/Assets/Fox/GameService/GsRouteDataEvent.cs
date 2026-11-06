namespace Fox.GameService
{
    public partial class GsRouteDataEvent
    {
        public virtual uint[] GetExtensions() => extensions;

        public string Id { get => id; set => id = value; }
    }
}
