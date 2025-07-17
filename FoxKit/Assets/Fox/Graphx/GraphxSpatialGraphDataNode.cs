using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphDataNode
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            position = Fox.Math.FoxToUnityVector3(position);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(position), Fox.Math.UnityToFoxVector3(position));
        }

        private static readonly Vector3 Scale = Vector3.one * 0.25f;
        public void OnDrawGizmos()
        {
            Gizmos.matrix = Matrix4x4.identity;
            Gizmos.color = EditorColors.PlayerUtilityColor;
            if (!this.transform.parent)
                Gizmos.DrawWireCube(this.transform.TransformPoint(position), Scale);
            else
                Gizmos.DrawWireCube(this.transform.parent.TransformPoint(position), Scale);
        }
    }
}