using Fox.Core.Utils;
using Fox.Graphx;
using Fox;
using UnityEditor;
using UnityEngine;
using System;

namespace Fox.GameService
{
    public partial class GsRouteData : Fox.Graphx.GraphxSpatialGraphData
    {
        private static readonly Color DefaultColor = new Color(1.0f, (float)100 / System.Byte.MaxValue, (float)43 / System.Byte.MaxValue);
        private static readonly Color SelectedColor = Color.yellow;
        private static readonly Vector3 Scale = Vector3.one * 0.1f;
        private static readonly Vector3 ScaleNode = Vector3.one * 0.25f;
        public override Type GetNodeType() => typeof(GsRouteDataNode);
        public override Type GetEdgeType() => typeof(GsRouteDataEdge);
        public override Type GetEdgeEventType() => typeof(GsRouteDataEdgeEvent);
        public override Type GetNodeEventType() => typeof(GsRouteDataNodeEvent);

        [SerializeField] private string defaultEdgeEvent = "RelaxedStandWalkAct";
        [SerializeField] private string defaultNodeEvent = "";

        [SerializeField] private GsRouteDataNodeEvent templateNodeEvent;
        [SerializeField] private GsRouteDataEdgeEvent templateEdgeEvent;

        public override void AddNodeEvent(GraphxSpatialGraphDataNode node)
        {
            var routeNode = node as GsRouteDataNode;
            if (routeNode == null)
                return;

            Undo.RegisterCompleteObjectUndo(routeNode, "Add Node Event");

            var ev = BuildDefaultNodeEvent(routeNode);
            if (ev != null)
                routeNode.nodeEvents.Add(ev);

            EditorUtility.SetDirty(routeNode);
        }

        public override bool ResolveNodeEvents(GraphxSpatialGraphDataNode node, int fromIndex)
        {
            var routeNode = node as GsRouteDataNode;
            if (routeNode == null)
                return false;

            if (fromIndex < 0)
                fromIndex = 0;

            bool changed = false;
            for (int i = fromIndex; i < routeNode.nodeEvents.Count; i++)
            {
                var ev = routeNode.nodeEvents[i];

                bool needsFresh = ev == null;
                if (!needsFresh)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (routeNode.nodeEvents[j] == ev)
                        {
                            needsFresh = true;
                            break;
                        }
                    }
                }

                if (!needsFresh)
                    continue;

                var fresh = BuildDefaultNodeEvent(routeNode);
                if (fresh != null)
                {
                    routeNode.nodeEvents[i] = fresh;
                    changed = true;
                }
            }

            if (changed)
                EditorUtility.SetDirty(routeNode);

