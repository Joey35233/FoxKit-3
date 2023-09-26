using Fox.EdCore;
using Fox.Graphx;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGraphx
{
    [CustomEditor(typeof(GraphxSpatialGraphDataNode), editorForChildClasses: true)]
    public class GraphxSpatialGraphDataNodeEditor : EntityEditor
    {
        private GraphxSpatialGraphDataNode Node => (GraphxSpatialGraphDataNode)target;

        private bool HasFrameBounds() => true;

        public Bounds OnGetFrameBounds() => new Bounds(Node.position, new Vector3(1, 1, 1));

        protected virtual void OnSceneGUI()
        {
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