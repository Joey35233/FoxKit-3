using Fox.EdCore;
using Fox.Graphx;
using System;
using UnityEditor;
using UnityEngine;

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
    }
}