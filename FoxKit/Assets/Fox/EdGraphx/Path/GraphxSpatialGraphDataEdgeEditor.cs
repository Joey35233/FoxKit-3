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

        private bool HasFrameBounds() => Edge.prevNode.Entity != null && Edge.nextNode.Entity != null;

        public Bounds OnGetFrameBounds()
        {
            var bounds = new Bounds((Edge.prevNode.Entity as GraphxSpatialGraphDataNode).position,
                new Vector3(0, 0, 0));
            bounds.Encapsulate((Edge.nextNode.Entity as GraphxSpatialGraphDataNode).position);

            return bounds;
        }
    }
}