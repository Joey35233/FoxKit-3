    using Fox.Core.Utils;
    using UnityEngine;

namespace Fox.GameService
{
    public partial class GsRouteDataEventAimStaticPoint : GsRouteDataEventAimPoint
    {
        private partial Vector3 aimPos_Get() => transform.TransformPoint(position);

        private partial void aimPos_Set(Vector3 value) => position = transform.InverseTransformPoint(value);
        
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            
            position = Fox.Math.FoxToUnityVector3(position);
        }
    }
}