using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphDataEdge
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
        }
        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);
        }
        private static readonly float NormalLength = 0.25f;
        public void OnDrawGizmos()
        {
            var prevNodeData = prevNode as GraphxSpatialGraphDataNode;
            var nextNodeData = nextNode as GraphxSpatialGraphDataNode;

            if (!prevNodeData || !nextNodeData)
                return;

            if (prevNodeData.transform.parent is null || nextNodeData.transform.parent is null)
                return;

            Vector3 prevNodePos = prevNodeData.transform.parent.TransformPoint(prevNodeData.position);
            Vector3 nextNodePos = nextNodeData.transform.parent.TransformPoint(nextNodeData.position);

            Gizmos.color = EditorColors.PlayerUtilityColor;
            Gizmos.DrawLine(prevNodePos, nextNodePos);

            //Normals

            Vector3 pathVec = nextNodePos - prevNodePos; // Start index at 1 to guarantee i - 1 exists
            Vector3 lineNormalVec = Vector3.Cross(pathVec, Vector3.up).normalized;
            lineNormalVec *= NormalLength;

            // Gizmo draw +lineNormalVec in green
            Gizmos.color = Color.green;
            Gizmos.DrawLine(prevNodePos, prevNodePos - lineNormalVec);
            Gizmos.DrawLine(nextNodePos, nextNodePos - lineNormalVec);
            // Gizmo draw -lineNormalVec in red
            Gizmos.color = Color.red;
            Gizmos.DrawLine(prevNodePos, prevNodePos + lineNormalVec);
            Gizmos.DrawLine(nextNodePos, nextNodePos + lineNormalVec);
        }
    }
}