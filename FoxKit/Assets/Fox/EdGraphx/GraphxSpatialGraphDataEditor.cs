using Fox.Graphx;
using System.Collections;
using UnityEditor;
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

            Button addNodeButton = new Button();
            addNodeButton.text = "Add Node";
            container.Add(addNodeButton);

            GraphxSpatialGraphDataField field = new GraphxSpatialGraphDataField();
            field.Build(this.serializedObject);
            container.Add(field);

            return container;
        }
    }
}