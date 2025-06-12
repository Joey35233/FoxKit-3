using Fox.Core;
using Fox.Core.Utils;
using Fox.Graphx;
using UnityEngine;
using System;

namespace Fox.Navx
{
    public partial class NavxAttributePathVolume
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            topPos = Fox.Math.FoxToUnityVector3(topPos);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(topPos), Fox.Math.UnityToFoxVector3(topPos));
        }

        private static readonly Vector3 Scale = Vector3.one * 0.25f;
        public override Type GetNodeType() => typeof(GraphxSpatialGraphDataNode);

        public void OnDrawGizmos()
        {
            Gizmos.matrix = transform.localToWorldMatrix;

            foreach (GraphxSpatialGraphDataEdge edge in edges)
            {
                var prevNode = edge.prevNode as GraphxSpatialGraphDataNode;
                var nextNode = edge.nextNode as GraphxSpatialGraphDataNode;

                Gizmos.DrawLine(prevNode.position + topPos, nextNode.position + topPos);

                Gizmos.DrawLine(nextNode.position, nextNode.position + topPos);
            }
        }
    }
}