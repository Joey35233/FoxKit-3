using Fox.Core;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphData
    {
        public Matrix4x4 GetGraphWorldMatrix() => Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);

        public Vector3 GetGraphWorldPosition(Vector3 pos) => GetGraphWorldMatrix().MultiplyPoint(pos);

        public virtual Type GetNodeType() => typeof(GraphxSpatialGraphDataNode);
        public virtual Type GetEdgeType() => typeof(GraphxSpatialGraphDataEdge);

        public int IndexOf(GraphxSpatialGraphDataNode node)
        {
            return this.nodes.IndexOf(node);
        }

        public GraphxSpatialGraphDataNode GetGraphNode(int index)
        {
            return this.nodes[index];
        }

        public Fox.Graphx.GraphxSpatialGraphDataNode AddNodeAfter(Fox.Graphx.GraphxSpatialGraphDataNode node)
        {
            Undo.RegisterCompleteObjectUndo(this, "Add Node After");

            int index = IndexOf(node);
            if (index < 0)
                throw new System.ArgumentException("Node not found in graph.");

            var newNode = CreateNode();
            newNode.transform.SetParent(transform);

            var newEdge = CreateEdge();
            newEdge.transform.SetParent(transform);

            ConnectEdge(node, newNode, newEdge);

            // If needed, update any edges pointing to next node
            HandleSplice(node, newNode, newEdge);

            // Insert into lists
            nodes.Insert(index + 1, newNode);
            edges.Add(newEdge);

            EditorUtility.SetDirty(this);
            return newNode;
        }

        protected virtual void ConnectEdge(
            Fox.Graphx.GraphxSpatialGraphDataNode prev,
            Fox.Graphx.GraphxSpatialGraphDataNode next,
            Fox.Graphx.GraphxSpatialGraphDataEdge edge)
        {
            edge.prevNode = prev;
            edge.nextNode = next;

            prev.outlinks.Add(edge);
            next.inlinks.Add(edge);
        }

        protected virtual void HandleSplice(
            Fox.Graphx.GraphxSpatialGraphDataNode prev,
            Fox.Graphx.GraphxSpatialGraphDataNode inserted,
            Fox.Graphx.GraphxSpatialGraphDataEdge newEdge)
        {
            // Look for existing edge to a next node
            var existingEdge = edges.FirstOrDefault(e => e.prevNode == prev && e.nextNode != null && e != newEdge);
            if (existingEdge == null)
                return;

            var oldNext = existingEdge.nextNode as Fox.Graphx.GraphxSpatialGraphDataNode;
            existingEdge.prevNode = inserted;

            // Reconnect links
            prev.outlinks.Remove(existingEdge);
            inserted.outlinks.Add(existingEdge);

            if (oldNext != null)
            {
                oldNext.inlinks.Remove(existingEdge);
                oldNext.inlinks.Add(existingEdge);
            }
        }

        protected Fox.Graphx.GraphxSpatialGraphDataNode CreateNode()
        {
            var newNodeGo = new GameObject();
            Undo.SetTransformParent(newNodeGo.transform, transform, "Set new graph node's parent");
            Undo.RegisterCreatedObjectUndo(newNodeGo, "Added graph node");

            var nodeType = this.GetNodeType();
            var newNode = Undo.AddComponent(newNodeGo, nodeType) as Fox.Graphx.GraphxSpatialGraphDataNode;

            var usedNames = UnityEngine.Object.FindObjectsOfType(nodeType, true)
                .Select(ent => ent.name).ToHashSet();
            newNodeGo.name = newNode.GenerateUniqueName(nodeType, usedNames);

            return newNode;
        }

        protected Fox.Graphx.GraphxSpatialGraphDataEdge CreateEdge()
        {
            var newEdgeGo = new GameObject();
            Undo.SetTransformParent(newEdgeGo.transform, transform, "Set new graph edge's parent");
            Undo.RegisterCreatedObjectUndo(newEdgeGo, "Added graph edge");

            var edgeType = GetEdgeType();
            var edge = Undo.AddComponent(newEdgeGo, GetEdgeType()) as Fox.Graphx.GraphxSpatialGraphDataEdge;

            var usedNames = UnityEngine.Object.FindObjectsOfType(edgeType, true)
                .Select(ent => ent.name).ToHashSet();
            edge.name = edge.GenerateUniqueName(edgeType, usedNames);

            return edge;
        }
    }
}