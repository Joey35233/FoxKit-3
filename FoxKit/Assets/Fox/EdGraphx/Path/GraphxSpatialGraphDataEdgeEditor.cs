using Fox.EdCore;
using Fox.Graphx;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGraphx
{
    [CustomEditor(typeof(GraphxSpatialGraphDataEdge), editorForChildClasses: true)]
    public class GraphxSpatialGraphDataEdgeEditor : EntityEditor
    {
        private GraphxSpatialGraphDataEdge Edge => (GraphxSpatialGraphDataEdge)target;

        private bool HasFrameBounds() => Edge.prevNode != null && Edge.nextNode != null;

        private void OnEnable()
        {
            Tools.hidden = true;
        }

        private void OnDisable()
        {
            Tools.hidden = false;
        }

        public Bounds OnGetFrameBounds()
        {
            Matrix4x4 mat = Edge.transform.parent.localToWorldMatrix;

            var bounds = new Bounds(mat.MultiplyPoint((Edge.prevNode as GraphxSpatialGraphDataNode).position),
                new Vector3(0, 0, 0));
            bounds.Encapsulate(mat.MultiplyPoint((Edge.nextNode as GraphxSpatialGraphDataNode).position));

            return bounds;
        }
    }
}