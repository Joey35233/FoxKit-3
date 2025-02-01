using Fox.Core;
using System;
using UnityEngine;
using UnityEngine.UIElements;

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
    }
}