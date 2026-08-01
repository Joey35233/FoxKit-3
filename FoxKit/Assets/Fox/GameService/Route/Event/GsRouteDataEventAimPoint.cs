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
    
    public partial class GsRouteDataEventAimPoint : DataElement
    {
        // TODO: Make these partial
        private RouteAimTargetType _type { get => type_Get(); set => type_Set(value); }
        
        private RouteAimTargetType type_Get() => (RouteAimTargetType)type;

        private void type_Set(RouteAimTargetType value)
        {
            type = (byte)value;

            switch (_type)
            {
                case RouteAimTargetType.NoTarget:
                    infoType = (byte)RouteAimInfoType.None;
                    break;
                case RouteAimTargetType.StaticPoint:
                    infoType = (byte)RouteAimInfoType.Point;
                    break;
                case RouteAimTargetType.Character:
                    infoType = (byte)RouteAimInfoType.Id;
                    break;
                case RouteAimTargetType.RouteAsSightMovePath:
                    infoType = (byte)RouteAimInfoType.Array;
                    break;
                case RouteAimTargetType.RouteAsObject:
                    infoType = (byte)RouteAimInfoType.Array;
                    break;
            }
        }
        
        private partial string typeName_Get()
        {
            return (RouteAimTargetType)type switch
            {
                RouteAimTargetType.NoTarget => "NoTarget",
                RouteAimTargetType.StaticPoint => "StaticPoint",
                RouteAimTargetType.Character => "Character",
                RouteAimTargetType.RouteAsSightMovePath => "RouteAsSightMovePath",
                RouteAimTargetType.RouteAsObject => "RouteAsObject",
                _ => "INV"
            };
        }

        private partial void typeName_Set(string value)
        {
            switch (value)
            {
                case "NoTarget":
                    _type = RouteAimTargetType.NoTarget;
                    break;
                case "StaticPoint":
                    _type = RouteAimTargetType.StaticPoint;
                    break;
                case "Character":
                    _type = RouteAimTargetType.Character;
                    break;
                case "RouteAsSightMovePath":
                    _type = RouteAimTargetType.RouteAsSightMovePath;
                    break;
                case "RouteAsObject":
                    _type = RouteAimTargetType.RouteAsObject;
                    break;
            }
        }
        
        private partial string bodySectionName_Get()
        {
            return (RouteBodySectionType)bodySection switch
            {
                RouteBodySectionType.Head => "Head",
                RouteBodySectionType.Breast => "Breast",
                _ => "INV"
            };
        }

        private partial void bodySectionName_Set(string value)
        {
            switch (value)
            {
                case "Head":
                    bodySection = (byte)RouteBodySectionType.Head;
                    break;
                case "Breast":
                    bodySection = (byte)RouteBodySectionType.Breast;
                    break;
            };
        }
    }
}