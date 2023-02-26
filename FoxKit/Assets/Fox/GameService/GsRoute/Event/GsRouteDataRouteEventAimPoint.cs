using Fox.Core;

namespace Fox.GameService
{
    public abstract partial class GsRouteDataRouteEventAimPoint : DataElement
    {
        public enum Type : byte
        {
            NoTarget = 0,
            StaticPoint = 1,
            Character = 2,
            RouteAsSightMovePath = 3,
            RouteAsObject = 4,
        }
    }
}