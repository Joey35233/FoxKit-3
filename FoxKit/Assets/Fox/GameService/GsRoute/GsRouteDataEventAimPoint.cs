using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fox.GameService
{
    public enum GsRouteDataEventAimPointType : byte
    {
        ROUTE_AIM_NO_TARGET = 0,
        ROUTE_AIM_STATIC_POINT = 1,
        ROUTE_AIM_CHARACTER = 2,
        ROUTE_AIM_ROUTE_AS_SIGHT_MOVE_PATH = 3,
        ROUTE_AIM_ROUTE_AS_OBJECT = 4,
    }
    public partial class GsRouteDataEventAimPoint
    {
    }
    public partial class GsRouteDataEventAimPointNoTarget : GsRouteDataEventAimPoint
    {
    }
    public partial class GsRouteDataEventAimPointStaticPoint : GsRouteDataEventAimPoint
    {
        Vector3 Point;
    }
    public partial class GsRouteDataEventAimPointCharacter : GsRouteDataEventAimPoint
    {
        string Name;
    }
    public partial class GsRouteDataEventAimPointRouteAsSightMovePath : GsRouteDataEventAimPoint
    {
        string[] Names = new string[4];
    }
    public partial class GsRouteDataEventAimPointRouteAsObject : GsRouteDataEventAimPoint
    {
        string[] Names = new string[4];
    }
}
