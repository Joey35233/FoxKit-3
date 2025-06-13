using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.GameKit
{
    public partial class TerrainBlock
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            pos = Fox.Math.FoxToUnityVector3(pos);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(pos), Fox.Math.UnityToFoxVector3(pos));
        }

        private UnityEngine.Transform gizmoTransform;

        private readonly BoxGizmo Gizmo = new BoxGizmo();

        public void OnDrawGizmos()
        {
            Gizmos.matrix = Matrix4x4.identity;
            Gizmo.Label = this.name;
            Gizmos.DrawWireCube(this.pos, Vector3.one);
        }

        public void OnDrawGizmosSelected()
        {
            Gizmos.matrix = Matrix4x4.identity;
            Gizmos.DrawWireCube(this.pos, Vector3.one);
            Gizmo.Label = null;
        }
    }
}
