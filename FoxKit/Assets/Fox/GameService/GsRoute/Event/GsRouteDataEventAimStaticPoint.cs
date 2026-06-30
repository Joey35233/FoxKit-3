using UnityEngine;

namespace Fox.GameService
{
    public partial class GsRouteDataEventAimStaticPoint : GsRouteDataEventAimPoint
    {
        private partial Vector3 aimPos_Get() => transform.parent.TransformPoint(position);

        private partial void aimPos_Set(Vector3 value) => position = transform.parent.InverseTransformPoint(value);
    }
}