using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphDataNode
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            position = Fox.Kernel.Math.FoxToUnityVector3(position);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(position), Fox.Kernel.Math.UnityToFoxVector3(position));
        }

        private static readonly Vector3 Scale = Vector3.one * 0.25f;

        public void OnDrawGizmos()
        {
            if (transform.parent.GetComponent<GraphxSpatialGraphData>() is not { } graph)
                return;

            Gizmos.matrix = graph.GetGraphWorldMatrix();

            Gizmos.DrawWireCube(position, Scale);
        }
    }
}