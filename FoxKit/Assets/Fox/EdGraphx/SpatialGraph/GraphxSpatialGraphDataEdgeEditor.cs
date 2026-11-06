using Fox.EdCore;
using Fox.Graphx;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGraphx
{
    [CustomEditor(typeof(GraphxSpatialGraphDataEdge), editorForChildClasses: true)]
    public class GraphxSpatialGraphDataEdgeEditor : EntityEditor
    {
        private GraphxSpatialGraphDataEdge Target => (GraphxSpatialGraphDataEdge)base.target;
        private GraphxSpatialGraphData Graph => Target.transform.parent.GetComponent<GraphxSpatialGraphData>();

        protected bool HasFrameBounds() => Graph != null && Target.PrevNode is not null && Target.NextNode is not null;

        protected Bounds OnGetFrameBounds()
        {
            Bounds bounds = new Bounds(Target.PrevNode.transform.position, new Vector3(0, 0, 0));
            bounds.Encapsulate(Target.NextNode.transform.position);

            return bounds;
        }

        private void OnEnable()
        {
            Tools.hidden = true;
        }

        private void OnDisable()
        {
            Tools.hidden = false;
        }
    }
}