using Fox.Core;
using Fox.Core.Utils;
using Fox.Graphx;
using UnityEngine;
using System;
using UnityEditor;

namespace Fox.Navx
{
    public partial class NavxAttributePathVolume : Fox.Graphx.GraphxPathVolume
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            topPos = Fox.Math.FoxToUnityVector3(topPos);
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            context.OverrideProperty(nameof(topPos), Fox.Math.UnityToFoxVector3(topPos));
        }

        public void OnDrawGizmos()
        {
            Gizmos.matrix = transform.localToWorldMatrix;

            foreach (GraphxSpatialGraphDataEdge edge in edges)
            {
                var prevNode = edge.prevNode as GraphxSpatialGraphDataNode;
                var nextNode = edge.nextNode as GraphxSpatialGraphDataNode;

                Gizmos.DrawLine(prevNode.transform.localPosition + topPos, nextNode.transform.localPosition + topPos);

                Gizmos.DrawLine(nextNode.transform.localPosition, nextNode.transform.localPosition + topPos);
            }
        }
    }
}