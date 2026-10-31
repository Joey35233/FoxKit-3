    using Fox.Core.Utils;
    using UnityEngine;

namespace Fox.GameService
{
    public partial class GsRouteDataEventAimStaticPoint : GsRouteDataEventAimPoint
    {
        private partial Vector3 aimPos_Get() => transform.TransformPoint(Position);

        private partial void aimPos_Set(Vector3 value) => Position = transform.InverseTransformPoint(value);
        
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            
            Position = Fox.Math.FoxToUnityVector3(Position);
        }
    }
}