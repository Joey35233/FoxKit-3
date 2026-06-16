using Assets.Fox.EdGraphx;
using Fox.Core;
using Fox.EdCore;
using Fox.Graphx;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdGraphx
{
    [CustomEditor(typeof(GraphxSpatialGraphDataNode), editorForChildClasses: true)]
    public class GraphxSpatialGraphDataNodeEditor : EntityEditor
    {
        private GraphxSpatialGraphDataNode Node => (GraphxSpatialGraphDataNode)target;

        private bool HasFrameBounds() => Node.transform.parent.GetComponent<GraphxSpatialGraphData>() is not null;

        public Bounds OnGetFrameBounds() => new Bounds(Node.transform.parent.GetComponent<GraphxSpatialGraphData>().GetGraphWorldPosition(Node.position), new Vector3(1, 1, 1));

        private void OnEnable()
        {
            Tools.hidden = true;
        }

        private void OnDisable()
        {
            Tools.hidden = false;
        }

        protected virtual void OnSceneGUI()
        {
            var graph = Node.transform.GetComponentInParent<GraphxSpatialGraphData>();
            if (graph == null)
                return;

            Handles.matrix = graph.GetGraphWorldMatrix();

            EditorGUI.BeginChangeCheck();
            Vector3 newTargetPosition = Handles.PositionHandle(Node.position, Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(Node, "Move GraphxSpatialGraphDataNode");
                Node.position = newTargetPosition;
            }

            if (Node.GetDirectionCount() > 0)
                DrawDirectionHandles();
        }

        private void DrawDirectionHandles()
        {
            Vector3 nodePos = Node.position;
            float size = HandleUtility.GetHandleSize(nodePos);
            int count = Node.GetDirectionCount();

            for (int i = 0; i < count; i++)
            {
                float dir = Node.GetDirection(i);
                Quaternion rot = Quaternion.Euler(0f, dir, 0f);
                Vector3 forward = rot * Vector3.forward;
                float radius = size * (1.2f + i * 0.5f);
                Vector3 tip = nodePos + forward * radius;

                Handles.color = Color.cyan;
                Handles.DrawLine(nodePos, tip);
                Handles.ConeHandleCap(0, tip, Quaternion.LookRotation(forward), size * 0.15f, EventType.Repaint);

                EditorGUI.BeginChangeCheck();
                Quaternion newRot = Handles.Disc(rot, nodePos, Vector3.up, radius, false, 0f);
                if (EditorGUI.EndChangeCheck())
                    Node.SetDirection(i, newRot.eulerAngles.y);
            }
        }

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement container = new VisualElement();

            Button addNodeButton = new Button();
            addNodeButton.text = "Add Node";
            addNodeButton.clicked += OnAddNodeButtonClicked;
            container.Add(addNodeButton);

            Button deleteNodeButton = new Button();
            deleteNodeButton.text = "Delete Node";
            deleteNodeButton.clicked += OnDeleteNodeButtonClicked;
            container.Add(deleteNodeButton);

            Button nextNodeButton = new Button();
            nextNodeButton.text = "Next Node";
            nextNodeButton.clicked += OnNextNodeButtonClicked;
            container.Add(nextNodeButton);

            Button previousNodeButton = new Button();
            previousNodeButton.text = "Previous Node";
            previousNodeButton.clicked += OnPreviousNodeButtonClicked;
            container.Add(previousNodeButton);

            Button graphButton = new Button();
            graphButton.text = "Select Graph";
            graphButton.clicked += OnGraphButtonClicked;
            container.Add(graphButton);

            var eventGraph = Node.transform.GetComponentInParent<GraphxSpatialGraphData>();
            if (eventGraph != null && eventGraph.GetNodeEventType() != null)
            {
                Button addNodeEventButton = new Button();
                addNodeEventButton.text = "Add Node Event";
                addNodeEventButton.clicked += OnAddNodeEventButtonClicked;
                container.Add(addNodeEventButton);

                VisualElement eventTypeSection = new VisualElement();
                container.Add(eventTypeSection);
                int builtCount = -1;
                int filledCount = Node.GetDirectionCount();

                container.schedule.Execute(() =>
                {
                    if (target == null || eventGraph == null)
                        return;

                    int count = Node.GetDirectionCount();

                    if (count > filledCount && eventGraph.ResolveNodeEvents(Node, filledCount))
                        serializedObject.Update();
                    filledCount = count;

                    if (count != builtCount)
                    {
                        BuildEventTypeDropdowns(eventTypeSection, eventGraph);
                        builtCount = count;
                    }
                }).Every(200);
            }

            GraphxSpatialGraphDataField field = new GraphxSpatialGraphDataField();
            field.Build(this.serializedObject);
            container.Add(field);

            return container;
        }

        private void OnAddNodeButtonClicked()
        {
            var graph = Node.transform.GetComponentInParent<GraphxSpatialGraphData>();
            if (graph == null)
            {
                Debug.LogError($"Parent GameObject is not a ${nameof(GraphxSpatialGraphData)}.");
                return;
            }

            var index = graph.IndexOf(Node);
            if (index == -1)
            {
                Debug.LogError($"Node is not assigned to parent's {nameof(GraphxSpatialGraphData.nodes)} property.");
                return;
            }

            // Create node at current position
            var newNode = graph.AddNodeAfter(Node);
            newNode.position = Node.position;
            Selection.activeGameObject = newNode.gameObject;
        }

        private void OnDeleteNodeButtonClicked()
        {
            var graph = Node.transform.GetComponentInParent<GraphxSpatialGraphData>();
            if (graph == null)
            {
                Debug.LogError($"Parent GameObject is not a {nameof(GraphxSpatialGraphData)}.");
                return;
            }

            var index = graph.IndexOf(Node);
            if (index == -1)
            {
                Debug.LogError($"Node is not assigned to parent's {nameof(GraphxSpatialGraphData.nodes)} property.");
                return;
            }

            GameObject selectAfter = graph.gameObject;
            if (graph.nodes.Count > 1)
            {
                int neighbourIndex;
                if (index > 0)
                    neighbourIndex = index - 1;
                else
                    neighbourIndex = 1;
                selectAfter = graph.GetGraphNode(neighbourIndex).gameObject;
            }

            graph.RemoveNode(Node);
            Selection.activeGameObject = selectAfter;
        }

        private void OnNextNodeButtonClicked()
        {
            var graph = Node.transform.GetComponentInParent<GraphxSpatialGraphData>();
            if (graph == null)
            {
                Debug.LogError($"Parent GameObject is not a {nameof(GraphxSpatialGraphData)}.");
                return;
            }

            var index = graph.IndexOf(Node);
            if (index == -1)
            {
                Debug.LogError($"Node is not assigned to parent's {nameof(GraphxSpatialGraphData.nodes)} property.");
                return;
            }

            var nextIndex = index + 1;
            if (nextIndex >= graph.nodes.Count)
            {
                nextIndex = 0;
            }

            var nextNode = graph.GetGraphNode(nextIndex);
            if (nextNode == null)
            {
                Debug.LogError($"Next graph node is null. Did you delete a node without removing it from parent's {nameof(GraphxSpatialGraphData.nodes)} property?");
            }

            Selection.activeGameObject = nextNode.gameObject;
        }

        private void OnPreviousNodeButtonClicked()
        {
            var graph = Node.transform.GetComponentInParent<GraphxSpatialGraphData>();
            if (graph == null)
            {
                Debug.LogError($"Parent GameObject is not a ${nameof(GraphxSpatialGraphData)}.");
                return;
            }

            var index = graph.IndexOf(Node);
            if (index == -1)
            {
                Debug.LogError($"Node is not assigned to parent's {nameof(GraphxSpatialGraphData.nodes)} property.");
                return;
            }

            var nextIndex = index - 1;
            if (nextIndex < 0)
            {
                nextIndex = graph.nodes.Count - 1;
            }

            var nextNode = graph.GetGraphNode(nextIndex);
            if (nextNode == null)
            {
                Debug.LogError($"Previous graph node is null. Did you delete a node without removing it from parent's {nameof(GraphxSpatialGraphData.nodes)} property?");
            }

            Selection.activeGameObject = nextNode.gameObject;
        }

        private void OnGraphButtonClicked()
        {
            var graph = Node.transform.GetComponentInParent<GraphxSpatialGraphData>();
            if (graph == null)
            {
                Debug.LogError($"Parent GameObject is not a ${nameof(GraphxSpatialGraphData)}.");
                return;
            }

            Selection.activeGameObject = graph.gameObject;
        }

        private void OnAddNodeEventButtonClicked()
        {
            var graph = Node.transform.GetComponentInParent<GraphxSpatialGraphData>();
            if (graph == null)
            {
                Debug.LogError($"Parent GameObject is not a {nameof(GraphxSpatialGraphData)}.");
                return;
            }

            int undoGroup = Undo.GetCurrentGroup();
            graph.AddNodeEvent(Node);
            Undo.CollapseUndoOperations(undoGroup);
        }

        private void BuildEventTypeDropdowns(VisualElement section, GraphxSpatialGraphData eventGraph)
        {
            section.Clear();

            Type typeBase = eventGraph.GetNodeEventType();
            if (typeBase == null)
                return;

            const string none = "(None)";
            List<string> choices = new List<string> { none };

            List<string> names = new List<string>();
            foreach (Type type in TypeCache.GetTypesDerivedFrom(typeBase))
            {
                if (type.IsAbstract)
                    continue;

                names.Add(FriendlyEventName(type));
            }
            names.Sort();
            choices.AddRange(names);

            int count = Node.GetDirectionCount();
            for (int i = 0; i < count; i++)
            {
                int index = i;
                Type type = Node.GetNodeEventTypeAt(index);
                string currentName = type != null ? FriendlyEventName(type) : none;

                int selected = choices.IndexOf(currentName);
                if (selected < 0)
                    selected = 0;

                PopupField<string> dropdown = new PopupField<string>($"Event {index} Type", choices, selected);
                dropdown.RegisterValueChangedCallback(evt =>
                    eventGraph.SetNodeEventType(Node, index, evt.newValue == none ? "" : evt.newValue));
                section.Add(dropdown);
            }
        }

        private static string FriendlyEventName(Type type)
        {
            string name = type.Name;
            if (name.StartsWith("TppRoute"))
                name = name.Substring("TppRoute".Length);

            if (name.EndsWith("EdgeEvent"))
                name = name.Substring(0, name.Length - "EdgeEvent".Length);
            else if (name.EndsWith("NodeEvent"))
                name = name.Substring(0, name.Length - "NodeEvent".Length);

            return name;
        }
    }
}