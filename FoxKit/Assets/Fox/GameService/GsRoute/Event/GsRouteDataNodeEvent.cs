namespace Fox.GameService
{
    public partial class GsRouteDataNodeEvent : GsRouteDataEvent
    {
        private partial string action_Get() => id;
        
        private partial void action_Set(string value) => id = value;
    }
}