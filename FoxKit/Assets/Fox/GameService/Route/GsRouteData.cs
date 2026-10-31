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
        public override Type GetNodeType() => typeof(GsRouteDataNode);
        public override Type GetEdgeType() => typeof(GsRouteDataEdge);
        public Type GetEdgeEventType() => typeof(GsRouteDataEdgeEvent);
        public Type GetNodeEventType() => typeof(GsRouteDataNodeEvent);

        [SerializeField] private string DefaultEdgeEvent = "RelaxedStandWalkAct";
        [SerializeField] private string DefaultNodeEvent = "";

        [SerializeField] private GsRouteDataNodeEvent templateNodeEvent;
        [SerializeField] private GsRouteDataEdgeEvent templateEdgeEvent;

        public void AddNodeEvent(GraphxSpatialGraphDataNode node)
        {
            GsRouteDataNode routeNode = node as GsRouteDataNode;
            if (routeNode == null)
                return;

            Undo.RegisterCompleteObjectUndo(routeNode, "Add Node Event");

            GsRouteDataNodeEvent ev = BuildDefaultNodeEvent(routeNode);
            if (ev != null)
                routeNode.Events.Add(ev);

            EditorUtility.SetDirty(routeNode);
        }

        public bool ResolveNodeEvents(GraphxSpatialGraphDataNode node, int fromIndex)
        {
            GsRouteDataNode routeNode = node as GsRouteDataNode;
            if (routeNode == null)
                return false;

            if (fromIndex < 0)
                fromIndex = 0;

            bool changed = false;
            for (int i = fromIndex; i < routeNode.Events.Count; i++)
            {
                GsRouteDataNodeEvent nodeEvent = routeNode.Events[i];

                bool needsFresh = nodeEvent == null;
                if (!needsFresh)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (routeNode.Events[j] == nodeEvent)
                        {
                            needsFresh = true;
                            break;
                        }
                    }
                }

                if (!needsFresh)
                    continue;

                GsRouteDataNodeEvent fresh = BuildDefaultNodeEvent(routeNode);
                if (fresh != null)
                {
                    routeNode.Events[i] = fresh;
                    changed = true;
                }
            }

            if (changed)
                EditorUtility.SetDirty(routeNode);

            return changed;
        }

        public void SetNodeEventType(GraphxSpatialGraphDataNode node, int index, string id)
        {
            GsRouteDataNode routeNode = node as GsRouteDataNode;
            if (routeNode == null || index < 0 || index >= routeNode.Events.Count)
                return;

            GsRouteDataNodeEvent oldEvent = routeNode.Events[index];

            if (string.IsNullOrEmpty(id))
            {
                Undo.RegisterCompleteObjectUndo(routeNode, "Remove Node Event");
                routeNode.Events.RemoveAt(index);
                if (oldEvent != null)
                    Undo.DestroyObjectImmediate(oldEvent.gameObject);
                EditorUtility.SetDirty(routeNode);
                return;
            }

            GsRouteDataNodeEvent newEvent = CreateDefaultNodeEvent(id, routeNode.transform);
            if (newEvent == null)
                return;

            if (oldEvent != null)
            {
                newEvent.Time = oldEvent.Time;
                newEvent.Dir = oldEvent.Dir;
                newEvent.IsLoop = oldEvent.IsLoop;
            }
            else
            {
                newEvent.Time = 8f;
            }

            Undo.RegisterCompleteObjectUndo(routeNode, "Change Node Event Type");
            routeNode.Events[index] = newEvent;
            if (oldEvent != null)
                Undo.DestroyObjectImmediate(oldEvent.gameObject);

            EditorUtility.SetDirty(routeNode);
        }

        private GsRouteDataNodeEvent BuildDefaultNodeEvent(GsRouteDataNode routeNode)
        {
            SyncEventTemplates();
            if (templateNodeEvent == null)
                return null;

            GsRouteDataNodeEvent fresh = CreateDefaultNodeEvent(templateNodeEvent.Id, routeNode.transform);
            if (fresh == null)
                return null;

            EditorUtility.CopySerialized(templateNodeEvent, fresh);
            return fresh;
        }

        protected override void OnEdgeCreated(GraphxSpatialGraphDataEdge edge)
        {
            GsRouteDataEdge routeEdge = edge as GsRouteDataEdge;
            if (routeEdge == null || routeEdge.Event != null)
                return;

            SyncEventTemplates();
            if (templateEdgeEvent == null)
                return;

            GsRouteDataEdgeEvent fresh = CreateDefaultEdgeEvent(templateEdgeEvent.Id, routeEdge.transform);
            if (fresh == null)
                return;

            EditorUtility.CopySerialized(templateEdgeEvent, fresh);
            routeEdge.Event = fresh;
        }

        private static GsRouteDataNodeEvent CreateDefaultNodeEvent(string id, Transform parent)
        {
            var go = new GameObject();
            Undo.RegisterCreatedObjectUndo(go, "Add Default Node Event");
            
            GsRouteDataNodeEvent nodeEvent = (GsRouteDataNodeEvent)(GameServiceModule.RouteNodeEventTypeMap.TryGetValue(new StrCode32(id), out Type eventType)
                ? go.AddComponent(eventType)
                : go.AddComponent<GsRouteDataNodeEvent>());
            
            go.transform.SetParent(parent, false);
            go.name = nodeEvent.GetClassEntityInfo().Name;
            nodeEvent.Id = id;
            return nodeEvent;
        }

        private static GsRouteDataEdgeEvent CreateDefaultEdgeEvent(string id, Transform parent)
        {
            var go = new GameObject();
            Undo.RegisterCreatedObjectUndo(go, "Add Default Edge Event");
            
            GsRouteDataEdgeEvent edgeEvent = (GsRouteDataEdgeEvent)(GameServiceModule.RouteEdgeEventTypeMap.TryGetValue(new StrCode32(id), out Type eventType)
                ? go.AddComponent(eventType)
                : go.AddComponent<GsRouteDataEdgeEvent>());
            
            go.transform.SetParent(parent, false);
            go.name = edgeEvent.GetClassEntityInfo().Name;
            edgeEvent.Id = id;
            return edgeEvent;
        }

        public void SyncEventTemplates()
        {
            var newNode = SyncTemplate(templateNodeEvent, DefaultNodeEvent, "Default Node Event") as GsRouteDataNodeEvent;
            var newEdge = SyncTemplate(templateEdgeEvent, DefaultEdgeEvent, "Default Edge Event") as GsRouteDataEdgeEvent;

            if (newNode == templateNodeEvent && newEdge == templateEdgeEvent)
                return;

            if (newNode != null && newNode != templateNodeEvent)
                newNode.Time = 8f;

            templateNodeEvent = newNode;
            templateEdgeEvent = newEdge;
            EditorUtility.SetDirty(this);
        }

        public UnityEngine.Object GetNodeEventTemplate() => templateNodeEvent;
        public UnityEngine.Object GetEdgeEventTemplate() => templateEdgeEvent;

        private GsRouteDataNodeEvent SyncTemplate(GsRouteDataNodeEvent existing, string id, string label)
        {
            if (string.IsNullOrEmpty(id))
            {
                if (existing != null)
                    Undo.DestroyObjectImmediate(existing.gameObject);
                return null;
            }

            if (existing != null && new StrCode32(id) == new StrCode32(existing.Id))
                return existing;

            if (existing != null)
                Undo.DestroyObjectImmediate(existing.gameObject);

            var fresh = CreateDefaultNodeEvent(id, this.transform);
            if (fresh != null)
            {
                fresh.gameObject.name = label;
                fresh.gameObject.hideFlags = HideFlags.HideInHierarchy;
            }
            return fresh;
        }
        
        private GsRouteDataEdgeEvent SyncTemplate(GsRouteDataEdgeEvent existing, string id, string label)
        {
            if (string.IsNullOrEmpty(id))
            {
                if (existing != null)
                    Undo.DestroyObjectImmediate(existing.gameObject);
                return null;
            }

            if (existing != null && new StrCode32(id) == new StrCode32(existing.Id))
                return existing;

            if (existing != null)
                Undo.DestroyObjectImmediate(existing.gameObject);

            var fresh = CreateDefaultEdgeEvent(id, this.transform);
            if (fresh != null)
            {
                fresh.gameObject.name = label;
                fresh.gameObject.hideFlags = HideFlags.HideInHierarchy;
            }
            return fresh;
        }

    }
}