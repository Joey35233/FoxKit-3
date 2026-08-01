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

        protected bool HasFrameBounds() => Graph != null && Target.prevNode is not null && Target.nextNode is not null;

        protected Bounds OnGetFrameBounds()
        {
            Bounds bounds = new Bounds(Target.prevNode.transform.position, new Vector3(0, 0, 0));
            bounds.Encapsulate(Target.nextNode.transform.position);

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