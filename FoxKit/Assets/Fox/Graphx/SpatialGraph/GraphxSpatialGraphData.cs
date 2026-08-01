using Fox.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphData
    {
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

            var incoming = edges.FirstOrDefault(e => e.nextNode == node);   // pred -> node
            var outgoing = edges.FirstOrDefault(e => e.prevNode == node);   // node -> succ
            var pred = incoming?.prevNode as GraphxSpatialGraphDataNode;
            var succ = outgoing?.nextNode as GraphxSpatialGraphDataNode;

            if (pred != null && succ != null && pred != succ)
            {
                incoming.nextNode = succ;
                incoming.transform.SetParent(succ.transform); // re-parent under the new nextNode so it survives the node's deletion
                succ.outlinks.Remove(outgoing);
                succ.outlinks.Add(incoming);
                RemoveEdge(outgoing);
            }
            else
            {
                foreach (var edge in edges.Where(e => e.prevNode == node || e.nextNode == node).ToList())
                {
                    (edge.prevNode as GraphxSpatialGraphDataNode)?.outlinks.Remove(edge);
                    (edge.nextNode as GraphxSpatialGraphDataNode)?.outlinks.Remove(edge);
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
            edge.prevNode = prev;
            edge.nextNode = next;

            prev.outlinks.Add(edge);

            next.outlinks.Add(edge);

            edge.transform.SetParent(next.transform);
        }

        protected virtual void HandleSplice(GraphxSpatialGraphDataNode prev, GraphxSpatialGraphDataNode inserted, GraphxSpatialGraphDataEdge newEdge)
        {
            var existingEdge = edges.FirstOrDefault(e => e.prevNode == prev && e.nextNode != null && e != newEdge);
            if (existingEdge == null)
                return;

            var oldNext = existingEdge.nextNode as GraphxSpatialGraphDataNode;
            existingEdge.prevNode = inserted;

            prev.outlinks.Remove(existingEdge);
            inserted.outlinks.Add(existingEdge);

            if (oldNext != null)
            {
                oldNext.outlinks.Remove(existingEdge);
                oldNext.outlinks.Add(existingEdge);
            }
        }
        protected void CreateLoopEdge()
        {
            var firstNode = nodes.First();
            var lastNode = nodes.Last();

            if (IsLoop() && firstNode.outlinks.Count < 2 && lastNode.outlinks.Count < 2)
            {
                var loopEdge = CreateEdge();

                loopEdge.prevNode = lastNode;
                loopEdge.nextNode = firstNode;
                loopEdge.transform.SetParent(firstNode.transform);

                lastNode.outlinks.Add(loopEdge);
                firstNode.outlinks.Add(loopEdge);

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

            var usedNames = FindObjectsByType(nodeType, FindObjectsInactive.Include, FindObjectsSortMode.None)
                .Select(ent => ent.name).ToHashSet();
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

            var usedNames = FindObjectsByType(edgeType, FindObjectsInactive.Include, FindObjectsSortMode.None)
                .Select(ent => ent.name).ToHashSet();
            edge.name = edge.GenerateUniqueName(edgeType, usedNames);

            OnEdgeCreated(edge);
            return edge;
        }

        protected virtual void OnNodeCreated(GraphxSpatialGraphDataNode node) { }
        protected virtual void OnEdgeCreated(GraphxSpatialGraphDataEdge edge) { }
    }
}