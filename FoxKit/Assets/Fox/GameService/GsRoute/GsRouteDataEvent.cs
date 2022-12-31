using Fox.Core;
using Fox.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.GameService
{
    public class GsRouteDataEvent
    {
        string Id;
        GsRouteDataEventAimPoint AimPoint;
        uint[] Extensions = new uint[4];
    }
}
