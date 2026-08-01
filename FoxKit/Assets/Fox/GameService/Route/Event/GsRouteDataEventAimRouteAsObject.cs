using System.Collections.Generic;
using UnityEngine;

namespace Fox.GameService
{
    public partial class GsRouteDataEventAimRouteAsObject : GsRouteDataEventAimPoint
    {
        public partial string routeId_Get(int index) => targetIds[index];

        public partial void routeId_Set(int index, string value) => targetIds[index] = value;

        public partial void routeId_AddElement(int index, string value)
        {
            if (index < targetIds.Length)
                targetIds[index] = value;
        }

        public partial void routeId_RemoveElement(int index)
        {
            if (index < targetIds.Length)
                targetIds[index] = string.Empty;
        }

        public partial int routeId_GetContainerSize()
        {
            int count;
            for (count = 0; count < targetIds.Length; count++)
                if (targetIds[count] == string.Empty)
                    break;
            
            return count;
        }
    }
}