            return changed;
        }

        public override void SetNodeEventType(GraphxSpatialGraphDataNode node, int index, string friendlyName)
        {
            var routeNode = node as GsRouteDataNode;
            if (routeNode == null || index < 0 || index >= routeNode.nodeEvents.Count)
                return;

            var old = routeNode.nodeEvents[index];

            if (string.IsNullOrEmpty(friendlyName))
            {
                Undo.RegisterCompleteObjectUndo(routeNode, "Remove Node Event");
                routeNode.nodeEvents.RemoveAt(index);
                if (old != null)
                    Undo.DestroyObjectImmediate(old.gameObject);
                EditorUtility.SetDirty(routeNode);
                return;
            }

            var fresh = CreateDefaultEvent(new StrCode32(friendlyName), routeNode.transform) as GsRouteDataNodeEvent;
            if (fresh == null)
                return;

            if (old != null)
            {
                fresh.time = old.time;
                fresh.direction = old.direction;
                fresh.isLoop = old.isLoop;
            }
            else
            {
                fresh.time = 8f;
            }

            Undo.RegisterCompleteObjectUndo(routeNode, "Change Node Event Type");
            routeNode.nodeEvents[index] = fresh;
            if (old != null)
                Undo.DestroyObjectImmediate(old.gameObject);

            EditorUtility.SetDirty(routeNode);
        }

        private GsRouteDataNodeEvent BuildDefaultNodeEvent(GsRouteDataNode routeNode)
        {
            SyncEventTemplates();
            if (templateNodeEvent == null)
                return null;

            var fresh = CreateDefaultEvent(templateNodeEvent.GetId(), routeNode.transform) as GsRouteDataNodeEvent;
            if (fresh == null)
                return null;

            EditorUtility.CopySerialized(templateNodeEvent, fresh);
            return fresh;
        }

        protected override void OnEdgeCreated(GraphxSpatialGraphDataEdge edge)
        {
            var routeEdge = edge as GsRouteDataEdge;
            if (routeEdge == null || routeEdge.edgeEvent != null)
                return;

            SyncEventTemplates();
            if (templateEdgeEvent == null)
                return;

            var fresh = CreateDefaultEvent(templateEdgeEvent.GetId(), routeEdge.transform) as GsRouteDataEdgeEvent;
            if (fresh == null)
                return;

            EditorUtility.CopySerialized(templateEdgeEvent, fresh);
            routeEdge.edgeEvent = fresh;
        }

        private static GsRouteDataRouteEvent CreateDefaultEvent(StrCode32 id, Transform parent)
        {
            if (!GameServiceModule.GsRouteDataEventDeserializationMap.TryGetValue(id, out var deserialize))
                return null;

            var go = new GameObject();
            Undo.RegisterCreatedObjectUndo(go, "Add Default Route Event");

            GsRouteDataRouteEvent ev = deserialize(go, new uint[4]);
            go.transform.SetParent(parent, false);
            go.name = ev.GetType().Name;
            return ev;
        }

        public override void SyncEventTemplates()
        {
            var newNode = SyncTemplate(templateNodeEvent, defaultNodeEvent, "Default Node Event") as GsRouteDataNodeEvent;
            var newEdge = SyncTemplate(templateEdgeEvent, defaultEdgeEvent, "Default Edge Event") as GsRouteDataEdgeEvent;

            if (newNode == templateNodeEvent && newEdge == templateEdgeEvent)
                return;

            if (newNode != null && newNode != templateNodeEvent)
                newNode.time = 8f;

            templateNodeEvent = newNode;
            templateEdgeEvent = newEdge;
            EditorUtility.SetDirty(this);
        }

        public override UnityEngine.Object GetNodeEventTemplate() => templateNodeEvent;
        public override UnityEngine.Object GetEdgeEventTemplate() => templateEdgeEvent;

        private GsRouteDataRouteEvent SyncTemplate(GsRouteDataRouteEvent existing, string typeName, string label)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                if (existing != null)
                    Undo.DestroyObjectImmediate(existing.gameObject);
                return null;
            }

            StrCode32 wanted = new StrCode32(typeName);
            if (existing != null && existing.GetId().Equals(wanted))
                return existing;

            if (existing != null)
                Undo.DestroyObjectImmediate(existing.gameObject);

            var fresh = CreateDefaultEvent(wanted, this.transform);
            if (fresh != null)
            {
                fresh.gameObject.name = label;
                fresh.gameObject.hideFlags = HideFlags.HideInHierarchy;
            }
            return fresh;
        }

        private void DrawGizmos(bool isSelected)
        {
            Gizmos.matrix = this.transform.localToWorldMatrix;
            Gizmos.color = isSelected ? SelectedColor : DefaultColor;

            for (int nodeIndex = 0; nodeIndex < nodes.Count; nodeIndex++)
            {
                var node = (GsRouteDataNode)nodes[nodeIndex];

                Gizmos.DrawWireCube(node.position, ScaleNode);

                for (int edgeIndex = 0; edgeIndex < node.outlinks.Count; edgeIndex++)
                {
                    var edge = node.outlinks[edgeIndex] as GsRouteDataEdge;
                    if (edge == null)
                        continue;

                    var prevNode = edge.prevNode as GsRouteDataNode;
                    var nextNode = edge.nextNode as GsRouteDataNode;
                    if (prevNode == null || nextNode == null)
                        continue;

                    Gizmos.DrawLine(prevNode.position, nextNode.position);
                }
            }
        }

        public void OnDrawGizmos() => DrawGizmos(false);

        public void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}