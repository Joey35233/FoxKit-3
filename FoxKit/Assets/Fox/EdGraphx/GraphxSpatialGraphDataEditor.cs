using Fox.Graphx;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Fox.EdGraphx
{
    [CustomEditor(typeof(GraphxSpatialGraphData), true)]
    public class GraphxSpatialGraphDataEditor : UnityEditor.Editor
    {
        protected new GraphxSpatialGraphData target => base.target as GraphxSpatialGraphData;

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement container = new VisualElement();

            Button addNodeButton = new Button(OnAddNodeButtonClicked) { text = "Add Node" };
            container.Add(addNodeButton);

            BuildDefaultEventSection(container);

            GraphxSpatialGraphDataField field = new GraphxSpatialGraphDataField();
            field.Build(this.serializedObject);
            container.Add(field);

            return container;
        }

        private void BuildDefaultEventSection(VisualElement container)
        {
            Type edgeEventType = target.GetEdgeEventType();
            Type nodeEventType = target.GetNodeEventType();
            if (edgeEventType == null && nodeEventType == null)
                return;

            VisualElement edgeTemplate = new VisualElement();
            VisualElement nodeTemplate = new VisualElement();

            AddEventDropdown(container, "defaultEdgeEvent", edgeEventType, "Default Edge Event", () =>
            {
                target.SyncEventTemplates();
                RebuildTemplateSection(edgeTemplate, target.GetEdgeEventTemplate());
            });
            container.Add(edgeTemplate);

            AddEventDropdown(container, "defaultNodeEvent", nodeEventType, "Default Node Event", () =>
            {
                target.SyncEventTemplates();
                RebuildTemplateSection(nodeTemplate, target.GetNodeEventTemplate());
            });
            container.Add(nodeTemplate);

            container.schedule.Execute(() =>
            {
                if (target == null)
                    return;

                target.SyncEventTemplates();
                RebuildTemplateSection(edgeTemplate, target.GetEdgeEventTemplate());
                RebuildTemplateSection(nodeTemplate, target.GetNodeEventTemplate());
            });
        }

        private void OnAddNodeButtonClicked()
        {
            int undoGroup = Undo.GetCurrentGroup();
            bool wasEmpty = target.nodes.Count == 0;
            GraphxSpatialGraphDataNode node = target.AddNode();

            if (wasEmpty && node != null)
            {
                var sceneView = SceneView.lastActiveSceneView;
                if (sceneView != null)
                {
                    Undo.RecordObject(node, "Place First Node");
                    node.position = target.GetGraphWorldMatrix().inverse.MultiplyPoint(sceneView.pivot);
                }
            }

            Undo.CollapseUndoOperations(undoGroup);
            Selection.activeGameObject = node.gameObject;
        }

        private void AddEventDropdown(VisualElement container, string propertyName, Type eventBaseType, string label, Action onChanged)
        {
            if (eventBaseType == null)
                return;

            var prop = serializedObject.FindProperty(propertyName);
            if (prop == null)
                return;

            const string none = "(None)";
            var choices = new List<string> { none };

            var names = new List<string>();
            foreach (Type type in TypeCache.GetTypesDerivedFrom(eventBaseType))
            {
                if (type.IsAbstract)
                    continue;

                names.Add(FriendlyEventName(type));
            }
            names.Sort();
            choices.AddRange(names);

            int index = choices.IndexOf(prop.stringValue);
            if (index < 0)
                index = 0;

            var popup = new PopupField<string>(label, choices, index);
            popup.RegisterValueChangedCallback(evt =>
            {
                var liveProp = serializedObject.FindProperty(propertyName);
                if (liveProp == null)
                    return;

                if (evt.newValue == none)
                    liveProp.stringValue = "";
                else
                    liveProp.stringValue = evt.newValue;

                serializedObject.ApplyModifiedProperties();
                onChanged?.Invoke();
            });
            container.Add(popup);
        }

        private void RebuildTemplateSection(VisualElement section, UnityEngine.Object template)
        {
            section.Clear();
            if (template == null)
                return;

            section.Add(new InspectorElement(template));
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