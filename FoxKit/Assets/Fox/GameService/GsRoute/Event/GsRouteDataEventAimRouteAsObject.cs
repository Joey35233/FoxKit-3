using System.Collections.Generic;
using UnityEngine;

namespace Fox.GameService
{
    public partial class GsRouteDataEventAimRouteAsObject : GsRouteDataEventAimPoint
    {
        // TODO: This won't get serialized.
        private int RouteIdCount = 0;

        public partial string routeId_Get(int index) => targetIds[index];

        public partial void routeId_Set(int index, string value) => targetIds[index] = value;

        public partial void routeId_AddElement(int index, string value)
        {
            if (index < targetIds.Length)
            {
                if (index < targetIds.Length - 1)
                {
                    for (int i = targetIds.Length - 1; i > index; i--)
                        targetIds[i] = targetIds[i - 1];
                }
                RouteIdCount++;
            }
        }

        public partial void routeId_RemoveElement(int index)
        {
            throw new System.NotImplementedException();
        }

        public partial int routeId_GetContainerSize() => RouteIdCount;
    }
}