using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Tactical
{
    public partial class GkTacticalActionWaypoint
    {
        public UnityEngine.Vector3 Position { get => position; set => position = value; }

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            position = Fox.Math.FoxToUnityVector3(position);
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            context.OverrideProperty(nameof(position), Fox.Math.UnityToFoxVector3(position));
        }
    }
}
