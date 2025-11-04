using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Geo
{
    public partial class GeoModuleCondition : Fox.Geo.GeoTrapCondition
    {
        public override void Reset()
        {
            base.Reset();
            isAndCheck = true;
        }
    }
}
