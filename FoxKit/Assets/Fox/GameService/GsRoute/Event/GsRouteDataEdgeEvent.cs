namespace Fox.GameService
{
    public partial class GsRouteDataEdgeEvent : GsRouteDataEvent
    {
        private partial string move_Get() => id;

        private partial void move_Set(string value) => id = value;
    }
}