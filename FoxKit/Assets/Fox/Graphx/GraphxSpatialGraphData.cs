using Fox.Core;
using Fox.Core.Utils;
using System;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphData
    {
        public Matrix4x4 GetGraphWorldMatrix() => Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);

        public Vector3 GetGraphWorldPosition(Vector3 pos) => GetGraphWorldMatrix().MultiplyPoint(pos);

        public virtual Type GetNodeType() => typeof(GraphxSpatialGraphDataNode);

        public int IndexOf(GraphxSpatialGraphDataNode node)
        {
            return this.nodes.IndexOf(node);
        }

        public GraphxSpatialGraphDataNode GetGraphNode(int index)
        {
            return this.nodes[index];
        }

        /// <summary>
        /// Add a node at the specified index.
        /// </summary>
        /// <param name="index">Index to insert at.</param>
        /// <param name="node">The new node.</param>
        public void AddGraphNode(int index, GraphxSpatialGraphDataNode node)
        {
            this.nodes.Insert(index, node);
        }

        private static readonly Color Color = Color.white;
        private static readonly Vector3 Scale = Vector3.one * 0.1f;
        private static readonly Vector3 ScaleNode = Vector3.one * 0.25f;
        private static readonly float NormalLength = 0.25f;

        public void OnDrawGizmos()
        {
            Gizmos.matrix = Matrix4x4.identity;

            for (int nodeIndex = 0; nodeIndex < nodes.Count; nodeIndex++)
            {
                Graphx.GraphxSpatialGraphDataNode node = nodes[nodeIndex];

                if (!node)
                    return;

                Gizmos.color = EditorColors.PlayerUtilityColor;
                Gizmos.DrawWireCube(this.transform.TransformPoint(node.position), ScaleNode);

                for (int edgeIndex = 0; edgeIndex < node.outlinks.Count; edgeIndex++)
                {
                    var edge = node.outlinks[edgeIndex] as GraphxSpatialGraphDataEdge;

                    if (!edge)
                        return;

                    var prevNode = edge.prevNode as GraphxSpatialGraphDataNode;
                    var nextNode = edge.nextNode as GraphxSpatialGraphDataNode;

                    if (!prevNode || !nextNode)
                        return;

                    Vector3 prevNodePos = this.transform.TransformPoint(prevNode.position);
                    Vector3 nextNodePos = this.transform.TransformPoint(nextNode.position);

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
    }
}