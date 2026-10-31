using Fox.Core;

namespace Fox.GameService
{
    public enum RouteAimTargetType : byte
    {
        NoTarget = 0,
        StaticPoint = 1,
        Character = 2,
        RouteAsSightMovePath = 3,
        RouteAsObject = 4,
    }
    
    public enum RouteAimInfoType : byte
    {
        None = 0,
        Point = 1,
        Id = 2,
        Array = 3,
    }
    
    public enum RouteBodySectionType : byte
    {
        Head = 0,
        Breast = 1,
    }
}