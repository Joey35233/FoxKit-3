using PlasticPipe.PlasticProtocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fox.GameService
{
    public class GsRouteDataNode
    {
        GsRouteDataEvent EdgeEvent;
        List<GsRouteDataEvent> NodeEvents;
    }
}
