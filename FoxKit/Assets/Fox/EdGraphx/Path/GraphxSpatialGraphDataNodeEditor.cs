﻿using Assets.Fox.EdGraphx;
using Fox.Core;
using Fox.EdCore;
using Fox.Graphx;
using System;
using System.Linq;
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
            GraphxSpatialGraphData graph = Node.transform.parent.GetComponent<GraphxSpatialGraphData>();

            Handles.matrix = graph.GetGraphWorldMatrix();

            EditorGUI.BeginChangeCheck();
            Vector3 newTargetPosition = Handles.PositionHandle(Node.position, Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(Node, "Move GraphxSpatialGraphDataNode");
                Node.position = newTargetPosition;
            }
        }

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement container = new VisualElement();

            Button addNodeButton = new Button();
            addNodeButton.text = "Add Node";
            addNodeButton.clicked += OnAddNodeButtonClicked;
            container.Add(addNodeButton);

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

        private void OnNextNodeButtonClicked()
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
    }
}