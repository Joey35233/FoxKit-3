using Fox.Core;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphData
    {
        public List<Fox.Graphx.GraphxSpatialGraphDataEdge> Edges => edges;
        public List<Fox.Graphx.GraphxSpatialGraphDataNode> Nodes => nodes;

        public bool HasBounds() => nodes.Count > 0;
        
        public Bounds GetWorldBounds()
        {
            Bounds bounds = new Bounds(nodes[0].transform.position, Vector3.zero);
            for (int i = 1; i < nodes.Count; i++)
                bounds.Encapsulate(nodes[i].transform.position);

            return bounds;
        }

        public bool IsVisibleInFrustum(Camera camera)
        {
            if (camera == null || nodes.Count == 0)
                return true;

            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
            return GeometryUtility.TestPlanesAABB(planes, GetWorldBounds());
        }

        public virtual Type GetNodeType() => typeof(GraphxSpatialGraphDataNode);
        public virtual Type GetEdgeType() => typeof(GraphxSpatialGraphDataEdge);
        public virtual bool IsLoop() => true;

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
            var newEdge = CreateEdge();

            ConnectEdge(node, newNode, newEdge);

            HandleSplice(node, newNode, newEdge);

            nodes.Insert(index + 1, newNode);
            edges.Add(newEdge);

            CreateLoopEdge();

            EditorUtility.SetDirty(this);
            return newNode;
        }

        public GraphxSpatialGraphDataNode AddNode()
        {
            if (nodes.Count == 0)
            {
                Undo.RegisterCompleteObjectUndo(this, "Add First Node");

                var first = CreateNode();
                nodes.Add(first);

                EditorUtility.SetDirty(this);
                return first;
            }

            return AddNodeAfter(nodes[nodes.Count - 1]);
        }

        public void RemoveNode(GraphxSpatialGraphDataNode node)
        {
            int index = IndexOf(node);
            if (index < 0)
                return;

            Undo.RegisterCompleteObjectUndo(this, "Remove Node");

            GraphxSpatialGraphDataEdge incoming = null;
            GraphxSpatialGraphDataEdge outgoing = null;
            foreach (GraphxSpatialGraphDataEdge edge in edges)
            {
                if (incoming == null && edge.NextNode == node)
                    incoming = edge;
                if (outgoing == null && edge.PrevNode == node)
                    outgoing = edge;
                if (incoming != null && outgoing != null)
                    break;
            }
            var pred = incoming?.PrevNode as GraphxSpatialGraphDataNode;
            var succ = outgoing?.NextNode as GraphxSpatialGraphDataNode;

            if (pred != null && succ != null && pred != succ)
            {
                incoming.NextNode = succ;
                incoming.transform.SetParent(succ.transform); // re-parent under the new nextNode so it survives the node's deletion
                succ.Outlinks.Remove(outgoing);
                succ.Outlinks.Add(incoming);
                RemoveEdge(outgoing);
            }
            else
            {
                // Collect first because RemoveEdge modifies the edge list.
                List<GraphxSpatialGraphDataEdge> connectedEdges = new();
                foreach (GraphxSpatialGraphDataEdge edge in edges)
                    if (edge.PrevNode == node || edge.NextNode == node)
                        connectedEdges.Add(edge);
                foreach (GraphxSpatialGraphDataEdge edge in connectedEdges)
                {
                    (edge.PrevNode as GraphxSpatialGraphDataNode)?.Outlinks.Remove(edge);
                    (edge.NextNode as GraphxSpatialGraphDataNode)?.Outlinks.Remove(edge);
                    RemoveEdge(edge);
                }
            }

            nodes.RemoveAt(index);
            Undo.DestroyObjectImmediate(node.gameObject);

            EditorUtility.SetDirty(this);
        }

        private void RemoveEdge(GraphxSpatialGraphDataEdge edge)
        {
            edges.Remove(edge);
            Undo.DestroyObjectImmediate(edge.gameObject);
        }

        protected virtual void ConnectEdge(GraphxSpatialGraphDataNode prev, GraphxSpatialGraphDataNode next, GraphxSpatialGraphDataEdge edge)
        {
            edge.PrevNode = prev;
            edge.NextNode = next;

            prev.Outlinks.Add(edge);

            next.Outlinks.Add(edge);

            edge.transform.SetParent(next.transform);
        }

        protected virtual void HandleSplice(GraphxSpatialGraphDataNode prev, GraphxSpatialGraphDataNode inserted, GraphxSpatialGraphDataEdge newEdge)
        {
            GraphxSpatialGraphDataEdge existingEdge = null;
            foreach (GraphxSpatialGraphDataEdge edge in edges)
            {
                if (edge.PrevNode == prev && edge.NextNode != null && edge != newEdge)
                {
                    existingEdge = edge;
                    break;
                }
            }
            if (existingEdge == null)
                return;

            var oldNext = existingEdge.NextNode as GraphxSpatialGraphDataNode;
            existingEdge.PrevNode = inserted;

            prev.Outlinks.Remove(existingEdge);
            inserted.Outlinks.Add(existingEdge);

            if (oldNext != null)
            {
                oldNext.Outlinks.Remove(existingEdge);
                oldNext.Outlinks.Add(existingEdge);
            }
        }
        protected void CreateLoopEdge()
        {
            var firstNode = nodes[0];
            var lastNode = nodes[nodes.Count - 1];

            if (IsLoop() && firstNode.Outlinks.Count < 2 && lastNode.Outlinks.Count < 2)
            {
                var loopEdge = CreateEdge();

                loopEdge.PrevNode = lastNode;
                loopEdge.NextNode = firstNode;
                loopEdge.transform.SetParent(firstNode.transform);

                lastNode.Outlinks.Add(loopEdge);
                firstNode.Outlinks.Add(loopEdge);

                edges.Add(loopEdge);
            }
        }

        protected GraphxSpatialGraphDataNode CreateNode()
        {
            var newNodeGo = new GameObject();
            Undo.SetTransformParent(newNodeGo.transform, transform, "Set new graph node's parent");
            Undo.RegisterCreatedObjectUndo(newNodeGo, "Added graph node");

            var nodeType = this.GetNodeType();
            var newNode = Undo.AddComponent(newNodeGo, nodeType) as Fox.Graphx.GraphxSpatialGraphDataNode;

            HashSet<string> usedNames = new();
            foreach (UnityEngine.Object entity in FindObjectsByType(nodeType, FindObjectsInactive.Include, FindObjectsSortMode.None))
                usedNames.Add(entity.name);
            newNodeGo.name = newNode.GenerateUniqueName(nodeType, usedNames);

            OnNodeCreated(newNode);
            return newNode;
        }

        protected GraphxSpatialGraphDataEdge CreateEdge()
        {
            var newEdgeGo = new GameObject();
            Undo.SetTransformParent(newEdgeGo.transform, transform, "Set new graph edge's parent");
            Undo.RegisterCreatedObjectUndo(newEdgeGo, "Added graph edge");

            var edgeType = GetEdgeType();
            var edge = Undo.AddComponent(newEdgeGo, GetEdgeType()) as GraphxSpatialGraphDataEdge;

            HashSet<string> usedNames = new();
            foreach (UnityEngine.Object entity in FindObjectsByType(edgeType, FindObjectsInactive.Include, FindObjectsSortMode.None))
                usedNames.Add(entity.name);
            edge.name = edge.GenerateUniqueName(edgeType, usedNames);

            OnEdgeCreated(edge);
            return edge;
        }

        protected virtual void OnNodeCreated(GraphxSpatialGraphDataNode node) { }
        protected virtual void OnEdgeCreated(GraphxSpatialGraphDataEdge edge) { }
    }
}