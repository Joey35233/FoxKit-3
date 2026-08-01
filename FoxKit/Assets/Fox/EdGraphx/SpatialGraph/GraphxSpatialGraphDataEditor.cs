using System.Collections.Generic;
using Fox.Graphx;
using Fox.EdCore;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdGraphx
{
    [CustomEditor(typeof(GraphxSpatialGraphData), true)]
    public class GraphxSpatialGraphDataEditor : UnityEditor.Editor
    {
        protected GraphxSpatialGraphData Target => (GraphxSpatialGraphData)base.target;

        // Focus
        protected bool HasFrameBounds() => Target.HasBounds();

        protected Bounds OnGetFrameBounds() => Target.GetWorldBounds();

        // Gizmos
        private static readonly Vector3 NodeGizmoScale = Vector3.one * 0.25f;

        private static Vector3[] GizmoVertexCache = null;

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(GraphxSpatialGraphData graph, GizmoType gizmoType)
        {
            if (graph == null)
                return;

            IReadOnlyList<GraphxSpatialGraphDataNode> nodes = graph.nodes;

            if (nodes.Count == 0 || !graph.IsVisibleInFrustum(Camera.current))
                return;

            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            Gizmos.matrix = graph.transform.localToWorldMatrix;
            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : EditorColors.GenericUnselectedColor;

            if (GizmoVertexCache == null || GizmoVertexCache.Length < nodes.Count)
                GizmoVertexCache = new Vector3[nodes.Count];
            
            for (int i = 0; i < nodes.Count; i++)
            {
                Vector3 vertex = nodes[i].transform.localPosition;
                GizmoVertexCache[i] = vertex;
                
                Gizmos.DrawWireCube(vertex, NodeGizmoScale);
            }

            Gizmos.DrawLineStrip(GizmoVertexCache[..nodes.Count], graph.IsLoop());
        }

        // GUI
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement container = new VisualElement();

            Button addNodeButton = new Button(OnAddNodeButtonClicked) { text = "Add Node" };
            container.Add(addNodeButton);

            BuildExtraSections(container);

            GraphxSpatialGraphDataField field = new GraphxSpatialGraphDataField();
            field.Build(this.serializedObject);
            container.Add(field);

            return container;
        }

        protected virtual void BuildExtraSections(VisualElement container) { }

        private void OnAddNodeButtonClicked()
        {
            int undoGroup = Undo.GetCurrentGroup();
            bool wasEmpty = Target.nodes.Count == 0;
            GraphxSpatialGraphDataNode node = Target.AddNode();

            if (wasEmpty && node != null)
            {
                if (HandleUtility.PlaceObject(Event.current.mousePosition, out Vector3 placedPosition, out _))
                {
                    Undo.RecordObject(node, "Place First Node");
                    node.transform.position = placedPosition;
                }
            }

            Undo.CollapseUndoOperations(undoGroup);
            Selection.activeGameObject = node.gameObject;
        }
    }
}
